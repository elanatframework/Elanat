using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveCommentViewMoreController : CodeBehindController
    {
        public ActionInactiveCommentViewMoreModel model = new ActionInactiveCommentViewMoreModel();

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