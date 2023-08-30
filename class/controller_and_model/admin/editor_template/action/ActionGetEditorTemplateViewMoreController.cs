using CodeBehind;

namespace Elanat
{
    public partial class ActionGetEditorTemplateViewMoreController : CodeBehindController
    {
        public ActionGetEditorTemplateViewMoreModel model = new ActionGetEditorTemplateViewMoreModel();

        public void PageLoad(HttpContext context)
        {		
            if (string.IsNullOrEmpty(context.Request.Query["editor_template_id"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["editor_template_id"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetViewMore(context.Request.Query["editor_template_id"]));

            View(model);
        }
    }
}