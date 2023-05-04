using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionGetFileDirectoryList : System.Web.UI.Page
    {
		public ActionGetFileDirectoryListModel model = new ActionGetFileDirectoryListModel();
		
        protected void Page_Load(object sender, EventArgs e)
        {
			model.SetValue(Request.QueryString);
        }
    }
}