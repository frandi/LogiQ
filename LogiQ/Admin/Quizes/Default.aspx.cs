﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogiQ.Admin.Quizes
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable rptQuiz_GetData()
        {
            return LogiQuiz.GetUserQuizes(0, Models.QuizItemType.All);
        }
    }
}