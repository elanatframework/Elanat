using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteModuleController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["module_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["module_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["module_id"].ToString(), StaticObject.AdminPath + "/module/"))
            {
                Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.Module dum = new DataUse.Module();
            dum.Delete(context.Request.Query["module_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_module", context.Request.Query["module_id"].ToString());
        }
    }
}