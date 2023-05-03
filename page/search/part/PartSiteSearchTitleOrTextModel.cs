using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class PartSiteSearchTitleOrTextModel
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