using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASU_E_Commerce
{
    public partial class Test_Edit_Delete_Books : System.Web.UI.Page
    {
        Service1.Service1 myservice = new Service1.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] data = myservice.book_details(TextBox1.Text,"","");
            TextBox2.Text = data[1];
            TextBox3.Text = data[2];
            TextBox4.Text = data[3];
            TextBox5.Text = data[4];
            TextBox6.Text = data[5];
            TextBox7.Text = data[6];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string result = myservice.edit_books(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, "", "");
            if (result == "Pass")
            {
                MessageBox.Show(Page,"Book edited");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string result = myservice.delete_book(TextBox8.Text,"","");
            if (result == "Pass")
            {
                MessageBox.Show(Page, "Books deleted");
            }
        }
    }
}