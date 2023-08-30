using CodeBehind;

namespace Elanat
{
    public partial class ActionGetRoleListController : CodeBehindController
    {
		public ActionGetRoleListModel model = new ActionGetRoleListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}