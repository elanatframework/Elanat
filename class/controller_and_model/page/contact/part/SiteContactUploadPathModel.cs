using CodeBehind;

namespace Elanat
{
    public partial class SiteContactUploadPathModel : CodeBehindModel
    {
        public string UploadPathLanguage { get; set; }
        public string UseUploadPathLanguage { get; set; }

        public string UploadPathTextValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
            UploadPathLanguage = aol.GetAddOnsLanguage("upload_path");
            UseUploadPathLanguage = aol.GetAddOnsLanguage("use_upload_path");
        }
    }
}