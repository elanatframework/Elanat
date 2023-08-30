using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminSystemMenuController : CodeBehindController
    {
        public PluginShowAdminSystemMenuModel model = new PluginShowAdminSystemMenuModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}