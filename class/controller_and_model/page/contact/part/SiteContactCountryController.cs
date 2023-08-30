using CodeBehind;

namespace Elanat
{
    public partial class SiteContactCountryController : CodeBehindController
    {
        public SiteContactCountryModel model = new SiteContactCountryModel();

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