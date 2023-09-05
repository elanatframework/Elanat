using CodeBehind;
using SetCodeBehind;
using System.Reflection.Metadata;
using System.Xml;

namespace Elanat
{
    public partial class AdminComponentModel : CodeBehindModel
    {
        public string ComponentLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string AddComponentLanguage { get; set; }
        public string ComponentPathLanguage { get; set; }
        public string UseComponentPathLanguage { get; set; }
        public string PriorityForComponentLanguage { get; set; }
        public string ComponentCategoryLanguage { get; set; }
        public string ComponentLoadTypeLanguage { get; set; }
        public string ComponentActiveLanguage { get; set; }
        public string ComponentUseLanguageLanguage { get; set; }
        public string ComponentUseModuleLanguage { get; set; }
        public string ComponentUsePluginLanguage { get; set; }
        public string ComponentUseReplacePartLanguage { get; set; }
        public string ComponentUseFetchLanguage { get; set; }
        public string ComponentUseItemLanguage { get; set; }
        public string ComponentUseElanatLanguage { get; set; }
        public string ComponentCacheDurationLanguage { get; set; }
        public string ComponentCacheParametersLanguage { get; set; }
        public string ComponentSortIndexLanguage { get; set; }
        public string ComponentAccessShowLanguage { get; set; }
        public string ComponentPublicAccessShowLanguage { get; set; }
        public string ComponentAccessAddLanguage { get; set; }
        public string ComponentPublicAccessAddLanguage { get; set; }
        public string ComponentAccessEditOwnLanguage { get; set; }
        public string ComponentPublicAccessEditOwnLanguage { get; set; }
        public string ComponentAccessDeleteOwnLanguage { get; set; }
        public string ComponentPublicAccessDeleteOwnLanguage { get; set; }
        public string ComponentAccessEditAllLanguage { get; set; }
        public string ComponentPublicAccessEditAllLanguage { get; set; }
        public string ComponentAccessDeleteAllLanguage { get; set; }
        public string ComponentPublicAccessDeleteAllLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool PriorityForComponentValue { get; set; } = true;
        public bool ComponentActiveValue { get; set; } = false;
        public bool ComponentUseLanguageValue { get; set; } = false;
        public bool ComponentUseModuleValue { get; set; } = false;
        public bool ComponentUsePluginValue { get; set; } = false;
        public bool ComponentUseReplacePartValue { get; set; } = false;
        public bool ComponentUseFetchValue { get; set; } = false;
        public bool ComponentUseItemValue { get; set; } = false;
        public bool ComponentUseElanatValue { get; set; } = false;
        public bool ComponentPublicAccessShowValue { get; set; } = false;
        public bool ComponentPublicAccessAddValue { get; set; } = false;
        public bool ComponentPublicAccessEditOwnValue { get; set; } = false;
        public bool ComponentPublicAccessDeleteOwnValue { get; set; } = false;
        public bool ComponentPublicAccessEditAllValue { get; set; } = false;
        public bool ComponentPublicAccessDeleteAllValue { get; set; } = false;

        public bool UseComponentPathValue { get; set; } = false;
        public IFormFile ComponentPathUploadValue { get; set; }
        public string ComponentPathTextValue { get; set; }

        public string ComponentLoadTypeOptionListValue { get; set; }
        public string ComponentLoadTypeOptionListSelectedValue { get; set; }

        public string ComponentCategoryValue { get; set; }
        public string ComponentCacheDurationValue { get; set; }
        public string ComponentCacheParametersValue { get; set; }
        public string ComponentSortIndexValue { get; set; }

        public string ComponentCategoryAttribute { get; set; }
        public string ComponentCacheDurationAttribute { get; set; }
        public string ComponentCacheParametersAttribute { get; set; }
        public string ComponentSortIndexAttribute { get; set; }
        public string ComponentLoadTypeAttribute { get; set; }

        public string ComponentCategoryCssClass { get; set; }
        public string ComponentCacheDurationCssClass { get; set; }
        public string ComponentCacheParametersCssClass { get; set; }
        public string ComponentSortIndexCssClass { get; set; }
        public string ComponentLoadTypeCssClass { get; set; }

