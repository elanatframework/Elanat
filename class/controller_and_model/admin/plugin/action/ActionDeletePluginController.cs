using CodeBehind;

namespace Elanat
{
    public partial class ActionDeletePluginController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["plugin_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["plugin_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["plugin_id"].ToString(), StaticObject.AdminPath + "/plugin/"))
            {
                Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.Plugin dup = new DataUse.Plugin();
            dup.Delete(context.Request.Query["plugin_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_plugin", context.Request.Query["plugin_id"].ToString());
        }
    }
}