using CodeBehind;

namespace Elanat
{
    public partial class SiteContactUploadPathController : CodeBehindController
    {
        public SiteContactUploadPathModel model = new SiteContactUploadPathModel();

        public void PageLoad(HttpContext context)
        {
            model.UploadPathTextValue = context.Request.Query["upload_path_text_value"];


            model.SetValue();

            View(model);
        }
    }
}