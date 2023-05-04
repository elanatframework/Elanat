using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactivePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["page_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["page_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Page dup = new DataUse.Page();
            dup.Inactive(Request.QueryString["page_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_page", Request.QueryString["page_id"].ToString());
        }
    }
}