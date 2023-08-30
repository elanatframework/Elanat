using CodeBehind;

namespace Elanat
{
    public partial class SiteContentReplyTextController : CodeBehindController
    {
        public SiteContentReplyTextModel model = new SiteContentReplyTextModel();

        public void PageLoad(HttpContext context)
        {
            model.TextValue = context.Request.Query["text_value"];
            model.TextCssClass = context.Request.Query["text_css_class"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}