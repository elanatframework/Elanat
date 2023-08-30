using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveContentReplyController : CodeBehindController
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

            DataUse.ContentReply ducr = new DataUse.ContentReply();
            ducr.Inactive(context.Request.Query["content_reply_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_content_reply", context.Request.Query["content_reply_id"].ToString());
        }
    }
}