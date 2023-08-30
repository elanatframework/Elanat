using CodeBehind;

namespace Elanat
{
    public partial class ActionIsUserContentReplyController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["content_reply_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["content_reply_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string ContentReplyId = context.Request.Query["content_reply_id"].ToString();

            DataUse.ContentReply ducr = new DataUse.ContentReply();

            if (ducr.IsUserContentReply(ccoc.UserId, ContentReplyId))
                Write("true");
            else
                Write("false");
        }
    }
}