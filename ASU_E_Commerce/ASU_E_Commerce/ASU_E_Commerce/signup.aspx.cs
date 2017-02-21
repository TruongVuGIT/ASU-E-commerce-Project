using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASU_E_Commerce
{
    public partial class signup : System.Web.UI.Page
    {
        Service1.Service1 myservice = new Service1.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("signin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string result = "";
            if (TextBox4.Text == TextBox5.Text && TextBox7.Text == TextBox8.Text)
            {
                result = myservice.sign_up(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox6.Text, TextBox7.Text, TextBox9.Text, TextBox10.Text, TextBox11.Text, TextBox12.Text, TextBox13.Text, "", "");
                if (result == "Pass")
                {
                    MessageBox.Show(Page, "Your account has been created. Please sign in.");
                    Response.Redirect("signin.aspx");
                }
                else
                {
                    MessageBox.Show(Page, result);
                }
            }
            else
            {
                MessageBox.Show(Page, "Please make sure email and password is matching");
            }
        }
    }
}