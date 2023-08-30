using CodeBehind;

namespace Elanat
{
    public partial class ActionAddContactResponseSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("contact_response_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/contact/"));
        }
    }
}