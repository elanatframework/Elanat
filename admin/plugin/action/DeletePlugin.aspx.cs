using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeletePlugin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["plugin_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["plugin_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["plugin_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.Plugin dup = new DataUse.Plugin();
            dup.Delete(Request.QueryString["plugin_id"].ToString());

            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_plugin", Request.QueryString["plugin_id"].ToString());
        }
    }
}