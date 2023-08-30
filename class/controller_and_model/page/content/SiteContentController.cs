using CodeBehind;

namespace Elanat
{
    public partial class SiteContentController : CodeBehindController
    {
        public SiteContentModel model = new SiteContentModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}