using CodeBehind;

namespace Elanat
{
    public partial class ActionGetComponentListController : CodeBehindController
    {
		public ActionGetComponentListModel model = new ActionGetComponentListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}