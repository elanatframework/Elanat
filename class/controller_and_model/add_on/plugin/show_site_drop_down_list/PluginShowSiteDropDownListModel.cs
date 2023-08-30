using CodeBehind;

namespace Elanat
{
    public partial class PluginShowSiteDropDownListModel : CodeBehindModel
    {
        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
            // Set Site Name Item
            ListClass.Site lcs = new ListClass.Site();
            lcs.FillSiteNameListItem();
            OptionListValue += lcs.SiteNameListItem.HtmlInputToOptionTag(true);
        }
    }
}