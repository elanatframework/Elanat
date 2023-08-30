using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminExtraHelperGroupController : CodeBehindController
    {
        public PluginShowAdminExtraHelperGroupModel model = new PluginShowAdminExtraHelperGroupModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context);

            View(model);
        }
    }
}