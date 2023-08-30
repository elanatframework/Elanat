using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowCalendarModel : CodeBehindModel
    {
        public void SetValue(string CurrentSiteCalendar)
        {
            Write(PageLoader.LoadWithServer("/include/calendar/" + CurrentSiteCalendar + "/server/Default.aspx"));
        }
    }
}