using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentUploadPathModel : CodeBehindModel
    {
        public string UploadPathLanguage { get; set; }
        public string UseUploadPathLanguage { get; set; }

        public string UploadPathTextValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
            UploadPathLanguage = aol.GetAddOnsLanguage("upload_path");
            UseUploadPathLanguage = aol.GetAddOnsLanguage("use_upload_path");
        }
    }
}