using CodeBehind;

namespace Elanat
{
    public partial class ActionGetUserCommentListController : CodeBehindController
    {
        public ActionGetUserCommentListModel model = new ActionGetUserCommentListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}