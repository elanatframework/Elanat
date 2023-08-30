using CodeBehind;

namespace Elanat
{
    public partial class AdminContentController : CodeBehindController
    {
        public AdminContentModel model = new AdminContentModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}