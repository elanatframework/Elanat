using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowAcceptCookieMessageController : CodeBehindController
    {
        public PluginSiteShowAcceptCookieMessageModel model = new PluginSiteShowAcceptCookieMessageModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context);

            View(model);
        }
    }
}