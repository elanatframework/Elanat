using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteUserFootPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["user_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["user_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["user_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            DataUse.User duu = new DataUse.User();
            duu.DeleteFootPrint(Request.QueryString["user_id"].ToString());

            Response.Write("true");
			
			
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_user_foot_print", Request.QueryString["user_id"].ToString());
        }
    }
}