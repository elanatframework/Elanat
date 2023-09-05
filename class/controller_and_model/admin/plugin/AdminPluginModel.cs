using CodeBehind;
using SetCodeBehind;
using System.Reflection;
using System.Xml;

namespace Elanat
{
    public partial class AdminPluginModel : CodeBehindModel
    {
        public string PluginLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string AddPluginLanguage { get; set; }
        public string PluginPathLanguage { get; set; }
        public string UsePluginPathLanguage { get; set; }
        public string PriorityForPluginLanguage { get; set; }
        public string PluginNameLanguage { get; set; }
        public string PluginCategoryLanguage { get; set; }
        public string PluginLoadTypeLanguage { get; set; }
        public string PluginActiveLanguage { get; set; }
        public string PluginUseLanguageLanguage { get; set; }
        public string PluginUsePluginLanguage { get; set; }
        public string PluginUseModuleLanguage { get; set; }
        public string PluginUseReplacePartLanguage { get; set; }
        public string PluginUseFetchLanguage { get; set; }
        public string PluginUseItemLanguage { get; set; }
        public string PluginUseElanatLanguage { get; set; }
        public string PluginCacheDurationLanguage { get; set; }
        public string PluginCacheParametersLanguage { get; set; }
        public string PluginMenuLanguage { get; set; }
        public string PluginMenuQueryStringLanguage { get; set; }
        public string PluginSortIndexLanguage { get; set; }
        public string PluginAccessShowLanguage { get; set; }
        public string PluginPublicAccessShowLanguage { get; set; }
        public string PluginAccessAddLanguage { get; set; }
        public string PluginPublicAccessAddLanguage { get; set; }
        public string PluginAccessEditOwnLanguage { get; set; }
        public string PluginPublicAccessEditOwnLanguage { get; set; }
        public string PluginAccessDeleteOwnLanguage { get; set; }
        public string PluginPublicAccessDeleteOwnLanguage { get; set; }
        public string PluginAccessEditAllLanguage { get; set; }
        public string PluginPublicAccessEditAllLanguage { get; set; }
        public string PluginAccessDeleteAllLanguage { get; set; }
        public string PluginPublicAccessDeleteAllLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool PriorityForPluginValue { get; set; } = true;
        public bool PluginActiveValue { get; set; } = false;
        public bool PluginUseLanguageValue { get; set; } = false;
        public bool PluginUsePluginValue { get; set; } = false;
        public bool PluginUseModuleValue { get; set; } = false;
        public bool PluginUseReplacePartValue { get; set; } = false;
        public bool PluginUseFetchValue { get; set; } = false;
        public bool PluginUseItemValue { get; set; } = false;
        public bool PluginUseElanatValue { get; set; } = false;
        public bool PluginPublicAccessShowValue { get; set; } = false;
        public bool PluginPublicAccessAddValue { get; set; } = false;
        public bool PluginPublicAccessEditOwnValue { get; set; } = false;
        public bool PluginPublicAccessDeleteOwnValue { get; set; } = false;
        public bool PluginPublicAccessEditAllValue { get; set; } = false;
        public bool PluginPublicAccessDeleteAllValue { get; set; } = false;

        public bool UsePluginPathValue { get; set; } = false;
        public IFormFile PluginPathUploadValue { get; set; }
        public string PluginPathTextValue { get; set; }

        public string PluginLoadTypeOptionListValue { get; set; }
        public string PluginLoadTypeOptionListSelectedValue { get; set; }

        public string PluginNameValue { get; set; }
        public string PluginCategoryValue { get; set; }
        public string PluginCacheDurationValue { get; set; }
        public string PluginCacheParametersValue { get; set; }
        public string PluginSortIndexValue { get; set; }

        public string PluginNameAttribute { get; set; }
        public string PluginCategoryAttribute { get; set; }
        public string PluginCacheDurationAttribute { get; set; }
        public string PluginCacheParametersAttribute { get; set; }
        public string PluginSortIndexAttribute { get; set; }
        public string PluginLoadTypeAttribute { get; set; }

        public string PluginNameCssClass { get; set; }
        public string PluginCategoryCssClass { get; set; }
        public string PluginCacheDurationCssClass { get; set; }
        public string PluginCacheParametersCssClass { get; set; }
        public string PluginSortIndexCssClass { get; set; }
        public string PluginLoadTypeCssClass { get; set; }

