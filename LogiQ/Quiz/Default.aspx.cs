using LogiQ.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogiQ.Quiz
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlQuizFilter.Visible = LogiQWebSecurity.IsCurrentUserAuthenticated();
            }
        }

        public IEnumerable rptQuiz_GetData()
        {
            IEnumerable<UserQuizView> view = null;

            if (LogiQWebSecurity.IsCurrentUserAuthenticated())
            {
                int userid = LogiQWebSecurity.GetCurrentUserId();
                QuizItemType type = QuizItemType.All;
                if (ddlQuizFilter.SelectedValue == QuizItemType.Unvisited.ToString().ToLower())
                    type = QuizItemType.Unvisited;
                else if (ddlQuizFilter.SelectedValue == QuizItemType.Visited.ToString().ToLower())
                    type = QuizItemType.Visited;

                view = LogiQuiz.GetUserQuizes(userid, type);
            }
            else
            {
                view = LogiQuiz.GetUserQuizes(0, QuizItemType.All);
            }

            return view;
        }
    }
}