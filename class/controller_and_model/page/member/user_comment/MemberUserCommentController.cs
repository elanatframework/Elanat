using CodeBehind;

namespace Elanat
{
    public partial class MemberUserCommentController : CodeBehindController
    {
        public MemberUserCommentModel model = new MemberUserCommentModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}