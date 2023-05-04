using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactivePlugin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["plugin_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["plugin_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Plugin dup = new DataUse.Plugin();
            dup.Inactive(Request.QueryString["plugin_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_plugin", Request.QueryString["plugin_id"].ToString());
        }
    }
}