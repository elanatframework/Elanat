using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperUploadFileModel : CodeBehindModel
    {
        public string UploadFileLanguage { get; set; }
        public string FilePathLanguage { get; set; }
        public string UseFilePathLanguage { get; set; }
        public string StartUploadLanguage { get; set; }
        
        public bool UseFilePathValue { get; set; } = false;
        public IFormFile FilePathUploadValue { get; set; }
        public string FilePathTextValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/upload_file/");
            UploadFileLanguage = aol.GetAddOnsLanguage("upload_file");
            FilePathLanguage = aol.GetAddOnsLanguage("file_path");
            UseFilePathLanguage = aol.GetAddOnsLanguage("use_file_path");
            StartUploadLanguage = aol.GetAddOnsLanguage("start_upload");
        }

        public void StartUpload()
        {
            if (!StaticObject.RoleUploadFileCheck())
            {
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_to_upload_file", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/upload_file/"), "problem");
                return;
            }


            // Set Extra Value
            ExtraValue ev = new ExtraValue();

            string FileDirectoryPath = ev.GetUploadDirectoryValue();

            string TmpFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "upload";

            // If Use File Path
            if (UseFilePathValue)
            {
                if (string.IsNullOrEmpty(FilePathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_file_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/upload_file/"), "problem");
                    return;
                }

                HttpClient webClient = new HttpClient();

                TmpFilePhysicalName = Path.GetFileName(FilePathTextValue);

                FileExtension = Path.GetExtension(TmpFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(TmpFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(FilePathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + TmpFilePhysicalName));
            }
            else
            {
                if (!FilePathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_file_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/upload_file/"), "problem");
                    return;
                }

                TmpFilePhysicalName = FilePathUploadValue.FileName;

                FileExtension = Path.GetExtension(TmpFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(TmpFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                FilePathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + TmpFilePhysicalName));
            }

            ev.FilePhysicalName = TmpFilePhysicalName;
            string FilePhysicalName = ev.GetUploadFileValue();

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/" + FileDirectoryPath)))
                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/" + FileDirectoryPath));

            FilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/" + FileDirectoryPath), FilePhysicalName);


            // Move Upload File In "upload" Directory To Upload
            File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + TmpFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "upload/" + FileDirectoryPath + "/" + FilePhysicalName));

            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Create Thumbnail Image
            if (FileAndDirectory.IsImageExtension(FileExtension))
                if (ElanatConfig.GetNode("file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value == "true")
                {
                    if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/" + FileDirectoryPath + "/thumb/")))
                        Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/" + FileDirectoryPath + "/thumb/"));

                    FileAndDirectory.CreateThumbnailImage(StaticObject.SitePath + "upload/" + FileDirectoryPath + "/" + FilePhysicalName, StaticObject.SitePath + "upload/" + FileDirectoryPath + "/thumb/" + FilePhysicalName);
                }


            // Set File Upload Path To Upload File List
            FileAndDirectory fad = new FileAndDirectory();
            fad.SetFileUploadPathToUploadFileList(FileDirectoryPath, FilePhysicalName);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("upload_file", TmpFilePhysicalName);


            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
            rf.AddLocalMessage(Language.GetAddOnsLanguage("file_was_upload", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/upload_file/"), "success");
            rf.AddLocalMessage("/upload/" + FileDirectoryPath + "/" + TmpFilePhysicalName, "help");
            rf.RedirectToResponseFormPage();
        }
    }
}