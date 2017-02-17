using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;

namespace ASU_E_Commerce
{
    public partial class search : System.Web.UI.Page
    {
        Service1.Service1 myservice = new Service1.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Books")
            {
                DropDownList2.Items.Clear();
                DropDownList2.Visible = true;
                DropDownList2.Items.Add("ISBN");
                DropDownList2.Items.Add("Title");
                DropDownList2.Items.Add("Subject");
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
                DropDownList5.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "Shirts")
            {
                DropDownList2.Items.Clear();
                DropDownList2.Visible = true;
                DropDownList2.Items.Add("Brand");
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
                DropDownList5.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "Product ID")
            {
                DropDownList2.Items.Clear();
                DropDownList2.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
                DropDownList5.Visible = false;
            }
            else
            {
                DropDownList2.Items.Clear();
                DropDownList2.Visible = true;
                DropDownList2.Items.Add("First Name");
                DropDownList2.Items.Add("Last Name");
                DropDownList2.Items.Add("Prefered Name");
                DropDownList2.Items.Add("ASU Email");
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
                DropDownList5.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Books")
            {
                string[] items = myservice.search_books(DropDownList2.SelectedValue, TextBox1.Text, "", "");

                //TableRow tempRow = new TableRow();
                //for (int x = 0; x < items.Length; x++)
                //{
                //    TableCell tempCell = new TableCell();
                //    tempCell.Text = String.Format("{0}){1}\n", x + 1, items[x]);
                //    tempRow.Cells.Add(tempCell);
                //    Table1.Rows.Add(tempRow);
                //}

                DataTable dt = new DataTable();
                dt.Columns.Add("#");
                dt.Columns.Add("Product ID");
                dt.Columns.Add("ISBN");
                dt.Columns.Add("Title");
                dt.Columns.Add("Subject");
                dt.Columns.Add("Qty");
                dt.Columns.Add("Price");
                dt.Columns.Add("Bidding");
                dt.Columns.Add("Seller's Name");
                dt.Columns.Add("Seller's Email");
                dt.Columns.Add("To Cart");

                for (int x = 0; x < items.Length; x++)
                {
                    dt.Rows.Add();
                    dt.Rows[x]["#"] = (x + 1).ToString();
                    string[] data = myservice.book_details(items[x],"","");
                    dt.Rows[x]["Product ID"] = data[0];
                    dt.Rows[x]["ISBN"] = data[1];
                    dt.Rows[x]["Title"] = data[2];
                    dt.Rows[x]["Subject"] = data[3];
                    dt.Rows[x]["Qty"] = data[4];
                    dt.Rows[x]["Price"] = data[5];
                    dt.Rows[x]["Bidding"] = data[6];
                    string[] info = myservice.get_user_info(data[7], "", "");
                    dt.Rows[x]["Seller's Name"] = info[2];
                    dt.Rows[x]["Seller's Email"] = info[3];
                    dt.Rows[x]["To Cart"] = "Add Button";
                }

                /////////////////////Below works but button is on lft-hand side of each row////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ButtonField btnfld = new ButtonField();

                btnfld.ButtonType = ButtonType.Button;

                btnfld.Text = "Add to cart";

                btnfld.CommandName = "MyCommand";//specify gridview CommandName for ButtonField to access it in GridView_RowCommand event function below

                btnfld.CausesValidation = false;

                GridView1.Columns.Add(btnfld);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
                System.Windows.Forms.MessageBox.Show("Product ID: " + row.Cells[2].Text + " and Quantity: " + row.Cells[6].Text);//For Testing purposes

                //Response.Redirect("signin.aspx");//for Testing purposes

            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}