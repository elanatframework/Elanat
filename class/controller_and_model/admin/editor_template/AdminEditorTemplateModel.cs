using CodeBehind;
using SetCodeBehind;
using System.Reflection.Metadata;
using System.Xml;

namespace Elanat
{
    public partial class AdminEditorTemplateModel : CodeBehindModel
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
        public IFormFile EditorTemplatePathUploadValue { get; set; }
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

        public List<ListItem> EditorTemplateAccessShowListItem = new List<ListItem>();
        public string EditorTemplateAccessShowListValue { get; set; }
        public string EditorTemplateAccessShowTemplateValue { get; set; }

        public string EditorTemplateAccessShowAttribute { get; set; }
        public string EditorTemplateAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
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


            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Editor Template Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/editor_template/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_EditorTemplateAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lcu.UserRoleListItem);
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
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_EditorTemplateCategory", "");
            InputRequest.Add("txt_EditorTemplateCacheDuration", "");
            InputRequest.Add("txt_EditorTemplateCacheParameters", "");
            InputRequest.Add("txt_EditorTemplateSortIndex", "");
            InputRequest.Add("cbxlst_EditorTemplateAccessShow", EditorTemplateAccessShowListValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/editor_template/");

            EditorTemplateCategoryAttribute += vc.ImportantInputAttribute.GetValue("txt_EditorTemplateCategory");
            EditorTemplateCacheDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_EditorTemplateCacheDuration");
            EditorTemplateCacheParametersAttribute += vc.ImportantInputAttribute.GetValue("txt_EditorTemplateCacheParameters");
            EditorTemplateSortIndexAttribute += vc.ImportantInputAttribute.GetValue("txt_EditorTemplateSortIndex");
            EditorTemplateAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_EditorTemplateAccessShow");

            EditorTemplateCategoryCssClass = EditorTemplateCategoryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_EditorTemplateCategory"));
            EditorTemplateCacheDurationCssClass = EditorTemplateCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_EditorTemplateCacheDuration"));
            EditorTemplateCacheParametersCssClass = EditorTemplateCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_EditorTemplateCacheParameters"));
            EditorTemplateSortIndexCssClass = EditorTemplateSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_EditorTemplateSortIndex"));
            EditorTemplateAccessShowCssClass = EditorTemplateAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_EditorTemplateAccessShow"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/editor_template/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
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
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_editor_template_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                EditorTemplateFilePhysicalName = Path.GetFileName(EditorTemplatePathTextValue);

                FileExtension = Path.GetExtension(EditorTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(EditorTemplateFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                webClient.DownloadFile(EditorTemplatePathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + EditorTemplateFilePhysicalName));
            }
            else
            {
                if (!EditorTemplatePathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_editor_template_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "problem");

                    return;
                }

                EditorTemplateFilePhysicalName = EditorTemplatePathUploadValue.FileName;

                FileExtension = Path.GetExtension(EditorTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(EditorTemplateFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                EditorTemplatePathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + EditorTemplateFilePhysicalName));
            }

            // Check Editor Template File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + EditorTemplateFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_editor_template").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            // Extract Zip File
            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + EditorTemplateFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/editor_template")))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "warning");

                return;
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/editor_template/catalog.xml"));

            XmlNode EditorTemplateCatalog = CatalogDocument.SelectSingleNode("/editor_template_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/");

            if (common.ExistValueToColumnCheck("el_editor_template", "editor_template_name", EditorTemplateCatalog["editor_template_name"].Attributes["value"].Value))
            {
                Write(aol.GetAddOnsLanguage("editor_template_name_is_duplicate"));

                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);
                return;
            }


            string EditorTemplateDirectoryPath = EditorTemplateCatalog["editor_template_directory_path"].Attributes["value"].Value;
            EditorTemplateDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/editor_template/"), EditorTemplateDirectoryPath);

            bool HasDll = false;

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (EditorTemplateDirectoryPath != EditorTemplateCatalog["editor_template_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Editor Template File In "editor_template" Directory To Editor Template
            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/editor_template/"), StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/editor_template/" + EditorTemplateDirectoryPath));

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

                UninstallDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/editor_template/" + EditorTemplateDirectoryPath + "/uninstall.xml"));


                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
            }

            // Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


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


            // Recompile
            if (HasDll)
            {
                CodeBehindCompiler.Initialization();
                CodeBehindCompiler.CompileAspx();
            }

            // Run Install Page
            if (!string.IsNullOrEmpty(EditorTemplateCatalog["editor_template_install_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.SitePath + "add_on/editor_template/" + duet.EditorTemplateDirectoryPath + "/" + EditorTemplateCatalog["editor_template_install_path"].Attributes["value"].Value, false);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_editor_template", duet.EditorTemplateName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("editor_template_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/editor_template/action/EditorTemplateNewRow.aspx?editor_template_id=" + duet.EditorTemplateId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}