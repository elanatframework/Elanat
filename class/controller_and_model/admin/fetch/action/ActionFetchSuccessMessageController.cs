using CodeBehind;

namespace Elanat
{
    public partial class ActionFetchSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("fetch_was_save_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/fetch/"));
        }
    }
}