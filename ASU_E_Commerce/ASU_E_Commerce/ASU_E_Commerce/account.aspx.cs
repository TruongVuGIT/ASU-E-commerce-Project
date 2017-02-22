using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ASU_E_Commerce
{
    public partial class account : System.Web.UI.Page
    {
        Service1.Service1 myservice = new Service1.Service1();
        private static LinkedList<string> productid = new LinkedList<string>();
        public static string edit_product = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (Session["loginid"] == null)
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["userid"] == ""))
            {
                Response.Redirect("default1.aspx");
            }

            //string login_id = Session["loginid"].ToString();
            //string user_id = Session["userid"].ToString();

            string login_id = myCookies["loginid"];
            string user_id = myCookies["userid"];


            string[] info = myservice.get_user_info(user_id, "", "");
            Label1.Text = info[0];
            Label2.Text = info[1];
            TextBox1.Text = info[2];
            Label3.Text = info[3];
            TextBox2.Text = info[4];
            TextBox5.Text = info[5];
            TextBox6.Text = info[6];
            TextBox7.Text = info[7];
            TextBox8.Text = info[8];
            TextBox9.Text = info[9];

            if (!IsPostBack)
            {
                load_products();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string user_id = Session["userid"].ToString();

            string edit = myservice.edit_user_info(user_id, TextBox1.Text, Label3.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text, "", "");
            if (edit == "Pass")
            {
                //Session["userid"] = null;
                //Session["loginid"] = null;

                HttpCookie myCookies = Request.Cookies["myCookieId"];
                myCookies["userid"] = null;
                myCookies["loginid"] = null;
                Response.Cookies.Add(myCookies);
                myCookies.Expires = DateTime.Now;

                Session["userid"] = null;
                Session["loginid"] = null;
                Session.Abandon();

                Response.Redirect("signin.aspx");
            }
        }

        private void load_products()
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            string user_id = myCookies["userid"];
            productid.Clear();

            string[] items = myservice.list_products(user_id, "", "");

            for (int x = 0; x < items.Length; x++)
            {
                string[] data = myservice.book_details(items[x], "", "");
                string product_id = data[0];
                productid.AddLast(data[0]);
                string isbn = data[1];
                string title = data[2];
                string subject = data[3];
                string quantity = data[4];
                string price = data[5];
                string bidding = data[6];
                string[] info = myservice.get_user_info(data[7], "", "");
                string seller_name = info[2];
                string seller_email = info[3];
                string result = "Product ID: " + product_id + " Quantity: " + quantity + " Price: " + price + " Bidding: " + bidding;
                ListBox1.Items.Add(result);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int position = ListBox1.SelectedIndex;

            HttpCookie myCookies = Request.Cookies["myCookieId"];
            string user_id = myCookies["userid"];

            if (position >= 0)
            {
                string[] item = myservice.list_products(user_id, "", "");

                string[] datas = myservice.book_details(item[position], "", "");
                string productid = datas[0];
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            int position = ListBox1.SelectedIndex;
            if (position >= 0)
            {
                edit_product = productid.ElementAt(position);
                Response.Redirect("edit_books.aspx");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int position = ListBox1.SelectedIndex;

            HttpCookie myCookies = Request.Cookies["myCookieId"];
            string user_id = myCookies["userid"];
            
            
            if (position >= 0)
            {
                myservice.delete_book(productid.ElementAt(position), "", "");
            }
            Response.Redirect("account.aspx");
        }
    }
}