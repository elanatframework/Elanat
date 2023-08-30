using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpAddressController : CodeBehindController
    {
        public SiteSignUpAddressModel model = new SiteSignUpAddressModel();

        public void PageLoad(HttpContext context)
        {
            model.AddressValue = context.Request.Query["address_value"];
            model.AddressCssClass= context.Request.Query["address_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}