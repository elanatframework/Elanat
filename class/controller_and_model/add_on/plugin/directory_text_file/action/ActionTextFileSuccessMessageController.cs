using CodeBehind;

namespace Elanat
{
    public partial class ActionTextFileSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertLanguageVariant("file_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), "success"));
        }
    }
}