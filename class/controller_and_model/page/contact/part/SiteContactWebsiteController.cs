using CodeBehind;

namespace Elanat
{
    public partial class SiteContactWebsiteController : CodeBehindController
    {
        public SiteContactWebsiteModel model = new SiteContactWebsiteModel();

        public void PageLoad(HttpContext context)
        {
            model.WebsiteValue = context.Request.Query["website_value"];
            model.WebsiteCssClass = context.Request.Query["website_css_class"];
            model.WebsiteAttribute = context.Request.Query["website_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}