using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteModule : System.Web.UI.Page
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

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["module_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.Module dum = new DataUse.Module();
            dum.Delete(Request.QueryString["module_id"].ToString());

            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_module", Request.QueryString["module_id"].ToString());
        }
    }
}