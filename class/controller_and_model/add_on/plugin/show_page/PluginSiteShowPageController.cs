using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowPageController : CodeBehindController
    {
        public PluginSiteShowPageModel model = new PluginSiteShowPageModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}