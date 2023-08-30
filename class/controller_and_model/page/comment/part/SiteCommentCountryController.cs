using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentCountryController : CodeBehindController
    {
        public SiteCommentCountryModel model = new SiteCommentCountryModel();

        public void PageLoad(HttpContext context)
        {
            model.CountryValue = context.Request.Query["country_value"];
            model.CountryCssClass = context.Request.Query["country_css_class"];
            model.CountryAttribute = context.Request.Query["country_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}