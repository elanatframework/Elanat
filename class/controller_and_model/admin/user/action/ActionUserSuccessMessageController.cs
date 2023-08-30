using CodeBehind;

namespace Elanat
{
    public partial class ActionUserSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("user_was_save_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/user/"));
        }
    }
}