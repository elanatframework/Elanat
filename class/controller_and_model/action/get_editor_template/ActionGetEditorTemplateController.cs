using CodeBehind;

namespace Elanat
{
    public partial class ActionGetEditorTemplateController : CodeBehindController
    {
        public ActionGetEditorTemplateModel model = new ActionGetEditorTemplateModel();

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

            string EditorTemplateId = context.Request.Query["editor_template_id"].ToString();


            // Editor Template Access Check
            DataUse.EditorTemplate duet = new DataUse.EditorTemplate();

            if (!duet.GetEditorTemplateAccessShowCheck(EditorTemplateId))
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/401");

                IgnoreViewAndModel = true;

                return;
            }

            model.SetValue(EditorTemplateId, context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}