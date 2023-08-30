namespace Elanat.DataUse
{
    public class ChangeUserDateAndTime
    {
        public string UserId;
        public string Calendar;
        public string FirstDayOfWeek;
        public string DateFormat;
        public string TimeFormat;
        public string DayDifference;
        public string TimeHoursDifference;
        public string TimeMinutesDifference;
        public string TimeZone;

        public void Start()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("change_user_date_and_time", new List<string>() { "@user_id", "@user_calendar", "@user_first_day_of_week", "@user_date_format", "@user_time_format", "@user_day_difference", "@user_time_hours_difference", "@user_time_minutes_difference", "@user_time_zone" }, new List<string>() { UserId, Calendar, FirstDayOfWeek, DateFormat, TimeFormat, DayDifference, TimeHoursDifference, TimeMinutesDifference, TimeZone });
        }
    }
}