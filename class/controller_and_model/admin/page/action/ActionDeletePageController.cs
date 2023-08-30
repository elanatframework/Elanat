using CodeBehind;

namespace Elanat
{
    public partial class ActionDeletePageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["page_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["page_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["page_id"].ToString(), StaticObject.AdminPath + "/page/"))
            {
                Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.Page dup = new DataUse.Page();
            dup.Delete(context.Request.Query["page_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_page", context.Request.Query["page_id"].ToString());
        }
    }
}