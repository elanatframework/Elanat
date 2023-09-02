using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminSiteTemplateModel : CodeBehindModel
    {
        public string SiteTemplateLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string AddSiteTemplateLanguage { get; set; }
        public string SiteTemplatePathLanguage { get; set; }
        public string UseSiteTemplatePathLanguage { get; set; }
        public string SiteTemplateActiveLanguage { get; set; }

        public bool UseSiteTemplatePathValue { get; set; } = false;
        public bool SiteTemplateActiveValue { get; set; } = false;
        public IFormFile SiteTemplatePathUploadValue { get; set; }
        public string SiteTemplatePathTextValue { get; set; }
        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/");
            SiteTemplateLanguage = aol.GetAddOnsLanguage("site_template");
            SiteTemplatePathLanguage = aol.GetAddOnsLanguage("site_template_path");
            AddSiteTemplateLanguage = aol.GetAddOnsLanguage("add_site_template");
            SiteTemplateActiveLanguage = aol.GetAddOnsLanguage("site_template_active");
            UseSiteTemplatePathLanguage = aol.GetAddOnsLanguage("use_site_template_path");
            AddLanguage = aol.GetAddOnsLanguage("add");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Site Template Page List
            ActionGetSiteTemplateListModel lm = new ActionGetSiteTemplateListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void AddSiteTemplate()
        {
            string SiteTemplateFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Site Template Path
            if (UseSiteTemplatePathValue)
            {
                if (string.IsNullOrEmpty(SiteTemplatePathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_site_template_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                SiteTemplateFilePhysicalName = Path.GetFileName(SiteTemplatePathTextValue);

                FileExtension = Path.GetExtension(SiteTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(SiteTemplateFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(SiteTemplatePathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteTemplateFilePhysicalName));
            }
            else
            {
                if (!SiteTemplatePathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_site_template_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");

                    return;
                }

                SiteTemplateFilePhysicalName = SiteTemplatePathUploadValue.FileName;

                FileExtension = Path.GetExtension(SiteTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(SiteTemplateFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                SiteTemplatePathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteTemplateFilePhysicalName));
            }

            // Check Site Template File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteTemplateFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_site_template").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            // Extract Zip File
            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteTemplateFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/site_template")))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "warning");

                return;
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/site_template/catalog.xml"));

            XmlNode SiteTemplateCatalog = CatalogDocument.SelectSingleNode("/site_template_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_site_template", "site_template_name", SiteTemplateCatalog["site_template_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("site_template_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");

                return;
            }


            string SiteTemplateDirectoryPath = SiteTemplateCatalog["site_template_directory_path"].Attributes["value"].Value;
            SiteTemplateDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "template/site/"), SiteTemplateDirectoryPath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (SiteTemplateDirectoryPath != SiteTemplateCatalog["site_template_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Site Template File In "site_template" Directory To Site Template
            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/site_template/"), StaticObject.ServerMapPath(StaticObject.SitePath + "template/site/" + SiteTemplateDirectoryPath));

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

                EmptyPaternDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "template/site/" + SiteTemplateDirectoryPath + "/uninstall.xml"));

                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
            }

            /// <Action> Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.SiteTemplate dust = new DataUse.SiteTemplate();

            dust.SiteTemplateName = SiteTemplateCatalog["site_template_name"].Attributes["value"].Value;
            dust.SiteTemplatePhysicalName = SiteTemplateCatalog["site_template_physical_name"].Attributes["value"].Value;
            dust.SiteTemplateDirectoryPath = SiteTemplateDirectoryPath;
            dust.SiteTemplateLoadTag = SiteTemplateCatalog["site_template_load_tag"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            dust.SiteTemplateStaticHead = SiteTemplateCatalog["site_template_static_head"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            dust.SiteTemplateActive = SiteTemplateActiveValue.BooleanToZeroOne();

            // Add Site Template
            dust.AddWithFillReturnDr();


            try { dust.ReturnDb.Close(); } catch (Exception) { }


            // Refill Value
            StaticObject.SetSiteTemplate();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_site_template", dust.SiteTemplateName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("site_template_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/site_template/action/SiteTemplateNewRow.aspx?site_template_id=" + dust.SiteTemplateId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}