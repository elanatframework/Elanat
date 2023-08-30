using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentZipCodeController : CodeBehindController
    {
        public SiteCommentZipCodeModel model = new SiteCommentZipCodeModel();

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