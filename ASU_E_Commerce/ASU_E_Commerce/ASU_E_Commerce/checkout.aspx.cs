﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Session["userid"].ToString();
            //NEED TO GET USER ACCOUNT INFORMATION
            if (Session["loginid"] == null)
            {
                Response.Redirect("default1.aspx");
            }

            string login_id = Session["loginid"].ToString();
            string user_id = Session["userid"].ToString();
            string[] info = myservice.get_user_info(user_id, "", "");
            FirstNameLabel.Text = info[0];
            LastNameLabel.Text = info[1];
            AddressLabel.Text = info[5];
            CityLabel.Text = info[7];
            StateLabel.Text = info[8];
            ZipLabel.Text = info[9];


            //Total Book Amount:
            TextBox1.Text = "100.64";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("mycart.aspx");
        }

        protected void PayPalBtn_Click(object sender, ImageClickEventArgs e)
        {
            string business = "cseecommerce@gmail.com";
            string itemName = "Java 101";
            double itemAmount = Convert.ToDouble(TextBox1.Text);
            string currencyCode = "USD";

            StringBuilder ppHref = new StringBuilder();

            ppHref.Append("https://www.paypal.com/cgi-bin/webscr?cmd=_xclick");
            ppHref.Append("&business=" + business);
            ppHref.Append("&item_name=" + itemName);
            ppHref.Append("&amount=" + itemAmount.ToString("#.00"));
            ppHref.Append("&currency_code=" + currencyCode);

            Response.Redirect(ppHref.ToString(), true);
        }
    }
}