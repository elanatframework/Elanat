using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace elanat
{
    public partial class PluginSiteShowCalendar : System.Web.UI.Page
    {
        public PluginSiteShowCalendarModel model = new PluginSiteShowCalendarModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            string CurrentSiteCalendar = "gregorian";
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            if (ccoc.Calendar != null)
                CurrentSiteCalendar = ccoc.Calendar;

            model.SetValue(CurrentSiteCalendar);
        }
    }
}