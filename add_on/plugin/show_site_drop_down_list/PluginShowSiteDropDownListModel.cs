using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class PluginShowSiteDropDownListModel
    {
        public string OptionListValue { get; set; } = "";

        public void SetValue()
        {
            // Set Site Name Item
            ListClass lc = new ListClass();
            lc.FillSiteNameListItem();
            OptionListValue += lc.SiteNameListItem.HtmlInputToOptionTag(true);
        }
    }
}