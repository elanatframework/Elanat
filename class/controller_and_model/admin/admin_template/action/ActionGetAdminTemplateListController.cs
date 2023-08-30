using CodeBehind;

namespace Elanat
{
    public partial class ActionGetAdminTemplateListController : CodeBehindController
    {
		public ActionGetAdminTemplateListModel model = new ActionGetAdminTemplateListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}