using CodeBehind;

namespace Elanat
{
    public partial class ActionGetUserContentListController : CodeBehindController
    {
        public ActionGetUserContentListModel model = new ActionGetUserContentListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}