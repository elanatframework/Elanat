using CodeBehind;

namespace Elanat
{
    public partial class ActionGetContentTextController : CodeBehindController
    {
        public ActionGetContentTextModel model = new ActionGetContentTextModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["content_id"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["content_id"].ToString().IsNumber())
            {
                IgnoreViewAndModel = true;
                return;
            }

            string ContentId = context.Request.Query["content_id"];

            model.SetValue(ContentId);

            View(model);
        }
    }
}