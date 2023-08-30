using CodeBehind;

namespace Elanat
{
    public partial class ActionGetFootPrintListController : CodeBehindController
    {
		public ActionGetFootPrintListModel model = new ActionGetFootPrintListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}