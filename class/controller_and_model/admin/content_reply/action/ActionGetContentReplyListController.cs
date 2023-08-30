using CodeBehind;

namespace Elanat
{
    public partial class ActionGetContentReplyListController : CodeBehindController
    {
		public ActionGetContentReplyListModel model = new ActionGetContentReplyListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}