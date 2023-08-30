using CodeBehind;

namespace Elanat
{
    public partial class AdminAddContentSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            string Action = context.Request.Query["action"];

            if (Action == "add")
                Write(GlobalClass.AlertAddOnsLanguageVariant("content_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/add_content/"));
            else
                Write(GlobalClass.AlertAddOnsLanguageVariant("content_was_save_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/add_content/"));
        }
    }
}