using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveUserController : CodeBehindController
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

            DataUse.User duu = new DataUse.User();
            duu.Active(context.Request.Query["user_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_user", context.Request.Query["user_id"].ToString());
        }
    }
}