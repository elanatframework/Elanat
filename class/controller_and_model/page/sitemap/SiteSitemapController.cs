using CodeBehind;

namespace Elanat
{
    public partial class SiteSitemapController : CodeBehindController
    {
        public SiteSitemapModel model = new SiteSitemapModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}