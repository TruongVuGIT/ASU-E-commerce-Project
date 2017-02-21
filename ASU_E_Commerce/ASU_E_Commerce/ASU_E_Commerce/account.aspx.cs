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

            load_products();
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
            //string user_id = Session["userid"].ToString();

            HttpCookie myCookies = Request.Cookies["myCookieId"];
            string user_id = myCookies["userid"];

            string[] items = myservice.list_products(user_id,"","");
            DataTable dt = new DataTable();
            dt.Columns.Add("#");
            dt.Columns.Add("Product ID");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Price");
            dt.Columns.Add("Bidding");
            dt.Columns.Add("Edit");
            dt.Columns.Add("Delete");

            for (int x = 0; x < items.Length; x++)
            {
                dt.Rows.Add();
                dt.Rows[x]["#"] = (x + 1).ToString();
                dt.Rows[x]["Product ID"] = items[x];
                if (items[x][0] == 'B')
                {
                    string[] data = myservice.book_details(items[x],"","");
                    dt.Rows[x]["Qty"] = data[4];
                    dt.Rows[x]["Price"] = data[5];
                    dt.Rows[x]["Bidding"] = data[6];
                }
                else
                {

                }

                dt.Rows[x]["Edit"] = "Edit Button";
                dt.Rows[x]["Delete"] = "Delete Button";
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}