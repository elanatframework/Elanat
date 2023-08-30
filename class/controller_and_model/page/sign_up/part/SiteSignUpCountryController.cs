using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpCountryController : CodeBehindController
    {
        public SiteSignUpCountryModel model = new SiteSignUpCountryModel();

        public void PageLoad(HttpContext context)
        {
            model.CountryValue = context.Request.Query["country_value"];
            model.CountryCssClass = context.Request.Query["country_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}