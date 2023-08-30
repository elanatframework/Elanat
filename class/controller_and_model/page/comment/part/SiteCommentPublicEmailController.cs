using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentPublicEmailController : CodeBehindController
    {
        public SiteCommentPublicEmailModel model = new SiteCommentPublicEmailModel();

        public void PageLoad(HttpContext context)
        {
            model.PublicEmailValue = context.Request.Query["public_email_value"];
            model.PublicEmailCssClass = context.Request.Query["public_email_css_class"];
            model.PublicEmailAttribute = context.Request.Query["public_email_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}