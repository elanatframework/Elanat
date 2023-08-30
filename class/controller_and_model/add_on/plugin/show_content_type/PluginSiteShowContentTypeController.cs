using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowContentTypeController : CodeBehindController
    {
        public PluginSiteShowContentTypeModel model = new PluginSiteShowContentTypeModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}