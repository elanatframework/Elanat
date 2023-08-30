using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteRoleController : CodeBehindController
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

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["role_id"].ToString(), StaticObject.AdminPath + "/role/"))
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
            dur.Delete(context.Request.Query["role_id"].ToString());

            Write("true");


            // Refill Value
            StaticObject.SetRoleValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_role", context.Request.Query["role_id"].ToString());
        }
    }
}