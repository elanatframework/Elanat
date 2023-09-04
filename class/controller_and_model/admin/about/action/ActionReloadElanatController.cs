using CodeBehind;

namespace Elanat
{
    public partial class ActionReloadElanatController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Environment.Exit(0);
        }
    }
}