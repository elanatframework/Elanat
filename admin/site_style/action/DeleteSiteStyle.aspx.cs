using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteSiteStyle : System.Web.UI.Page
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

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["site_style_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            duss.Delete(Request.QueryString["site_style_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_site_style", Request.QueryString["site_style_id"].ToString());
        }
    }
}