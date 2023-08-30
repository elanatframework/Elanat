using CodeBehind;

namespace Elanat
{
    public partial class SiteAboutController : CodeBehindController
    {
        public SiteAboutModel model = new SiteAboutModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context);

            View(model);
        }
    }
}