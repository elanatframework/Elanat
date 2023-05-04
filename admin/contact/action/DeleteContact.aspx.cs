using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["contact_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["contact_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["contact_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            DataUse.Contact duc = new DataUse.Contact();
            duc.Delete(Request.QueryString["contact_id"].ToString());

            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_contact", Request.QueryString["contact_id"].ToString());
        }
    }
}