using CodeBehind;

namespace Elanat
{
    public partial class ActionGetContentListController : CodeBehindController
    {
		public ActionGetContentListModel model = new ActionGetContentListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}