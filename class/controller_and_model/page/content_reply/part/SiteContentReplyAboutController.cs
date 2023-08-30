using CodeBehind;

namespace Elanat
{
    public partial class SiteContentReplyAboutController : CodeBehindController
    {
        public SiteContentReplyAboutModel model = new SiteContentReplyAboutModel();

        public void PageLoad(HttpContext context)
        {
            model.AboutValue = context.Request.Query["about_value"];
            model.AboutCssClass = context.Request.Query["about_css_class"];
            model.AboutAttribute = context.Request.Query["about_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}