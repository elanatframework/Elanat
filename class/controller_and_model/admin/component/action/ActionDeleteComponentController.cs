using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteComponentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["component_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["component_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["component_id"].ToString(), StaticObject.AdminPath + "/component/"))
            {
                Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.Component duc = new DataUse.Component();
            duc.Delete(context.Request.Query["component_id"].ToString());

            Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_component", context.Request.Query["component_id"].ToString());
        }
    }
}