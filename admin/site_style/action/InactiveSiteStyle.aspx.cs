using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveSiteStyle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["site_style_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["site_style_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            duss.Inactive(Request.QueryString["site_style_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_site_style", Request.QueryString["site_style_id"].ToString());
        }
    }
}