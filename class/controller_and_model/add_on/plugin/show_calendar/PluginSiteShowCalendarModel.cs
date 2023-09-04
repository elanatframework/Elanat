using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowCalendarModel : CodeBehindModel
    {
        public void SetValue(string CurrentSiteCalendar)
        {
            Write(PageLoader.LoadWithServer(StaticObject.SitePath + "include/calendar/" + CurrentSiteCalendar + "/server/Default.aspx"));
        }
    }
}