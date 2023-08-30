using CodeBehind;

namespace Elanat
{
    public partial class ActionGetTrashContentListController : CodeBehindController
    {
		public ActionGetTrashContentListModel model = new ActionGetTrashContentListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}