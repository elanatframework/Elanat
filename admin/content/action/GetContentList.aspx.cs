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
    public partial class ActionGetContentList : System.Web.UI.Page
    {
		public ActionGetContentListModel model = new ActionGetContentListModel();
		
        protected void Page_Load(object sender, EventArgs e)
        {
			model.SetValue(Request.QueryString);
        }
    }
}