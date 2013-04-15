using LogiQ.Helpers;
using LogiQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogiQ.Admin.Quizes
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                DataBind();
        }

        public override void DataBind()
        {
            QuizItem qItem = null;

            if (Request.QueryString["id"] != null)
            {
                

                Guid id = Request.QueryString["id"].ToString().ToGuid();
                if (id != Guid.Empty)
                {
                    LogiQContext db = new LogiQContext();
                    qItem = db.QuizItems.Find(id);
                }
            }

            if (qItem != null)
            {
                hdnId.Value = qItem.ID.ToString();
                txtTitle.Text = qItem.Title;
                txtQuestion.Text = qItem.Question;
                txtRightAnswer.Text = qItem.RightAnswer;
            }

            base.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    DateTime dtNow = DateTime.Now;
                    LogiQContext db = new LogiQContext();

                    QuizItem qItem = null;

                    Guid id = hdnId.Value.ToGuid();
                    if (id != Guid.Empty)
                        qItem = db.QuizItems.Find(id);

                    if (qItem == null)
                    {
                        qItem = new QuizItem();
                        qItem.CreatedDate = dtNow;
                    }

                    qItem.Title = txtTitle.Text;
                    qItem.Question = txtQuestion.Text;
                    qItem.RightAnswer = txtRightAnswer.Text;
                    qItem.UpdatedDate = dtNow;

                    db.SaveChanges();

                    hdnId.Value = qItem.ID.ToString();
                    lblMessage.Text = "Success!";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.GetLongMessages();
                }
                
            }
        }
    }
}