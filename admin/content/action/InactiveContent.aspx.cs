using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["content_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["content_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Content duc = new DataUse.Content();
            duc.Inactive(Request.QueryString["content_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_content", Request.QueryString["content_id"].ToString());
        }
    }
}