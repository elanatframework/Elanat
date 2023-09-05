using CodeBehind;
using SetCodeBehind;
using System.Reflection.Metadata;
using System.Xml;

namespace Elanat
{
    public partial class AdminExtraHelperModel : CodeBehindModel
    {
        public string ExtraHelperLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string AddExtraHelperLanguage { get; set; }
        public string ExtraHelperPathLanguage { get; set; }
        public string UseExtraHelperPathLanguage { get; set; }
        public string PriorityForExtraHelperLanguage { get; set; }
        public string ExtraHelperCategoryLanguage { get; set; }
        public string ExtraHelperActiveLanguage { get; set; }
        public string ExtraHelperUseLanguageLanguage { get; set; }
        public string ExtraHelperUseModuleLanguage { get; set; }
        public string ExtraHelperUsePluginLanguage { get; set; }
        public string ExtraHelperUseReplacePartLanguage { get; set; }
        public string ExtraHelperUseFetchLanguage { get; set; }
        public string ExtraHelperUseItemLanguage { get; set; }
        public string ExtraHelperUseElanatLanguage { get; set; }
        public string ExtraHelperCacheDurationLanguage { get; set; }
        public string ExtraHelperCacheParametersLanguage { get; set; }
        public string ExtraHelperSortIndexLanguage { get; set; }
        public string ExtraHelperAccessShowLanguage { get; set; }
        public string ExtraHelperPublicAccessShowLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool PriorityForExtraHelperValue { get; set; } = true;
        public bool ExtraHelperActiveValue { get; set; } = false;
        public bool ExtraHelperUseLanguageValue { get; set; } = false;
        public bool ExtraHelperUseModuleValue { get; set; } = false;
        public bool ExtraHelperUsePluginValue { get; set; } = false;
        public bool ExtraHelperUseReplacePartValue { get; set; } = false;
        public bool ExtraHelperUseFetchValue { get; set; } = false;
        public bool ExtraHelperUseItemValue { get; set; } = false;
        public bool ExtraHelperUseElanatValue { get; set; } = false;
        public bool ExtraHelperPublicAccessShowValue { get; set; } = false;

        public bool UseExtraHelperPathValue { get; set; } = false;
        public IFormFile ExtraHelperPathUploadValue { get; set; }
        public string ExtraHelperPathTextValue { get; set; }

        public string ExtraHelperCategoryValue { get; set; }
        public string ExtraHelperCacheDurationValue { get; set; }
        public string ExtraHelperCacheParametersValue { get; set; }
        public string ExtraHelperSortIndexValue { get; set; }

        public string ExtraHelperCategoryAttribute { get; set; }
        public string ExtraHelperCacheDurationAttribute { get; set; }
        public string ExtraHelperCacheParametersAttribute { get; set; }
        public string ExtraHelperSortIndexAttribute { get; set; }

        public string ExtraHelperCategoryCssClass { get; set; }
        public string ExtraHelperCacheDurationCssClass { get; set; }
        public string ExtraHelperCacheParametersCssClass { get; set; }
        public string ExtraHelperSortIndexCssClass { get; set; }

        public List<ListItem> ExtraHelperAccessShowListItem = new List<ListItem>();
        public string ExtraHelperAccessShowListValue { get; set; }
        public string ExtraHelperAccessShowTemplateValue { get; set; }

