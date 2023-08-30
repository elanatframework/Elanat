using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowSiteController : CodeBehindController
    {
        public PluginSiteShowSiteModel model = new PluginSiteShowSiteModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}