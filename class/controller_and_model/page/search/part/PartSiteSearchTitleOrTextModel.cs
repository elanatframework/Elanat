using CodeBehind;

namespace Elanat
{
    public partial class PartSiteSearchTitleOrTextModel : CodeBehindModel
    {
        public string TitleSearchOrTextSearchLanguage { get; set; }

        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/search/");
            TitleSearchOrTextSearchLanguage = aol.GetAddOnsLanguage("title_search_or_text_search");
            

            // Set Title Text Value
            OptionListValue = OptionListValue.HtmlInputAddOptionTag(aol.GetAddOnsLanguage("both"), "both");
            OptionListValue = OptionListValue.HtmlInputAddOptionTag(aol.GetAddOnsLanguage("title_search"), "title");
            OptionListValue = OptionListValue.HtmlInputAddOptionTag(aol.GetAddOnsLanguage("text_search"), "text");
        }
    }
}