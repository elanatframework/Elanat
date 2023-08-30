using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpAboutController : CodeBehindController
    {
        public SiteSignUpAboutModel model = new SiteSignUpAboutModel();

        public void PageLoad(HttpContext context)
        {
            model.AboutValue = context.Request.Query["about_value"];
            model.AboutCssClass = context.Request.Query["about_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}