using CodeBehind;

namespace Elanat
{
    public partial class ActionContentReplySuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("content_reply_was_save_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/content_reply/"));
        }
    }
}