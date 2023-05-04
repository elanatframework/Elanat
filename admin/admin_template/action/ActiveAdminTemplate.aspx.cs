using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionActiveAdminTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["admin_template_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["admin_template_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.AdminTemplate duat = new DataUse.AdminTemplate();
            duat.Active(Request.QueryString["admin_template_id"].ToString());
            Response.Write("true");


            // Refill Value
            StaticObject.SetAdminTemplate();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_admin_template", Request.QueryString["admin_template_id"].ToString());
        }
    }
}