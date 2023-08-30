using CodeBehind;

namespace Elanat
{
    public partial class ActionGetInactiveCommentListController : CodeBehindController
    {
		public ActionGetInactiveCommentListModel model = new ActionGetInactiveCommentListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}