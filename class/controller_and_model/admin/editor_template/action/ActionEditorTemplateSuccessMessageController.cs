using CodeBehind;

namespace Elanat
{
    public partial class ActionEditorTemplateSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("editor_template_was_save_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/editor_template/"));
        }
    }
}