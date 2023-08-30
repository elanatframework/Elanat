using CodeBehind;

namespace Elanat
{
    public partial class ActionIsCurrentUserController : CodeBehindController
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

            string UserId = context.Request.Query["user_id"].ToString();

            if (ccoc.UserId == UserId)
                Write("true");
            else
                Write("false");
        }
    }
}