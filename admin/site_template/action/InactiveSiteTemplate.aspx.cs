using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveSiteTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["site_template_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["site_template_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.SiteTemplate dust = new DataUse.SiteTemplate();
            dust.Inactive(Request.QueryString["site_template_id"].ToString());
            Response.Write("true");


            // Refill Value
            StaticObject.SetSiteTemplate();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_site_template", Request.QueryString["site_template_id"].ToString());
        }
    }
}