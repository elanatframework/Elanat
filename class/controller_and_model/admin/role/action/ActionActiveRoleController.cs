using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveRoleController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["role_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["role_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Role dur = new DataUse.Role();
            dur.Active(context.Request.Query["role_id"].ToString());
            Write("true");


            // Refill Value
            StaticObject.SetRoleValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_role", context.Request.Query["role_id"].ToString());
        }
    }
}