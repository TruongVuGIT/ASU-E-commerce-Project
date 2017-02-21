using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASU_E_Commerce
{    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["userid"] == ""))
            {
                Response.Redirect("signin.aspx");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("mycart.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
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

            Response.Redirect("default1.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("account.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("shirts.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("books.aspx");
        }
    }
}