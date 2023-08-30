using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSiteTemplateListController : CodeBehindController
    {
		public ActionGetSiteTemplateListModel model = new ActionGetSiteTemplateListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}