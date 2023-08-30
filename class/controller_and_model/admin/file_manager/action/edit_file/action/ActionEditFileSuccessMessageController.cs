using CodeBehind;

namespace Elanat
{
    public partial class ActionEditFileSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("file_was_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/file_manager/"));
        }
    }
}