using CodeBehind;

namespace Elanat
{
    public partial class PluginShowLanguageDropDownListController : CodeBehindController
    {
        public PluginShowLanguageDropDownListModel model = new PluginShowLanguageDropDownListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}