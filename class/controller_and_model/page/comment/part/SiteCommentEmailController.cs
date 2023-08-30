using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentEmailController : CodeBehindController
    {
        public SiteCommentEmailModel model = new SiteCommentEmailModel();

        public void PageLoad(HttpContext context)
        {
            model.EmailValue = context.Request.Query["email_value"];
            model.EmailCssClass = context.Request.Query["email_css_class"];
            model.EmailAttribute = context.Request.Query["email_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}