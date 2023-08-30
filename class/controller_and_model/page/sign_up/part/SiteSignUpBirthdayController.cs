using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpBirthdayController : CodeBehindController
    {
        public SiteSignUpBirthdayModel model = new SiteSignUpBirthdayModel();

        public void PageLoad(HttpContext context)
        {
            model.BirthdayYearOptionListSelectedValue = context.Request.Query["birthday_year_value"];
            model.BirthdayMountOptionListSelectedValue = context.Request.Query["birthday_mount_value"];
            model.BirthdayDayOptionListSelectedValue = context.Request.Query["birthday_day_value"];

            model.BirthdayYearCssClass = context.Request.Query["birthday_year_css_class"];
            model.BirthdayMountCssClass = context.Request.Query["birthday_mount_css_class"];
            model.BirthdayDayCssClass = context.Request.Query["birthday_day_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}