using CodeBehind;

namespace Elanat
{
    public partial class ActionGetMenuListController : CodeBehindController
    {
		public ActionGetMenuListModel model = new ActionGetMenuListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}