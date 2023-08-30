using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminUserMenuController : CodeBehindController
    {
        public PluginShowAdminUserMenuModel model = new PluginShowAdminUserMenuModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}