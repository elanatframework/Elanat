using CodeBehind;

namespace Elanat
{
    public partial class ActionIsUserContactController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["contact_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["contact_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string ContactId = context.Request.Query["contact_id"].ToString();

            DataUse.Contact duc = new DataUse.Contact();

            if(duc.IsUserContact(ccoc.UserId ,ContactId))
                Write("true");
            else
                Write("false");
        }
    }
}