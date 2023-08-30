using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowLanguageController : CodeBehindController
    {
        public PluginSiteShowLanguageModel model = new PluginSiteShowLanguageModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}