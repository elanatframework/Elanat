using CodeBehind;

namespace Elanat
{
    public partial class AdminDashboardController : CodeBehindController
    {
        public AdminDashboardModel model = new AdminDashboardModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}