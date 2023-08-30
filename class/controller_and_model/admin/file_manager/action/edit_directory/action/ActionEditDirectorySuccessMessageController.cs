using CodeBehind;

namespace Elanat
{
    public partial class ActionEditDirectorySuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("directory_was_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/file_manager/"));
        }
    }
}