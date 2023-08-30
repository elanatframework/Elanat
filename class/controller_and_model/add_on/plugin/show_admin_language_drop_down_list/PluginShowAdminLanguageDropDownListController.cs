using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminLanguageDropDownListController : CodeBehindController
    {
        public PluginShowAdminLanguageDropDownListModel model = new PluginShowAdminLanguageDropDownListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}