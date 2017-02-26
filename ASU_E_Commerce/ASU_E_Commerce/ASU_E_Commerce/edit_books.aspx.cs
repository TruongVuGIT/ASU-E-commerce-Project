using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASU_E_Commerce
{
    public partial class edit_books : System.Web.UI.Page
    {
        string product_id = "";
        Service1.Service1 service = new Service1.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["userid"] == ""))
            {
                Response.Redirect("default1.aspx");
            }

            // Label2.Text = account.edit_product;
            product_id = account.edit_product;//set product_id



            string[] data = service.book_details(product_id, "", "");
            string prod_id = data[0];
            string isbn = data[1];
            string title = data[2];
            string subject = data[3];
            string quantity = data[4];
            string price = data[5];
            string bidding = data[6];
            string[] info = service.get_user_info(data[7], "", "");
            string seller_name = info[2];
            string seller_email = info[3];

            Label2.Text = prod_id;
            TextBox2.Text = isbn;
            TextBox3.Text = title;
            TextBox4.Text = subject;
            TextBox8.Text = quantity;
            TextBox6.Text = price;
            TextBox7.Text = bidding;
            Label3.Text = seller_name;
            Label4.Text = seller_email;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (product_id != "")
            //{

            //submit changes
            //(string product_id, string isbn, string title, string subject, string quantity, string price, string bidding)
            //string response = service.edit_books(product_id, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox8.Text, TextBox6.Text, TextBox7.Text, "", "");
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            string login_id = myCookies["loginid"];
            string user_id = myCookies["userid"];
            /*
            if (IsPostBack)
            {
                string response = service.edit_books(Label2.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox8.Text, TextBox6.Text, TextBox7.Text, "","");
            }
            */
            // MessageBox.Show(Page, response);
            //if (response == "Pass")
            //{
            //    Label5.Visible = false;
            //    account.edit_product = "";
            //    Response.Redirect("account.aspx");
            //}
            //else
            //{
            //    Label5.Visible = true;
            //    Label5.Text = response;
            //}
            // }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label5.Visible = false;
            account.edit_product = "";
            Response.Redirect("account.aspx");
        }
    }
}