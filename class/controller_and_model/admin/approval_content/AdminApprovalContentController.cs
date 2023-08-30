using CodeBehind;

namespace Elanat
{
    public partial class AdminApprovalContentController : CodeBehindController
    {
        public AdminApprovalContentModel model = new AdminApprovalContentModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}