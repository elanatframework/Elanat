using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionActiveLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["link_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["link_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Link dul = new DataUse.Link();
            dul.Active(Request.QueryString["link_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_link", Request.QueryString["link_id"].ToString());
        }
    }
}