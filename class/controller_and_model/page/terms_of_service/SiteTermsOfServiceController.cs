using CodeBehind;

namespace Elanat
{
    public partial class SiteTermsOfServiceController : CodeBehindController
    {
        public SiteTermsOfServiceModel model = new SiteTermsOfServiceModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}