using CodeBehind;

namespace Elanat
{
    public partial class PartSiteSearchCategoryController : CodeBehindController
    {
        public PartSiteSearchCategoryModel model = new PartSiteSearchCategoryModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}