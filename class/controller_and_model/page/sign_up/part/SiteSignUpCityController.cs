using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpCityController : CodeBehindController
    {
        public SiteSignUpCityModel model = new SiteSignUpCityModel();

        public void PageLoad(HttpContext context)
        {
            model.CityValue = context.Request.Query["city_value"];
            model.CityCssClass = context.Request.Query["city_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}