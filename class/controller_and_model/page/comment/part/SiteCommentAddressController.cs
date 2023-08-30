using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentAddressController : CodeBehindController
    {
        public SiteCommentAddressModel model = new SiteCommentAddressModel();

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