using CodeBehind;

namespace Elanat
{
    public partial class ActionGetFileDirectoryListController : CodeBehindController
    {
		public ActionGetFileDirectoryListModel model = new ActionGetFileDirectoryListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}