using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminSiteDropDownListController : CodeBehindController
    {
        public PluginShowAdminSiteDropDownListModel model = new PluginShowAdminSiteDropDownListModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}