        public List<ListItem> ComponentAccessShowListItem = new List<ListItem>();
        public string ComponentAccessShowListValue { get; set; }
        public string ComponentAccessShowTemplateValue { get; set; }
        public List<ListItem> ComponentAccessAddListItem = new List<ListItem>();
        public string ComponentAccessAddListValue { get; set; }
        public string ComponentAccessAddTemplateValue { get; set; }
        public List<ListItem> ComponentAccessEditOwnListItem = new List<ListItem>();
        public string ComponentAccessEditOwnListValue { get; set; }
        public string ComponentAccessEditOwnTemplateValue { get; set; }
        public List<ListItem> ComponentAccessDeleteOwnListItem = new List<ListItem>();
        public string ComponentAccessDeleteOwnListValue { get; set; }
        public string ComponentAccessDeleteOwnTemplateValue { get; set; }
        public List<ListItem> ComponentAccessEditAllListItem = new List<ListItem>();
        public string ComponentAccessEditAllListValue { get; set; }
        public string ComponentAccessEditAllTemplateValue { get; set; }
        public List<ListItem> ComponentAccessDeleteAllListItem = new List<ListItem>();
        public string ComponentAccessDeleteAllListValue { get; set; }
        public string ComponentAccessDeleteAllTemplateValue { get; set; }

        public string ComponentAccessShowAttribute { get; set; }
        public string ComponentAccessShowCssClass { get; set; }
        public string ComponentAccessAddAttribute { get; set; }
        public string ComponentAccessAddCssClass { get; set; }
        public string ComponentAccessEditOwnAttribute { get; set; }
        public string ComponentAccessEditOwnCssClass { get; set; }
        public string ComponentAccessDeleteOwnAttribute { get; set; }
        public string ComponentAccessDeleteOwnCssClass { get; set; }
        public string ComponentAccessEditAllAttribute { get; set; }
        public string ComponentAccessEditAllCssClass { get; set; }
        public string ComponentAccessDeleteAllAttribute { get; set; }
        public string ComponentAccessDeleteAllCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/");
            ComponentPathLanguage = aol.GetAddOnsLanguage("component_path");
            ComponentLanguage = aol.GetAddOnsLanguage("component");
            AddComponentLanguage = aol.GetAddOnsLanguage("add_component");
            UseComponentPathLanguage = aol.GetAddOnsLanguage("use_component_path");
            PriorityForComponentLanguage = aol.GetAddOnsLanguage("priority_for_component");
            ComponentCategoryLanguage = aol.GetAddOnsLanguage("component_category");
            ComponentLoadTypeLanguage = aol.GetAddOnsLanguage("component_load_type");
            ComponentAccessShowLanguage = aol.GetAddOnsLanguage("component_access_show");
            ComponentPublicAccessShowLanguage = aol.GetAddOnsLanguage("component_public_access_show");
            ComponentPublicAccessAddLanguage = aol.GetAddOnsLanguage("component_public_access_add");
            ComponentPublicAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("component_public_access_delete_own");
            ComponentPublicAccessDeleteAllLanguage = aol.GetAddOnsLanguage("component_public_access_delete_all");
            ComponentPublicAccessEditOwnLanguage = aol.GetAddOnsLanguage("component_public_access_edit_own");
            ComponentPublicAccessEditAllLanguage = aol.GetAddOnsLanguage("component_public_access_edit_all");
            ComponentAccessAddLanguage = aol.GetAddOnsLanguage("component_access_add"); ;
            ComponentAccessEditOwnLanguage = aol.GetAddOnsLanguage("component_access_edit_own");
            ComponentAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("component_access_delete_own");
            ComponentAccessEditAllLanguage = aol.GetAddOnsLanguage("component_access_edit_all");
            ComponentAccessDeleteAllLanguage = aol.GetAddOnsLanguage("component_access_delete_all");
            ComponentSortIndexLanguage = aol.GetAddOnsLanguage("component_sort_index");
            ComponentActiveLanguage = aol.GetAddOnsLanguage("component_active");
            AddLanguage = aol.GetAddOnsLanguage("add");
            ComponentCacheDurationLanguage = aol.GetAddOnsLanguage("component_cache_duration");
            ComponentCacheParametersLanguage = aol.GetAddOnsLanguage("component_cache_parameters");
            ComponentUseLanguageLanguage = aol.GetAddOnsLanguage("component_use_language");
            ComponentUseModuleLanguage = aol.GetAddOnsLanguage("component_use_module");
            ComponentUsePluginLanguage = aol.GetAddOnsLanguage("component_use_plugin");
            ComponentUseReplacePartLanguage = aol.GetAddOnsLanguage("component_use_replace_part");
            ComponentUseFetchLanguage = aol.GetAddOnsLanguage("component_use_fetch");
            ComponentUseItemLanguage = aol.GetAddOnsLanguage("component_use_item");
            ComponentUseElanatLanguage = aol.GetAddOnsLanguage("component_use_elanat");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Page Loader Item
            ListClass.PageLoadType lcplt = new ListClass.PageLoadType();
            lcplt.FillPageLoadTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ComponentLoadTypeOptionListValue += lcplt.PageLoadTypeListItem.HtmlInputToOptionTag(ComponentLoadTypeOptionListSelectedValue);

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Component Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/component/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ComponentAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lcu.UserRoleListItem);
            ComponentAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            ComponentAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            ComponentAccessShowTemplateValue = ComponentAccessShowTemplateValue.Replace("$_asp attribute;", ComponentAccessShowAttribute);
            ComponentAccessShowTemplateValue = ComponentAccessShowTemplateValue.Replace("$_asp css_class;", ComponentAccessShowCssClass);
            ComponentAccessShowTemplateValue = ComponentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(ComponentAccessShowListItem);

