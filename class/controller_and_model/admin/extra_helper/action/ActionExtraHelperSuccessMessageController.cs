using CodeBehind;

namespace Elanat
{
    public partial class ActionExtraHelperSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("extra_helper_was_save_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/extra_helper/"));
        }
    }
}