﻿using LogiQ.Helpers;
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
                    txtFirstName.Text = user.FirstName;
                    txtLastName.Text = user.LastName;
                    txtEmail.Text = user.Email;
                    txtPhone.Text = user.Phone;

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
            if (IsValid)
            {
                try
                {
                    bool newUser = false;
                    MembershipUser user = LogiQWebSecurity.GetUser(txtUsername.Text);

                    int uId = lblUserId.Text.ToInteger();
                    if (uId == 0)
                    {
                        if (user == null)
                        {
                            user = LogiQWebSecurity.CreateUserAndAccount(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                            newUser = true;
                        }
                        else
                            throw new Exception("User {0} was taken. Please choose other username.");
                    }

                    if (user != null)
                    {
                        user.FirstName = txtFirstName.Text;
                        user.LastName = txtLastName.Text;
                        user.Email = txtEmail.Text;
                        user.Phone = txtPhone.Text;

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

                        if (newUser)
                            Response.Redirect("Edit.aspx?u=" + user.UserName);
                        else
                            lblMessage.Text = "Success, user profile updated!";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.GetLongMessages();
                }
            }
        }

        protected void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    string userName = Request.QueryString["u"];
                    if (LogiQWebSecurity.ChangePassword(userName, txtOldPassword.Text, txtNewPassword.Text))
                        lblMessage.Text = "Success, password changed!";
                    else
                        throw new Exception("Failed! Please check the old password.");
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.GetLongMessages();
                }
            }
        }

        class UserRoles
        {
            public string Role { get; set; }
            public bool IsUserInRole { get; set; }
        }

        
    }
}