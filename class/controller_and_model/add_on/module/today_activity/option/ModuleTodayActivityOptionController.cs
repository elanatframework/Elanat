using CodeBehind;

namespace Elanat
{
    public partial class ModuleTodayActivityOptionController : CodeBehindController
    {
        public ModuleTodayActivityOptionModel model = new ModuleTodayActivityOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveTodayActivityOption"]))
            {
                btn_SaveTodayActivityOption_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveTodayActivityOption_Click(HttpContext context)
        {
            model.ActiveFootPrintValue = context.Request.Form["cbx_ActiveFootPrint"] == "on";
            model.ActiveVisitValue = context.Request.Form["cbx_ActiveVisit"] == "on";
            model.ActiveNewUserValue = context.Request.Form["cbx_ActiveNewUser"] == "on";
            model.ActiveContactValue = context.Request.Form["cbx_ActiveContact"] == "on";
            model.ActiveCommentValue = context.Request.Form["cbx_ActiveComment"] == "on";
            model.ActiveContentValue = context.Request.Form["cbx_ActiveContent"] == "on";
            model.ActiveActiveContentValue = context.Request.Form["cbx_ActiveActiveContent"] == "on";
            model.ActiveInactiveContentValue = context.Request.Form["cbx_ActiveInactiveContent"] == "on";

            model.SaveTodayActivityOption();

            View(model);
        }
    }
}