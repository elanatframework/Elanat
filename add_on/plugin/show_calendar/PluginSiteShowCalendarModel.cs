using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat
{
    public class PluginSiteShowCalendarModel
    {
        public void SetValue(string CurrentSiteCalendar)
        {
            HttpContext.Current.Response.Write(PageLoader.LoadWithServer("/include/calendar/" + CurrentSiteCalendar + "/server/Default.aspx"));
        }
    }
}