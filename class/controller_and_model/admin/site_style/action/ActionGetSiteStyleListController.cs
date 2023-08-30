using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSiteStyleListController : CodeBehindController
    {
		public ActionGetSiteStyleListModel model = new ActionGetSiteStyleListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}