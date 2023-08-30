using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteEditorTemplateController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["editor_template_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["editor_template_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["editor_template_id"].ToString(), StaticObject.AdminPath + "/editor_template/"))
            {
                Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.EditorTemplate duet = new DataUse.EditorTemplate();
            duet.Delete(context.Request.Query["editor_template_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_editor_template", context.Request.Query["editor_template_id"].ToString());
        }
    }
}