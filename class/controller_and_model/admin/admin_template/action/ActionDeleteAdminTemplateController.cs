using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteAdminTemplateController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["admin_template_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["admin_template_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["admin_template_id"].ToString(), StaticObject.AdminPath + "/admin_template/"))
            {
                Write("false");
                return;
            }

            DataUse.AdminTemplate duat = new DataUse.AdminTemplate();
            duat.Delete(context.Request.Query["admin_template_id"].ToString());

            Write("true");


            // Refill Value
            StaticObject.SetAdminTemplate();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_admin_template", context.Request.Query["admin_template_id"].ToString());
        }
    }
}