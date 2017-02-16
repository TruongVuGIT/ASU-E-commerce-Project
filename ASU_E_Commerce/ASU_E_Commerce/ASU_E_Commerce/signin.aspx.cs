using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASU_E_Commerce
{
    public partial class signin : System.Web.UI.Page
    {
        Service1.Service1 myservice = new Service1.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginid"] != null || Session["userid"] != null)
            {
                Response.Redirect("default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string[] info = myservice.sign_in(TextBox1.Text, TextBox2.Text, "", "");

            if (info[0] != null && info[1] != null)
            {
                Session["loginid"] = info[0];
                Session["userid"] = info[1]; //hard code

                Response.Redirect("default.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}