using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASU_E_Commerce
{
    public partial class mycart : System.Web.UI.Page
    {
        Service1.Service1 myservice = new Service1.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["userid"] == ""))
            {
                Response.Redirect("default1.aspx");
            }

            string login_id = myCookies["loginid"];
            string user_id = myCookies["userid"];

            if (!IsPostBack)
            {
                load_products();
            }
        }

        private void load_products()
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            string user_id = myCookies["userid"];

            string[] products = myservice.product_list(user_id, "", "");
            string[] quantity = myservice.quantity(user_id, "", "");

            for (int x = 0; x < products.Length; x++)
            {
                string display = "Products: " + products[x] + " Quantity: " + quantity[x];
                ListBox1.Items.Add(display);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)// checkout button
        {
            Response.Redirect("checkout.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)// back button
        {
            Response.Redirect("default.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)// remove button
        {

        }

        protected void Button5_Click(object sender, EventArgs e)// view details button
        {
            int position = ListBox1.SelectedIndex;

            HttpCookie myCookies = Request.Cookies["myCookieId"];
            string user_id = myCookies["userid"];

            string[] item = myservice.product_list(user_id, "", "");
            if (position >= 0)
            {
                string[] data = myservice.book_details(item[position], "", "");
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
}