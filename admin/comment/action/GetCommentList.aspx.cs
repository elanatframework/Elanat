using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionGetCommentList : System.Web.UI.Page
    {
		public ActionGetCommentListModel model = new ActionGetCommentListModel();
		
        protected void Page_Load(object sender, EventArgs e)
        {
			model.SetValue(Request.QueryString);
        }
    }
}