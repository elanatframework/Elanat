using CodeBehind;

namespace Elanat
{
    public partial class SiteContactAddressController : CodeBehindController
    {
        public SiteContactAddressModel model = new SiteContactAddressModel();

        public void PageLoad(HttpContext context)
        {
            model.AddressValue = context.Request.Query["address_value"];
            model.AddressCssClass = context.Request.Query["address_css_class"];
            model.AddressAttribute = context.Request.Query["address_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}