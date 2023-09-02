using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperSiteLogoModel : CodeBehindModel
    {
        public string SiteLogoLanguage { get; set; }
        public string UploadLogoLanguage { get; set; }
        public string LogoPathLanguage { get; set; }
        public string UseLogoPathLanguage { get; set; }
        public string SiteLanguage { get; set; }
        public string StartUploadLanguage { get; set; }
        
        public bool UseLogoPathValue { get; set; } = false;
        public string LogoPathTextValue { get; set; }
        public IFormFile LogoPathUploadValue { get; set; }
        public string SiteOptionListValue { get; set; }
        public string SiteOptionListSelectedValue { get; set; }
        public string SiteIconValue { get; set; }


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/site_logo/");
            SiteLogoLanguage = aol.GetAddOnsLanguage("site_logo");
            UploadLogoLanguage = aol.GetAddOnsLanguage("upload_logo");
            LogoPathLanguage = aol.GetAddOnsLanguage("logo_path");
            UseLogoPathLanguage = aol.GetAddOnsLanguage("use_logo_path");
            SiteLanguage = aol.GetAddOnsLanguage("site");
            StartUploadLanguage = aol.GetAddOnsLanguage("start_upload");


            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Set Current Value
            ListClass.Site lcs = new ListClass.Site();

            // Set Site Item
            lcs.FillSiteNameListItem();
            SiteOptionListValue += lcs.SiteNameListItem.HtmlInputToOptionTag(ccoc.SiteSiteGlobalName);


            SiteIconValue = ccoc.SiteSiteGlobalName;
        }

        public void StartUpload()
        {
            string LogoFilePhysicalName = "";
            string LogoExtension = "";
            string DirectoryName = "logo";

            // If Use Logo Path
            if (UseLogoPathValue)
            {
                if (string.IsNullOrEmpty(LogoPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_logo_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/site_logo/"), "problem");
                    return;
                }

                HttpClient webClient = new HttpClient();

                LogoFilePhysicalName = Path.GetFileName(LogoPathTextValue);

                LogoExtension = Path.GetExtension(LogoFilePhysicalName);

                if (!FileAndDirectory.IsImageExtension(LogoExtension))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/site_logo/"), "problem");
                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(LogoFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(LogoPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + LogoFilePhysicalName));
            }
            else
            {
                if (!LogoPathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_logo_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/site_logo/"), "problem");
                    return;
                }

                LogoFilePhysicalName = LogoPathUploadValue.FileName;

                LogoExtension = Path.GetExtension(LogoFilePhysicalName);

                if (!FileAndDirectory.IsImageExtension(LogoExtension))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/site_logo/"), "problem");
                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(LogoFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                LogoPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + LogoFilePhysicalName));
            }

            // Convert Image To Png Format
            FileAndDirectory fad = new FileAndDirectory();
            fad.ConvertImageToPngFormat(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + LogoFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + LogoFilePhysicalName + ".tmp"));

            string LogoPhysicalName = SiteOptionListSelectedValue;

            if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/site_logo/" + LogoPhysicalName + ".png")))
                File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/site_logo/" + LogoPhysicalName + ".png"));

            File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + LogoFilePhysicalName + ".tmp"), StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/site_logo/" + LogoPhysicalName + ".png"));

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            SiteIconValue = LogoPhysicalName;


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("upload_logo", LogoFilePhysicalName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("logo_was_upload", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/site_logo/"), "success", false, "", "", "el_RefreshSiteLogo()");
        }
    }
}