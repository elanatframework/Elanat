using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class PartSiteSearchCategoryModel
    {
        public string CategoryLanguage { get; set; } = "";

        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/search/");
            CategoryLanguage = aol.GetAddOnsLanguage("category");


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Category Item
            OptionListValue = OptionListValue.HtmlInputAddOptionTag(aol.GetAddOnsLanguage("all"), "0");

            lc.FillCategoryListItemTree(StaticObject.GetCurrentSiteSiteId(), "-");
            OptionListValue += lc.CategoryListItemTree.HtmlInputToOptionTag();
        }
    }
}