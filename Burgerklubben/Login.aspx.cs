using System;
using Burgerklubben.Classes;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Burgerklubben
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }
        protected void ButtonLoginAdmin_Click(object sender, EventArgs e)
        {
           int count = new LoginManager().CheckLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (count == 1)
                {
                    Session["UserName"] = txtUserName.Text.Trim();
                    Response.Redirect("AdminCrud.aspx");
                }
                else
                {
                    lblErrorMessage.Visible = true;
                }
            
        }
    }
}