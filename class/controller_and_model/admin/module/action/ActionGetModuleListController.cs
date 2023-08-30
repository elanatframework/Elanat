using CodeBehind;

namespace Elanat
{
    public partial class ActionGetModuleListController : CodeBehindController
    {
		public ActionGetModuleListModel model = new ActionGetModuleListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}