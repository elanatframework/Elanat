using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentBirthdayController : CodeBehindController
    {
        public SiteCommentBirthdayModel model = new SiteCommentBirthdayModel();

        public void PageLoad(HttpContext context)
        {
            model.BirthdayYearOptionListSelectedValue = context.Request.Query["birthday_year_value"];
            model.BirthdayMountOptionListSelectedValue = context.Request.Query["birthday_mount_value"];
            model.BirthdayDayOptionListSelectedValue = context.Request.Query["birthday_day_value"];

            model.BirthdayYearCssClass = context.Request.Query["birthday_year_css_class"];
            model.BirthdayMountCssClass = context.Request.Query["birthday_mount_css_class"];
            model.BirthdayDayCssClass = context.Request.Query["birthday_day_css_class"];

            model.BirthdayYearAttribute = context.Request.Query["birthday_year_attribute"];
            model.BirthdayMountAttribute = context.Request.Query["birthday_mount_attribute"];
            model.BirthdayDayAttribute = context.Request.Query["birthday_day_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}