using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpEmailController : CodeBehindController
    {
        public SiteSignUpEmailModel model = new SiteSignUpEmailModel();

        public void PageLoad(HttpContext context)
        {
            model.EmailValue = context.Request.Query["email_value"];
            model.EmailCssClass = context.Request.Query["email_css_class"];
            model.RepeatEmailValue = context.Request.Query["repeat_email_value"];
            model.RepeatEmailCssClass = context.Request.Query["repeat_email_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}