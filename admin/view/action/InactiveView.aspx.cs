using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["view_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["view_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.View duv = new DataUse.View();
            duv.Inactive(Request.QueryString["view_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_view", Request.QueryString["view_id"].ToString());
        }
    }
}