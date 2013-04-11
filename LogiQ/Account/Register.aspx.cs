using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogiQ.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                LogiQWebSecurity.CreateUserAndAccount(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                if (LogiQWebSecurity.Login(txtUsername.Text, txtPassword.Text))
                    Response.Redirect("~/");
            }
        }
    }
}