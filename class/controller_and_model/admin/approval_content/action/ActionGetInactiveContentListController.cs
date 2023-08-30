using CodeBehind;

namespace Elanat
{
    public partial class ActionGetInactiveContentListController : CodeBehindController
    {
		public ActionGetInactiveContentListModel model = new ActionGetInactiveContentListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}