            // Component Access Add
            HtmlCheckBoxList HtmlCheckBoxListAccessAdd = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/component/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ComponentAccessAdd");
            HtmlCheckBoxListAccessAdd.AddRange(lcu.UserRoleListItem);
            ComponentAccessAddTemplateValue = HtmlCheckBoxListAccessAdd.GetValue();
            ComponentAccessAddListValue = HtmlCheckBoxListAccessAdd.GetList();
            ComponentAccessAddTemplateValue = ComponentAccessAddTemplateValue.Replace("$_asp attribute;", ComponentAccessAddAttribute);
            ComponentAccessAddTemplateValue = ComponentAccessAddTemplateValue.Replace("$_asp css_class;", ComponentAccessAddCssClass);
            ComponentAccessAddTemplateValue = ComponentAccessAddTemplateValue.HtmlInputSetCheckBoxListValue(ComponentAccessAddListItem);

            // Component Access Delete All
            HtmlCheckBoxList HtmlCheckBoxListAccessDeleteAll = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/component/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ComponentAccessDeleteAll");
            HtmlCheckBoxListAccessDeleteAll.AddRange(lcu.UserRoleListItem);
            ComponentAccessDeleteAllTemplateValue = HtmlCheckBoxListAccessDeleteAll.GetValue();
            ComponentAccessDeleteAllListValue = HtmlCheckBoxListAccessDeleteAll.GetList();
            ComponentAccessDeleteAllTemplateValue = ComponentAccessDeleteAllTemplateValue.Replace("$_asp attribute;", ComponentAccessDeleteAllAttribute);
            ComponentAccessDeleteAllTemplateValue = ComponentAccessDeleteAllTemplateValue.Replace("$_asp css_class;", ComponentAccessDeleteAllCssClass);
            ComponentAccessDeleteAllTemplateValue = ComponentAccessDeleteAllTemplateValue.HtmlInputSetCheckBoxListValue(ComponentAccessDeleteAllListItem);

