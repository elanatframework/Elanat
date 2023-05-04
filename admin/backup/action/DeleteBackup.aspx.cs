using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteBackup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["backup_physical_name"]))
            {
                Response.Write("false");
                return;
            }

            System.IO.File.Delete(Request.MapPath(StaticObject.SitePath + "backup/" + Request.QueryString["backup_physical_name"].ToString()));
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_backup", Request.QueryString["backup_physical_name"].ToString());
        }
    }
}