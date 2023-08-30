using CodeBehind;

namespace Elanat
{
    public partial class ActionDeletePatchController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["patch_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["patch_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["patch_id"].ToString(), StaticObject.AdminPath + "/patch/"))
            {
                Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.Patch dup = new DataUse.Patch();
            dup.Delete(context.Request.Query["patch_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_patch", context.Request.Query["patch_id"].ToString());
        }
    }
}