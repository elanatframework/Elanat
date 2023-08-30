using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveAdminStyleController : CodeBehindController
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

            DataUse.AdminStyle duas = new DataUse.AdminStyle();
            duas.Inactive(context.Request.Query["admin_style_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_admin_style", context.Request.Query["admin_style_id"].ToString());
        }
    }
}