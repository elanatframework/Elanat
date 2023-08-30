using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeDirectoryPermissionsSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("directory_permissions_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/file_manager/"));
        }
    }
}