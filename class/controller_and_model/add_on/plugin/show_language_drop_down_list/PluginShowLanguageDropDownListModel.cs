using CodeBehind;

namespace Elanat
{
    public partial class PluginShowLanguageDropDownListModel : CodeBehindModel
    {
        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
            // Set Language Name Item
            ListClass.LanguageList lcl = new ListClass.LanguageList();
            lcl.FillActiveLanguageNameListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            OptionListValue += lcl.ActiveLanguageNameListItem.HtmlInputToOptionTag(true);
        }
    }
}