using CodeBehind;

namespace Elanat
{
    public partial class StartTimerController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            ScheduledTimer.Main();
        }
    }
}