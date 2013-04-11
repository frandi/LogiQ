using LogiQ.Helpers;
using LogiQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogiQ.Admin.Users
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }

        public override void DataBind()
        {
            string[] roles = System.Web.Security.Roles.GetAllRoles();
            for (int i = 0; i < roles.Length; i++)
            {
                chkRoles.Items.Add(new ListItem(roles[i]));
            }

            base.DataBind();

            string username = Request.QueryString["u"];
            if (!string.IsNullOrEmpty(username))
            {
                MembershipUser user = LogiQWebSecurity.GetUser(username);
                if (user != null)
                {
                    lblTitle.Text = "Edit User";

                    lblUserId.Text = user.UserId.ToString();
                    txtUsername.Text = user.UserName;
                    txtEmail.Text = user.Email;

                    dlUserId.Visible = true;

                    for (int i = 0; i < chkRoles.Items.Count; i++)
                    {
                        chkRoles.Items[i].Selected = user.Roles.Contains(chkRoles.Items[i].Text);
                    }
                }
            }

            base.DataBind();
        }

        public System.Collections.IEnumerable rptRoles_GetData()
        {
            List<UserRoles> list = new List<UserRoles>();

            string username = Request.QueryString["u"];
            string[] roles = System.Web.Security.Roles.GetAllRoles();
            for (int i = 0; i < roles.Length; i++)
            {
                list.Add(new UserRoles()
                {
                    Role = roles[i],
                    IsUserInRole = !string.IsNullOrEmpty(username) ? System.Web.Security.Roles.IsUserInRole(username, roles[i]) : false
                });
            }
            return list;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipUser user = LogiQWebSecurity.GetUser(txtUsername.Text);

                int uId = lblUserId.Text.ToInteger();
                if (uId > 0)
                {
                    if (user != null)
                    {
                        user.Email = txtEmail.Text;

                        string sRole = "";
                        for (int i = 0; i < chkRoles.Items.Count; i++)
                        {
                            if (chkRoles.Items[i].Selected)
                            {
                                if (!string.IsNullOrEmpty(sRole))
                                    sRole += ",";
                                sRole += chkRoles.Items[i].Text;
                            }
                        }
                        user.Roles = sRole.Split(',');

                        LogiQWebSecurity.UpdateUser(user);

                        lblMessage.Text = "Success";
                    }
                }
                else
                {
                    if (user == null)
                    {
                        LogiQWebSecurity.CreateUserAndAccount(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                        throw new Exception("User {0} was taken. Please choose other username.");
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.GetLongMessages();
            }
            
        }

        class UserRoles
        {
            public string Role { get; set; }
            public bool IsUserInRole { get; set; }
        }
    }
}