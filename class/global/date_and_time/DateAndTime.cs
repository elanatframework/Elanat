using System.Reflection;

namespace Elanat
{
    public class DateAndTime
    {
        public static double GetDateTimeSecondsDifference(DateTime FirstDateTime, DateTime SecondDateTime)
        {
            TimeSpan ts = FirstDateTime - SecondDateTime;
            double Seconds = ts.TotalSeconds;
            return Seconds;
        }

        public static double GetDateTimeHoursDifference(DateTime FirstDateTime, DateTime SecondDateTime)
        {
            TimeSpan ts = FirstDateTime - SecondDateTime;
            double Hours = ts.TotalHours;
            return Hours;
        }

        public static double GetDateTimeDayDifference(DateTime FirstDateTime, DateTime SecondDateTime)
        {
            TimeSpan ts = FirstDateTime - SecondDateTime;
            double Days = ts.TotalDays;
            return Days;
        }

        public static DateTime GetDateAndTime()
        {
            double day = Convert.ToInt32(StaticObject.DefaultDayDifference);
            double hours = Convert.ToInt32(StaticObject.DefaultTimeDifferenceHours);
            double minutes = Convert.ToInt32(StaticObject.DefaultTimeDifferenceMinutes);

            return DateTime.Now.AddDays(day).AddHours(hours).AddMinutes(minutes);
        }

        public static long GetDateAndTimeLong()
        {
            return long.Parse(GetDate("yyyy/MM/dd").Replace(@"/", "") +  GetTime("HH:mm:ss").Replace(":", ""));
        }

        public static string GetDate(string Format = "default", double DayDifference = 0)
        {
            if (Format == "default")
                Format = "{0:" + StaticObject.DefaultDateFormat + "}";
            else
                Format = "{0:" + Format.Replace("/", "'/'") + "}";

            int date = Convert.ToInt32(StaticObject.DefaultDayDifference);
            DateTime TmpDateTime;

            TmpDateTime = DateTime.Now.AddDays(date);
            TmpDateTime = DateTime.Now.AddDays(DayDifference);

            if (Format == "tuning" || Format == "{0:tuning}")
                return TmpDateTime.ToDateAndTimeTuning(StaticObject.GetCurrentAdminGlobalLanguage(), "date");

            return string.Format(Format, TmpDateTime);
        }

        public static string GetTime(string Format = "default", int SecondsDifference = 0)
        {
            if (Format == "default")
                Format = "{0:" + StaticObject.DefaulttimeFormat + "}";
            else
                Format = "{0:" + Format + "}";
            double hours = Convert.ToInt32(StaticObject.DefaultTimeDifferenceHours);
            double minutes = Convert.ToInt32(StaticObject.DefaultTimeDifferenceMinutes);

            if (Format == "tuning")
                return DateTime.Now.AddHours(hours).AddMinutes(minutes).AddSeconds(SecondsDifference).ToDateAndTimeTuning(StaticObject.GetCurrentAdminGlobalLanguage(), "time");

            return string.Format(Format, DateTime.Now.AddHours(hours).AddMinutes(minutes).AddSeconds(SecondsDifference));
        }

        public string GetLocalDate(string Calendar, string Date)
        {
            if (string.IsNullOrEmpty(Calendar))
                Calendar = StaticObject.DefaultSiteCalendar;

            string DllPath = StaticObject.ServerMapPath(StaticObject.SitePath + "include/calendar/" + Calendar + "/dll/" + Calendar + " calendar.dll");
            Assembly Dll = Assembly.LoadFrom(DllPath);
            System.Type type = Dll.GetType(Calendar + "_calendar." + Calendar);
            MethodInfo Method = Dll.GetTypes()[0].GetMethod("GetDate");
            Object obj = Activator.CreateInstance(type);

            var ReturnValue = Method.Invoke(obj, new object[] { DateTime.Parse(Date + " 00:00:00") }).ToString();
            return ReturnValue.ToString();
        }
    }
}