using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpZipCodeController : CodeBehindController
    {
        public SiteSignUpZipCodeModel model = new SiteSignUpZipCodeModel();

        public void PageLoad(HttpContext context)
        {
            model.ZipCodeValue = context.Request.Query["zip_code_value"];
            model.ZipCodeCssClass = context.Request.Query["zip_code_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}