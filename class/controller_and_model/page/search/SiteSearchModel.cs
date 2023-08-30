using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteSearchModel : CodeBehindModel
    {
        public string SearchLanguage { get; set; }
        public string WordLanguage { get; set; }

        public string TitleOrTextPartValue { get; set; }
        public string DatePartValue { get; set; }
        public string CategoryPartValue { get; set; }
        public string ContentValue { get; set; }

        public string CategoryOptionListSelectedValue { get; set; }
        public string TitleOrTextOptionListSelectedValue { get; set; }
        public string SearchFromValue { get; set; }
        public string SearchUntilValue { get; set; }

        public string SearchValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/search/");
            SearchLanguage = aol.GetAddOnsLanguage("search");
            WordLanguage = aol.GetAddOnsLanguage("word");


            // Set Value
            XmlDocument RssOptionDocument = new XmlDocument();
            RssOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/search_option/option/search_option.xml"));

            XmlNode node = RssOptionDocument.SelectSingleNode("search_option_root");

            bool ActiveCategorySearch = node["category_search"].Attributes["active"].Value == "true";
            bool ActiveDateSearch = node["date_search"].Attributes["active"].Value == "true";
            bool ActiveTitleTextSearch = node["title_text_search"].Attributes["active"].Value == "true";


            if (ActiveCategorySearch)
                CategoryPartValue = PageLoader.LoadWithServer(StaticObject.ServerMapPath(StaticObject.SitePath + "page/search/part/PartSiteSearchCategory.aspx"), true);

            if (ActiveDateSearch)
                DatePartValue = PageLoader.LoadWithServer(StaticObject.ServerMapPath(StaticObject.SitePath + "page/search/part/PartSiteSearchDate.aspx"), true);

            if (ActiveTitleTextSearch)
                TitleOrTextPartValue = PageLoader.LoadWithServer(StaticObject.ServerMapPath(StaticObject.SitePath + "page/search/part/PartSiteSearchTitleOrText.aspx"), true);
        }

        public void Search(HttpContext context, bool IsQuerySearch = false)
        {
            // Set Value
            XmlDocument SearchOptionDocument = new XmlDocument();
            SearchOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/search_option/option/search_option.xml"));

            XmlNode node = SearchOptionDocument.SelectSingleNode("search_option_root");

            int MnimumSearchCharacter = node["minimum_search_character"].Attributes["value"].Value.ToNumber();
            bool ActiveCategorySearch = node["category_search"].Attributes["active"].Value == "true";
            bool ActiveDateSearch = node["date_search"].Attributes["active"].Value == "true";
            bool ActiveTitleTextSearch = node["title_text_search"].Attributes["active"].Value == "true";

            if (MnimumSearchCharacter > SearchValue.Length)
            {
                // Set Language
                AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/search/");
                SearchLanguage = aol.GetAddOnsLanguage("search");

                if (IsQuerySearch)
                {
                    ContentValue = GlobalClass.Alert(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", StaticObject.GetCurrentSiteGlobalLanguage()).Replace("$_asp field_name;", SearchLanguage).Replace("$_asp minimum_count;", MnimumSearchCharacter.ToString()), StaticObject.GetCurrentSiteGlobalLanguage(), "problem");
                    return;
                }
                else
                {
                    ResponseForm.WriteLocalAlone(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", StaticObject.GetCurrentSiteGlobalLanguage()).Replace("$_asp field_name;", SearchLanguage).Replace("$_asp minimum_count;", MnimumSearchCharacter.ToString()), "problem");

                    return;
                }
            }

            if (!string.IsNullOrEmpty(SearchValue))
            {
                string Search = "search=" + SearchValue;
                string Type = (ActiveTitleTextSearch) ? "&type=" + TitleOrTextOptionListSelectedValue : "&type=both";
                string CategorySelectedIndex = (ActiveCategorySearch) ? ((CategoryOptionListSelectedValue == "0") ? "&category=all" : "&category=" + CategoryOptionListSelectedValue) : "&category=all";
                string FromDate = (ActiveDateSearch) ? "&from_date=" + SearchFromValue.Replace("/", "-") : "";
                string UntilDate = (ActiveDateSearch) ? "&until_date=" + SearchUntilValue.Replace("/", "-") : "";
                string Page = (!string.IsNullOrEmpty(context.Request.Query["page"])) ? "&page=" + context.Request.Query["page"].ToString() : "" ;

                if (IsQuerySearch)
                    ContentValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/search/action/Search.aspx?" + Search + CategorySelectedIndex + Type + FromDate + UntilDate + Page);
                else
                {
                    context.Response.Redirect(StaticObject.SitePath + "page/search/action/Search.aspx?" + Search + CategorySelectedIndex + Type + FromDate + UntilDate + Page);
                    return;
                }
            }
        }
    }
}