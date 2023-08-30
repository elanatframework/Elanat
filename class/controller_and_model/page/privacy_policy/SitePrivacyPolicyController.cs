using CodeBehind;

namespace Elanat
{
    public partial class SitePrivacyPolicyController : CodeBehindController
    {
        public SitePrivacyPolicyModel model = new SitePrivacyPolicyModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}