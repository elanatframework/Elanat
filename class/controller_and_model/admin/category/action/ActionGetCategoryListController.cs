using CodeBehind;

namespace Elanat
{
    public partial class ActionGetCategoryListController : CodeBehindController
    {
		public ActionGetCategoryListModel model = new ActionGetCategoryListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}