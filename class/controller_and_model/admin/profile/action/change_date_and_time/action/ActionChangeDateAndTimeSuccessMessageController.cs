using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeDateAndTimeSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("date_and_time_was_change", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/profile/"));
        }
    }
}