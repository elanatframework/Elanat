using CodeBehind;

namespace Elanat
{
    public partial class AdminFootPrintController : CodeBehindController
    {
        public AdminFootPrintModel model = new AdminFootPrintModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}