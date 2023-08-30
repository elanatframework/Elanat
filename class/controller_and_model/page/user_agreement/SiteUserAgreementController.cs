using CodeBehind;

namespace Elanat
{
    public partial class SiteUserAgreementController : CodeBehindController
    {
        public SiteUserAgreementModel model = new SiteUserAgreementModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}