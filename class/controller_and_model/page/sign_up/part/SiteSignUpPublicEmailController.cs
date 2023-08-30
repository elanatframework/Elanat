using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpPublicEmailController : CodeBehindController
    {
        public SiteSignUpPublicEmailModel model = new SiteSignUpPublicEmailModel();

        public void PageLoad(HttpContext context)
        {
            model.PublicEmailValue = context.Request.Query["public_email_value"];
            model.PublicEmailCssClass = context.Request.Query["public_email_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}