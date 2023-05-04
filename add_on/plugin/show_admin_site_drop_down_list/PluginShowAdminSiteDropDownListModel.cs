using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class PluginShowAdminSiteDropDownListModel
    {
        public string SiteLanguage { get; set; }

        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
			// Set Language
			SiteLanguage = Language.GetAddOnsLanguage("site", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/plugin/show_admin_site_drop_down_list/");
			
			
            // Set Site Name Item
            ListClass lc = new ListClass();
            lc.FillSiteNameListItem();
            OptionListValue += lc.SiteNameListItem.HtmlInputToOptionTag(true);
        }
    }
}