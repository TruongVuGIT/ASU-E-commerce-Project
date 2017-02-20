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
                DataTable dt = new DataTable();
                dt.Columns.Add("#");
                dt.Columns.Add("Product Name");
                dt.Columns.Add("Product ID");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price per item");
                dt.Columns.Add("Total");

                //Testing Purposes
                //dt.Rows.Add();
                // dt.Rows[0]["Product ID"] = "B001";
                for (int x = 0; x < 1; x++)
                {
                    dt.Rows.Add();
                    dt.Rows[x]["#"] = (x + 1).ToString();
                    dt.Rows[x]["Product Name"] = tempItem[0];
                    dt.Rows[x]["Product ID"] = tempItem[1];
                    dt.Rows[x]["Quantity"] = tempItem[2];
                    dt.Rows[x]["Price per item"] = tempItem[3];
                    dt.Rows[x]["Total"] = tempItem[4];
                }
                /*
                /////////////////////Below works but button is on lft-hand side of each row////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ButtonField btnfld = new ButtonField();

                btnfld.ButtonType = ButtonType.Button;

                btnfld.Text = "Description";

                btnfld.CommandName = "MyCommand";//specify gridview CommandName for ButtonField to access it in GridView_RowCommand event function below

                btnfld.CausesValidation = false;

                GridView1.Columns.Add(btnfld);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                */
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }


        }

        protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)//function for btnfld when invoked via "MyCommand". Added OnRowCommand="GridView1_RowCommand" in Markup.
        {
            if (e.CommandName == "MyCommand")//All buttons have Same CommandName when Dynamically created, but row index captured below to differentiate buttons
            {
                //Can add stuff here to do something
                //System.Windows.Forms.MessageBox.Show("My message here");//For Testing purposes

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
                //Row index captured at this point to do stuff
                System.Windows.Forms.MessageBox.Show("Product Name = " + row.Cells[3].Text);//For Testing purposes

                //Response.Redirect("signin.aspx");//for Testing purposes

            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}