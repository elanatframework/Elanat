using CodeBehind;

namespace Elanat
{
    public partial class ActionGetAttachmentListController : CodeBehindController
    {
		public ActionGetAttachmentListModel model = new ActionGetAttachmentListModel();
		
        public void PageLoad(HttpContext context)
        {
			model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}