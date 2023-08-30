using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveRoleController : CodeBehindController
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

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            List<string> RoleIdList = ccoc.GetRoleIdList();
            if (RoleIdList.Count == 1 && string.Join("", RoleIdList.ToArray()) == context.Request.Query["role_id"].ToString())
            {
                Write("false");
                return;
            }

            DataUse.Role dur = new DataUse.Role();
            dur.Inactive(context.Request.Query["role_id"].ToString());
            Write("true");


            // Refill Value
            StaticObject.SetRoleValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_role", context.Request.Query["role_id"].ToString());
        }
    }
}