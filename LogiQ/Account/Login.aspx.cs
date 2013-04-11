using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogiQ.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (LogiQWebSecurity.Login(txtUsername.Text, txtPassword.Text, chkRememberMe.Checked))
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if (!string.IsNullOrEmpty(returnUrl))
                        Response.Redirect(returnUrl);
                    else
                        Response.Redirect("~/");
                }
                else
                {
                    lblMessage.Text = "Username or Password was incorrect";
                }
            }
        }
    }
}