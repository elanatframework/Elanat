using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentCityController : CodeBehindController
    {
        public SiteCommentCityModel model = new SiteCommentCityModel();

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