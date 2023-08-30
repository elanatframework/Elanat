using CodeBehind;

namespace Elanat
{
    public partial class SiteContentReplyTypeController : CodeBehindController
    {
        public SiteContentReplyTypeModel model = new SiteContentReplyTypeModel();

        public void PageLoad(HttpContext context)
        {
            model.TypeOptionListSelectedValue = context.Request.Query["type_value"];
            model.TypeCssClass = context.Request.Query["type_css_class"];
            model.ContentReplyTypeValue = context.Request.Query["content_reply_type"];

            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}