            // Component Access Delete Own
            HtmlCheckBoxList HtmlCheckBoxListAccessDeleteOwn = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/component/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ComponentAccessDeleteOwn");
            HtmlCheckBoxListAccessDeleteOwn.AddRange(lcu.UserRoleListItem);
            ComponentAccessDeleteOwnTemplateValue = HtmlCheckBoxListAccessDeleteOwn.GetValue();
            ComponentAccessDeleteOwnListValue = HtmlCheckBoxListAccessDeleteOwn.GetList();
            ComponentAccessDeleteOwnTemplateValue = ComponentAccessDeleteOwnTemplateValue.Replace("$_asp attribute;", ComponentAccessDeleteOwnAttribute);
            ComponentAccessDeleteOwnTemplateValue = ComponentAccessDeleteOwnTemplateValue.Replace("$_asp css_class;", ComponentAccessDeleteOwnCssClass);
            ComponentAccessDeleteOwnTemplateValue = ComponentAccessDeleteOwnTemplateValue.HtmlInputSetCheckBoxListValue(ComponentAccessDeleteOwnListItem);

            // Component Access Edit All
            HtmlCheckBoxList HtmlCheckBoxListAccessEditAll = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/component/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ComponentAccessEditAll");
            HtmlCheckBoxListAccessEditAll.AddRange(lcu.UserRoleListItem);
            ComponentAccessEditAllTemplateValue = HtmlCheckBoxListAccessEditAll.GetValue();
            ComponentAccessEditAllListValue = HtmlCheckBoxListAccessEditAll.GetList();
            ComponentAccessEditAllTemplateValue = ComponentAccessEditAllTemplateValue.Replace("$_asp attribute;", ComponentAccessEditAllAttribute);
            ComponentAccessEditAllTemplateValue = ComponentAccessEditAllTemplateValue.Replace("$_asp css_class;", ComponentAccessEditAllCssClass);
            ComponentAccessEditAllTemplateValue = ComponentAccessEditAllTemplateValue.HtmlInputSetCheckBoxListValue(ComponentAccessEditAllListItem);

            // Component Access Edit Own
            HtmlCheckBoxList HtmlCheckBoxListAccessEditOwn = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/component/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ComponentAccessEditOwn");
            HtmlCheckBoxListAccessEditOwn.AddRange(lcu.UserRoleListItem);
            ComponentAccessEditOwnTemplateValue = HtmlCheckBoxListAccessEditOwn.GetValue();
            ComponentAccessEditOwnListValue = HtmlCheckBoxListAccessEditOwn.GetList();
            ComponentAccessEditOwnTemplateValue = ComponentAccessEditOwnTemplateValue.Replace("$_asp attribute;", ComponentAccessEditOwnAttribute);
            ComponentAccessEditOwnTemplateValue = ComponentAccessEditOwnTemplateValue.Replace("$_asp css_class;", ComponentAccessEditOwnCssClass);
            ComponentAccessEditOwnTemplateValue = ComponentAccessEditOwnTemplateValue.HtmlInputSetCheckBoxListValue(ComponentAccessEditOwnListItem);


            PriorityForComponentValue = true;
            ComponentCacheDurationValue = "0";
            ComponentSortIndexValue = "0";


