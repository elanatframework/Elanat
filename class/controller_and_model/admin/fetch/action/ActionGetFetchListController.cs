using CodeBehind;

namespace Elanat
{
    public partial class ActionGetFetchListController : CodeBehindController
    {
		public ActionGetFetchListModel model = new ActionGetFetchListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}