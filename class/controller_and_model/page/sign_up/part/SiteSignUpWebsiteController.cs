using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpWebsiteController : CodeBehindController
    {
        public SiteSignUpWebsiteModel model = new SiteSignUpWebsiteModel();

        public void PageLoad(HttpContext context)
        {
            model.WebsiteValue = context.Request.Query["website_value"];
            model.WebsiteCssClass = context.Request.Query["website_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}