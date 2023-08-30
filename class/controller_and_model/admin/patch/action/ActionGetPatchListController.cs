using CodeBehind;

namespace Elanat
{
    public partial class ActionGetPatchListController : CodeBehindController
    {
		public ActionGetPatchListModel model = new ActionGetPatchListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}