using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminAdminTemplateModel : CodeBehindModel
    {
        public string AdminTemplateLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string AddAdminTemplateLanguage { get; set; }
        public string AdminTemplatePathLanguage { get; set; }
        public string UseAdminTemplatePathLanguage { get; set; }
        public string AdminTemplateActiveLanguage { get; set; }

        public bool UseAdminTemplatePathValue { get; set; } = false;
        public bool AdminTemplateActiveValue { get; set; } = false;
        public IFormFile AdminTemplatePathUploadValue { get; set; }
        public string AdminTemplatePathTextValue { get; set; }
        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/");
            AdminTemplateLanguage = aol.GetAddOnsLanguage("admin_template");
            AdminTemplatePathLanguage = aol.GetAddOnsLanguage("admin_template_path");
            AddAdminTemplateLanguage = aol.GetAddOnsLanguage("add_admin_template");
            AdminTemplateActiveLanguage = aol.GetAddOnsLanguage("admin_template_active");
            UseAdminTemplatePathLanguage = aol.GetAddOnsLanguage("use_admin_template_path");
            AddLanguage = aol.GetAddOnsLanguage("add");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Admin Template Page List
            ActionGetAdminTemplateListModel lm = new ActionGetAdminTemplateListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void AddAdminTemplate()
        {
            string AdminTemplateFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Admin Template Path
            if (UseAdminTemplatePathValue)
            {
                if (string.IsNullOrEmpty(AdminTemplatePathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_admin_template_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                AdminTemplateFilePhysicalName = Path.GetFileName(AdminTemplatePathTextValue);

                FileExtension = Path.GetExtension(AdminTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AdminTemplateFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(AdminTemplatePathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AdminTemplateFilePhysicalName));
            }
            else
            {
                if (!AdminTemplatePathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_admin_template_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/"), "problem");

                    return;
                }

                AdminTemplateFilePhysicalName = AdminTemplatePathUploadValue.FileName;

                FileExtension = Path.GetExtension(AdminTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AdminTemplateFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                AdminTemplatePathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AdminTemplateFilePhysicalName));
            }

            // Check Admin Template File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AdminTemplateFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_admin_template").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            // Extract Zip File
            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AdminTemplateFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/admin_template")))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/"), "warning");

                return;
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/admin_template/catalog.xml"));

            XmlNode AdminTemplateCatalog = CatalogDocument.SelectSingleNode("/admin_template_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_admin_template", "admin_template_name", AdminTemplateCatalog["admin_template_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("admin_template_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/"), "problem");

                return;
            }


            string AdminTemplateDirectoryPath = AdminTemplateCatalog["admin_template_directory_path"].Attributes["value"].Value;
            AdminTemplateDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/"), AdminTemplateDirectoryPath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (AdminTemplateDirectoryPath != AdminTemplateCatalog["admin_template_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Admin Template File In "admin_template" Directory To Admin Template
            FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/admin_template/"), StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + AdminTemplateDirectoryPath), true);

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

                EmptyPaternDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + AdminTemplateDirectoryPath + "/uninstall.xml"));

                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
            }

            /// <Action> Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.AdminTemplate duat = new DataUse.AdminTemplate();

            duat.AdminTemplateName = AdminTemplateCatalog["admin_template_name"].Attributes["value"].Value;
            duat.AdminTemplatePhysicalName = AdminTemplateCatalog["admin_template_physical_name"].Attributes["value"].Value;
            duat.AdminTemplateDirectoryPath = AdminTemplateDirectoryPath;
            duat.AdminTemplateLoadTag = AdminTemplateCatalog["admin_template_load_tag"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            duat.AdminTemplateStaticHead = AdminTemplateCatalog["admin_template_static_head"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            duat.AdminTemplateActive = AdminTemplateActiveValue.BooleanToZeroOne();

            // Add Admin Template
            duat.AddWithFillReturnDr();


            try { duat.ReturnDb.Close(); } catch (Exception) { }


            // Refill Value
            StaticObject.SetAdminTemplate();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_admin_template", duat.AdminTemplateName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("admin_template_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/admin_template/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/admin_template/action/AdminTemplateNewRow.aspx?admin_template_id=" + duat.AdminTemplateId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}