using CodeBehind;

namespace Elanat
{
    public partial class AdminFileManagerModel : CodeBehindModel
    {
        public string FileManagerLanguage { get; set; }
        public string PathLanguage { get; set; }
        public string UseFilePathLanguage { get; set; }
        public string FilePathLanguage { get; set; }
        public string StartUploadLanguage { get; set; }
        public string FileNameLanguage { get; set; }
        public string FileTextLanguage { get; set; }
        public string CreateFileLanguage { get; set; }
        public string DirectoryNameLanguage { get; set; }
        public string CreateDirectoryLanguage { get; set; }
        public string UploadFileLanguage { get; set; }
        public string NewDirectoryLanguage { get; set; }
        public string NewFileLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public string PathValue { get; set; }
        public string PathHiddenValue { get; set; }

        public bool UseFilePathValue { get; set; } = false;
        public IFormFile FilePathUploadValue { get; set; }
        public string FilePathTextValue { get; set; }

        public string FileNameValue { get; set; }
        public string FileTextValue { get; set; }
        public string DirectoryNameValue { get; set; }

        public string FileNameAttribute { get; set; }
        public string FileTextAttribute { get; set; }
        public string DirectoryNameAttribute { get; set; }

        public string FileNameCssClass { get; set; }
        public string FileTextCssClass { get; set; }
        public string DirectoryNameCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> CreateFileEvaluateErrorList;
        public List<string> CreateDirectoryEvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindCreateFileEvaluateError = false;
        public bool FindCreateDirectoryEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/");
            FileManagerLanguage = aol.GetAddOnsLanguage("file_manager");
            PathLanguage = aol.GetAddOnsLanguage("path");
            UseFilePathLanguage = aol.GetAddOnsLanguage("use_file_path");
            FilePathLanguage = aol.GetAddOnsLanguage("file_path");
            StartUploadLanguage = aol.GetAddOnsLanguage("start_upload");
            FileNameLanguage = aol.GetAddOnsLanguage("file_name");
            FileTextLanguage = aol.GetAddOnsLanguage("file_text");
            CreateFileLanguage = aol.GetAddOnsLanguage("create_file");
            DirectoryNameLanguage = aol.GetAddOnsLanguage("directory_name");
            CreateDirectoryLanguage = aol.GetAddOnsLanguage("create_directory");
            UploadFileLanguage = aol.GetAddOnsLanguage("upload_file");
            NewDirectoryLanguage = aol.GetAddOnsLanguage("new_directory");
            NewFileLanguage = aol.GetAddOnsLanguage("new_file");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            FileAndDirectory fad = new FileAndDirectory();

            string RootPath = "";
            if (string.IsNullOrEmpty(PathHiddenValue))
                RootPath = (string.IsNullOrEmpty(QueryString.GetValue("directory"))) ? fad.GetRootPath(StaticObject.ServerMapPath("/")) : fad.GetRootPath(StaticObject.ServerMapPath("/" + QueryString.GetValue("directory")));
            else
                RootPath = PathHiddenValue;

            PathValue = RootPath;
            PathHiddenValue = RootPath;

            List<string> SubDirectoryList = StringClass.ExtractFromString(RootPath, "/");

            string DirectoryPath = "";
            PathValue = "<a href='#' onclick='el_OpenFileDirectory(&apos;directory&apos;,&apos;/&apos;,&apos;/&apos;)'>root</a>";
            foreach (string SubDirectory in SubDirectoryList)
            {
                if (string.IsNullOrEmpty(SubDirectory))
                    continue;

                DirectoryPath += "/" + SubDirectory;
                PathValue += "<div class='el_slash'>/</div>" + "<a href='#' onclick='el_OpenFileDirectory(&apos;directory&apos;,&apos;" + SubDirectory + "&apos;,&apos;" + DirectoryPath + "&apos;)'>" + SubDirectory + "</a>";
            }


            // Set File Manager Page List
            ActionGetFileDirectoryListModel lm = new ActionGetFileDirectoryListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_FileName", "");
            InputRequest.Add("txt_FileText", "");
            InputRequest.Add("txt_DirectoryName", "");

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/file_manager/", "create_file");

            FileNameAttribute += vc.ImportantInputAttribute.GetValue("txt_FileName");
            FileTextAttribute += vc.ImportantInputAttribute.GetValue("txt_FileText");

            FileNameCssClass = FileNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FileName"));
            FileTextCssClass = FileTextCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FileText"));


            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/file_manager/", "create_directory");

            DirectoryNameAttribute += vc.ImportantInputAttribute.GetValue("txt_DirectoryName");

            DirectoryNameCssClass = DirectoryNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_DirectoryName"));
        }

        public void CreateFileEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "create_file", StaticObject.AdminPath + "/file_manager/");

            CreateFileEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindCreateFileEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void CreateDirectoryEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "create_directory", StaticObject.AdminPath + "/file_manager/");

            CreateDirectoryEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindCreateDirectoryEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void CreateFile()
        {
            string Path = StaticObject.ServerMapPath(StaticObject.SitePath + PathHiddenValue);
            string FileName = FileNameValue;
            string[] Lines = FileTextValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            File.WriteAllLines(Path + "/" + FileName, Lines);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("create_file", Path + "/" + FileName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("file_was_create", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/"), "success", false, StaticObject.AdminPath + "/file_manager/action/FileDirectoryNewRow.aspx?file_directory_path=" + Path + "/" + FileName, "div_TableBox");
        }

        public void CreateDirectory()
        {
            string Path = StaticObject.ServerMapPath(StaticObject.SitePath + PathHiddenValue);
            string DirectoryName = DirectoryNameValue;

            DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(Path, DirectoryName);

            Directory.CreateDirectory(Path + "/" + DirectoryName);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("create_directory", Path + "/" + DirectoryName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("directory_was_create", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/"), "success", false, StaticObject.AdminPath + "/file_manager/action/FileDirectoryNewRow.aspx?file_directory_path=" + Path + "/" + DirectoryName, "div_TableBox");
        }

        public void StartUpload()
        {
            string Path = StaticObject.ServerMapPath(StaticObject.SitePath + PathHiddenValue);
            string FilePhysicalName = "";

            // If Use File Path
            if (UseFilePathValue)
            {
                if (string.IsNullOrEmpty(FilePathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_file_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                FilePhysicalName = System.IO.Path.GetFileName(FilePathTextValue);
                FilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(Path, FilePhysicalName);

                webClient.DownloadFile(FilePathTextValue, Path + "/" + FilePhysicalName);
            }
            else
            {
                if (!FilePathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_file_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/"), "problem");

                    return;
                }

                FilePhysicalName = System.IO.Path.GetFileName(FilePathUploadValue.FileName);
                FilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(Path, FilePhysicalName);

                FilePathUploadValue.SaveAs(Path + "/" + FilePhysicalName);
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("upload_file", Path + "/" + FilePhysicalName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("file_was_upload", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/"), "success", false, StaticObject.AdminPath + "/file_manager/action/FileDirectoryNewRow.aspx?file_directory_path=" + Path + "/" + FilePhysicalName, "div_TableBox");
        }
    }
}