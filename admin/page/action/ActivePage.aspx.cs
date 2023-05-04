using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionActivePage : System.Web.UI.Page
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
            dup.Active(Request.QueryString["page_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_page", Request.QueryString["page_id"].ToString());
        }
    }
}