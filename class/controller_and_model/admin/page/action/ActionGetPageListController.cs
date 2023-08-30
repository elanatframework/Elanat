using CodeBehind;

namespace Elanat
{
    public partial class ActionGetPageListController : CodeBehindController
    {
		public ActionGetPageListModel model = new ActionGetPageListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}