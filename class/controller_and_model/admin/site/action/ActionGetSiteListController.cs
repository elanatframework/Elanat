using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSiteListController : CodeBehindController
    {
		public ActionGetSiteListModel model = new ActionGetSiteListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}