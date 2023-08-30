using CodeBehind;

namespace Elanat
{
    public partial class ActionGetPluginListController : CodeBehindController
    {
		public ActionGetPluginListModel model = new ActionGetPluginListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}