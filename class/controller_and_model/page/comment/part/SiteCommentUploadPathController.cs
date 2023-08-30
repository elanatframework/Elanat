using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentUploadPathController : CodeBehindController
    {
        public SiteCommentUploadPathModel model = new SiteCommentUploadPathModel();

        public void PageLoad(HttpContext context)
        {
            model.UploadPathTextValue = context.Request.Query["upload_path_text_value"];


            model.SetValue();

            View(model);
        }
    }
}