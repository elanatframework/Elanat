using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminLanguageModel : CodeBehindModel
    {
        public string AddLanguage { get; set; }
        public string AddLanguageVariantLanguage { get; set; }
        public string AddLanguageLanguage { get; set; }
        public string LanguageLanguage { get; set; }
        public string EditHandheldLanguageVariantLanguage { get; set; }
        public string EditLanguageVariantLanguage { get; set; }
        public string LanguageDefaultSiteLanguage { get; set; }
        public string LanguagePathLanguage { get; set; }
        public string LanguageActiveLanguage { get; set; }
        public string UseLanguagePathLanguage { get; set; }
        public string ShowLinkInSiteLanguage { get; set; }
        public string AddHandheldLanguageVariantLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool LanguageActiveValue { get; set; } = false;
        public bool UseLanguagePathValue { get; set; } = false;
        public bool ShowLinkInSiteValue { get; set; } = false;

        public IFormFile LanguagePathUploadValue { get; set; }
        public string LanguagePathTextValue { get; set; }

        public string LanguageDefaultSiteOptionListValue { get; set; }
        public string LanguageDefaultSiteOptionListSelectedValue { get; set; }

        public string LanguageDefaultSiteAttribute { get; set; }
        public string LanguageDefaultSiteCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/");
            AddLanguage = aol.GetAddOnsLanguage("add");
            AddLanguageVariantLanguage = aol.GetAddOnsLanguage("add_language_variant");
            EditLanguageVariantLanguage = aol.GetAddOnsLanguage("edit_language_variant");
            AddLanguageLanguage = aol.GetAddOnsLanguage("add_language");
            LanguageDefaultSiteLanguage = aol.GetAddOnsLanguage("language_default_site");
            LanguageLanguage = aol.GetAddOnsLanguage("language");
            LanguagePathLanguage = aol.GetAddOnsLanguage("language_path");
            LanguageActiveLanguage = aol.GetAddOnsLanguage("language_active");
            UseLanguagePathLanguage = aol.GetAddOnsLanguage("use_language_path");
            ShowLinkInSiteLanguage = aol.GetAddOnsLanguage("show_link_in_site");
            AddHandheldLanguageVariantLanguage = aol.GetAddOnsLanguage("add_handheld_language_variant");
            EditHandheldLanguageVariantLanguage = aol.GetAddOnsLanguage("edit_handheld_language_variant");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
            ListClass.Site lcs = new ListClass.Site();

            // Set Site Item
            lcs.FillSiteListItem();
            LanguageDefaultSiteOptionListValue += LanguageDefaultSiteOptionListValue.HtmlInputAddOptionTag("", "0");
            LanguageDefaultSiteOptionListValue += lcs.SiteListItem.HtmlInputToOptionTag(LanguageDefaultSiteOptionListSelectedValue);


            // Set Language Page List
            ActionGetLanguageListModel lm = new ActionGetLanguageListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("ddlst_LanguageDefaultSite", LanguageDefaultSiteOptionListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/language/", "add_language");

            LanguageDefaultSiteAttribute += vc.ImportantInputAttribute.GetValue("ddlst_LanguageDefaultSite");

            LanguageDefaultSiteCssClass = LanguageDefaultSiteCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_LanguageDefaultSite"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "add_language", StaticObject.AdminPath + "/language/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void AddLanguagePackage()
        {
            string LanguageFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Language Path
            if (UseLanguagePathValue)
            {
                if (string.IsNullOrEmpty(LanguagePathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_language_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                LanguageFilePhysicalName = Path.GetFileName(LanguagePathTextValue);

                FileExtension = Path.GetExtension(LanguageFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(LanguageFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(LanguagePathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + LanguageFilePhysicalName));
            }
            else
            {
                if (!LanguagePathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_language_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "problem");

                    return;
                }

                LanguageFilePhysicalName = LanguagePathUploadValue.FileName;

                FileExtension = Path.GetExtension(LanguageFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(LanguageFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                LanguagePathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + LanguageFilePhysicalName));
            }

            // Check Language File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + LanguageFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_language").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            // Extract Zip File
            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + LanguageFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/language")))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "warning");

                return;
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/language/catalog.xml"));

            XmlNode LanguageCatalog = CatalogDocument.SelectSingleNode("/language_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_language", "language_global_name", LanguageCatalog["language_global_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("language_global_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "problem");

                return;
            }

            if (common.ExistValueToColumnCheck("el_language", "language_name", LanguageCatalog["language_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("language_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "problem");

                return;
            }


            string LanguageGlobalName = LanguageCatalog["language_global_name"].Attributes["value"].Value;
            LanguageGlobalName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "language/"), LanguageGlobalName);
            string LanguageName = LanguageCatalog["language_name"].Attributes["value"].Value;
            string LanguageIsRightToLeft = (LanguageCatalog["language_is_right_to_left"].Attributes["value"].Value == "true").BooleanToZeroOne();

            // Move All Language File In "language" Directory To Language
            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/language/"), StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + LanguageGlobalName));

            // If "root" Directory Exist
            if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
            {
                if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                    if (StaticObject.AdminDirectoryPath != "admin")
                        Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));


                /// <Action> Create Uninstall List
                DirectoryInfo directory = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"));

                XmlDocument UninstallDocument = new XmlDocument();
                UninstallDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/uninstall/uninstall.xml"));

                XmlNode FilePathList = UninstallDocument.SelectSingleNode("uninstall_root/file_path_list");
                                
                foreach (FileInfo file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    XmlElement FilePathElement = UninstallDocument.CreateElement("file_path");
                    FilePathElement.InnerText = file.FullName.Replace(StaticObject.ServerMapPath((StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/").Replace("/","\\")), @"\");
                    FilePathList.AppendChild(FilePathElement);
                }

                UninstallDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + LanguageGlobalName + "/uninstall.xml"));


                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
            }

            // Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.Language dul = new DataUse.Language();

            dul.LanguageName = LanguageName;
            dul.LanguageGlobalName = LanguageGlobalName;
            dul.LanguageIsRightToLeft = LanguageIsRightToLeft;
            dul.LanguageShowLinkInSite = ShowLinkInSiteValue.BooleanToZeroOne();
            dul.LanguageActive = LanguageActiveValue.BooleanToZeroOne();
            dul.SiteId = LanguageDefaultSiteOptionListSelectedValue;

            // Add Language
            dul.AddWithFillReturnDr();


            try { dul.ReturnDb.Close(); } catch (Exception) { }


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_language", LanguageGlobalName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("language_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "success", false, StaticObject.AdminPath + "/language/action/LanguageNewRow.aspx?language_id=" + dul.LanguageId, "div_TableBox");
        }
    }
}