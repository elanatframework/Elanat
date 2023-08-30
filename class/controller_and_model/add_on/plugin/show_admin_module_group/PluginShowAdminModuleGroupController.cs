using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminModuleGroupController : CodeBehindController
    {
        public PluginShowAdminModuleGroupModel model = new PluginShowAdminModuleGroupModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}