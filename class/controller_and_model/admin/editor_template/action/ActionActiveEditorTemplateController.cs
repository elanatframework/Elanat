using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveEditorTemplateController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["editor_template_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["editor_template_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.EditorTemplate duet = new DataUse.EditorTemplate();
            duet.Active(context.Request.Query["editor_template_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_editor_template", context.Request.Query["editor_template_id"].ToString());
        }
    }
}