            // Set Component Page List
            ActionGetComponentListModel lm = new ActionGetComponentListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_ComponentCategory", "");
            InputRequest.Add("ddlst_ComponentLoadType", ComponentLoadTypeOptionListValue);
            InputRequest.Add("txt_ComponentCacheDuration", "");
            InputRequest.Add("txt_ComponentCacheParameters", "");
            InputRequest.Add("txt_ComponentSortIndex", "");
            InputRequest.Add("cbxlst_ComponentAccessShow", ComponentAccessShowListValue);
            InputRequest.Add("cbxlst_ComponentAccessAdd", ComponentAccessAddListValue);
            InputRequest.Add("cbxlst_ComponentAccessDeleteOwn", ComponentAccessDeleteOwnListValue);
            InputRequest.Add("cbxlst_ComponentAccessEditOwn", ComponentAccessEditOwnListValue);
            InputRequest.Add("cbxlst_ComponentAccessDeleteAll", ComponentAccessDeleteAllListValue);
            InputRequest.Add("cbxlst_ComponentAccessEditAll", ComponentAccessEditAllListValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/component/");

            ComponentCategoryAttribute += vc.ImportantInputAttribute.GetValue("txt_ComponentCategory");
            ComponentLoadTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ComponentLoadType");
            ComponentCacheDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_ComponentCacheDuration");
            ComponentCacheParametersAttribute += vc.ImportantInputAttribute.GetValue("txt_ComponentCacheParameters");
            ComponentSortIndexAttribute += vc.ImportantInputAttribute.GetValue("txt_ComponentSortIndex");
            ComponentAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ComponentAccessShow");
            ComponentAccessAddAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ComponentAccessAdd");
            ComponentAccessDeleteOwnAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ComponentAccessDeleteOwn");
            ComponentAccessEditOwnAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ComponentAccessEditOwn");
            ComponentAccessDeleteAllAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ComponentAccessDeleteAll");
            ComponentAccessEditAllAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ComponentAccessEditAll");

            ComponentCategoryCssClass = ComponentCategoryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ComponentCategory"));
            ComponentLoadTypeCssClass = ComponentLoadTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ComponentLoadType"));
            ComponentCacheDurationCssClass = ComponentCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ComponentCacheDuration"));
            ComponentCacheParametersCssClass = ComponentCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ComponentCacheParameters"));
            ComponentSortIndexCssClass = ComponentSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ComponentSortIndex"));
            ComponentAccessShowCssClass = ComponentAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ComponentAccessShow"));
            ComponentAccessAddCssClass = ComponentAccessAddCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ComponentAccessAdd"));
            ComponentAccessDeleteOwnCssClass = ComponentAccessDeleteOwnCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ComponentAccessDeleteOwn"));
            ComponentAccessEditOwnCssClass = ComponentAccessEditOwnCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ComponentAccessEditOwn"));
            ComponentAccessDeleteAllCssClass = ComponentAccessDeleteAllCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ComponentAccessDeleteAll"));
            ComponentAccessEditAllCssClass = ComponentAccessEditAllCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ComponentAccessEditAll"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/component/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void AddComponent()
        {
            string ComponentFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Component Path
            if (UseComponentPathValue)
            {
                if (string.IsNullOrEmpty(ComponentPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_component_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                ComponentFilePhysicalName = Path.GetFileName(ComponentPathTextValue);

                FileExtension = Path.GetExtension(ComponentFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(ComponentFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                webClient.DownloadFile(ComponentPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ComponentFilePhysicalName));
            }
            else
            {
                if (!ComponentPathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_component_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/"), "problem");

                    return;
                }

                ComponentFilePhysicalName = ComponentPathUploadValue.FileName;

                FileExtension = Path.GetExtension(ComponentFilePhysicalName);

                if (FileExtension != ".zip")
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(ComponentFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                ComponentPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ComponentFilePhysicalName));
            }

            // Check Component File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ComponentFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_component").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            // Extract Zip File
            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ComponentFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/component")))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/"), "warning");

                return;
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/component/catalog.xml"));

            XmlNode ComponentCatalog = CatalogDocument.SelectSingleNode("/component_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_component", "component_name", ComponentCatalog["component_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("component_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/"), "problem");

                return;
            }


            string ComponentDirectoryPath = ComponentCatalog["component_directory_path"].Attributes["value"].Value;
            ComponentDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.AdminPath), ComponentDirectoryPath);

            bool HasDll = false;

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (ComponentDirectoryPath != ComponentCatalog["component_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Component File In "component" Directory To Component
            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/component/"), StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + ComponentDirectoryPath));

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

                UninstallDocument.Save(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + ComponentDirectoryPath + "/uninstall.xml"));

                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
            }

            // Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.Component duc = new DataUse.Component();

            duc.ComponentName = ComponentCatalog["component_name"].Attributes["value"].Value;
            duc.ComponentCategory = (PriorityForComponentValue) ? ComponentCatalog["component_category"].Attributes["value"].Value.SpaceToUnderline() : ComponentCategoryValue.SpaceToUnderline();
            duc.ComponentDirectoryPath = ComponentDirectoryPath;
            duc.ComponentPhysicalName = ComponentCatalog["component_physical_name"].Attributes["value"].Value;
            duc.ComponentLoadType = (PriorityForComponentValue) ? ComponentCatalog["component_best_load_status"].Attributes["value"].Value : ComponentLoadTypeOptionListSelectedValue;
            duc.ComponentUseLanguage = (PriorityForComponentValue) ? ComponentCatalog["component_replace"].Attributes["use_language"].Value.TrueFalseToZeroOne() : ComponentUseLanguageValue.BooleanToZeroOne();
            duc.ComponentUseModule = (PriorityForComponentValue) ? ComponentCatalog["component_replace"].Attributes["use_module"].Value.TrueFalseToZeroOne() : ComponentUseModuleValue.BooleanToZeroOne();
            duc.ComponentUsePlugin = (PriorityForComponentValue) ? ComponentCatalog["component_replace"].Attributes["use_plugin"].Value.TrueFalseToZeroOne() : ComponentUsePluginValue.BooleanToZeroOne();
            duc.ComponentUseReplacePart = (PriorityForComponentValue) ? ComponentCatalog["component_replace"].Attributes["use_replace_part"].Value.TrueFalseToZeroOne() : ComponentUseReplacePartValue.BooleanToZeroOne();
            duc.ComponentUseFetch = (PriorityForComponentValue) ? ComponentCatalog["component_replace"].Attributes["use_fetch"].Value.TrueFalseToZeroOne() : ComponentUseFetchValue.BooleanToZeroOne();
            duc.ComponentUseItem = (PriorityForComponentValue) ? ComponentCatalog["component_replace"].Attributes["use_item"].Value.TrueFalseToZeroOne() : ComponentUseItemValue.BooleanToZeroOne();
            duc.ComponentUseElanat = (PriorityForComponentValue) ? ComponentCatalog["component_replace"].Attributes["use_elanat"].Value.TrueFalseToZeroOne() : ComponentUseElanatValue.BooleanToZeroOne();
            duc.ComponentCacheDuration = (ComponentCacheDurationValue.IsNumber()) ? ComponentCacheDurationValue : "0";
            duc.ComponentCacheParameters = (PriorityForComponentValue) ? ComponentCatalog["component_cache_parameters"].InnerText : ComponentCacheParametersValue;
            duc.ComponentPublicAccessAdd = ComponentPublicAccessAddValue.BooleanToZeroOne();
            duc.ComponentPublicAccessEditOwn = ComponentPublicAccessEditOwnValue.BooleanToZeroOne();
            duc.ComponentPublicAccessDeleteOwn = ComponentPublicAccessDeleteOwnValue.BooleanToZeroOne();
            duc.ComponentPublicAccessEditAll = ComponentPublicAccessEditAllValue.BooleanToZeroOne();
            duc.ComponentPublicAccessDeleteAll = ComponentPublicAccessDeleteAllValue.BooleanToZeroOne();
            duc.ComponentPublicAccessShow = ComponentPublicAccessShowValue.BooleanToZeroOne();
            duc.ComponentSortIndex = ComponentSortIndexValue;
            duc.ComponentActive = ComponentActiveValue.BooleanToZeroOne();

            // Add Component
            duc.AddWithFillReturnDr();

            // Set Component Role Access
            duc.SetComponentRoleAccess(duc.ComponentId, ComponentAccessShowListItem, ComponentAccessAddListItem, ComponentAccessEditOwnListItem, ComponentAccessDeleteOwnListItem, ComponentAccessEditAllListItem, ComponentAccessDeleteAllListItem);


            try { duc.ReturnDb.Close(); } catch (Exception) { }


            // Recompile
            if (HasDll)
            {
                CodeBehindCompiler.Initialization();
                CodeBehindCompiler.CompileAspx();
            }

            // Run Install Page
            if (!string.IsNullOrEmpty(ComponentCatalog["component_install_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.AdminPath + "/" + duc.ComponentDirectoryPath + "/" + ComponentCatalog["component_install_path"].Attributes["value"].Value, false);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_component", duc.ComponentName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("component_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/component/action/ComponentNewRow.aspx?component_id=" + duc.ComponentId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}