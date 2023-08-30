using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteAdminStyleController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["admin_style_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["admin_style_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["admin_style_id"].ToString(), StaticObject.AdminPath + "/admin_style/"))
            {
                Write("false");
                return;
            }

            DataUse.AdminStyle duas = new DataUse.AdminStyle();
            duas.Delete(context.Request.Query["admin_style_id"].ToString());

            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_admin_style", context.Request.Query["admin_style_id"].ToString());
        }
    }
}