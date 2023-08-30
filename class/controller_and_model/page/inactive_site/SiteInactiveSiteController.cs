using CodeBehind;

namespace Elanat
{
    public partial class SiteInactiveSiteController : CodeBehindController
    {
        public SiteInactiveSiteModel model = new SiteInactiveSiteModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}