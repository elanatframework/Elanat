using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeLanguageSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("language_was_change", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/profile/"));
        }
    }
}