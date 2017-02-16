using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASU_E_Commerce
{
    public partial class checkout : System.Web.UI.Page
    {
        Service1.Service1 myservice = new Service1.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userID = "2";
                //Session["userid"].ToString();
            //NEED TO GET USER ACCOUNT INFORMATION
            //Label1.Text = myservice.
            string[] temp = myservice.get_user_info(userID, "", "");
            Label1.Text = temp[3].ToString();

            //Total Book Amount:
            TextBox1.Text = "100.64";
        }
    }
}