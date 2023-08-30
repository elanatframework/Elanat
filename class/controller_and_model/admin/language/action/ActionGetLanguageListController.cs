using CodeBehind;

namespace Elanat
{
    public partial class ActionGetLanguageListController : CodeBehindController
    {
		public ActionGetLanguageListModel model = new ActionGetLanguageListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}