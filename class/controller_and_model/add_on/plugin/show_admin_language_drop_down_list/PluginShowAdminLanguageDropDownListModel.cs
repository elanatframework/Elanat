using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminLanguageDropDownListModel : CodeBehindModel
    {
        public string LanguageLanguage { get; set; }

        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
			// Set Language
			LanguageLanguage = Language.GetAddOnsLanguage("language", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/plugin/show_admin_language_drop_down_list/");
			
			
            // Set Language Name Item
            ListClass.LanguageList lcl = new ListClass.LanguageList();
            lcl.FillActiveLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            OptionListValue += lcl.ActiveLanguageNameListItem.HtmlInputToOptionTag(true);
        }
    }
}