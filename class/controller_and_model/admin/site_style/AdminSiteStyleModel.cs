using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminSiteStyleModel : CodeBehindModel
    {
        public string SiteStyleLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string AddSiteStyleLanguage { get; set; }
        public string SiteStylePathLanguage { get; set; }
        public string UseSiteStylePathLanguage { get; set; }
        public string SiteStyleActiveLanguage { get; set; }

        public bool UseSiteStylePathValue { get; set; } = false;
        public bool SiteStyleActiveValue { get; set; } = false;
        public IFormFile SiteStylePathUploadValue { get; set; }
        public string SiteStylePathTextValue { get; set; }
        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_style/");
            SiteStylePathLanguage = aol.GetAddOnsLanguage("site_style_path");
            SiteStyleLanguage = aol.GetAddOnsLanguage("site_style");
            AddSiteStyleLanguage = aol.GetAddOnsLanguage("add_site_style");
            SiteStyleActiveLanguage = aol.GetAddOnsLanguage("site_style_active");
            UseSiteStylePathLanguage = aol.GetAddOnsLanguage("use_site_style_path");
            AddLanguage = aol.GetAddOnsLanguage("add");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Site Style Page List
            ActionGetSiteStyleListModel lm = new ActionGetSiteStyleListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void AddSiteStyle()
        {
            string SiteStyleFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Site Style Path
            if (UseSiteStylePathValue)
            {
                if (string.IsNullOrEmpty(SiteStylePathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_site_style_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_style/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                SiteStyleFilePhysicalName = Path.GetFileName(SiteStylePathTextValue);

                FileExtension = Path.GetExtension(SiteStyleFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_style/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(SiteStyleFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(SiteStylePathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteStyleFilePhysicalName));
            }
            else
            {
                if (!SiteStylePathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_site_style_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_style/"), "problem");

                    return;
                }

                SiteStyleFilePhysicalName = SiteStylePathUploadValue.FileName;

                FileExtension = Path.GetExtension(SiteStyleFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_style/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(SiteStyleFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                SiteStylePathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteStyleFilePhysicalName));
            }

            // Check Site Style File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteStyleFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_site_style").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            // Extract Zip File
            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteStyleFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/site_style")))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_style/"), "warning");

                return;
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/site_style/catalog.xml"));

            XmlNode SiteStyleCatalog = CatalogDocument.SelectSingleNode("/site_style_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_site_style", "site_style_name", SiteStyleCatalog["site_style_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("site_style_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_style/"), "problem");

                return;
            }


            string SiteStyleDirectoryPath = SiteStyleCatalog["site_style_directory_path"].Attributes["value"].Value;
            SiteStyleDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/site/"), SiteStyleDirectoryPath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (SiteStyleDirectoryPath != SiteStyleCatalog["site_style_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Site Style File In "site_style" Directory To Site Style
            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/site_style/"), StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/site/" + SiteStyleDirectoryPath));

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

                EmptyPaternDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/site/" + SiteStyleDirectoryPath + "/uninstall.xml"));

                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
            }

            /// <Action> Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.SiteStyle duss = new DataUse.SiteStyle();

            duss.SiteStyleName = SiteStyleCatalog["site_style_name"].Attributes["value"].Value;
            duss.SiteStylePhysicalName = SiteStyleCatalog["site_style_physical_name"].Attributes["value"].Value;
            duss.SiteStyleDirectoryPath = SiteStyleDirectoryPath;
            duss.SiteStyleTemplate = SiteStyleCatalog["site_style_template"].Attributes["value"].Value;
            duss.SiteStyleLoadTag = SiteStyleCatalog["site_style_load_tag"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            duss.SiteStyleStaticHead = SiteStyleCatalog["site_style_static_head"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            duss.SiteStyleActive = SiteStyleActiveValue.BooleanToZeroOne();

            // Add Site Style
            duss.AddWithFillReturnDr();


            try { duss.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_site_style", duss.SiteStyleName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("site_style_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_style/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/site_style/action/SiteStyleNewRow.aspx?site_style_id=" + duss.SiteStyleId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}