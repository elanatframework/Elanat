using CodeBehind;

namespace Elanat
{
    public partial class SiteContentReplyMobileNumberController : CodeBehindController
    {
        public SiteContentReplyMobileNumberModel model = new SiteContentReplyMobileNumberModel();

        public void PageLoad(HttpContext context)
        {
            model.MobileNumberValue = context.Request.Query["mobile_number_value"];
            model.MobileNumberCssClass = context.Request.Query["mobile_number_css_class"];
            model.MobileNumberAttribute = context.Request.Query["mobile_number_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}