using CodeBehind;

namespace Elanat
{
    public partial class SiteContentReplyZipCodeController : CodeBehindController
    {
        public SiteContentReplyZipCodeModel model = new SiteContentReplyZipCodeModel();

        public void PageLoad(HttpContext context)
        {
            model.ZipCodeValue = context.Request.Query["zip_code_value"];
            model.ZipCodeCssClass = context.Request.Query["zip_code_css_class"];
            model.ZipCodeAttribute = context.Request.Query["zip_code_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}