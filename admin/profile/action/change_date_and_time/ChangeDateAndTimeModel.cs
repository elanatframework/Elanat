using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionChangeDateAndTimeModel
    {
        public string DateAndTimeLanguage { get; set; }
        public string ChangeDateAndTimeLanguage { get; set; }
        public string MemberLanguage { get; set; }
        public string CalendarLanguage { get; set; }
        public string FirstDayOfWeekLanguage { get; set; }
        public string DateFormatLanguage { get; set; }
        public string TimeFormatLanguage { get; set; }
        public string DayDifferenceLanguage { get; set; }
        public string TimeHoursDifferenceLanguage { get; set; }
        public string TimeMinutesDifferenceLanguage { get; set; }
        public string TimeZoneLanguage { get; set; }

        public string DateFormatValue { get; set; }
        public string TimeFormatValue { get; set; }
        public string DayDifferenceValue { get; set; }
        public string TimeHoursDifferenceValue { get; set; }
        public string TimeMinutesDifferenceValue { get; set; }

        public string DateFormatAttribute { get; set; }
        public string TimeFormatAttribute { get; set; }
        public string DayDifferenceAttribute { get; set; }
        public string TimeHoursDifferenceAttribute { get; set; }
        public string TimeMinutesDifferenceAttribute { get; set; }

        public string DateFormatCssClass { get; set; }
        public string TimeFormatCssClass { get; set; }
        public string DayDifferenceCssClass { get; set; }
        public string TimeHoursDifferenceCssClass { get; set; }
        public string TimeMinutesDifferenceCssClass { get; set; }

        public string CalendarOptionListValue { get; set; }
        public string FirstDayOfWeekOptionListValue { get; set; }
        public string TimeZoneOptionListValue { get; set; }
        public string CalendarOptionListSelectedValue { get; set; }
        public string FirstDayOfWeekOptionListSelectedValue { get; set; }
        public string TimeZoneOptionListSelectedValue { get; set; }

        public string CalendarAttribute { get; set; }
        public string FirstDayOfWeekAttribute { get; set; }
        public string TimeZoneAttribute { get; set; }

        public string CalendarCssClass { get; set; }
        public string FirstDayOfWeekCssClass { get; set; }
        public string TimeZoneCssClass { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/profile/");
            DateAndTimeLanguage = aol.GetAddOnsLanguage("date_and_time");
            ChangeDateAndTimeLanguage = aol.GetAddOnsLanguage("change_date_and_time");
            CalendarLanguage = aol.GetAddOnsLanguage("calendar");
            FirstDayOfWeekLanguage = aol.GetAddOnsLanguage("first_day_of_week");
            DateFormatLanguage = aol.GetAddOnsLanguage("date_format");
            TimeFormatLanguage = aol.GetAddOnsLanguage("time_format");
            DayDifferenceLanguage = aol.GetAddOnsLanguage("day_difference");
            TimeHoursDifferenceLanguage = aol.GetAddOnsLanguage("time_hours_difference");
            TimeMinutesDifferenceLanguage = aol.GetAddOnsLanguage("time_minutes_difference");
            TimeZoneLanguage = aol.GetAddOnsLanguage("time_zone");


            // Set User Info
            DataBaseSocket db = new DataBaseSocket();

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_info", "@user_id", ccoc.UserId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                dbdr.dr.Read();

            // Set Current Value
            TimeFormatValue = dbdr.dr["user_time_format"].ToString();
            DateFormatValue = dbdr.dr["user_date_format"].ToString();
            DayDifferenceValue = dbdr.dr["user_day_difference"].ToString();
            TimeHoursDifferenceValue = dbdr.dr["user_time_hours_difference"].ToString();
            TimeMinutesDifferenceValue = dbdr.dr["user_time_minutes_difference"].ToString();

            string CurrentCalendar = dbdr.dr["user_calendar"].ToString();
            string CurrentFirstDayOfWeek = dbdr.dr["user_first_day_of_week"].ToString();
            string CurrentTimeZone = dbdr.dr["user_time_zone"].ToString();

            db.Close();


            ListClass lc = new ListClass();

            // Set Calendar Item
            lc.FillCalendarListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            CalendarOptionListValue += CalendarOptionListValue.HtmlInputAddOptionTag("", "");
            CalendarOptionListValue += lc.CalendarListItem.HtmlInputToOptionTag(CurrentCalendar);

            // Set Day Of Weak Item
            lc.FillDayOfWeakListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            FirstDayOfWeekOptionListValue += FirstDayOfWeekOptionListValue.HtmlInputAddOptionTag("", "0");
            FirstDayOfWeekOptionListValue += lc.DayOfWeakListItem.HtmlInputToOptionTag(CurrentFirstDayOfWeek);

            // Set Time Zone Item
            lc.FillTimeZoneListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            TimeZoneOptionListValue += TimeZoneOptionListValue.HtmlInputAddOptionTag("", "0");
            TimeZoneOptionListValue += lc.TimeZoneListItem.HtmlInputToOptionTag(CurrentTimeZone);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("ddlst_Calendar", CalendarOptionListValue);
            InputRequest.Add("ddlst_FirstDayOfWeek", FirstDayOfWeekOptionListValue);
            InputRequest.Add("ddlst_TimeZone", TimeZoneOptionListValue);
            InputRequest.Add("txt_DateFormat", "");
            InputRequest.Add("txt_TimeFormat", "");
            InputRequest.Add("txt_DayDifference", "");
            InputRequest.Add("txt_TimeHoursDifference", "");
            InputRequest.Add("txt_TimeMinutesDifference", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/profile/", "change_date_and_time");

            CalendarAttribute += vc.ImportantInputAttribute["ddlst_Calendar"];
            FirstDayOfWeekAttribute += vc.ImportantInputAttribute["ddlst_FirstDayOfWeek"];
            TimeZoneAttribute += vc.ImportantInputAttribute["ddlst_TimeZone"];
            DateFormatAttribute += vc.ImportantInputAttribute["txt_DateFormat"];
            TimeFormatAttribute += vc.ImportantInputAttribute["txt_TimeFormat"];
            DayDifferenceAttribute += vc.ImportantInputAttribute["txt_DayDifference"];
            TimeHoursDifferenceAttribute += vc.ImportantInputAttribute["txt_TimeHoursDifference"];
            TimeMinutesDifferenceAttribute += vc.ImportantInputAttribute["txt_TimeMinutesDifference"];

            CalendarCssClass = CalendarCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_Calendar"]);
            FirstDayOfWeekCssClass = FirstDayOfWeekCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_FirstDayOfWeek"]);
            TimeZoneCssClass = TimeZoneCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_TimeZone"]);
            DateFormatCssClass = DateFormatCssClass.AddHtmlClass(vc.ImportantInputClass["txt_DateFormat"]);
            TimeFormatCssClass = TimeFormatCssClass.AddHtmlClass(vc.ImportantInputClass["txt_TimeFormat"]);
            DayDifferenceCssClass = DayDifferenceCssClass.AddHtmlClass(vc.ImportantInputClass["txt_DayDifference"]);
            TimeHoursDifferenceCssClass = TimeHoursDifferenceCssClass.AddHtmlClass(vc.ImportantInputClass["txt_TimeHoursDifference"]);
            TimeMinutesDifferenceCssClass = TimeMinutesDifferenceCssClass.AddHtmlClass(vc.ImportantInputClass["txt_TimeMinutesDifference"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "change_date_and_time", StaticObject.AdminPath + "/profile/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //CalendarCssClass = CalendarCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_Calendar"]);
                //FirstDayOfWeekCssClass = FirstDayOfWeekCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_FirstDayOfWeek"]);
                //TimeZoneCssClass = TimeZoneCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_TimeZone"]);
                //DateFormatCssClass = DateFormatCssClass.AddHtmlClass(vc.WarningFieldClass["txt_DateFormat"]);
                //TimeFormatCssClass = TimeFormatCssClass.AddHtmlClass(vc.WarningFieldClass["txt_TimeFormat"]);
                //DayDifferenceCssClass = DayDifferenceCssClass.AddHtmlClass(vc.WarningFieldClass["txt_DayDifference"]);
                //TimeHoursDifferenceCssClass = TimeHoursDifferenceCssClass.AddHtmlClass(vc.WarningFieldClass["txt_TimeHoursDifference"]);
                //TimeMinutesDifferenceCssClass = TimeMinutesDifferenceCssClass.AddHtmlClass(vc.WarningFieldClass["txt_TimeMinutesDifference"]);
            }
        }

        public void ChangeDateAndTime()
        {
            // Get Current Client Object
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.ChangeUserDateAndTime ducudat = new DataUse.ChangeUserDateAndTime();

            ducudat.UserId = ccoc.UserId;
            ducudat.Calendar = CalendarOptionListSelectedValue;
            ducudat.FirstDayOfWeek = FirstDayOfWeekOptionListSelectedValue;
            ducudat.TimeZone = TimeZoneOptionListSelectedValue;
            ducudat.DateFormat = DateFormatValue;
            ducudat.TimeFormat = TimeFormatValue;
            ducudat.DayDifference = DayDifferenceValue;
            ducudat.TimeHoursDifference = TimeHoursDifferenceValue;
            ducudat.TimeMinutesDifference = TimeMinutesDifferenceValue;

            ducudat.Start();


            // Set Run Time Update
            ccoc.Calendar = ducudat.Calendar;
            ccoc.FirstDayOfWeek = ducudat.FirstDayOfWeek;
            ccoc.DateFormat = ducudat.DateFormat;
            ccoc.TimeFormat = ducudat.TimeFormat;
            ccoc.DayDifference = ducudat.DayDifference;
            ccoc.TimeHoursDifference = ducudat.TimeHoursDifference;
            ccoc.TimeMinutesDifference = ducudat.TimeMinutesDifference;
            ccoc.TimeZone = ducudat.TimeZone;


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("change_date_and_time", ccoc.UserId);
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/profile/action/change_date_and_time/action/SuccessMessage.aspx", true);
        }
    }
}