        public List<ListItem> PluginMenuListItem = new List<ListItem>();
        public string PluginMenuListValue { get; set; }
        public string PluginMenuTemplateValue { get; set; }
        public List<ListItem> PluginAccessShowListItem = new List<ListItem>();
        public string PluginAccessShowListValue { get; set; }
        public string PluginAccessShowTemplateValue { get; set; }
        public List<ListItem> PluginAccessAddListItem = new List<ListItem>();
        public string PluginAccessAddListValue { get; set; }
        public string PluginAccessAddTemplateValue { get; set; }
        public List<ListItem> PluginAccessEditOwnListItem = new List<ListItem>();
        public string PluginAccessEditOwnListValue { get; set; }
        public string PluginAccessEditOwnTemplateValue { get; set; }
        public List<ListItem> PluginAccessDeleteOwnListItem = new List<ListItem>();
        public string PluginAccessDeleteOwnListValue { get; set; }
        public string PluginAccessDeleteOwnTemplateValue { get; set; }
        public List<ListItem> PluginAccessEditAllListItem = new List<ListItem>();
        public string PluginAccessEditAllListValue { get; set; }
        public string PluginAccessEditAllTemplateValue { get; set; }
        public List<ListItem> PluginAccessDeleteAllListItem = new List<ListItem>();
        public string PluginAccessDeleteAllListValue { get; set; }
        public string PluginAccessDeleteAllTemplateValue { get; set; }

        public string PluginMenuAttribute { get; set; }
        public string PluginMenuCssClass { get; set; }
        public string PluginAccessShowAttribute { get; set; }
        public string PluginAccessShowCssClass { get; set; }
        public string PluginAccessAddAttribute { get; set; }
        public string PluginAccessAddCssClass { get; set; }
        public string PluginAccessEditOwnAttribute { get; set; }
        public string PluginAccessEditOwnCssClass { get; set; }
        public string PluginAccessDeleteOwnAttribute { get; set; }
        public string PluginAccessDeleteOwnCssClass { get; set; }
        public string PluginAccessEditAllAttribute { get; set; }
        public string PluginAccessEditAllCssClass { get; set; }
        public string PluginAccessDeleteAllAttribute { get; set; }
        public string PluginAccessDeleteAllCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/plugin/");
            PluginLanguage = aol.GetAddOnsLanguage("plugin");
            PluginMenuLanguage = aol.GetAddOnsLanguage("plugin_menu");
            PluginPathLanguage = aol.GetAddOnsLanguage("plugin_path");
            AddPluginLanguage = aol.GetAddOnsLanguage("add_plugin");
            UsePluginPathLanguage = aol.GetAddOnsLanguage("use_plugin_path");
            PriorityForPluginLanguage = aol.GetAddOnsLanguage("priority_for_plugin");
            PluginCategoryLanguage = aol.GetAddOnsLanguage("plugin_category");
            PluginLoadTypeLanguage = aol.GetAddOnsLanguage("plugin_load_type");
            PluginAccessShowLanguage = aol.GetAddOnsLanguage("plugin_access_show");
            PluginPublicAccessShowLanguage = aol.GetAddOnsLanguage("plugin_public_access_show");
            PluginPublicAccessAddLanguage = aol.GetAddOnsLanguage("plugin_public_access_add");
            PluginPublicAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("plugin_public_access_delete_own");
            PluginPublicAccessDeleteAllLanguage = aol.GetAddOnsLanguage("plugin_public_access_delete_all");
            PluginPublicAccessEditOwnLanguage = aol.GetAddOnsLanguage("plugin_public_access_edit_own");
            PluginPublicAccessEditAllLanguage = aol.GetAddOnsLanguage("plugin_public_access_edit_all");
            PluginAccessAddLanguage = aol.GetAddOnsLanguage("plugin_access_add");
            PluginAccessEditOwnLanguage = aol.GetAddOnsLanguage("plugin_access_edit_own");
            PluginAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("plugin_access_delete_own");
            PluginAccessEditAllLanguage = aol.GetAddOnsLanguage("plugin_access_edit_all");
            PluginAccessDeleteAllLanguage = aol.GetAddOnsLanguage("plugin_access_delete_all");
            PluginSortIndexLanguage = aol.GetAddOnsLanguage("plugin_sort_index");
            PluginMenuQueryStringLanguage = aol.GetAddOnsLanguage("plugin_menu_query_string");
            PluginActiveLanguage = aol.GetAddOnsLanguage("plugin_active");
            AddLanguage = aol.GetAddOnsLanguage("add");
            PluginCacheDurationLanguage = aol.GetAddOnsLanguage("plugin_cache_duration");
            PluginCacheParametersLanguage = aol.GetAddOnsLanguage("plugin_cache_parameters");
            PluginUseLanguageLanguage = aol.GetAddOnsLanguage("plugin_use_language");
            PluginUseModuleLanguage = aol.GetAddOnsLanguage("plugin_use_module");
            PluginUsePluginLanguage = aol.GetAddOnsLanguage("plugin_use_plugin");
            PluginUseReplacePartLanguage = aol.GetAddOnsLanguage("plugin_use_replace_part");
            PluginUseFetchLanguage = aol.GetAddOnsLanguage("plugin_use_fetch");
            PluginUseItemLanguage = aol.GetAddOnsLanguage("plugin_use_item");
            PluginUseElanatLanguage = aol.GetAddOnsLanguage("plugin_use_elanat");
            PluginNameLanguage = aol.GetAddOnsLanguage("plugin_name");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Page Loader Item
            ListClass.PageLoadType lcplt = new ListClass.PageLoadType();
            lcplt.FillPageLoadTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            PluginLoadTypeOptionListValue += lcplt.PageLoadTypeListItem.HtmlInputToOptionTag(PluginLoadTypeOptionListSelectedValue);

