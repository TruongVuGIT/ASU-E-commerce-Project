﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;

namespace ASU_E_Commerce
{
    public partial class search : System.Web.UI.Page
    {
        Service1.Service1 myservice = new Service1.Service1();
        private static LinkedList<string> productid = new LinkedList<string>();
        private static LinkedList<int> quantity = new LinkedList<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["userid"] == ""))
            {
                Button3.Visible = false;
            }
            else
            {
                Button3.Visible = true;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Books")
            {
                DropDownList2.Items.Clear();
                DropDownList2.Visible = true;
                DropDownList2.Items.Add("ISBN");
                DropDownList2.Items.Add("Title");
                DropDownList2.Items.Add("Subject");
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
                DropDownList5.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "Shirts")
            {
                DropDownList2.Items.Clear();
                DropDownList2.Visible = true;
                DropDownList2.Items.Add("Brand");
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
                DropDownList5.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "Product ID")
            {
                DropDownList2.Items.Clear();
                DropDownList2.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
                DropDownList5.Visible = false;
            }
            else
            {
                DropDownList2.Items.Clear();
                DropDownList2.Visible = true;
                DropDownList2.Items.Add("First Name");
                DropDownList2.Items.Add("Last Name");
                DropDownList2.Items.Add("Prefered Name");
                DropDownList2.Items.Add("ASU Email");
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
                DropDownList5.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Books")
            {
                productid.Clear();
                quantity.Clear();
                ListBox1.Items.Clear();
                string[] items = myservice.search_books(DropDownList2.SelectedValue, TextBox1.Text, "", "");
                for (int x = 0; x < items.Length; x++)
                {
                    string[] data = myservice.book_details(items[x], "", "");
                    string product_id = data[0];
                    productid.AddLast(data[0]);
                    string isbn = data[1];
                    string title = data[2];
                    string subject = data[3];
                    string qty = data[4];
                    quantity.AddLast(Convert.ToInt32(data[4]));
                    string price = data[5];
                    string bidding = data[6];
                    string[] info = myservice.get_user_info(data[7], "", "");
                    string seller_name = info[2];
                    string seller_email = info[3];
                    string result = "Product ID: " + product_id + " Quantity: " + qty + " Price: " + price + " Bidding: " + bidding;
                    ListBox1.Items.Add(result);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)//view details button
        {
            if (ListBox1.SelectedIndex >= 0)
            {
                string[] items = myservice.search_books(DropDownList2.SelectedValue, TextBox1.Text, "", "");
                int index = ListBox1.SelectedIndex;
                string productid = items[index];
                for (int x = 0; x < items.Length; x++)
                {
                    string[] data = myservice.book_details(productid, "", "");
                    Label4.Text = data[0];
                    Label5.Text = data[1];
                    Label6.Text = data[2];
                    Label7.Text = data[3];
                    Label8.Text = data[4];
                    Label9.Text = data[5];
                    Label10.Text = data[6];
                    string[] info = myservice.get_user_info(data[7], "", "");
                    Label11.Text = info[2];
                    Label12.Text = info[3];

                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)// add to cart button
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            string user_id = myCookies["userid"];
            string result = "";
            int position = ListBox1.SelectedIndex;
            if (position >= 0)
            {
                int selected_ammount = Convert.ToInt32(DropDownList6.SelectedItem.Text);
                int sold_ammount = Convert.ToInt32(quantity.ElementAt(position));
                if (selected_ammount <= sold_ammount && selected_ammount > 0)
                {
                    result = myservice.add_cart(user_id, productid.ElementAt(position), Convert.ToString(selected_ammount), "", "");
                    MessageBox.Show(Page, result);
                }
            }
        }
    }
}