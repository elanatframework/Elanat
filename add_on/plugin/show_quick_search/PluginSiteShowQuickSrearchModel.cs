using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat
{
    public class PluginSiteShowQuickSrearchModel
    {
        public void SetValue()
        {
            string QuickSearchTemplate = Template.GetSiteTemplate("part/quick_search");

            HttpContext.Current.Response.Write(QuickSearchTemplate);
        }
    }
}