using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminAdminStyleModel : CodeBehindModel
    {
        public string AdminStyleLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string AddAdminStyleLanguage { get; set; }
        public string AdminStylePathLanguage { get; set; }
        public string UseAdminStylePathLanguage { get; set; }
        public string AdminStyleActiveLanguage { get; set; }

        public bool UseAdminStylePathValue { get; set; } = false;
        public bool AdminStyleActiveValue { get; set; } = false;
        public IFormFile AdminStylePathUploadValue { get; set; }
        public string AdminStylePathTextValue { get; set; }
        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_style/");
            AdminStyleLanguage = aol.GetAddOnsLanguage("admin_style");
            AdminStylePathLanguage = aol.GetAddOnsLanguage("admin_style_path");
            AddAdminStyleLanguage = aol.GetAddOnsLanguage("add_admin_style");
            AdminStyleActiveLanguage = aol.GetAddOnsLanguage("admin_style_active");
            UseAdminStylePathLanguage = aol.GetAddOnsLanguage("use_admin_style_path");
            AddLanguage = aol.GetAddOnsLanguage("add");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Site Style Page List
            ActionGetAdminStyleListModel lm = new ActionGetAdminStyleListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void AddAdminStyle()
        {
            string AdminStyleFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Admin Style Path
            if (UseAdminStylePathValue)
            {
                if (string.IsNullOrEmpty(AdminStylePathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_admin_style_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_style/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                AdminStyleFilePhysicalName = Path.GetFileName(AdminStylePathTextValue);

                FileExtension = Path.GetExtension(AdminStyleFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_style/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AdminStyleFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(AdminStylePathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AdminStyleFilePhysicalName));
            }
            else
            {
                if (!AdminStylePathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_admin_style_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_style/"), "problem");

                    return;
                }

                AdminStyleFilePhysicalName = AdminStylePathUploadValue.FileName;

                FileExtension = Path.GetExtension(AdminStyleFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_style/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AdminStyleFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                AdminStylePathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AdminStyleFilePhysicalName));
            }

            // Check Admin Style File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AdminStyleFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_admin_style").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            // Extract Zip File
            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AdminStyleFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/admin_style")))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_style/"), "warning");

                return;
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/admin_style/catalog.xml"));

            XmlNode AdminStyleCatalog = CatalogDocument.SelectSingleNode("/admin_style_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_admin_style", "admin_style_name", AdminStyleCatalog["admin_style_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("admin_style_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_style/"), "problem");

                return;
            }


            string AdminStyleDirectoryPath = AdminStyleCatalog["admin_style_directory_path"].Attributes["value"].Value;
            AdminStyleDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/admin/"), AdminStyleDirectoryPath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (AdminStyleDirectoryPath != AdminStyleCatalog["admin_style_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");
            
            // Move All Admin Style File In "admin_style" Directory To Admin Style
            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/admin_style/"), StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/admin/" + AdminStyleDirectoryPath));

            // If "root" Directory Exist
            if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
            {
                if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                    if (StaticObject.AdminDirectoryPath != "admin")
                        Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));


                /// <Action> Create Uninstall List
                DirectoryInfo directory = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"));

                XmlDocument EmptyPaternDocument = new XmlDocument();
                EmptyPaternDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/uninstall/uninstall.xml"));

                XmlNode FilePathList = EmptyPaternDocument.SelectSingleNode("uninstall_root/file_path_list");

                foreach (FileInfo file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    XmlElement FilePathElement = EmptyPaternDocument.CreateElement("file_path");
                    FilePathElement.InnerText = file.FullName.Replace(StaticObject.ServerMapPath((StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/").Replace("/","\\")), @"\");
                    FilePathList.AppendChild(FilePathElement);
                }

                EmptyPaternDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/admin/" + AdminStyleDirectoryPath + "/uninstall.xml"));

                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
            }

            /// <Action> Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.AdminStyle duas = new DataUse.AdminStyle();

            duas.AdminStyleName = AdminStyleCatalog["admin_style_name"].Attributes["value"].Value;
            duas.AdminStylePhysicalName = AdminStyleCatalog["admin_style_physical_name"].Attributes["value"].Value;
            duas.AdminStyleDirectoryPath = AdminStyleDirectoryPath;
            duas.AdminStyleTemplate = AdminStyleCatalog["admin_style_template"].Attributes["value"].Value;
            duas.AdminStyleLoadTag = AdminStyleCatalog["admin_style_load_tag"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            duas.AdminStyleStaticHead = AdminStyleCatalog["admin_style_static_head"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            duas.AdminStyleActive = AdminStyleActiveValue.BooleanToZeroOne();

            // Add Admin Style
            duas.AddWithFillReturnDr();


            try { duas.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_admin_style", duas.AdminStyleName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("admin_style_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_style/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/admin_style/action/AdminStyleNewRow.aspx?admin_style_id=" + duas.AdminStyleId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}