            // Set Menu
            ListClass.Menu lcm = new ListClass.Menu();
            lcm.FillMenuListItem(StaticObject.GetCurrentSiteSiteId());
            HtmlCheckBoxList HtmlCheckBoxListMenu = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/plugin/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PluginMenu");
            HtmlCheckBoxListMenu.AddRange(lcm.MenuListItem);
            PluginMenuTemplateValue = HtmlCheckBoxListMenu.GetValue();
            PluginMenuListValue = HtmlCheckBoxListMenu.GetList();
            PluginMenuTemplateValue = PluginMenuTemplateValue.Replace("$_asp attribute;", PluginMenuAttribute);
            PluginMenuTemplateValue = PluginMenuTemplateValue.Replace("$_asp css_class;", PluginMenuCssClass);
            PluginMenuTemplateValue = PluginMenuTemplateValue.HtmlInputSetCheckBoxListValue(PluginMenuListItem);

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Plugin Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/plugin/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PluginAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lcu.UserRoleListItem);
            PluginAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            PluginAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            PluginAccessShowTemplateValue = PluginAccessShowTemplateValue.Replace("$_asp attribute;", PluginAccessShowAttribute);
            PluginAccessShowTemplateValue = PluginAccessShowTemplateValue.Replace("$_asp css_class;", PluginAccessShowCssClass);
            PluginAccessShowTemplateValue = PluginAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(PluginAccessShowListItem);

            // Plugin Access Add
            HtmlCheckBoxList HtmlCheckBoxListAccessAdd = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/plugin/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PluginAccessAdd");
            HtmlCheckBoxListAccessAdd.AddRange(lcu.UserRoleListItem);
            PluginAccessAddTemplateValue = HtmlCheckBoxListAccessAdd.GetValue();
            PluginAccessAddListValue = HtmlCheckBoxListAccessAdd.GetList();
            PluginAccessAddTemplateValue = PluginAccessAddTemplateValue.Replace("$_asp attribute;", PluginAccessAddAttribute);
            PluginAccessAddTemplateValue = PluginAccessAddTemplateValue.Replace("$_asp css_class;", PluginAccessAddCssClass);
            PluginAccessAddTemplateValue = PluginAccessAddTemplateValue.HtmlInputSetCheckBoxListValue(PluginAccessAddListItem);

