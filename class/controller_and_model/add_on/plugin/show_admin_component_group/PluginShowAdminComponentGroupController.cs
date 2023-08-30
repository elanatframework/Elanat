using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminComponentGroupController : CodeBehindController
    {
        public PluginShowAdminComponentGroupModel model = new PluginShowAdminComponentGroupModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}