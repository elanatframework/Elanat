using CodeBehind;

namespace Elanat
{
    public partial class ActionGetCommentListController : CodeBehindController
    {
		public ActionGetCommentListModel model = new ActionGetCommentListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}