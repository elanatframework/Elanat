using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeDateAndTimeController : CodeBehindController
    {
        public ActionChangeDateAndTimeModel model = new ActionChangeDateAndTimeModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ChangeDateAndTime"]))
            {
                btn_ChangeDateAndTime_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_ChangeDateAndTime_Click(HttpContext context)
        {
            model.CalendarOptionListSelectedValue = context.Request.Form["ddlst_Calendar"];
            model.FirstDayOfWeekOptionListSelectedValue = context.Request.Form["ddlst_FirstDayOfWeek"];
            model.TimeZoneOptionListSelectedValue = context.Request.Form["ddlst_TimeZone"];
            model.DateFormatValue = context.Request.Form["txt_DateFormat"];
            model.TimeFormatValue = context.Request.Form["txt_TimeFormat"];
            model.DayDifferenceValue = context.Request.Form["txt_DayDifference"];
            model.TimeHoursDifferenceValue = context.Request.Form["txt_TimeHoursDifference"];
            model.TimeMinutesDifferenceValue = context.Request.Form["txt_TimeMinutesDifference"];


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.ChangeDateAndTime();

            model.SuccessView();

            View(model);
        }
    }
}