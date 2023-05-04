using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeletePatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["patch_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["patch_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["patch_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.Patch dup = new DataUse.Patch();
            dup.Delete(Request.QueryString["patch_id"].ToString());

            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_patch", Request.QueryString["patch_id"].ToString());
        }
    }
}