using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpPhoneNumberController : CodeBehindController
    {
        public SiteSignUpPhoneNumberModel model = new SiteSignUpPhoneNumberModel();

        public void PageLoad(HttpContext context)
        {
            model.PhoneNumberValue = context.Request.Query["phone_number_value"];
            model.PhoneNumberCssClass = context.Request.Query["phone_number_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}