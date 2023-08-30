using CodeBehind;

namespace Elanat
{
    public partial class SiteMainController : CodeBehindController
    {
        public SiteMainModel model = new SiteMainModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}