using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class PluginShowAdminLanguageDropDownListModel
    {
        public string LanguageLanguage { get; set; }

        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
			// Set Language
			LanguageLanguage = Language.GetAddOnsLanguage("language", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/plugin/show_admin_language_drop_down_list/");
			
			
            // Set Language Name Item
            ListClass lc = new ListClass();
            lc.FillActiveLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            OptionListValue += lc.ActiveLanguageNameListItem.HtmlInputToOptionTag(true);
        }
    }
}