using CodeBehind;

namespace Elanat
{
    public partial class MemberUserStatisticsController : CodeBehindController
    {
        public MemberUserStatisticsModel model = new MemberUserStatisticsModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}