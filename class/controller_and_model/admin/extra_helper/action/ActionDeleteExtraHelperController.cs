using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteExtraHelperController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["extra_helper_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["extra_helper_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["extra_helper_id"].ToString(), StaticObject.AdminPath + "/extra_helper/"))
            {
                Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();
            dueh.Delete(context.Request.Query["extra_helper_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_extra_helper", context.Request.Query["extra_helper_id"].ToString());
        }
    }
}