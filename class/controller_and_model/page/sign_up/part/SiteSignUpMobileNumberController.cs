using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpMobileNumberController : CodeBehindController
    {
        public SiteSignUpMobileNumberModel model = new SiteSignUpMobileNumberModel();

        public void PageLoad(HttpContext context)
        {
            model.MobileNumberValue = context.Request.Query["mobile_number_value"];
            model.MobileNumberCssClass = context.Request.Query["mobile_number_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}