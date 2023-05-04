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
    public class AdminModuleModel
    {
        public string ModuleLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string AddModuleLanguage { get; set; }
        public string ModulePathLanguage { get; set; }
        public string UseModulePathLanguage { get; set; }
        public string PriorityForModuleLanguage { get; set; }
        public string ModuleCategoryLanguage { get; set; }
        public string ModuleLoadTypeLanguage { get; set; }
        public string ModuleActiveLanguage { get; set; }
        public string ModuleUseLanguageLanguage { get; set; }
        public string ModuleUseModuleLanguage { get; set; }
        public string ModuleUsePluginLanguage { get; set; }
        public string ModuleUseReplacePartLanguage { get; set; }
        public string ModuleUseFetchLanguage { get; set; }
        public string ModuleUseItemLanguage { get; set; }
        public string ModuleUseElanatLanguage { get; set; }
        public string ModuleCacheDurationLanguage { get; set; }
        public string ModuleCacheParametersLanguage { get; set; }
        public string ModuleMenuLanguage { get; set; }
        public string ModuleMenuQueryStringLanguage { get; set; }
        public string ModuleSortIndexLanguage { get; set; }
        public string ModuleAccessShowLanguage { get; set; }
        public string ModulePublicAccessShowLanguage { get; set; }
        public string ModuleAccessAddLanguage { get; set; }
        public string ModulePublicAccessAddLanguage { get; set; }
        public string ModuleAccessEditOwnLanguage { get; set; }
        public string ModulePublicAccessEditOwnLanguage { get; set; }
        public string ModuleAccessDeleteOwnLanguage { get; set; }
        public string ModulePublicAccessDeleteOwnLanguage { get; set; }
        public string ModuleAccessEditAllLanguage { get; set; }
        public string ModulePublicAccessEditAllLanguage { get; set; }
        public string ModuleAccessDeleteAllLanguage { get; set; }
        public string ModulePublicAccessDeleteAllLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool PriorityForModuleValue { get; set; } = true;
        public bool ModuleActiveValue { get; set; } = false;
        public bool ModuleUseLanguageValue { get; set; } = false;
        public bool ModuleUseModuleValue { get; set; } = false;
        public bool ModuleUsePluginValue { get; set; } = false;
        public bool ModuleUseReplacePartValue { get; set; } = false;
        public bool ModuleUseFetchValue { get; set; } = false;
        public bool ModuleUseItemValue { get; set; } = false;
        public bool ModuleUseElanatValue { get; set; } = false;
        public bool ModulePublicAccessShowValue { get; set; } = false;
        public bool ModulePublicAccessAddValue { get; set; } = false;
        public bool ModulePublicAccessEditOwnValue { get; set; } = false;
        public bool ModulePublicAccessDeleteOwnValue { get; set; } = false;
        public bool ModulePublicAccessEditAllValue { get; set; } = false;
        public bool ModulePublicAccessDeleteAllValue { get; set; } = false;

        public bool UseModulePathValue { get; set; } = false;
        public HttpPostedFile ModulePathUploadValue { get; set; }
        public string ModulePathTextValue { get; set; }

        public string ModuleLoadTypeOptionListValue { get; set; }
        public string ModuleLoadTypeOptionListSelectedValue { get; set; }

        public string ModuleCategoryValue { get; set; }
        public string ModuleCacheDurationValue { get; set; }
        public string ModuleCacheParametersValue { get; set; }
        public string ModuleSortIndexValue { get; set; }

        public string ModuleCategoryAttribute { get; set; }
        public string ModuleCacheDurationAttribute { get; set; }
        public string ModuleCacheParametersAttribute { get; set; }
        public string ModuleSortIndexAttribute { get; set; }
        public string ModuleLoadTypeAttribute { get; set; }

        public string ModuleCategoryCssClass { get; set; }
        public string ModuleCacheDurationCssClass { get; set; }
        public string ModuleCacheParametersCssClass { get; set; }
        public string ModuleSortIndexCssClass { get; set; }
        public string ModuleLoadTypeCssClass { get; set; }

        public ListItemCollection ModuleMenuListItem = new ListItemCollection();
        public string ModuleMenuListValue { get; set; }
        public string ModuleMenuTemplateValue { get; set; }
        public ListItemCollection ModuleAccessShowListItem = new ListItemCollection();
        public string ModuleAccessShowListValue { get; set; }
        public string ModuleAccessShowTemplateValue { get; set; }
        public ListItemCollection ModuleAccessAddListItem = new ListItemCollection();
        public string ModuleAccessAddListValue { get; set; }
        public string ModuleAccessAddTemplateValue { get; set; }
        public ListItemCollection ModuleAccessEditOwnListItem = new ListItemCollection();
        public string ModuleAccessEditOwnListValue { get; set; }
        public string ModuleAccessEditOwnTemplateValue { get; set; }
        public ListItemCollection ModuleAccessDeleteOwnListItem = new ListItemCollection();
        public string ModuleAccessDeleteOwnListValue { get; set; }
        public string ModuleAccessDeleteOwnTemplateValue { get; set; }
        public ListItemCollection ModuleAccessEditAllListItem = new ListItemCollection();
        public string ModuleAccessEditAllListValue { get; set; }
        public string ModuleAccessEditAllTemplateValue { get; set; }
        public ListItemCollection ModuleAccessDeleteAllListItem = new ListItemCollection();
        public string ModuleAccessDeleteAllListValue { get; set; }
        public string ModuleAccessDeleteAllTemplateValue { get; set; }

        public string ModuleMenuAttribute { get; set; }
        public string ModuleMenuCssClass { get; set; }
        public string ModuleAccessShowAttribute { get; set; }
        public string ModuleAccessShowCssClass { get; set; }
        public string ModuleAccessAddAttribute { get; set; }
        public string ModuleAccessAddCssClass { get; set; }
        public string ModuleAccessEditOwnAttribute { get; set; }
        public string ModuleAccessEditOwnCssClass { get; set; }
        public string ModuleAccessDeleteOwnAttribute { get; set; }
        public string ModuleAccessDeleteOwnCssClass { get; set; }
        public string ModuleAccessEditAllAttribute { get; set; }
        public string ModuleAccessEditAllCssClass { get; set; }
        public string ModuleAccessDeleteAllAttribute { get; set; }
        public string ModuleAccessDeleteAllCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/");
            ModuleMenuLanguage = aol.GetAddOnsLanguage("module_menu");
            ModulePathLanguage = aol.GetAddOnsLanguage("module_path");
            AddModuleLanguage = aol.GetAddOnsLanguage("add_module");
            ModuleLanguage = aol.GetAddOnsLanguage("module");
            UseModulePathLanguage = aol.GetAddOnsLanguage("use_module_path");
            PriorityForModuleLanguage = aol.GetAddOnsLanguage("priority_for_module");
            ModuleCategoryLanguage = aol.GetAddOnsLanguage("module_category");
            ModuleLoadTypeLanguage = aol.GetAddOnsLanguage("module_load_type");
            ModuleAccessShowLanguage = aol.GetAddOnsLanguage("module_access_show");
            ModulePublicAccessShowLanguage = aol.GetAddOnsLanguage("module_public_access_show");
            ModulePublicAccessAddLanguage = aol.GetAddOnsLanguage("module_public_access_add");
            ModulePublicAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("module_public_access_delete_own");
            ModulePublicAccessDeleteAllLanguage = aol.GetAddOnsLanguage("module_public_access_delete_all");
            ModulePublicAccessEditOwnLanguage = aol.GetAddOnsLanguage("module_public_access_edit_own");
            ModulePublicAccessEditAllLanguage = aol.GetAddOnsLanguage("module_public_access_edit_all");
            ModuleAccessAddLanguage = aol.GetAddOnsLanguage("module_access_add");
            ModuleAccessEditOwnLanguage = aol.GetAddOnsLanguage("module_access_edit_own");
            ModuleAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("module_access_delete_own");
            ModuleAccessEditAllLanguage = aol.GetAddOnsLanguage("module_access_edit_all");
            ModuleAccessDeleteAllLanguage = aol.GetAddOnsLanguage("module_access_delete_all");
            ModuleSortIndexLanguage = aol.GetAddOnsLanguage("module_sort_index");
            ModuleMenuQueryStringLanguage = aol.GetAddOnsLanguage("module_menu_query_string");
            ModuleActiveLanguage = aol.GetAddOnsLanguage("module_active");
            AddLanguage = aol.GetAddOnsLanguage("add");
            ModuleCacheDurationLanguage = aol.GetAddOnsLanguage("module_cache_duration");
            ModuleCacheParametersLanguage = aol.GetAddOnsLanguage("module_cache_parameters");
            ModuleUseLanguageLanguage = aol.GetAddOnsLanguage("module_use_language");
            ModuleUseModuleLanguage = aol.GetAddOnsLanguage("module_use_module");
            ModuleUsePluginLanguage = aol.GetAddOnsLanguage("module_use_plugin");
            ModuleUseReplacePartLanguage = aol.GetAddOnsLanguage("module_use_replace_part");
            ModuleUseFetchLanguage = aol.GetAddOnsLanguage("module_use_fetch");
            ModuleUseItemLanguage = aol.GetAddOnsLanguage("module_use_item");
            ModuleUseElanatLanguage = aol.GetAddOnsLanguage("module_use_elanat");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Page Loader Item
            lc.FillPageLoadTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ModuleLoadTypeOptionListValue += lc.PageLoadTypeListItem.HtmlInputToOptionTag(ModuleLoadTypeOptionListSelectedValue);

            // Set Menu
            lc.FillMenuListItem(StaticObject.GetCurrentSiteSiteId());
            HtmlCheckBoxList HtmlCheckBoxListMenu = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleMenu");
            HtmlCheckBoxListMenu.AddRange(lc.MenuListItem);
            ModuleMenuTemplateValue = HtmlCheckBoxListMenu.GetValue();
            ModuleMenuListValue = HtmlCheckBoxListMenu.GetList();
            ModuleMenuTemplateValue = ModuleMenuTemplateValue.Replace("$_asp attribute;", ModuleMenuAttribute);
            ModuleMenuTemplateValue = ModuleMenuTemplateValue.Replace("$_asp css_class;", ModuleMenuCssClass);
            ModuleMenuTemplateValue = ModuleMenuTemplateValue.HtmlInputSetCheckBoxListValue(ModuleMenuListItem);

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Module Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lc.UserRoleListItem);
            ModuleAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            ModuleAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            ModuleAccessShowTemplateValue = ModuleAccessShowTemplateValue.Replace("$_asp attribute;", ModuleAccessShowAttribute);
            ModuleAccessShowTemplateValue = ModuleAccessShowTemplateValue.Replace("$_asp css_class;", ModuleAccessShowCssClass);
            ModuleAccessShowTemplateValue = ModuleAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessShowListItem);

            // Module Access Add
            HtmlCheckBoxList HtmlCheckBoxListAccessAdd = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessAdd");
            HtmlCheckBoxListAccessAdd.AddRange(lc.UserRoleListItem);
            ModuleAccessAddTemplateValue = HtmlCheckBoxListAccessAdd.GetValue();
            ModuleAccessAddListValue = HtmlCheckBoxListAccessAdd.GetList();
            ModuleAccessAddTemplateValue = ModuleAccessAddTemplateValue.Replace("$_asp attribute;", ModuleAccessAddAttribute);
            ModuleAccessAddTemplateValue = ModuleAccessAddTemplateValue.Replace("$_asp css_class;", ModuleAccessAddCssClass);
            ModuleAccessAddTemplateValue = ModuleAccessAddTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessAddListItem);

            // Module Access Delete All
            HtmlCheckBoxList HtmlCheckBoxListAccessDeleteAll = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessDeleteAll");
            HtmlCheckBoxListAccessDeleteAll.AddRange(lc.UserRoleListItem);
            ModuleAccessDeleteAllTemplateValue = HtmlCheckBoxListAccessDeleteAll.GetValue();
            ModuleAccessDeleteAllListValue = HtmlCheckBoxListAccessDeleteAll.GetList();
            ModuleAccessDeleteAllTemplateValue = ModuleAccessDeleteAllTemplateValue.Replace("$_asp attribute;", ModuleAccessDeleteAllAttribute);
            ModuleAccessDeleteAllTemplateValue = ModuleAccessDeleteAllTemplateValue.Replace("$_asp css_class;", ModuleAccessDeleteAllCssClass);
            ModuleAccessDeleteAllTemplateValue = ModuleAccessDeleteAllTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessDeleteAllListItem);

            // Module Access Delete Own
            HtmlCheckBoxList HtmlCheckBoxListAccessDeleteOwn = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessDeleteOwn");
            HtmlCheckBoxListAccessDeleteOwn.AddRange(lc.UserRoleListItem);
            ModuleAccessDeleteOwnTemplateValue = HtmlCheckBoxListAccessDeleteOwn.GetValue();
            ModuleAccessDeleteOwnListValue = HtmlCheckBoxListAccessDeleteOwn.GetList();
            ModuleAccessDeleteOwnTemplateValue = ModuleAccessDeleteOwnTemplateValue.Replace("$_asp attribute;", ModuleAccessDeleteOwnAttribute);
            ModuleAccessDeleteOwnTemplateValue = ModuleAccessDeleteOwnTemplateValue.Replace("$_asp css_class;", ModuleAccessDeleteOwnCssClass);
            ModuleAccessDeleteOwnTemplateValue = ModuleAccessDeleteOwnTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessDeleteOwnListItem);

            // Module Access Edit All
            HtmlCheckBoxList HtmlCheckBoxListAccessEditAll = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessEditAll");
            HtmlCheckBoxListAccessEditAll.AddRange(lc.UserRoleListItem);
            ModuleAccessEditAllTemplateValue = HtmlCheckBoxListAccessEditAll.GetValue();
            ModuleAccessEditAllListValue = HtmlCheckBoxListAccessEditAll.GetList();
            ModuleAccessEditAllTemplateValue = ModuleAccessEditAllTemplateValue.Replace("$_asp attribute;", ModuleAccessEditAllAttribute);
            ModuleAccessEditAllTemplateValue = ModuleAccessEditAllTemplateValue.Replace("$_asp css_class;", ModuleAccessEditAllCssClass);
            ModuleAccessEditAllTemplateValue = ModuleAccessEditAllTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessEditAllListItem);

            // Module Access Edit Own
            HtmlCheckBoxList HtmlCheckBoxListAccessEditOwn = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessEditOwn");
            HtmlCheckBoxListAccessEditOwn.AddRange(lc.UserRoleListItem);
            ModuleAccessEditOwnTemplateValue = HtmlCheckBoxListAccessEditOwn.GetValue();
            ModuleAccessEditOwnListValue = HtmlCheckBoxListAccessEditOwn.GetList();
            ModuleAccessEditOwnTemplateValue = ModuleAccessEditOwnTemplateValue.Replace("$_asp attribute;", ModuleAccessEditOwnAttribute);
            ModuleAccessEditOwnTemplateValue = ModuleAccessEditOwnTemplateValue.Replace("$_asp css_class;", ModuleAccessEditOwnCssClass);
            ModuleAccessEditOwnTemplateValue = ModuleAccessEditOwnTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessEditOwnListItem);


            PriorityForModuleValue = true;
            ModuleCacheDurationValue = "0";
            ModuleSortIndexValue = "0";


            // Set Module Page List
            ActionGetModuleListModel lm = new ActionGetModuleListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_ModuleCategory", "");
            InputRequest.Add("ddlst_ModuleLoadType", ModuleLoadTypeOptionListValue);
            InputRequest.Add("txt_ModuleCacheDuration", "");
            InputRequest.Add("txt_ModuleCacheParameters", "");
            InputRequest.Add("txt_ModuleSortIndex", "");
            InputRequest.Add("cbxlst_ModuleMenu", ModuleMenuListValue);
            InputRequest.Add("cbxlst_ModuleAccessShow", ModuleAccessShowListValue);
            InputRequest.Add("cbxlst_ModuleAccessAdd", ModuleAccessAddListValue);
            InputRequest.Add("cbxlst_ModuleAccessDeleteOwn", ModuleAccessDeleteOwnListValue);
            InputRequest.Add("cbxlst_ModuleAccessEditOwn", ModuleAccessEditOwnListValue);
            InputRequest.Add("cbxlst_ModuleAccessDeleteAll", ModuleAccessDeleteAllListValue);
            InputRequest.Add("cbxlst_ModuleAccessEditAll", ModuleAccessEditAllListValue);

                       
            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/module/");

            ModuleCategoryAttribute += vc.ImportantInputAttribute["txt_ModuleCategory"];
            ModuleLoadTypeAttribute += vc.ImportantInputAttribute["ddlst_ModuleLoadType"];
            ModuleCacheDurationAttribute += vc.ImportantInputAttribute["txt_ModuleCacheDuration"];
            ModuleCacheParametersAttribute += vc.ImportantInputAttribute["txt_ModuleCacheParameters"];
            ModuleSortIndexAttribute += vc.ImportantInputAttribute["txt_ModuleSortIndex"];
            ModuleMenuAttribute += vc.ImportantInputAttribute["cbxlst_ModuleMenu"];
            ModuleAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_ModuleAccessShow"];
            ModuleAccessAddAttribute += vc.ImportantInputAttribute["cbxlst_ModuleAccessAdd"];
            ModuleAccessDeleteOwnAttribute += vc.ImportantInputAttribute["cbxlst_ModuleAccessDeleteOwn"];
            ModuleAccessEditOwnAttribute += vc.ImportantInputAttribute["cbxlst_ModuleAccessEditOwn"];
            ModuleAccessDeleteAllAttribute += vc.ImportantInputAttribute["cbxlst_ModuleAccessDeleteAll"];
            ModuleAccessEditAllAttribute += vc.ImportantInputAttribute["cbxlst_ModuleAccessEditAll"];

            ModuleCategoryCssClass = ModuleCategoryCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ModuleCategory"]);
            ModuleLoadTypeCssClass = ModuleLoadTypeCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ModuleLoadType"]);
            ModuleCacheDurationCssClass = ModuleCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ModuleCacheDuration"]);
            ModuleCacheParametersCssClass = ModuleCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ModuleCacheParameters"]);
            ModuleSortIndexCssClass = ModuleSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ModuleSortIndex"]);
            ModuleMenuCssClass = ModuleMenuCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ModuleMenu"]);
            ModuleAccessShowCssClass = ModuleAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ModuleAccessShow"]);
            ModuleAccessAddCssClass = ModuleAccessAddCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ModuleAccessAdd"]);
            ModuleAccessDeleteOwnCssClass = ModuleAccessDeleteOwnCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ModuleAccessDeleteOwn"]);
            ModuleAccessEditOwnCssClass = ModuleAccessEditOwnCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ModuleAccessEditOwn"]);
            ModuleAccessDeleteAllCssClass = ModuleAccessDeleteAllCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ModuleAccessDeleteAll"]);
            ModuleAccessEditAllCssClass = ModuleAccessEditAllCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ModuleAccessEditAll"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/module/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //ModuleCategoryCssClass = ModuleCategoryCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ModuleCategory"]);
                //ModuleLoadTypeCssClass = ModuleLoadTypeCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ModuleLoadType"]);
                //ModuleCacheDurationCssClass = ModuleCacheDurationCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ModuleCacheDuration"]);
                //ModuleCacheParametersCssClass = ModuleCacheParametersCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ModuleCacheParameters"]);
                //ModuleSortIndexCssClass = ModuleSortIndexCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ModuleSortIndex"]);
                //ModuleMenuCssClass = ModuleMenuCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ModuleMenu"]);
                //ModuleAccessShowCssClass = ModuleAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ModuleAccessShow"]);
                //ModuleAccessAddCssClass = ModuleAccessAddCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ModuleAccessAdd"]);
                //ModuleAccessDeleteOwnCssClass = ModuleAccessDeleteOwnCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ModuleAccessDeleteOwn"]);
                //ModuleAccessEditOwnCssClass = ModuleAccessEditOwnCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ModuleAccessEditOwn"]);
                //ModuleAccessDeleteAllCssClass = ModuleAccessDeleteAllCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ModuleAccessDeleteAll"]);
                //ModuleAccessEditAllCssClass = ModuleAccessEditAllCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ModuleAccessEditAll"]);
            }
        }

        public void AddModule()
        {
            string ModuleFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Module Path
            if (UseModulePathValue)
            {
                if (string.IsNullOrEmpty(ModulePathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_module_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/"), "problem");

                System.Net.WebClient webClient = new System.Net.WebClient();

                ModuleFilePhysicalName = Path.GetFileName(ModulePathTextValue);

                FileExtension = Path.GetExtension(ModuleFilePhysicalName);

                if (FileExtension != ".zip")
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(ModuleFilePhysicalName));

                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                webClient.DownloadFile(ModulePathTextValue, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ModuleFilePhysicalName));
            }
            else
            {
                if (!ModulePathUploadValue.HtmlInputHasFile())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_module_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/"), "problem");

                ModuleFilePhysicalName = ModulePathUploadValue.FileName;

                FileExtension = Path.GetExtension(ModuleFilePhysicalName);

                if (FileExtension != ".zip")
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(ModuleFilePhysicalName));

                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                ModulePathUploadValue.SaveAs(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ModuleFilePhysicalName));
            }

            // Check Module File Size
            double FileSize = new FileInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ModuleFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_module").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");
            }

            // Extract Zip File
            ZipFileSocket zfs = new ZipFileSocket();
            zfs.UnZip(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + ModuleFilePhysicalName), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/module")))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/"), "warning");
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/module/catalog.xml"));

            XmlNode ModuleCatalog = CatalogDocument.SelectSingleNode("/module_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_module", "module_name", ModuleCatalog["module_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("module_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/"), "problem");
            }


            string ModuleDirectoryPath = ModuleCatalog["module_directory_path"].Attributes["value"].Value;
            ModuleDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/"), ModuleDirectoryPath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (ModuleDirectoryPath != ModuleCatalog["module_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Module File In "module" Directory To Module
            Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/module/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath));


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
                rci.AddTmpBinAddOnToTmpBinFileList(rci.BinFileName, ModuleCatalog["module_name"].Attributes["value"].Value, "module", ModuleDirectoryPath);
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

                UninstallDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/uninstall.xml"));


                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + ""), true);
            }

            // Delete Physical File
            Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.Module dum = new DataUse.Module();

            dum.ModuleName = ModuleCatalog["module_name"].Attributes["value"].Value;
            dum.ModuleCategory = (PriorityForModuleValue) ? ModuleCatalog["module_category"].Attributes["value"].Value.SpaceToUnderline() : ModuleCategoryValue.SpaceToUnderline();
            dum.ModuleDirectoryPath = ModuleDirectoryPath;
            dum.ModulePhysicalName = ModuleCatalog["module_physical_name"].Attributes["value"].Value;
            dum.ModuleLoadType = (PriorityForModuleValue) ? ModuleCatalog["module_best_load_status"].Attributes["value"].Value : ModuleLoadTypeOptionListSelectedValue;
            dum.ModuleUseLanguage = (PriorityForModuleValue) ? ModuleCatalog["module_replace"].Attributes["use_language"].Value.TrueFalseToZeroOne() : ModuleUseLanguageValue.BooleanToZeroOne();
            dum.ModuleUseModule = (PriorityForModuleValue) ? ModuleCatalog["module_replace"].Attributes["use_module"].Value.TrueFalseToZeroOne() : ModuleUseModuleValue.BooleanToZeroOne();
            dum.ModuleUsePlugin = (PriorityForModuleValue) ? ModuleCatalog["module_replace"].Attributes["use_plugin"].Value.TrueFalseToZeroOne() : ModuleUsePluginValue.BooleanToZeroOne();
            dum.ModuleUseReplacePart = (PriorityForModuleValue) ? ModuleCatalog["module_replace"].Attributes["use_replace_part"].Value.TrueFalseToZeroOne() : ModuleUseReplacePartValue.BooleanToZeroOne();
            dum.ModuleUseFetch = (PriorityForModuleValue) ? ModuleCatalog["module_replace"].Attributes["use_fetch"].Value.TrueFalseToZeroOne() : ModuleUseFetchValue.BooleanToZeroOne();
            dum.ModuleUseItem = (PriorityForModuleValue) ? ModuleCatalog["module_replace"].Attributes["use_item"].Value.TrueFalseToZeroOne() : ModuleUseItemValue.BooleanToZeroOne();
            dum.ModuleUseElanat = (PriorityForModuleValue) ? ModuleCatalog["module_replace"].Attributes["use_elanat"].Value.TrueFalseToZeroOne() : ModuleUseElanatValue.BooleanToZeroOne();
            dum.ModuleCacheDuration = (ModuleCacheDurationValue.IsNumber()) ? ModuleCacheDurationValue : "0";
            dum.ModuleCacheParameters = (PriorityForModuleValue) ? ModuleCatalog["module_cache_parameters"].InnerText : ModuleCacheParametersValue;
            dum.ModulePublicAccessAdd = ModulePublicAccessAddValue.BooleanToZeroOne();
            dum.ModulePublicAccessEditOwn = ModulePublicAccessEditOwnValue.BooleanToZeroOne();
            dum.ModulePublicAccessDeleteOwn = ModulePublicAccessDeleteOwnValue.BooleanToZeroOne();
            dum.ModulePublicAccessEditAll = ModulePublicAccessEditAllValue.BooleanToZeroOne();
            dum.ModulePublicAccessDeleteAll = ModulePublicAccessDeleteAllValue.BooleanToZeroOne();
            dum.ModulePublicAccessShow = ModulePublicAccessShowValue.BooleanToZeroOne();
            dum.ModuleSortIndex = ModuleSortIndexValue;
            dum.ModuleActive = ModuleActiveValue.BooleanToZeroOne();

            // Add Module
            dum.AddWithFillReturnDr();

            // Add Menu Module
            List<string> ModuleQueryString = new List<string>();
            foreach (ListItem item in ModuleMenuListItem)
                if (item.Selected)
                    ModuleQueryString.Add(HttpContext.Current.Request.Form["txt_ModuleMenuQueryString_Add_" + item.Value].ToString());
            dum.AddMenuModule(dum.ModuleId, ModuleMenuListItem, ModuleQueryString);

            // Set Module Role Access
            dum.SetModuleRoleAccess(dum.ModuleId, ModuleAccessShowListItem, ModuleAccessAddListItem, ModuleAccessEditOwnListItem, ModuleAccessDeleteOwnListItem, ModuleAccessEditAllListItem, ModuleAccessDeleteAllListItem);


            try { dum.ReturnDb.Close(); } catch (Exception) { }


            // Run Install Page
            if (!HasDll)
                if (!string.IsNullOrEmpty(ModuleCatalog["module_install_path"].Attributes["value"].Value))
                    PageLoader.LoadWithServer("/add_on/module/" + dum.ModuleDirectoryPath + "/" + ModuleCatalog["module_install_path"].Attributes["value"].Value);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_module", dum.ModuleName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("module_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/module/action/ModuleNewRow.aspx?module_id=" + dum.ModuleId, "div_TableBox");

            if (HasDll)
                rf.SetTmpBinAlert();

            rf.RedirectToResponseFormPage();
        }
    }
}