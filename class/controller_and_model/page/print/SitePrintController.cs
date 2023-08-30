using CodeBehind;

namespace Elanat
{
    public partial class SitePrintController : CodeBehindController
    {
        public SitePrintModel model = new SitePrintModel();

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

            string ContentId = context.Request.Query["content_id"].ToString();


            model.SetValue(ContentId);

            View(model);
        }
    }
}