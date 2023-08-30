using CodeBehind;

namespace Elanat
{
    public partial class ActionIsUserInactiveCommentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["comment_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["comment_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string CommentId = context.Request.Query["comment_id"].ToString();

            DataUse.Comment duc = new DataUse.Comment();

            if(duc.IsUserComment(ccoc.UserId ,CommentId))
                Write("true");
            else
                Write("false");
        }
    }
}