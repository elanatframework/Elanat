using CodeBehind;

namespace Elanat
{
    public partial class ActionGetContactListController : CodeBehindController
    {
		public ActionGetContactListModel model = new ActionGetContactListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}