            // Plugin Access Delete All
            HtmlCheckBoxList HtmlCheckBoxListAccessDeleteAll = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/plugin/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PluginAccessDeleteAll");
            HtmlCheckBoxListAccessDeleteAll.AddRange(lcu.UserRoleListItem);
            PluginAccessDeleteAllTemplateValue = HtmlCheckBoxListAccessDeleteAll.GetValue();
            PluginAccessDeleteAllListValue = HtmlCheckBoxListAccessDeleteAll.GetList();
            PluginAccessDeleteAllTemplateValue = PluginAccessDeleteAllTemplateValue.Replace("$_asp attribute;", PluginAccessDeleteAllAttribute);
            PluginAccessDeleteAllTemplateValue = PluginAccessDeleteAllTemplateValue.Replace("$_asp css_class;", PluginAccessDeleteAllCssClass);
            PluginAccessDeleteAllTemplateValue = PluginAccessDeleteAllTemplateValue.HtmlInputSetCheckBoxListValue(PluginAccessDeleteAllListItem);

            // Plugin Access Delete Own
            HtmlCheckBoxList HtmlCheckBoxListAccessDeleteOwn = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/plugin/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PluginAccessDeleteOwn");
            HtmlCheckBoxListAccessDeleteOwn.AddRange(lcu.UserRoleListItem);
            PluginAccessDeleteOwnTemplateValue = HtmlCheckBoxListAccessDeleteOwn.GetValue();
            PluginAccessDeleteOwnListValue = HtmlCheckBoxListAccessDeleteOwn.GetList();
            PluginAccessDeleteOwnTemplateValue = PluginAccessDeleteOwnTemplateValue.Replace("$_asp attribute;", PluginAccessDeleteOwnAttribute);
            PluginAccessDeleteOwnTemplateValue = PluginAccessDeleteOwnTemplateValue.Replace("$_asp css_class;", PluginAccessDeleteOwnCssClass);
            PluginAccessDeleteOwnTemplateValue = PluginAccessDeleteOwnTemplateValue.HtmlInputSetCheckBoxListValue(PluginAccessDeleteOwnListItem);

            // Plugin Access Edit All
            HtmlCheckBoxList HtmlCheckBoxListAccessEditAll = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/plugin/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PluginAccessEditAll");
            HtmlCheckBoxListAccessEditAll.AddRange(lcu.UserRoleListItem);
            PluginAccessEditAllTemplateValue = HtmlCheckBoxListAccessEditAll.GetValue();
            PluginAccessEditAllListValue = HtmlCheckBoxListAccessEditAll.GetList();
            PluginAccessEditAllTemplateValue = PluginAccessEditAllTemplateValue.Replace("$_asp attribute;", PluginAccessEditAllAttribute);
            PluginAccessEditAllTemplateValue = PluginAccessEditAllTemplateValue.Replace("$_asp css_class;", PluginAccessEditAllCssClass);
            PluginAccessEditAllTemplateValue = PluginAccessEditAllTemplateValue.HtmlInputSetCheckBoxListValue(PluginAccessEditAllListItem);

            // Plugin Access Edit Own
            HtmlCheckBoxList HtmlCheckBoxListAccessEditOwn = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/plugin/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PluginAccessEditOwn");
            HtmlCheckBoxListAccessEditOwn.AddRange(lcu.UserRoleListItem);
            PluginAccessEditOwnTemplateValue = HtmlCheckBoxListAccessEditOwn.GetValue();
            PluginAccessEditOwnListValue = HtmlCheckBoxListAccessEditOwn.GetList();
            PluginAccessEditOwnTemplateValue = PluginAccessEditOwnTemplateValue.Replace("$_asp attribute;", PluginAccessEditOwnAttribute);
            PluginAccessEditOwnTemplateValue = PluginAccessEditOwnTemplateValue.Replace("$_asp css_class;", PluginAccessEditOwnCssClass);
            PluginAccessEditOwnTemplateValue = PluginAccessEditOwnTemplateValue.HtmlInputSetCheckBoxListValue(PluginAccessEditOwnListItem);


            PriorityForPluginValue = true;
            PluginCacheDurationValue = "0";
            PluginSortIndexValue = "0";


