using CodeBehind;

namespace Elanat
{
    public partial class PartSiteSearchDateController : CodeBehindController
    {
        public PartSiteSearchDateModel model = new PartSiteSearchDateModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}