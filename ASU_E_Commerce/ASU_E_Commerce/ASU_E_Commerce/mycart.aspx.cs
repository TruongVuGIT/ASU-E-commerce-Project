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
        private static LinkedList<string> productid = new LinkedList<string>();
        private static LinkedList<int> quantity = new LinkedList<int>();
        private static LinkedList<double> price = new LinkedList<double>();
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
            productid.Clear();
            quantity.Clear();
            price.Clear();
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            string user_id = myCookies["userid"];

            string[] products = myservice.product_list(user_id, "", "");
            string[] qty = myservice.quantity(user_id, "", "");

            for (int x = 0; x < products.Length; x++)
            {
                productid.AddLast(products[x]);
                quantity.AddLast(Convert.ToInt32(qty[x]));
                string display = "Products: " + products[x] + " Quantity: " + qty[x];
                ListBox1.Items.Add(display);
            }

            for (int x = 0; x < productid.Count; x++)
            {
                string[] data = myservice.book_details(productid.ElementAt(x), "", "");
                price.AddLast(Convert.ToDouble(data[5]));
            }

            double total_price = 0;
            for (int x = 0; x < productid.Count; x++)
            {
                total_price += (quantity.ElementAt(x) * price.ElementAt(x));
            }

            Label3.Text = Convert.ToString(total_price);
        }

        protected void Button1_Click(object sender, EventArgs e)// checkout button
        {
            Session["total"] = Label3.Text;
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