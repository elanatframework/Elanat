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
    public class AdminEditorTemplateModel
    {
        public string EditorTemplateLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string AddEditorTemplateLanguage { get; set; }
        public string EditorTemplatePathLanguage { get; set; }
        public string UseEditorTemplatePathLanguage { get; set; }
        public string PriorityForEditorTemplateLanguage { get; set; }
        public string EditorTemplateCategoryLanguage { get; set; }
        public string EditorTemplateActiveLanguage { get; set; }
        public string EditorTemplateUseLanguageLanguage { get; set; }
        public string EditorTemplateUseModuleLanguage { get; set; }
        public string EditorTemplateUsePluginLanguage { get; set; }
        public string EditorTemplateUseReplacePartLanguage { get; set; }
        public string EditorTemplateUseFetchLanguage { get; set; }
        public string EditorTemplateUseItemLanguage { get; set; }
        public string EditorTemplateUseElanatLanguage { get; set; }
        public string EditorTemplateCacheDurationLanguage { get; set; }
        public string EditorTemplateCacheParametersLanguage { get; set; }
        public string EditorTemplateSortIndexLanguage { get; set; }
        public string EditorTemplateAccessShowLanguage { get; set; }
        public string EditorTemplatePublicAccessShowLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool PriorityForEditorTemplateValue { get; set; } = true;
        public bool EditorTemplateActiveValue { get; set; } = false;
        public bool EditorTemplateUseLanguageValue { get; set; } = false;
        public bool EditorTemplateUseModuleValue { get; set; } = false;
        public bool EditorTemplateUsePluginValue { get; set; } = false;
        public bool EditorTemplateUseReplacePartValue { get; set; } = false;
        public bool EditorTemplateUseFetchValue { get; set; } = false;
        public bool EditorTemplateUseItemValue { get; set; } = false;
        public bool EditorTemplateUseElanatValue { get; set; } = false;
        public bool EditorTemplatePublicAccessShowValue { get; set; } = false;

        public bool UseEditorTemplatePathValue { get; set; } = false;
        public HttpPostedFile EditorTemplatePathUploadValue { get; set; }
        public string EditorTemplatePathTextValue { get; set; }

        public string EditorTemplateCategoryValue { get; set; }
        public string EditorTemplateCacheDurationValue { get; set; }
        public string EditorTemplateCacheParametersValue { get; set; }
        public string EditorTemplateSortIndexValue { get; set; }

        public string EditorTemplateCategoryAttribute { get; set; }
        public string EditorTemplateCacheDurationAttribute { get; set; }
        public string EditorTemplateCacheParametersAttribute { get; set; }
        public string EditorTemplateSortIndexAttribute { get; set; }

        public string EditorTemplateCategoryCssClass { get; set; }
        public string EditorTemplateCacheDurationCssClass { get; set; }
        public string EditorTemplateCacheParametersCssClass { get; set; }
        public string EditorTemplateSortIndexCssClass { get; set; }

        public ListItemCollection EditorTemplateAccessShowListItem = new ListItemCollection();
        public string EditorTemplateAccessShowListValue { get; set; }
        public string EditorTemplateAccessShowTemplateValue { get; set; }

        public string EditorTemplateAccessShowAttribute { get; set; }
        public string EditorTemplateAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/");
            EditorTemplateLanguage = aol.GetAddOnsLanguage("editor_template");
            EditorTemplatePathLanguage = aol.GetAddOnsLanguage("editor_template_path");
            AddEditorTemplateLanguage = aol.GetAddOnsLanguage("add_editor_template");
            PriorityForEditorTemplateLanguage = aol.GetAddOnsLanguage("priority_for_editor_template");
            EditorTemplateCategoryLanguage = aol.GetAddOnsLanguage("editor_template_category");
            UseEditorTemplatePathLanguage = aol.GetAddOnsLanguage("use_editor_template_path");
            EditorTemplateActiveLanguage = aol.GetAddOnsLanguage("editor_template_active");
            EditorTemplatePublicAccessShowLanguage = aol.GetAddOnsLanguage("editor_template_public_access_show");
            EditorTemplateAccessShowLanguage = aol.GetAddOnsLanguage("editor_template_access_show");
            EditorTemplateSortIndexLanguage = aol.GetAddOnsLanguage("editor_template_sort_index");
            AddLanguage = aol.GetAddOnsLanguage("add");
            EditorTemplateCacheDurationLanguage = aol.GetAddOnsLanguage("editor_template_cache_duration");
            EditorTemplateCacheParametersLanguage = aol.GetAddOnsLanguage("editor_template_cache_parameters");
            EditorTemplateUseLanguageLanguage = aol.GetAddOnsLanguage("editor_template_use_language");
            EditorTemplateUseModuleLanguage = aol.GetAddOnsLanguage("editor_template_use_module");
            EditorTemplateUsePluginLanguage = aol.GetAddOnsLanguage("editor_template_use_plugin");
            EditorTemplateUseReplacePartLanguage = aol.GetAddOnsLanguage("editor_template_use_replace_part");
            EditorTemplateUseFetchLanguage = aol.GetAddOnsLanguage("editor_template_use_fetch");
            EditorTemplateUseItemLanguage = aol.GetAddOnsLanguage("editor_template_use_item");
            EditorTemplateUseElanatLanguage = aol.GetAddOnsLanguage("editor_template_use_elanat");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
            ListClass lc = new ListClass();

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Editor Template Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/editor_template/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_EditorTemplateAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lc.UserRoleListItem);
            EditorTemplateAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            EditorTemplateAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            EditorTemplateAccessShowTemplateValue = EditorTemplateAccessShowTemplateValue.Replace("$_asp attribute;", EditorTemplateAccessShowAttribute);
            EditorTemplateAccessShowTemplateValue = EditorTemplateAccessShowTemplateValue.Replace("$_asp css_class;", EditorTemplateAccessShowCssClass);
            EditorTemplateAccessShowTemplateValue = EditorTemplateAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(EditorTemplateAccessShowListItem);


            PriorityForEditorTemplateValue = true;
            EditorTemplateCacheDurationValue = "0";
            EditorTemplateSortIndexValue = "0";


            // Set Editor Template Page List
            ActionGetEditorTemplateListModel lm = new ActionGetEditorTemplateListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_EditorTemplateCategory", "");
            InputRequest.Add("txt_EditorTemplateCacheDuration", "");
            InputRequest.Add("txt_EditorTemplateCacheParameters", "");
            InputRequest.Add("txt_EditorTemplateSortIndex", "");
            InputRequest.Add("cbxlst_EditorTemplateAccessShow", EditorTemplateAccessShowListValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/editor_template/");

            EditorTemplateCategoryAttribute += vc.ImportantInputAttribute["txt_EditorTemplateCategory"];
            EditorTemplateCacheDurationAttribute += vc.ImportantInputAttribute["txt_EditorTemplateCacheDuration"];
            EditorTemplateCacheParametersAttribute += vc.ImportantInputAttribute["txt_EditorTemplateCacheParameters"];
            EditorTemplateSortIndexAttribute += vc.ImportantInputAttribute["txt_EditorTemplateSortIndex"];
            EditorTemplateAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_EditorTemplateAccessShow"];

            EditorTemplateCategoryCssClass = EditorTemplateCategoryCssClass.AddHtmlClass(vc.ImportantInputClass["txt_EditorTemplateCategory"]);
            EditorTemplateCacheDurationCssClass = EditorTemplateCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass["txt_EditorTemplateCacheDuration"]);
            EditorTemplateCacheParametersCssClass = EditorTemplateCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass["txt_EditorTemplateCacheParameters"]);
            EditorTemplateSortIndexCssClass = EditorTemplateSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass["txt_EditorTemplateSortIndex"]);
            EditorTemplateAccessShowCssClass = EditorTemplateAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_EditorTemplateAccessShow"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/editor_template/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //EditorTemplateCategoryCssClass = EditorTemplateCategoryCssClass.AddHtmlClass(vc.WarningFieldClass["txt_EditorTemplateCategory"]);
                //EditorTemplateCacheDurationCssClass = EditorTemplateCacheDurationCssClass.AddHtmlClass(vc.WarningFieldClass["txt_EditorTemplateCacheDuration"]);
                //EditorTemplateCacheParametersCssClass = EditorTemplateCacheParametersCssClass.AddHtmlClass(vc.WarningFieldClass["txt_EditorTemplateCacheParameters"]);
                //EditorTemplateSortIndexCssClass = EditorTemplateSortIndexCssClass.AddHtmlClass(vc.WarningFieldClass["txt_EditorTemplateSortIndex"]);
                //EditorTemplateAccessShowCssClass = EditorTemplateAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_EditorTemplateAccessShow"]);
            }
        }

        public void AddEditorTemplate()
        {
            string EditorTemplateFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Editor Template Path
            if (UseEditorTemplatePathValue)
            {
                if (string.IsNullOrEmpty(EditorTemplatePathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_editor_template_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "problem");

                System.Net.WebClient webClient = new System.Net.WebClient();

                EditorTemplateFilePhysicalName = Path.GetFileName(EditorTemplatePathTextValue);

                FileExtension = Path.GetExtension(EditorTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(EditorTemplateFilePhysicalName));

                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                webClient.DownloadFile(EditorTemplatePathTextValue, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + EditorTemplateFilePhysicalName));
            }
            else
            {
                if (!EditorTemplatePathUploadValue.HtmlInputHasFile())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_editor_template_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "problem");

                EditorTemplateFilePhysicalName = EditorTemplatePathUploadValue.FileName;

                FileExtension = Path.GetExtension(EditorTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(EditorTemplateFilePhysicalName));

                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                EditorTemplatePathUploadValue.SaveAs(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + EditorTemplateFilePhysicalName));
            }

            // Check Editor Template File Size
            double FileSize = new FileInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + EditorTemplateFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_editor_template").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");
            }

            // Extract Zip File
            ZipFileSocket zfs = new ZipFileSocket();
            zfs.UnZip(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + EditorTemplateFilePhysicalName), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/editor_template")))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "warning");
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/editor_template/catalog.xml"));

            XmlNode EditorTemplateCatalog = CatalogDocument.SelectSingleNode("/editor_template_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/");

            if (common.ExistValueToColumnCheck("el_editor_template", "editor_template_name", EditorTemplateCatalog["editor_template_name"].Attributes["value"].Value))
            {
                HttpContext.Current.Response.Write(aol.GetAddOnsLanguage("editor_template_name_is_duplicate"));

                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);
                return;
            }


            string EditorTemplateDirectoryPath = EditorTemplateCatalog["editor_template_directory_path"].Attributes["value"].Value;
            EditorTemplateDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/editor_template/"), EditorTemplateDirectoryPath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (EditorTemplateDirectoryPath != EditorTemplateCatalog["editor_template_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Editor Template File In "editor_template" Directory To Editor Template
            Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/editor_template/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/editor_template/" + EditorTemplateDirectoryPath));


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
                rci.AddTmpBinAddOnToTmpBinFileList(rci.BinFileName, EditorTemplateCatalog["editor_template_name"].Attributes["value"].Value, "editor_template", EditorTemplateDirectoryPath);
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

                UninstallDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/editor_template/" + EditorTemplateDirectoryPath + "/uninstall.xml"));


                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + ""), true);
            }

            // Delete Physical File
            Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.EditorTemplate duet = new DataUse.EditorTemplate();

            duet.EditorTemplateName = EditorTemplateCatalog["editor_template_name"].Attributes["value"].Value;
            duet.EditorTemplateCategory = (PriorityForEditorTemplateValue) ? EditorTemplateCatalog["editor_template_category"].Attributes["value"].Value.SpaceToUnderline() : EditorTemplateCategoryValue.SpaceToUnderline();
            duet.EditorTemplateDirectoryPath = EditorTemplateDirectoryPath;
            duet.EditorTemplatePhysicalName = EditorTemplateCatalog["editor_template_physical_name"].Attributes["value"].Value;
            duet.EditorTemplateUseLanguage = (PriorityForEditorTemplateValue) ? EditorTemplateCatalog["editor_template_replace"].Attributes["use_language"].Value.TrueFalseToZeroOne() : EditorTemplateUseLanguageValue.BooleanToZeroOne();
            duet.EditorTemplateUseModule = (PriorityForEditorTemplateValue) ? EditorTemplateCatalog["editor_template_replace"].Attributes["use_module"].Value.TrueFalseToZeroOne() : EditorTemplateUseModuleValue.BooleanToZeroOne();
            duet.EditorTemplateUsePlugin = (PriorityForEditorTemplateValue) ? EditorTemplateCatalog["editor_template_replace"].Attributes["use_plugin"].Value.TrueFalseToZeroOne() : EditorTemplateUsePluginValue.BooleanToZeroOne();
            duet.EditorTemplateUseReplacePart = (PriorityForEditorTemplateValue) ? EditorTemplateCatalog["editor_template_replace"].Attributes["use_replace_part"].Value.TrueFalseToZeroOne() : EditorTemplateUseReplacePartValue.BooleanToZeroOne();
            duet.EditorTemplateUseFetch = (PriorityForEditorTemplateValue) ? EditorTemplateCatalog["editor_template_replace"].Attributes["use_fetch"].Value.TrueFalseToZeroOne() : EditorTemplateUseFetchValue.BooleanToZeroOne();
            duet.EditorTemplateUseItem = (PriorityForEditorTemplateValue) ? EditorTemplateCatalog["editor_template_replace"].Attributes["use_item"].Value.TrueFalseToZeroOne() : EditorTemplateUseItemValue.BooleanToZeroOne();
            duet.EditorTemplateUseElanat = (PriorityForEditorTemplateValue) ? EditorTemplateCatalog["editor_template_replace"].Attributes["use_elanat"].Value.TrueFalseToZeroOne() : EditorTemplateUseElanatValue.BooleanToZeroOne();
            duet.EditorTemplateCacheDuration = (EditorTemplateCacheDurationValue.IsNumber()) ? EditorTemplateCacheDurationValue : "0";
            duet.EditorTemplateCacheParameters = (PriorityForEditorTemplateValue) ? EditorTemplateCatalog["editor_template_cache_parameters"].InnerText : EditorTemplateCacheParametersValue;
            duet.EditorTemplatePublicAccessShow = EditorTemplatePublicAccessShowValue.BooleanToZeroOne();
            duet.EditorTemplateSortIndex = EditorTemplateSortIndexValue;
            duet.EditorTemplateActive = EditorTemplateActiveValue.BooleanToZeroOne();

            // Add Template Template
            duet.AddWithFillReturnDr();

            // Set Template Template Access Show
            duet.SetEditorTemplateAccessShow(duet.EditorTemplateId, EditorTemplateAccessShowListItem);


            try { duet.ReturnDb.Close(); } catch (Exception) { }


            // Run Install Page
            if (!HasDll)
                if (!string.IsNullOrEmpty(EditorTemplateCatalog["editor_template_install_path"].Attributes["value"].Value))
                    PageLoader.LoadWithServer("/add_on/editor_template/" + duet.EditorTemplateDirectoryPath + "/" + EditorTemplateCatalog["editor_template_install_path"].Attributes["value"].Value);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_editor_template", duet.EditorTemplateName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("editor_template_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/editor_template/action/EditorTemplateNewRow.aspx?editor_template_id=" + duet.EditorTemplateId, "div_TableBox");

            if (HasDll)
                rf.SetTmpBinAlert();

            rf.RedirectToResponseFormPage();
        }
    }
}