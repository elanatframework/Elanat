using CodeBehind;

namespace Elanat
{
    public partial class ActionGetUserListController : CodeBehindController
    {
		public ActionGetUserListModel model = new ActionGetUserListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}