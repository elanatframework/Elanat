using CodeBehind;

namespace Elanat
{
    public partial class ActionIsUserContentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["content_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["content_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string ContentId = context.Request.Query["content_id"].ToString();

            DataUse.Content duc = new DataUse.Content();

            if(duc.IsUserContent(ccoc.UserId ,ContentId))
                Write("true");
            else
                Write("false");
        }
    }
}