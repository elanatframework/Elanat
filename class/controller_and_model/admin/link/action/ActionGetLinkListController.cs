using CodeBehind;

namespace Elanat
{
    public partial class ActionGetLinkListController : CodeBehindController
    {
		public ActionGetLinkListModel model = new ActionGetLinkListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}