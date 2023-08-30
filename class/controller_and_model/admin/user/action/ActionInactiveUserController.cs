using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveUserController : CodeBehindController
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

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ccoc.UserId == context.Request.Query["user_id"].ToString())
            {
                Write("false");
                return;
            }

            DataUse.User duu = new DataUse.User();
            duu.Inactive(context.Request.Query["user_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_user", context.Request.Query["user_id"].ToString());
        }
    }
}