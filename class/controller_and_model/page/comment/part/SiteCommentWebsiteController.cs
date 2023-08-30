using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentWebsiteController : CodeBehindController
    {
        public SiteCommentWebsiteModel model = new SiteCommentWebsiteModel();

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