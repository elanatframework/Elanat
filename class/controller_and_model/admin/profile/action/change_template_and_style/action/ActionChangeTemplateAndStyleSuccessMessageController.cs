using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeTemplateAndStyleSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("template_and_style_was_change", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/profile/"));
        }
    }
}