using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["group_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["group_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Group dug = new DataUse.Group();
            dug.Inactive(Request.QueryString["group_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_group", Request.QueryString["group_id"].ToString());
        }
    }
}