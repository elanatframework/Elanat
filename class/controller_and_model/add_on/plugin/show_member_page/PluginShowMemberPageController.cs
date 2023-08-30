using CodeBehind;

namespace Elanat
{
    public partial class PluginShowMemberPageController : CodeBehindController
    {
        public PluginShowMemberPageModel model = new PluginShowMemberPageModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}