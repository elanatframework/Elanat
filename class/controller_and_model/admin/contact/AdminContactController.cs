using CodeBehind;

namespace Elanat
{
    public partial class AdminContactController : CodeBehindController
    {
        public AdminContactModel model = new AdminContactModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}