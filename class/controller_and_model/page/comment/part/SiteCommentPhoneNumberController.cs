using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentPhoneNumberController : CodeBehindController
    {
        public SiteCommentPhoneNumberModel model = new SiteCommentPhoneNumberModel();

        public void PageLoad(HttpContext context)
        {
            model.PhoneNumberValue = context.Request.Query["phone_number_value"];
            model.PhoneNumberCssClass = context.Request.Query["phone_number_css_class"];
            model.PhoneNumberAttribute = context.Request.Query["phone_number_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}