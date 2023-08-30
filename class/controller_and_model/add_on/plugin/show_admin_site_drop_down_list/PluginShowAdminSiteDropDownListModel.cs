using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminSiteDropDownListModel : CodeBehindModel
    {
        public string SiteLanguage { get; set; }

        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
			// Set Language
			SiteLanguage = Language.GetAddOnsLanguage("site", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/plugin/show_admin_site_drop_down_list/");
			
			
            // Set Site Name Item
            ListClass.Site lcs = new ListClass.Site();
            lcs.FillSiteNameListItem();
            OptionListValue += lcs.SiteNameListItem.HtmlInputToOptionTag(true);
        }
    }
}