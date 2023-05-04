using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteAdminStyle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["admin_style_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["admin_style_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["admin_style_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            DataUse.AdminStyle duas = new DataUse.AdminStyle();
            duas.Delete(Request.QueryString["admin_style_id"].ToString());

            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_admin_style", Request.QueryString["admin_style_id"].ToString());
        }
    }
}