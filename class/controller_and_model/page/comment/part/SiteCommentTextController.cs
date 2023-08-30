using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentTextController : CodeBehindController
    {
        public SiteCommentTextModel model = new SiteCommentTextModel();

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