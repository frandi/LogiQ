using LogiQ.Helpers;
using LogiQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogiQ.Admin.Users
{
    public partial class Role : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                DataBind();
        }

        public override void DataBind()
        {
            LogiQContext db = new LogiQContext();
            dgRole.DataSource = db.Roles.OrderBy(r => r.RoleName).ToList();

            base.DataBind();
        }

        protected void dgRole_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgRole.EditItemIndex = e.Item.ItemIndex;
            DataBind();
        }

        protected void dgRole_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgRole.EditItemIndex = -1;
            DataBind();
        }

        protected void dgRole_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            LogiQContext db = new LogiQContext();

            object roleId = dgRole.DataKeys[e.Item.ItemIndex];
            var role = db.Roles.Find(roleId);
            if (role != null)
            {
                role.RoleName = (e.Item.Cells[0].Controls[0] as TextBox).Text;
                db.SaveChanges();
            }

            dgRole.EditItemIndex = -1;
            DataBind();
        }

        protected void dgRole_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string role = "";
            if (dgRole.EditItemIndex > -1)
                role = (e.Item.Cells[0].Controls[0] as TextBox).Text;
            else
                role = e.Item.Cells[0].Text;

            if (!string.IsNullOrEmpty(role))
            {
                try
                {
                    if (!Roles.DeleteRole(role, true))
                    {
                        lblMessage.Text = "Role cannot be removed";
                    }

                    dgRole.EditItemIndex = -1;
                    DataBind();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.GetLongMessages();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Roles.CreateRole(txtNewRole.Text);
            Response.Redirect(Request.RawUrl);
        }

        

        
    }
}