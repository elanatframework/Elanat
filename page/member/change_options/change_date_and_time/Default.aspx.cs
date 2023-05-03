using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class MemberChangeDateAndTime : System.Web.UI.Page
    {
        public MemberChangeDateAndTimeModel model = new MemberChangeDateAndTimeModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_ChangeDateAndTime"]))
                btn_ChangeDateAndTime_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_ChangeDateAndTime_Click(object sender, EventArgs e)
        {
            model.IsFirstStart = false;

            model.CalendarOptionListSelectedValue = Request.Form["ddlst_Calendar"];
            model.FirstDayOfWeekOptionListSelectedValue = Request.Form["ddlst_FirstDayOfWeek"];
            model.TimeZoneOptionListSelectedValue = Request.Form["ddlst_TimeZone"];
            model.DateFormatValue = Request.Form["txt_DateFormat"];
            model.TimeFormatValue = Request.Form["txt_TimeFormat"];
            model.DayDifferenceValue = Request.Form["txt_DayDifference"];
            model.TimeHoursDifferenceValue= Request.Form["txt_TimeHoursDifference"];
            model.TimeMinutesDifferenceValue= Request.Form["txt_TimeMinutesDifference"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.ChangeDateAndTime();

            model.SuccessView();
        }
    }
}