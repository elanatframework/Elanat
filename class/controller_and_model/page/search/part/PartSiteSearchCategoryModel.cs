using CodeBehind;

namespace Elanat
{
    public partial class PartSiteSearchCategoryModel : CodeBehindModel
    {
        public string CategoryLanguage { get; set; } = "";

        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/search/");
            CategoryLanguage = aol.GetAddOnsLanguage("category");


            // Set Current Value
            ListClass.Category lcc = new ListClass.Category();

            // Set Category Item
            OptionListValue = OptionListValue.HtmlInputAddOptionTag(aol.GetAddOnsLanguage("all"), "0");

            lcc.FillCategoryListItemTree(StaticObject.GetCurrentSiteSiteId(), "-");
            OptionListValue += lcc.CategoryListItemTree.HtmlInputToOptionTag();
        }
    }
}