using CodeBehind;

namespace Elanat
{
    public partial class SiteContactCityController : CodeBehindController
    {
        public SiteContactCityModel model = new SiteContactCityModel();

        public void PageLoad(HttpContext context)
        {
            model.CityValue = context.Request.Query["city_value"];
            model.CityCssClass = context.Request.Query["city_css_class"];
            model.CityAttribute = context.Request.Query["city_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}