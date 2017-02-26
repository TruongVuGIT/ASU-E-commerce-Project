using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ASU_E_Commerce
{
    public partial class checkout : System.Web.UI.Page
    {
        Service1.Service1 myservice = new Service1.Service1();
        private static LinkedList<string> productid = new LinkedList<string>();
        private static LinkedList<int> quantity = new LinkedList<int>();
        private static LinkedList<double> price = new LinkedList<double>();
        protected void Page_Load(object sender, EventArgs e)
        {

            //Session["userid"].ToString();
            //NEED TO GET USER ACCOUNT INFORMATION
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
            FirstNameLabel.Text = info[0];
            LastNameLabel.Text = info[1];
            AddressLabel.Text = info[5];
            CityLabel.Text = info[7];
            StateLabel.Text = info[8];
            ZipLabel.Text = info[9];


            //Total Book Amount:
            if (Session["total"].ToString() != "")
            {
                Label1.Text = Session["total"].ToString();
            }

            if (!IsPostBack)
            {
                load_products();
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("mycart.aspx");
        }

        protected void PayPalBtn_Click(object sender, ImageClickEventArgs e)
        {
            string business = "cseecommerce@gmail.com";
            string itemName = "Java 101";
            double itemAmount = Convert.ToDouble(Label1.Text);
            string currencyCode = "USD";

            StringBuilder ppHref = new StringBuilder();

            ppHref.Append("https://www.paypal.com/cgi-bin/webscr?cmd=_xclick");
            ppHref.Append("&business=" + business);
            ppHref.Append("&item_name=" + itemName);
            ppHref.Append("&amount=" + itemAmount.ToString("#.00"));
            ppHref.Append("&currency_code=" + currencyCode);

            Response.Redirect(ppHref.ToString(), true);
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
              
            }

            for (int x = 0; x < productid.Count; x++)
            {
                string[] data = myservice.book_details(productid.ElementAt(x), "", "");
                price.AddLast(Convert.ToDouble(data[5]));
            }

            for (int x = 0; x < productid.Count; x++)
            {
                TextBox1.Text += "Products: " + productid.ElementAt(x) + " Quantity: " + quantity.ElementAt(x) + " Price: " + price.ElementAt(x);
            }
        }
    }
}