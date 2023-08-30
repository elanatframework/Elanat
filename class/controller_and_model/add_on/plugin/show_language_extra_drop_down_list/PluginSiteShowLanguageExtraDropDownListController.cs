using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowLanguageExtraDropDownListController : CodeBehindController
    {
        public PluginSiteShowLanguageExtraDropDownListModel model = new PluginSiteShowLanguageExtraDropDownListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}