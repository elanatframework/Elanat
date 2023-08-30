using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeFilePermissionsSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("file_permissions_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/file_manager/"));
        }
    }
}