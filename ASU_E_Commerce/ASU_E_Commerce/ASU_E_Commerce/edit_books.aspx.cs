using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASU_E_Commerce
{
    public partial class edit_books : System.Web.UI.Page
    {
        string product_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = account.edit_product;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            account.edit_product = "";
            Response.Redirect("account.aspx");
        }
    }
}