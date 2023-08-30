using CodeBehind;

namespace Elanat
{
    public partial class ActionCreateContentTypeValueController : CodeBehindController
    {
        public ActionCreateContentTypeValueModel model = new ActionCreateContentTypeValueModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["content_type"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            string ContentType = context.Request.Query["content_type"];


            model.SetValue(ContentType);

            View(model);
        }
    }
}