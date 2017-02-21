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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string[] tempItem = { "Java 101", "B00004", "1", "121.00", "121.00" };// this is for testing, need service to get cart info
            if (Session["loginid"] == null)
            {
                Response.Redirect("default1.aspx");
            }
            else
            {
                ListBox1.Items.Clear();
                for (int x = 0; x < 1; x++)
                {
                    /*
                    //dt.Rows[x]["#"] = (x + 1).ToString();
                    string[] data = myservice.book_details(items[x], "", "");
                    string product_id = data[0];
                    string isbn = data[1];
                    string title = data[2];
                    string subject = data[3];
                    string quantity = data[4];
                    string price = data[5];
                    string bidding = data[6];
                    string[] info = myservice.get_user_info(data[7], "", "");
                    string seller_name = info[2];
                    string seller_email = info[3];
                    */
                    string result = "Product ID: " + tempItem[1] + " Quantity: " + tempItem[2] + " Price: " + tempItem[3];
                    ListBox1.Items.Add(result);
                }
            
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
            
                //hard coded for testing
                for (int x = 0; x < 1; x++)
                {
                    //dt.Rows[x]["#"] = (x + 1).ToString();

                    Label4.Text = "test";
                    Label5.Text = "test";
                    Label6.Text = "test";
                    Label7.Text = "test";
                    Label8.Text = "1";
                    Label9.Text = "121.00";
                    Label10.Text = "121.00";

                    Label11.Text = "test";
                    Label12.Text = "test";

                }
            
        }
    }
}