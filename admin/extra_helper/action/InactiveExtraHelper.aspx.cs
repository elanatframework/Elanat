using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveExtraHelper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["extra_helper_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["extra_helper_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.ExtraHelper duex = new DataUse.ExtraHelper();
            duex.Inactive(Request.QueryString["extra_helper_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_extra_helper", Request.QueryString["extra_helper_id"].ToString());
        }
    }
}