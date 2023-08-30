using CodeBehind;

namespace Elanat
{
    public partial class PluginShowCurrentSiteController : CodeBehindController
    {
        public PluginShowCurrentSiteModel model = new PluginShowCurrentSiteModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}