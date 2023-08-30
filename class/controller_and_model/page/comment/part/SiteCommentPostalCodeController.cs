using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentPostalCodeController : CodeBehindController
    {
        public SiteCommentPostalCodeModel model = new SiteCommentPostalCodeModel();

        public void PageLoad(HttpContext context)
        {
            model.PostalCodeValue = context.Request.Query["postal_code_value"];
            model.PostalCodeCssClass = context.Request.Query["postal_code_css_class"];
            model.PostalCodeAttribute = context.Request.Query["postal_code_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}