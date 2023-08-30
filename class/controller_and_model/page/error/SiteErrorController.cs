using CodeBehind;

namespace Elanat
{
    public partial class SiteErrorController : CodeBehindController
    {
        public SiteErrorModel model = new SiteErrorModel();

        public void PageLoad(HttpContext context)
        {
            string ErrorValue = "";

            if (!string.IsNullOrEmpty(context.Request.Query["value"]))
                ErrorValue = context.Request.Query["value"];

            model.SetValue(ErrorValue);

            View(model);
        }
    }
}