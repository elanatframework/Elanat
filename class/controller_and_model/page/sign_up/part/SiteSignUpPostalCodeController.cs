using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpPostalCodeController : CodeBehindController
    {
        public SiteSignUpPostalCodeModel model = new SiteSignUpPostalCodeModel();

        public void PageLoad(HttpContext context)
        {
            model.PostalCodeValue = context.Request.Query["postal_code_value"];
            model.PostalCodeCssClass = context.Request.Query["postal_code_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}