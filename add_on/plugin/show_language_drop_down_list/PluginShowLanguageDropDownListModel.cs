using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class PluginShowLanguageDropDownListModel
    {
        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
            // Set Language Name Item
            ListClass lc = new ListClass();
            lc.FillActiveLanguageNameListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            OptionListValue += lc.ActiveLanguageNameListItem.HtmlInputToOptionTag(true);
        }
    }
}