        public string ExtraHelperAccessShowAttribute { get; set; }
        public string ExtraHelperAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/");
            ExtraHelperLanguage = aol.GetAddOnsLanguage("extra_helper");
            AddExtraHelperLanguage = aol.GetAddOnsLanguage("add_extra_helper");
            ExtraHelperPathLanguage = aol.GetAddOnsLanguage("extra_helper_path");
            PriorityForExtraHelperLanguage = aol.GetAddOnsLanguage("priority_for_extra_helper");
            ExtraHelperCategoryLanguage = aol.GetAddOnsLanguage("extra_helper_category");
            AddExtraHelperLanguage = aol.GetAddOnsLanguage("add_extra_helper");
            UseExtraHelperPathLanguage = aol.GetAddOnsLanguage("use_extra_helper_path");
            ExtraHelperActiveLanguage = aol.GetAddOnsLanguage("extra_helper_active");
            ExtraHelperPublicAccessShowLanguage = aol.GetAddOnsLanguage("extra_helper_public_access_show");
            ExtraHelperAccessShowLanguage = aol.GetAddOnsLanguage("extra_helper_access_show");
            ExtraHelperSortIndexLanguage = aol.GetAddOnsLanguage("extra_helper_sort_index");
            AddLanguage = aol.GetAddOnsLanguage("add");
            ExtraHelperCacheDurationLanguage = aol.GetAddOnsLanguage("extra_helper_cache_duration");
            ExtraHelperCacheParametersLanguage = aol.GetAddOnsLanguage("extra_helper_cache_parameters");
            ExtraHelperUseLanguageLanguage = aol.GetAddOnsLanguage("extra_helper_use_language");
            ExtraHelperUseModuleLanguage = aol.GetAddOnsLanguage("extra_helper_use_module");
            ExtraHelperUsePluginLanguage = aol.GetAddOnsLanguage("extra_helper_use_plugin");
            ExtraHelperUseReplacePartLanguage = aol.GetAddOnsLanguage("extra_helper_use_replace_part");
            ExtraHelperUseFetchLanguage = aol.GetAddOnsLanguage("extra_helper_use_fetch");
            ExtraHelperUseItemLanguage = aol.GetAddOnsLanguage("extra_helper_use_item");
            ExtraHelperUseElanatLanguage = aol.GetAddOnsLanguage("extra_helper_use_elanat");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Extra Helper Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/extra_helper/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ExtraHelperAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lcu.UserRoleListItem);
            ExtraHelperAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            ExtraHelperAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            ExtraHelperAccessShowTemplateValue = ExtraHelperAccessShowTemplateValue.Replace("$_asp attribute;", ExtraHelperAccessShowAttribute);
            ExtraHelperAccessShowTemplateValue = ExtraHelperAccessShowTemplateValue.Replace("$_asp css_class;", ExtraHelperAccessShowCssClass);
            ExtraHelperAccessShowTemplateValue = ExtraHelperAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(ExtraHelperAccessShowListItem);


            PriorityForExtraHelperValue = true;
            ExtraHelperCacheDurationValue = "0";
            ExtraHelperSortIndexValue = "0";


