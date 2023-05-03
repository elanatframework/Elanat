using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class IncludeHijriCalendarModel
    {
        public string CalendarLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(string CurrentDate = "")
        {
            System.Globalization.HijriCalendar hc = new System.Globalization.HijriCalendar();
            DateTime dt = DateTime.Now;

            if (!string.IsNullOrEmpty(CurrentDate))
            {
                string[] ArrayCurrentDate = CurrentDate.Split('-');

                try
                {
                    dt = new DateTime(int.Parse(ArrayCurrentDate[0]), int.Parse(ArrayCurrentDate[1]), int.Parse(ArrayCurrentDate[2]), hc);
                }
                catch
                {
                    dt = new DateTime(int.Parse(ArrayCurrentDate[0]), int.Parse(ArrayCurrentDate[1]), 1, hc);
                }
            }


            string CalendarBoxStruct = Struct.GetNode("calendar/box").InnerText;
            string MountOptionListItemStruct = Struct.GetNode("calendar/mount_option_list").InnerText;
            string DayeOfWeekOptionListStruct = Struct.GetNode("calendar/day_of_week").InnerText;
            string DayListItemStruct = Struct.GetNode("calendar/day").InnerText;

            string TmpMountOptionListItemStruct = "";
            string SumMountOptionListItemStruct = "";
            string TmpDayeOfWeekOptionListStruct = "";
            string SumDayeOfWeekOptionListStruct = "";
            string TmpDayListItemStruct = "";
            string SumDayListItemStruct = "";
            string EmptyDayListItemStruct = DayListItemStruct.Replace("$_asp day_value;", "").Replace("$_asp is_select;", "");


            // Sec Current Value
            ListClass lc = new ListClass();

            string CurrentYear = hc.GetYear(dt).ToString();
            
            // Set Mount Value
            lc.FillHijriMountListItemByCalendarLanguage(StaticObject.GetCurrentSiteGlobalLanguage());
            string CurrentMount = hc.GetMonth(dt).ToString();

            foreach (ListItem Mount in lc.HijriMountListItemByCalendarLanguage)
            {
                TmpMountOptionListItemStruct = MountOptionListItemStruct;
                TmpMountOptionListItemStruct = TmpMountOptionListItemStruct.Replace("$_asp mount_option_value;", Mount.Value);
                TmpMountOptionListItemStruct = TmpMountOptionListItemStruct.Replace("$_asp mount_option_text;", Mount.Text + " (" + CurrentYear + ")");
                TmpMountOptionListItemStruct = (CurrentMount == Mount.Value) ? TmpMountOptionListItemStruct.Replace("$_asp is_select;", " selected=\"\"") : TmpMountOptionListItemStruct.Replace("$_asp is_select;", "");
                SumMountOptionListItemStruct += TmpMountOptionListItemStruct;
            }


            // Set Day Of Week Value
            lc.FillPersianDayOfWeakListItem(StaticObject.GetCurrentSiteGlobalLanguage());

            foreach (ListItem DayOfWeek in lc.PersianDayOfWeakListItem)
            {
                TmpDayeOfWeekOptionListStruct = DayeOfWeekOptionListStruct;
                TmpDayeOfWeekOptionListStruct = TmpDayeOfWeekOptionListStruct.Replace("$_asp day_of_week_value;", DayOfWeek.Text[0].ToString());
                SumDayeOfWeekOptionListStruct += TmpDayeOfWeekOptionListStruct;
            }

            // Set Day Value
            string CurrentDay = hc.GetDayOfMonth(dt).ToString();
            int CurrentDayNumber = hc.GetDayOfMonth(dt);

            DateTime TmpDateTime = (hc.GetDayOfMonth(dt) > 1) ? dt.AddDays((hc.GetDayOfMonth(dt) * -1) + 1) : dt;
            int CurrentDayOfWeek = (int)hc.GetDayOfWeek(TmpDateTime);
            CurrentDayOfWeek = (CurrentDayOfWeek == 6) ? 0 : CurrentDayOfWeek + 1;

            for (int DayOfWeekCounter = 0; DayOfWeekCounter < CurrentDayOfWeek; DayOfWeekCounter++)
                SumDayListItemStruct += EmptyDayListItemStruct;

            int CurrentMountNumber = hc.GetMonth(dt);
            int DayCounter = 0;
            while (hc.GetMonth(TmpDateTime) == CurrentMountNumber)
            {
                DayCounter++;

                TmpDayListItemStruct = DayListItemStruct;
                TmpDayListItemStruct = (DayCounter == CurrentDayNumber) ? TmpDayListItemStruct.Replace("$_asp is_select;", " class=\"el_select\"") : TmpDayListItemStruct.Replace("$_asp is_select;", "");
                TmpDayListItemStruct = TmpDayListItemStruct.Replace("$_asp day_value;", (DayCounter).ToString());
                SumDayListItemStruct += TmpDayListItemStruct;

                TmpDateTime = TmpDateTime.AddDays(1);
            }

            int AfterEmptyCount = 0;
            if ((CurrentDayOfWeek + DayCounter) <= 35)
                AfterEmptyCount = 35 - (CurrentDayOfWeek + DayCounter);
            else
                AfterEmptyCount = 42 - (CurrentDayOfWeek + DayCounter);

            for (int AfterEmptyCounter = 0; AfterEmptyCounter < AfterEmptyCount; AfterEmptyCounter++)
                SumDayListItemStruct += EmptyDayListItemStruct;

            // Set Box Value
            CalendarBoxStruct = CalendarBoxStruct.Replace("$_asp calendar_mount_option_list;", SumMountOptionListItemStruct);
            CalendarBoxStruct = CalendarBoxStruct.Replace("$_asp day_of_week_list;", SumDayeOfWeekOptionListStruct);
            CalendarBoxStruct = CalendarBoxStruct.Replace("$_asp day_list;", SumDayListItemStruct);
            CalendarBoxStruct = CalendarBoxStruct.Replace("$_asp current_date;", CurrentYear + "-" + CurrentMount + "-" + CurrentDay);
            CalendarBoxStruct = CalendarBoxStruct.Replace("$_asp calendar_path;", "hijri");

            ContentValue = CalendarBoxStruct;
        }
    }
}