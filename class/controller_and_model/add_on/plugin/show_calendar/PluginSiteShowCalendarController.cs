using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowCalendarController : CodeBehindController
    {
        public PluginSiteShowCalendarModel model = new PluginSiteShowCalendarModel();

        public void PageLoad(HttpContext context)
        {
            string CurrentSiteCalendar = StaticObject.DefaultSiteCalendar;

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            if (ccoc.Calendar != null)
                CurrentSiteCalendar = ccoc.Calendar;

            model.SetValue(CurrentSiteCalendar);

            View(model);
        }
    }
}