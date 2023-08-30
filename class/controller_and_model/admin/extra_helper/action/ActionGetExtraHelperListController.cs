using CodeBehind;

namespace Elanat
{
    public partial class ActionGetExtraHelperListController : CodeBehindController
    {
		public ActionGetExtraHelperListModel model = new ActionGetExtraHelperListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}