            // Set Extra Helper Page List
            ActionGetExtraHelperListModel lm = new ActionGetExtraHelperListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_ExtraHelperCategory", "");
            InputRequest.Add("txt_ExtraHelperCacheDuration", "");
            InputRequest.Add("txt_ExtraHelperCacheParameters", "");
            InputRequest.Add("txt_ExtraHelperSortIndex", "");
            InputRequest.Add("cbxlst_ExtraHelperAccessShow", ExtraHelperAccessShowListValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/extra_helper/");

            ExtraHelperCategoryAttribute += vc.ImportantInputAttribute.GetValue("txt_ExtraHelperCategory");
            ExtraHelperCacheDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_ExtraHelperCacheDuration");
            ExtraHelperCacheParametersAttribute += vc.ImportantInputAttribute.GetValue("txt_ExtraHelperCacheParameters");
            ExtraHelperSortIndexAttribute += vc.ImportantInputAttribute.GetValue("txt_ExtraHelperSortIndex");
            ExtraHelperAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ExtraHelperAccessShow");

            ExtraHelperCategoryCssClass = ExtraHelperCategoryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ExtraHelperCategory"));
            ExtraHelperCacheDurationCssClass = ExtraHelperCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ExtraHelperCacheDuration"));
            ExtraHelperCacheParametersCssClass = ExtraHelperCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ExtraHelperCacheParameters"));
            ExtraHelperSortIndexCssClass = ExtraHelperSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ExtraHelperSortIndex"));
            ExtraHelperAccessShowCssClass = ExtraHelperAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ExtraHelperAccessShow"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/extra_helper/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void AddExtraHelper()
        {
            string ExtraHelperFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Extra Helper Path
            if (UseExtraHelperPathValue)
            {
                if (string.IsNullOrEmpty(ExtraHelperPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_extra_helper_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                ExtraHelperFilePhysicalName = Path.GetFileName(ExtraHelperPathTextValue);

                FileExtension = Path.GetExtension(ExtraHelperFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(ExtraHelperFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                webClient.DownloadFile(ExtraHelperPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ExtraHelperFilePhysicalName));
            }
            else
            {
                if (!ExtraHelperPathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_extra_helper_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");

                    return;
                }

                ExtraHelperFilePhysicalName = ExtraHelperPathUploadValue.FileName;

                FileExtension = Path.GetExtension(ExtraHelperFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(ExtraHelperFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                ExtraHelperPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ExtraHelperFilePhysicalName));
            }

            // Check Extra Helper File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ExtraHelperFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_extra_helper").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            // Extract Zip File
            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ExtraHelperFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/extra_helper")))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "warning");

                return;
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/extra_helper/catalog.xml"));

            XmlNode ExtraHelperCatalog = CatalogDocument.SelectSingleNode("/extra_helper_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_extra_helper", "extra_helper_name", ExtraHelperCatalog["extra_helper_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("extra_helper_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");

                return;
            }


            string ExtraHelperDirectoryPath = ExtraHelperCatalog["extra_helper_directory_path"].Attributes["value"].Value;
            ExtraHelperDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/"), ExtraHelperDirectoryPath);

            bool HasDll = false;

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (ExtraHelperDirectoryPath != ExtraHelperCatalog["extra_helper_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Extra Helper File In "extra_helper" Directory To Extra Helper
            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/extra_helper/"), StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/" + ExtraHelperDirectoryPath));

            // If "root" Directory Exist
            if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
            {
                if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                    if (StaticObject.AdminDirectoryPath != "admin")
                        Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));

                if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/bin/")))
                    HasDll = true;

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

                UninstallDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/" + ExtraHelperDirectoryPath + "/uninstall.xml"));


                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
            }

            // Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();

            dueh.ExtraHelperName = ExtraHelperCatalog["extra_helper_name"].Attributes["value"].Value;
            dueh.ExtraHelperCategory = (PriorityForExtraHelperValue) ? ExtraHelperCatalog["extra_helper_category"].Attributes["value"].Value.SpaceToUnderline() : ExtraHelperCategoryValue.SpaceToUnderline();
            dueh.ExtraHelperDirectoryPath = ExtraHelperDirectoryPath;
            dueh.ExtraHelperPhysicalName = ExtraHelperCatalog["extra_helper_physical_name"].Attributes["value"].Value;
            dueh.ExtraHelperUseLanguage = (PriorityForExtraHelperValue) ? ExtraHelperCatalog["extra_helper_replace"].Attributes["use_language"].Value.TrueFalseToZeroOne() : ExtraHelperUseLanguageValue.BooleanToZeroOne();
            dueh.ExtraHelperUseModule = (PriorityForExtraHelperValue) ? ExtraHelperCatalog["extra_helper_replace"].Attributes["use_module"].Value.TrueFalseToZeroOne() : ExtraHelperUseModuleValue.BooleanToZeroOne();
            dueh.ExtraHelperUsePlugin = (PriorityForExtraHelperValue) ? ExtraHelperCatalog["extra_helper_replace"].Attributes["use_plugin"].Value.TrueFalseToZeroOne() : ExtraHelperUsePluginValue.BooleanToZeroOne();
            dueh.ExtraHelperUseReplacePart = (PriorityForExtraHelperValue) ? ExtraHelperCatalog["extra_helper_replace"].Attributes["use_replace_part"].Value.TrueFalseToZeroOne() : ExtraHelperUseReplacePartValue.BooleanToZeroOne();
            dueh.ExtraHelperUseFetch = (PriorityForExtraHelperValue) ? ExtraHelperCatalog["extra_helper_replace"].Attributes["use_fetch"].Value.TrueFalseToZeroOne() : ExtraHelperUseFetchValue.BooleanToZeroOne();
            dueh.ExtraHelperUseItem = (PriorityForExtraHelperValue) ? ExtraHelperCatalog["extra_helper_replace"].Attributes["use_item"].Value.TrueFalseToZeroOne() : ExtraHelperUseItemValue.BooleanToZeroOne();
            dueh.ExtraHelperUseElanat = (PriorityForExtraHelperValue) ? ExtraHelperCatalog["extra_helper_replace"].Attributes["use_elanat"].Value.TrueFalseToZeroOne() : ExtraHelperUseElanatValue.BooleanToZeroOne();
            dueh.ExtraHelperCacheDuration = (ExtraHelperCacheDurationValue.IsNumber()) ? ExtraHelperCacheDurationValue : "0";
            dueh.ExtraHelperCacheParameters = (PriorityForExtraHelperValue) ? ExtraHelperCatalog["extra_helper_cache_parameters"].InnerText : ExtraHelperCacheParametersValue;
            dueh.ExtraHelperPublicAccessShow = ExtraHelperPublicAccessShowValue.BooleanToZeroOne();
            dueh.ExtraHelperSortIndex = ExtraHelperSortIndexValue;
            dueh.ExtraHelperActive = ExtraHelperActiveValue.BooleanToZeroOne();

            // Add Extra Helper
            dueh.AddWithFillReturnDr();

            // Set Extra Helper Access Show
            dueh.SetExtraHelperAccessShow(dueh.ExtraHelperId, ExtraHelperAccessShowListItem);


            try { dueh.ReturnDb.Close(); } catch (Exception) { }


            // Recompile
            if (HasDll)
            {
                CodeBehindCompiler.Initialization();
                CodeBehindCompiler.CompileAspx();
            }

            // Run Install Page
            if (!string.IsNullOrEmpty(ExtraHelperCatalog["extra_helper_install_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.SitePath + "add_on/extra_helper/" + dueh.ExtraHelperDirectoryPath + "/" + ExtraHelperCatalog["extra_helper_install_path"].Attributes["value"].Value, false);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_extra_helper", dueh.ExtraHelperName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("extra_helper_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/extra_helper/action/ExtraHelperNewRow.aspx?extra_helper_id=" + dueh.ExtraHelperId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}