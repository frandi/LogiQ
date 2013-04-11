using LogiQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogiQ.Admin.Users
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public System.Collections.IEnumerable rptUsers_GetData()
        {
            LogiQContext db = new LogiQContext();
            return db.UserProfiles.OrderBy(u => u.UserName);
        }
    }
}