using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveContentReplyController : CodeBehindController
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

            DataUse.ContentReply duacr = new DataUse.ContentReply();
            duacr.Active(context.Request.Query["content_reply_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_content_reply", context.Request.Query["content_reply_id"].ToString());
        }
    }
}