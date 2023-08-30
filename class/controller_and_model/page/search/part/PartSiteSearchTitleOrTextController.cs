using CodeBehind;

namespace Elanat
{
    public partial class PartSiteSearchTitleOrTextController : CodeBehindController
    {
        public PartSiteSearchTitleOrTextModel model = new PartSiteSearchTitleOrTextModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}