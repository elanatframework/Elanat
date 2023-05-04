using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveComponent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["component_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["component_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Component duc = new DataUse.Component();
            duc.Inactive(Request.QueryString["component_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_component", Request.QueryString["component_id"].ToString());
        }
    }
}