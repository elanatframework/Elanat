using CodeBehind;

namespace Elanat
{
    public partial class ActionCommentNewRowController : CodeBehindController
    {
        public ActionCommentNewRowModel model = new ActionCommentNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["comment_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["comment_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.CommentIdValue = context.Request.Query["comment_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}