using CodeBehind;

namespace Elanat
{
    public partial class ActionGetGroupListController : CodeBehindController
    {
		public ActionGetGroupListModel model = new ActionGetGroupListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}