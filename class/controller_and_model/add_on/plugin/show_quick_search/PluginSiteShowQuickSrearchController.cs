using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowQuickSrearchController : CodeBehindController
    {
        public PluginSiteShowQuickSrearchModel model = new PluginSiteShowQuickSrearchModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}