using CodeBehind;

namespace Elanat
{
    public partial class ActionSearchController : CodeBehindController
    {
        public ActionSearchModel model = new ActionSearchModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}