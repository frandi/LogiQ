using LogiQ.Helpers;
using LogiQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogiQ.Quiz
{
    public partial class Item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                    DataBind();
                else
                    Response.Redirect("Default.aspx");
            }
        }

        public override void DataBind()
        {
            string id = Request.QueryString["id"];
            Guid gId = id.ToGuid();
            if (gId != Guid.Empty)
            {
                LogiQContext db = new LogiQContext();
                QuizItem q = db.QuizItems.Find(gId);
                if (q != null)
                {
                    lblTitle.Text = q.Title;
                    lblQuestion.Text = q.Question;
                }
            }

            base.DataBind();
        }
    }
}