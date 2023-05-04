using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionActiveSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["site_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["site_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Site dus = new DataUse.Site();
            dus.Active(Request.QueryString["site_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_site", Request.QueryString["site_id"].ToString());
        }
    }
}