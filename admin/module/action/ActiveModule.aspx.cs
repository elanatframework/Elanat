using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionActiveModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["module_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["module_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Module dum = new DataUse.Module();
            dum.Active(Request.QueryString["module_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_module", Request.QueryString["module_id"].ToString());
        }
    }
}