using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentTypeController : CodeBehindController
    {
        public SiteCommentTypeModel model = new SiteCommentTypeModel();

        public void PageLoad(HttpContext context)
        {
            model.TypeOptionListSelectedValue = context.Request.Query["type_value"];
            model.TypeCssClass = context.Request.Query["type_css_class"];
            model.CommentTypeValue = context.Request.Query["comment_type"];

            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}