using CodeBehind;

namespace Elanat
{
    public partial class ActionGetEditorTemplateListController : CodeBehindController
    {
		public ActionGetEditorTemplateListModel model = new ActionGetEditorTemplateListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}