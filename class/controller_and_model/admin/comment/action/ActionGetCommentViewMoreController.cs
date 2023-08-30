using CodeBehind;

namespace Elanat
{
    public partial class ActionGetCommentViewMoreController : CodeBehindController
    {
        public ActionGetCommentViewMoreModel model = new ActionGetCommentViewMoreModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["comment_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["comment_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["comment_id"]));

            View(model);
        }
    }
}