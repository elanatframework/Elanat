using CodeBehind;

namespace Elanat
{
    public partial class ActionGetUserFootPrintListController : CodeBehindController
    {
        public ActionGetUserFootPrintListModel model = new ActionGetUserFootPrintListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}