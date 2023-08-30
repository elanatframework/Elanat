using CodeBehind;

namespace Elanat
{
    public partial class ActionGetContentReplyViewMoreController : CodeBehindController
    {
        public ActionGetContentReplyViewMoreModel model = new ActionGetContentReplyViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["content_reply_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["content_reply_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["content_reply_id"]));

            View(model);
        }
    }
}