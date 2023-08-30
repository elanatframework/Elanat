using CodeBehind;

namespace Elanat
{
    public partial class ActionGetItemListController : CodeBehindController
    {
		public ActionGetItemListModel model = new ActionGetItemListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}