using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class AdminExtraHelperModel
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
        public HttpPostedFile ExtraHelperPathUploadValue { get; set; }
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

        public ListItemCollection ExtraHelperAccessShowListItem = new ListItemCollection();
        public string ExtraHelperAccessShowListValue { get; set; }
        public string ExtraHelperAccessShowTemplateValue { get; set; }

        public string ExtraHelperAccessShowAttribute { get; set; }
        public string ExtraHelperAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
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


            // Set Current Value
            ListClass lc = new ListClass();

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Extra Helper Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/extra_helper/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ExtraHelperAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lc.UserRoleListItem);
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
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_ExtraHelperCategory", "");
            InputRequest.Add("txt_ExtraHelperCacheDuration", "");
            InputRequest.Add("txt_ExtraHelperCacheParameters", "");
            InputRequest.Add("txt_ExtraHelperSortIndex", "");
            InputRequest.Add("cbxlst_ExtraHelperAccessShow", ExtraHelperAccessShowListValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/extra_helper/");

            ExtraHelperCategoryAttribute += vc.ImportantInputAttribute["txt_ExtraHelperCategory"];
            ExtraHelperCacheDurationAttribute += vc.ImportantInputAttribute["txt_ExtraHelperCacheDuration"];
            ExtraHelperCacheParametersAttribute += vc.ImportantInputAttribute["txt_ExtraHelperCacheParameters"];
            ExtraHelperSortIndexAttribute += vc.ImportantInputAttribute["txt_ExtraHelperSortIndex"];
            ExtraHelperAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_ExtraHelperAccessShow"];

            ExtraHelperCategoryCssClass = ExtraHelperCategoryCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ExtraHelperCategory"]);
            ExtraHelperCacheDurationCssClass = ExtraHelperCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ExtraHelperCacheDuration"]);
            ExtraHelperCacheParametersCssClass = ExtraHelperCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ExtraHelperCacheParameters"]);
            ExtraHelperSortIndexCssClass = ExtraHelperSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ExtraHelperSortIndex"]);
            ExtraHelperAccessShowCssClass = ExtraHelperAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ExtraHelperAccessShow"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/extra_helper/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //ExtraHelperCategoryCssClass = ExtraHelperCategoryCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ExtraHelperCategory"]);
                //ExtraHelperCacheDurationCssClass = ExtraHelperCacheDurationCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ExtraHelperCacheDuration"]);
                //ExtraHelperCacheParametersCssClass = ExtraHelperCacheParametersCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ExtraHelperCacheParameters"]);
                //ExtraHelperSortIndexCssClass = ExtraHelperSortIndexCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ExtraHelperSortIndex"]);
                //ExtraHelperAccessShowCssClass = ExtraHelperAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ExtraHelperAccessShow"]);
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
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_extra_helper_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");

                System.Net.WebClient webClient = new System.Net.WebClient();

                ExtraHelperFilePhysicalName = Path.GetFileName(ExtraHelperPathTextValue);

                FileExtension = Path.GetExtension(ExtraHelperFilePhysicalName);

                if (FileExtension != ".zip")
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(ExtraHelperFilePhysicalName));

                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                webClient.DownloadFile(ExtraHelperPathTextValue, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ExtraHelperFilePhysicalName));
            }
            else
            {
                if (!ExtraHelperPathUploadValue.HtmlInputHasFile())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_extra_helper_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");

                ExtraHelperFilePhysicalName = ExtraHelperPathUploadValue.FileName;

                FileExtension = Path.GetExtension(ExtraHelperFilePhysicalName);

                if (FileExtension != ".zip")
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(ExtraHelperFilePhysicalName));

                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                ExtraHelperPathUploadValue.SaveAs(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ExtraHelperFilePhysicalName));
            }

            // Check Extra Helper File Size
            double FileSize = new FileInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ExtraHelperFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_extra_helper").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");
            }

            // Extract Zip File
            ZipFileSocket zfs = new ZipFileSocket();
            zfs.UnZip(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ExtraHelperFilePhysicalName), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/extra_helper")))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "warning");
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/extra_helper/catalog.xml"));

            XmlNode ExtraHelperCatalog = CatalogDocument.SelectSingleNode("/extra_helper_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_extra_helper", "extra_helper_name", ExtraHelperCatalog["extra_helper_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("extra_helper_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "problem");
            }


            string ExtraHelperDirectoryPath = ExtraHelperCatalog["extra_helper_directory_path"].Attributes["value"].Value;
            ExtraHelperDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/"), ExtraHelperDirectoryPath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (ExtraHelperDirectoryPath != ExtraHelperCatalog["extra_helper_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Extra Helper File In "extra_helper" Directory To Extra Helper
            Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/extra_helper/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/" + ExtraHelperDirectoryPath));


            bool HasDll = false;

            // If "root" Directory Exist
            if (Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
            {
                if (Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                    if (StaticObject.AdminDirectoryPath != "admin")
                        Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));


                // Move "root/bin" Path To "root/App_Data/elanat_system_data/tmp_bin" Path
                ReCompileIssues rci = new ReCompileIssues();
                rci.PreparingAddOnBinDll(DirectoryName);
                rci.AddTmpBinAddOnToTmpBinFileList(rci.BinFileName, ExtraHelperCatalog["extra_helper_name"].Attributes["value"].Value, "extra_helper", ExtraHelperDirectoryPath);
                HasDll = (rci.BinFileName.Count > 0);


                /// <Action> Create Uninstall List
                DirectoryInfo directory = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"));

                XmlDocument UninstallDocument = new XmlDocument();
                UninstallDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/uninstall/uninstall.xml"));

                XmlNode FilePathList = UninstallDocument.SelectSingleNode("uninstall_root/file_path_list");

                foreach (FileInfo file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    XmlElement FilePathElement = UninstallDocument.CreateElement("file_path");
                    FilePathElement.InnerText = file.FullName.Replace(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), @"\");
                    FilePathList.AppendChild(FilePathElement);
                }

                UninstallDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/" + ExtraHelperDirectoryPath + "/uninstall.xml"));


                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + ""), true);
            }

            // Delete Physical File
            Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


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


            // Run Install Page
            if (!HasDll)
                if (!string.IsNullOrEmpty(ExtraHelperCatalog["extra_helper_install_path"].Attributes["value"].Value))
                    PageLoader.LoadWithServer("/add_on/extra_helper/" + dueh.ExtraHelperDirectoryPath + "/" + ExtraHelperCatalog["extra_helper_install_path"].Attributes["value"].Value);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_extra_helper", dueh.ExtraHelperName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("extra_helper_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/extra_helper/action/ExtraHelperNewRow.aspx?extra_helper_id=" + dueh.ExtraHelperId, "div_TableBox");

            if (HasDll)
                rf.SetTmpBinAlert();

            rf.RedirectToResponseFormPage();
        }
    }
}