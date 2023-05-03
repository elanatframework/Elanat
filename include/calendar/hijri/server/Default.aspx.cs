using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class HijriCalendar : System.Web.UI.Page
    {
        public IncludeHijriCalendarModel model = new IncludeHijriCalendarModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            string CurrentDate = "";

            if (!string.IsNullOrEmpty(Request.QueryString["current_date"]))
                CurrentDate = Request.QueryString["current_date"];

            model.SetValue(CurrentDate);
        }
    }
}