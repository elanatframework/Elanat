using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteUserController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["user_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["user_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["user_id"].ToString(), StaticObject.AdminPath + "/user/"))
            {
                Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ccoc.UserId == context.Request.Query["user_id"].ToString())
            {
                Write("false");
                return;
            }

            DataUse.User duu = new DataUse.User();
            duu.Delete(context.Request.Query["user_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_user", context.Request.Query["user_id"].ToString());
        }
    }
}