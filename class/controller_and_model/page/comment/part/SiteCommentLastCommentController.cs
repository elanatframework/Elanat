using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentLastCommentController : CodeBehindController
    {
        public SiteCommentLastCommentModel model = new SiteCommentLastCommentModel();

        public void PageLoad(HttpContext context)
        {
            string ContentId = int.Parse(context.Request.Query["content_id"]).ToString();

            model.SetValue(ContentId);

            View(model);
        }
    }
}