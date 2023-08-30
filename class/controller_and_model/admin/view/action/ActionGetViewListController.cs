using CodeBehind;

namespace Elanat
{
    public partial class ActionGetViewListController : CodeBehindController
    {
		public ActionGetViewListModel model = new ActionGetViewListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}