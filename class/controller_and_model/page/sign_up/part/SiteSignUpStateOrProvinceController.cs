using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpStateOrProvinceController : CodeBehindController
    {
        public SiteSignUpStateOrProvinceModel model = new SiteSignUpStateOrProvinceModel();

        public void PageLoad(HttpContext context)
        {
            model.StateOrProvinceValue = context.Request.Query["state_or_province_value"];
            model.StateOrProvinceCssClass = context.Request.Query["state_or_province_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}