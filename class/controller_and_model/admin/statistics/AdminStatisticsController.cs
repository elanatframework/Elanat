using CodeBehind;

namespace Elanat
{
    public partial class AdminStatisticsController : CodeBehindController
    {
        public AdminStatisticsModel model = new AdminStatisticsModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context);

            View(model);
        }
    }
}