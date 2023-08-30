using CodeBehind;

namespace Elanat
{
    public partial class SiteRssController : CodeBehindController
    {
        public SiteRssModel model = new SiteRssModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}