using CodeBehind;

namespace Elanat
{
    public partial class ActionGetAdminStyleListController : CodeBehindController
    {
        public ActionGetAdminStyleListModel model = new ActionGetAdminStyleListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}