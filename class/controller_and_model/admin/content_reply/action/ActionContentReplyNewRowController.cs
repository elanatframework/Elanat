using CodeBehind;

namespace Elanat
{
    public partial class ActionContentReplyNewRowController : CodeBehindController
    {
        public ActionContentReplyNewRowModel model = new ActionContentReplyNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["content_reply_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["content_reply_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.ContentReplyIdValue = context.Request.Query["content_reply_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}