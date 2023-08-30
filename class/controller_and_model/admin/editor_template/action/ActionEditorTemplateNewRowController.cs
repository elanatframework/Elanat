using CodeBehind;

namespace Elanat
{
    public partial class ActionEditorTemplateNewRowController : CodeBehindController
    {
        public ActionEditorTemplateNewRowModel model = new ActionEditorTemplateNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["editor_template_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["editor_template_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.EditorTemplateIdValue = context.Request.Query["editor_template_id"].ToString();


            model.SetValue();

            View(model);
        }
    }
}