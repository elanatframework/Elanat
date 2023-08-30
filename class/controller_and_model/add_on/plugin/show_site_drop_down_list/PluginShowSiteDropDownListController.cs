using CodeBehind;

namespace Elanat
{
    public partial class PluginShowSiteDropDownListController : CodeBehindController
    {
        public PluginShowSiteDropDownListModel model = new PluginShowSiteDropDownListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}