            // Set Plugin Page List
            ActionGetPluginListModel lm = new ActionGetPluginListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_PluginName", "");
            InputRequest.Add("txt_PluginCategory", "");
            InputRequest.Add("ddlst_PluginLoadType", PluginLoadTypeOptionListValue);
            InputRequest.Add("txt_PluginCacheDuration", "");
            InputRequest.Add("txt_PluginCacheParameters", "");
            InputRequest.Add("txt_PluginSortIndex", "");
            InputRequest.Add("cbxlst_PluginMenu", PluginMenuListValue);
            InputRequest.Add("cbxlst_PluginAccessShow", PluginAccessShowListValue);
            InputRequest.Add("cbxlst_PluginAccessAdd", PluginAccessAddListValue);
            InputRequest.Add("cbxlst_PluginAccessDeleteOwn", PluginAccessDeleteOwnListValue);
            InputRequest.Add("cbxlst_PluginAccessEditOwn", PluginAccessEditOwnListValue);
            InputRequest.Add("cbxlst_PluginAccessDeleteAll", PluginAccessDeleteAllListValue);
            InputRequest.Add("cbxlst_PluginAccessEditAll", PluginAccessEditAllListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/plugin/");

            PluginNameAttribute += vc.ImportantInputAttribute.GetValue("txt_PluginName");
            PluginCategoryAttribute += vc.ImportantInputAttribute.GetValue("txt_PluginCategory");
            PluginLoadTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_PluginLoadType");
            PluginCacheDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_PluginCacheDuration");
            PluginCacheParametersAttribute += vc.ImportantInputAttribute.GetValue("txt_PluginCacheParameters");
            PluginSortIndexAttribute += vc.ImportantInputAttribute.GetValue("txt_PluginSortIndex");
            PluginMenuAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_PluginMenu");
            PluginAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_PluginAccessShow");
            PluginAccessAddAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_PluginAccessAdd");
            PluginAccessDeleteOwnAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_PluginAccessDeleteOwn");
            PluginAccessEditOwnAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_PluginAccessEditOwn");
            PluginAccessDeleteAllAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_PluginAccessDeleteAll");
            PluginAccessEditAllAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_PluginAccessEditAll");

            PluginNameCssClass = PluginNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PluginName"));
            PluginCategoryCssClass = PluginCategoryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PluginCategory"));
            PluginLoadTypeCssClass = PluginLoadTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_PluginLoadType"));
            PluginCacheDurationCssClass = PluginCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PluginCacheDuration"));
            PluginCacheParametersCssClass = PluginCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PluginCacheParameters"));
            PluginSortIndexCssClass = PluginSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PluginSortIndex"));
            PluginMenuCssClass = PluginMenuCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_PluginMenu"));
            PluginAccessShowCssClass = PluginAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_PluginAccessShow"));
            PluginAccessAddCssClass = PluginAccessAddCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_PluginAccessAdd"));
            PluginAccessDeleteOwnCssClass = PluginAccessDeleteOwnCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_PluginAccessDeleteOwn"));
            PluginAccessEditOwnCssClass = PluginAccessEditOwnCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_PluginAccessEditOwn"));
            PluginAccessDeleteAllCssClass = PluginAccessDeleteAllCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_PluginAccessDeleteAll"));
            PluginAccessEditAllCssClass = PluginAccessEditAllCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_PluginAccessEditAll"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/plugin/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void AddPlugin()
        {
            string PluginDirectoryPath = "";
            string PluginFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";
            string PluginName = "";

            // If Use Plugin Path
            if (UsePluginPathValue)
            {
                if (string.IsNullOrEmpty(PluginPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_plugin_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/plugin/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                PluginFilePhysicalName = Path.GetFileName(PluginPathTextValue);

                FileExtension = Path.GetExtension(PluginFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(PluginFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                webClient.DownloadFile(PluginPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PluginFilePhysicalName));
            }
            else
            {
                if (!PluginPathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_plugin_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/plugin/"), "problem");

                    return;
                }

                PluginFilePhysicalName = PluginPathUploadValue.FileName;

                FileExtension = Path.GetExtension(PluginFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(PluginFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                PluginPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PluginFilePhysicalName));
            }

            // Check Plugin File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PluginFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_plugin").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");

                return;
            }

            XmlDocument CatalogDocument = new XmlDocument();
            bool PriorityForPlugin = PriorityForPluginValue;

            bool HasDll = false;

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            // Extract Zip File
            if (FileExtension == ".zip")
            {
                ZipFileClass zfc = new ZipFileClass();
                zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PluginFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/plugin")))
                {
                    // Delete Physical File
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/plugin/"), "warning");

                    return;
                }

                CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/plugin/catalog.xml"));
                XmlNode TmpPluginCatalog = CatalogDocument.SelectSingleNode("/plugin_catalog_root");


                // Unique Value To Column Check
                DataUse.Common common = new DataUse.Common();
                if (common.ExistValueToColumnCheck("el_plugin", "plugin_name", TmpPluginCatalog["plugin_name"].Attributes["value"].Value))
                {
                    // Delete Physical File
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("plugin_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/plugin/"), "problem");

                    return;
                }


                PluginDirectoryPath = TmpPluginCatalog["plugin_directory_path"].Attributes["value"].Value;
                PluginDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/"), PluginDirectoryPath);

                if (PluginDirectoryPath != TmpPluginCatalog["plugin_directory_path"].Attributes["value"].Value)
                {
                    ResponseForm.WriteLocalAlone(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

                    return;
                }

                // Move All Plugin File In "plugin" Directory To Plugin
                Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/plugin/"), StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath));

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

                    UninstallDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/uninstall.xml"));


                    /// <Action> Move All File In "root" Directory To Site Path
                    FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(PluginNameValue))
                    PluginNameValue = PluginFilePhysicalName.GetTextBeforeLastValue(".");

                string PluginPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "plugin/"), PluginNameValue);
                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                // Create New Catalog Document
                XmlDocument NewCatalogDocument = new XmlDocument();
                NewCatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/plugin/catalog.xml"));

                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_name").Attributes["value"].Value = PluginNameValue;
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_directory_path").Attributes["value"].Value = PluginPath;
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_physical_name").Attributes["value"].Value = PluginFilePhysicalName;
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_replace").Attributes["use_language"].Value = PluginUseLanguageValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_replace").Attributes["use_replace_part"].Value = PluginUseReplacePartValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_replace").Attributes["use_module"].Value = PluginUseModuleValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_replace").Attributes["use_plugin"].Value = PluginUsePluginValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_replace").Attributes["use_elanat"].Value = PluginUseElanatValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_replace").Attributes["use_item"].Value = PluginUseItemValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_replace").Attributes["use_fetch"].Value = PluginUseFetchValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_cache_parameters").InnerText = PluginCacheParametersValue;
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_author").Attributes["value"].Value = ccoc.UserSiteName;
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_best_load_status").Attributes["value"].Value = PluginLoadTypeOptionListSelectedValue;
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_release_date").Attributes["value"].Value = DateAndTime.GetDate("yyyy/MM/dd");
                NewCatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_category").Attributes["value"].Value = PluginCategoryValue.SpaceToUnderline();

                PluginName = PluginNameValue;

                // if (dbdr.dr != null && dbdr.dr.HasRows)Directory Name Exist In plugin Directory, Get New Directory Name
                PluginName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/"), PluginName);

                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginName), true);
                PriorityForPlugin = false;
                PluginDirectoryPath = PluginName;

                NewCatalogDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginName + "/catalog.xml"));


                // Set Plugin Default Image
                File.Copy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/plugin/image.png"), StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginName + "/image.png"));
            }

            // Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.Plugin dup = new DataUse.Plugin();

            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/catalog.xml"));
            XmlNode PluginCatalog = CatalogDocument.SelectSingleNode("plugin_catalog_root");

            dup.PluginName = (PriorityForPlugin) ? PluginCatalog["plugin_name"].Attributes["value"].Value : PluginNameValue;
            dup.PluginCategory = (PriorityForPluginValue) ? PluginCatalog["plugin_category"].Attributes["value"].Value.SpaceToUnderline() : PluginCategoryValue.SpaceToUnderline();
            dup.PluginDirectoryPath = PluginCatalog["plugin_directory_path"].Attributes["value"].Value;
            dup.PluginPhysicalName = PluginCatalog["plugin_physical_name"].Attributes["value"].Value;
            dup.PluginLoadType = (PriorityForPluginValue) ? PluginCatalog["plugin_best_load_status"].Attributes["value"].Value : PluginLoadTypeOptionListSelectedValue;
            dup.PluginUseLanguage = (PriorityForPluginValue) ? PluginCatalog["plugin_replace"].Attributes["use_language"].Value.TrueFalseToZeroOne() : PluginUseLanguageValue.BooleanToZeroOne();
            dup.PluginUseModule = (PriorityForPluginValue) ? PluginCatalog["plugin_replace"].Attributes["use_module"].Value.TrueFalseToZeroOne() : PluginUseModuleValue.BooleanToZeroOne();
            dup.PluginUsePlugin = (PriorityForPluginValue) ? PluginCatalog["plugin_replace"].Attributes["use_plugin"].Value.TrueFalseToZeroOne() : PluginUsePluginValue.BooleanToZeroOne();
            dup.PluginUseReplacePart = (PriorityForPluginValue) ? PluginCatalog["plugin_replace"].Attributes["use_replace_part"].Value.TrueFalseToZeroOne() : PluginUseReplacePartValue.BooleanToZeroOne();
            dup.PluginUseFetch = (PriorityForPluginValue) ? PluginCatalog["plugin_replace"].Attributes["use_fetch"].Value.TrueFalseToZeroOne() : PluginUseFetchValue.BooleanToZeroOne();
            dup.PluginUseItem = (PriorityForPluginValue) ? PluginCatalog["plugin_replace"].Attributes["use_item"].Value.TrueFalseToZeroOne() : PluginUseItemValue.BooleanToZeroOne();
            dup.PluginUseElanat = (PriorityForPluginValue) ? PluginCatalog["plugin_replace"].Attributes["use_elanat"].Value.TrueFalseToZeroOne() : PluginUseElanatValue.BooleanToZeroOne();
            dup.PluginCacheDuration = (PluginCacheDurationValue.IsNumber()) ? PluginCacheDurationValue : "0";
            dup.PluginCacheParameters = (PriorityForPluginValue) ? PluginCatalog["plugin_cache_parameters"].InnerText : PluginCacheParametersValue;
            dup.PluginPublicAccessAdd = PluginPublicAccessAddValue.BooleanToZeroOne();
            dup.PluginPublicAccessEditOwn = PluginPublicAccessEditOwnValue.BooleanToZeroOne();
            dup.PluginPublicAccessDeleteOwn = PluginPublicAccessDeleteOwnValue.BooleanToZeroOne();
            dup.PluginPublicAccessEditAll = PluginPublicAccessEditAllValue.BooleanToZeroOne();
            dup.PluginPublicAccessDeleteAll = PluginPublicAccessDeleteAllValue.BooleanToZeroOne();
            dup.PluginPublicAccessShow = PluginPublicAccessShowValue.BooleanToZeroOne();
            dup.PluginSortIndex = PluginSortIndexValue;
            dup.PluginActive = PluginActiveValue.BooleanToZeroOne();

            // Add Plugin
            dup.AddWithFillReturnDr();

            // Add Menu Plugin
            List<string> PluginQueryString = new List<string>();
            foreach (ListItem item in PluginMenuListItem)
                if (item.Selected)
                    PluginQueryString.Add(new HttpContextAccessor().HttpContext.Request.Form["txt_PluginMenuQueryString_Add_" + item.Value].ToString());
            dup.AddMenuPlugin(dup.PluginId, PluginMenuListItem, PluginQueryString);

            // Set Plugin Role Access
            dup.SetPluginRoleAccess(dup.PluginId, PluginAccessShowListItem, PluginAccessAddListItem, PluginAccessEditOwnListItem, PluginAccessDeleteOwnListItem, PluginAccessEditAllListItem, PluginAccessDeleteAllListItem);


            try { dup.ReturnDb.Close(); } catch (Exception) { }


            // Recompile
            if (HasDll)
            {
                CodeBehindCompiler.Initialization();
                CodeBehindCompiler.CompileAspx();
            }

            // Run Install Page
            if (!string.IsNullOrEmpty(PluginCatalog["plugin_install_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.SitePath + "add_on/plugin/" + dup.PluginDirectoryPath + "/" + PluginCatalog["plugin_install_path"].Attributes["value"].Value, true);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_plugin", dup.PluginName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("plugin_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/plugin/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/plugin/action/PluginNewRow.aspx?plugin_id=" + dup.PluginId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}