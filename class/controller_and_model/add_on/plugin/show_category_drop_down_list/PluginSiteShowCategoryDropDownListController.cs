using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowCategoryDropDownListController : CodeBehindController
    {
        public PluginSiteShowCategoryDropDownListModel model = new PluginSiteShowCategoryDropDownListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}