using CodeBehind;

namespace Elanat
{
    public partial class SiteLogoutController : CodeBehindController
    {
        public SiteLogoutModel model = new SiteLogoutModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}