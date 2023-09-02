using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminBackupModel : CodeBehindModel
    {
        public string BackupLanguage { get; set; }
        public string MakeBackupLanguage { get; set; }
        public string UploadBackupLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string StartBackupLanguage { get; set; }
        public string BackupPathLanguage { get; set; }
        public string StartUploadLanguage { get; set; }
        public string UseBackupPathLanguage { get; set; }
        public string AllFileAndDirectoryLanguage { get; set; }
        public string DataBaseLanguage { get; set; }
        public string ActionDirectoryLanguage { get; set; }
        public string AdminDirectoryLanguage { get; set; }
        public string AddOnDirectoryLanguage { get; set; }
        public string AppDataDirectoryLanguage { get; set; }
        public string BinDirectoryLanguage { get; set; }
        public string ClientDirectoryLanguage { get; set; }
        public string IncludeDirectoryLanguage { get; set; }
        public string LanguageDirectoryLanguage { get; set; }
        public string MemberDirectoryLanguage { get; set; }
        public string PageDirectoryLanguage { get; set; }
        public string TemplateDirectoryLanguage { get; set; }
        public string UploadDirectoryLanguage { get; set; }
        public string RobotsTxtFileLanguage { get; set; }
        public bool UseBackupPathValue { get; set; } = false;
        public bool AllFileAndDirectoryValue { get; set; } = false;
        public bool DataBaseValue { get; set; } = false;
        public bool ActionDirectoryValue { get; set; } = false;
        public bool AdminDirectoryValue { get; set; } = false;
        public bool AddOnDirectoryValue { get; set; } = false;
        public bool AppDataDirectoryValue { get; set; } = false;
        public bool BinDirectoryValue { get; set; } = false;
        public bool ClientDirectoryValue { get; set; } = false;
        public bool IncludeDirectoryValue { get; set; } = false;
        public bool LanguageDirectoryValue { get; set; } = false;
        public bool MemberDirectoryValue { get; set; } = false;
        public bool PageDirectoryValue { get; set; } = false;
        public bool TemplateDirectoryValue { get; set; } = false;
        public bool UploadDirectoryValue { get; set; } = false;
        public bool RobotsTxtFileValue { get; set; } = false;
        public IFormFile BackupPathUploadValue { get; set; }
        public string BackupPathTextValue { get; set; }

        public string ContentValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/backup/");
            MakeBackupLanguage = aol.GetAddOnsLanguage("make_backup");
            StartBackupLanguage = aol.GetAddOnsLanguage("start_backup");
            StartUploadLanguage = aol.GetAddOnsLanguage("start_upload");
            UploadBackupLanguage = aol.GetAddOnsLanguage("upload_backup");
            ActionDirectoryLanguage = aol.GetAddOnsLanguage("action_directory");
            AddOnDirectoryLanguage = aol.GetAddOnsLanguage("add_on_directory");
            AdminDirectoryLanguage = aol.GetAddOnsLanguage("admin_directory");
            AllFileAndDirectoryLanguage = aol.GetAddOnsLanguage("all_file_and_directory");
            AppDataDirectoryLanguage = aol.GetAddOnsLanguage("app_data_directory");
            BinDirectoryLanguage = aol.GetAddOnsLanguage("bin_directory");
            ClientDirectoryLanguage = aol.GetAddOnsLanguage("client_directory");
            DataBaseLanguage = aol.GetAddOnsLanguage("database");
            IncludeDirectoryLanguage = aol.GetAddOnsLanguage("include_directory");
            LanguageDirectoryLanguage = aol.GetAddOnsLanguage("language_directory");
            MemberDirectoryLanguage = aol.GetAddOnsLanguage("member_directory");
            PageDirectoryLanguage = aol.GetAddOnsLanguage("page_directory");
            RobotsTxtFileLanguage = aol.GetAddOnsLanguage("robots_txt_file");
            TemplateDirectoryLanguage = aol.GetAddOnsLanguage("template_directory");
            UploadDirectoryLanguage = aol.GetAddOnsLanguage("upload_directory");
            UseBackupPathLanguage = aol.GetAddOnsLanguage("use_backup_path");
            BackupLanguage = aol.GetAddOnsLanguage("backup");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            DirectoryInfo DirInfo = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "backup/"));

            string[] BackupExtensions = new[] { ".bak", ".dat" };
            var Directories = DirInfo.GetFiles("*", SearchOption.AllDirectories).Where(f => BackupExtensions.Contains(f.Extension.ToLower())).ToArray();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string ClientLanguageVariantTemplate = doc.SelectSingleNode("template_root/table/backup/client_language_variant").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string HeaderTemplate = doc.SelectSingleNode("template_root/table/backup/header/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/backup/row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string TmpRowBoxTemplate = "";
            string SumRowBoxTemplate = "";

            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_restore;", Language.GetLanguage("are_you_sure_want_to_restore", StaticObject.GetCurrentAdminGlobalLanguage()));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_delete;", Language.GetLanguage("are_you_sure_want_to_delete", StaticObject.GetCurrentAdminGlobalLanguage()));

            HeaderTemplate = HeaderTemplate.Replace("$_asp_lang backup_physical_name;", aol.GetAddOnsLanguage("backup_physical_name"));
            HeaderTemplate = HeaderTemplate.Replace("$_asp_lang backup_size;", aol.GetAddOnsLanguage("backup_size"));

            foreach (FileInfo file in Directories)
            {
                string FileSize = file.Length.ToBitSizeTuning();

                TmpRowBoxTemplate = RowBoxTemplate;

                TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp backup_physical_name;", file.Name);
                TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp backup_size;", FileSize);
                TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp backup_extension;", Path.GetExtension(file.Name).Remove(0, 1));

                SumRowBoxTemplate += TmpRowBoxTemplate;
            }

            ContentValue = ClientLanguageVariantTemplate + HeaderTemplate + SumRowBoxTemplate + ContentValue;
        }

        public void StartBackup()
        {
            ExtraValue evc = new ExtraValue();

            string FileName = evc.GetBackupFileAndDirectoryValue() + ".zip.bak";
            FileName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "backup/"), FileName);

            ZipFileClass zip = new ZipFileClass();

            // If All File And Directory Checked
            bool UseFileAndDirectoryBackup = false;
            if (AllFileAndDirectoryValue)
            {
                DirectoryInfo[] dirget = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath)).GetDirectories();

                DirectoryInfo dirInfo = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath));
                FileInfo[] fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);

                List<string> FileDirectoryPath = new List<string>();


                foreach (DirectoryInfo dir in dirget)
                {
                    if (dir.Name == "backup")
                        continue;

                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + dir.Name));
                }

                foreach (FileInfo file in fileInfo)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + file.Name));


                zip.CreateZip(FileDirectoryPath.ToArray(), StaticObject.ServerMapPath(StaticObject.SitePath + "backup/" + FileName));
                UseFileAndDirectoryBackup = true;
            }
            else
            {
                List<string> FileDirectoryPath = new List<string>();

                if (ActionDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "action/"));

                if (AddOnDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/"));

                if (AdminDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.AdminPath));

                if (AppDataDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/"));

                if (BinDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "bin/"));

                if (ClientDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "client/"));

                if (IncludeDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "include/"));

                if (LanguageDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "language/"));

                if (MemberDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "member/"));

                if (PageDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "page/"));

                if (TemplateDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "template/"));

                if (UploadDirectoryValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/"));

                if (RobotsTxtFileValue)
                    FileDirectoryPath.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "robots.txt"));

                if (FileDirectoryPath.Count > 0)
                {
                    zip.CreateZip(FileDirectoryPath.ToArray(), StaticObject.ServerMapPath(StaticObject.SitePath + "backup/" + FileName));
                    UseFileAndDirectoryBackup = true;
                }
            }

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());


            if (UseFileAndDirectoryBackup)
            {
                // Add Reference
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("create_backup", "_");


                rf.AddLocalMessage(Language.GetAddOnsLanguage("backup_was_create", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/backup/"), "success");
                rf.AddPageLoad(StaticObject.AdminPath + "/backup/action/BackupNewRow.aspx?backup_physical_name=" + FileName, "div_TableBox");
            }


            // If DataBase Checked
            if (DataBaseValue)
            {
                string DataBaseFileName = evc.GetBackupDataBaseValue() + ".dat";
                DataBaseFileName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "backup/"), DataBaseFileName);

                DataBaseSocket db = new DataBaseSocket();
                db.SetProcedure("start_backup", new List<string>() { "@database_name", "@backup_directory_path", "@backup_physical_name" }, new List<string>() { ElanatConfig.GetNode("/security/database_name").Attributes["value"].Value, StaticObject.ServerMapPath(StaticObject.SitePath + "backup/"), DataBaseFileName });


                // Add Reference
                ReferenceClass rc2 = new ReferenceClass();
                rc2.StartEvent("create_database_backup", "_");


                rf.AddLocalMessage(Language.GetAddOnsLanguage("database_backup_was_create", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/backup/"), "success");
                rf.AddPageLoad(StaticObject.AdminPath + "/backup/action/BackupNewRow.aspx?backup_physical_name=" + DataBaseFileName, "div_TableBox");
            }

            rf.RedirectToResponseFormPage();
        }

        public void StartUpload()
        {
            string BackupFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Backup Path Else If Use File Upload
            if (UseBackupPathValue)
            {
                if (string.IsNullOrEmpty(BackupPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_backup_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/backup/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                BackupFilePhysicalName = Path.GetFileName(BackupPathTextValue);

                FileExtension = Path.GetExtension(BackupFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), "backup");

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(BackupPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + BackupFilePhysicalName));
            }
            else
            {
                if (BackupPathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_backup_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/backup/"), "problem");

                    return;
                }

                BackupFilePhysicalName = Path.GetFileName(BackupPathUploadValue.FileName);

                FileExtension = Path.GetExtension(BackupFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), "backup");

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                BackupPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + BackupFilePhysicalName));
            }

            // File Extension Check
            if (!(FileExtension == ".dat" || FileExtension == ".bak"))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_bat_or_dat_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/backup/"), "problem");

                return;
            }

            long FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + BackupFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_backup").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            string BackupFilePhysicalNewName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "backup/"), BackupFilePhysicalName);

            File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + BackupFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "backup/" + BackupFilePhysicalNewName));

            // Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            
            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("start_upload", BackupFilePhysicalNewName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("backup_was_create", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/backup/"), "success", false, StaticObject.AdminPath + "/backup/action/BackupNewRow.aspx?backup_physical_name=" + BackupFilePhysicalNewName, "div_TableBox");
        }
    }
}