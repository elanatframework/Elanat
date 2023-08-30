using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionEditPluginModel : CodeBehindModel
    {
        public string EditPluginLanguage { get; set; }
        public string PluginCategoryLanguage { get; set; }
        public string PluginLoadTypeLanguage { get; set; }
        public string PluginActiveLanguage { get; set; }
        public string PluginUseLanguageLanguage { get; set; }
        public string PluginUseModuleLanguage { get; set; }
        public string PluginUsePluginLanguage { get; set; }
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
        public string SavePluginLanguage { get; set; }

        public bool PluginActiveValue { get; set; } = false;
        public bool PluginUseLanguageValue { get; set; } = false;
        public bool PluginUseModuleValue { get; set; } = false;
        public bool PluginUsePluginValue { get; set; } = false;
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

        public bool IsFirstStart { get; set; } = true;
        public string PluginIdValue { get; set; }
        public string PluginMenuQueryStringValue { get; set; }

        public string PluginLoadTypeOptionListValue { get; set; }
        public string PluginLoadTypeOptionListSelectedValue { get; set; }

        public string PluginCategoryValue { get; set; }
        public string PluginCacheDurationValue { get; set; }
        public string PluginCacheParametersValue { get; set; }
        public string PluginSortIndexValue { get; set; }

        public string PluginCategoryAttribute { get; set; }
        public string PluginCacheDurationAttribute { get; set; }
        public string PluginCacheParametersAttribute { get; set; }
        public string PluginSortIndexAttribute { get; set; }
        public string PluginLoadTypeAttribute { get; set; }

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

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/plugin/");
            SavePluginLanguage = aol.GetAddOnsLanguage("save_plugin");
            EditPluginLanguage = aol.GetAddOnsLanguage("edit_plugin");
            PluginCategoryLanguage = aol.GetAddOnsLanguage("plugin_category");
            PluginLoadTypeLanguage = aol.GetAddOnsLanguage("plugin_load_type");
            PluginAccessShowLanguage = aol.GetAddOnsLanguage("plugin_access_show");
            PluginPublicAccessShowLanguage = aol.GetAddOnsLanguage("plugin_public_access_show");
            PluginPublicAccessAddLanguage = aol.GetAddOnsLanguage("plugin_public_access_add");
            PluginPublicAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("plugin_public_access_delete_own");
            PluginPublicAccessDeleteAllLanguage = aol.GetAddOnsLanguage("plugin_public_access_delete_all");
            PluginPublicAccessEditOwnLanguage = aol.GetAddOnsLanguage("plugin_public_access_edit_own");
            PluginPublicAccessEditAllLanguage = aol.GetAddOnsLanguage("plugin_public_access_edit_all");
            PluginAccessAddLanguage = aol.GetAddOnsLanguage("plugin_access_add"); ;
            PluginAccessEditOwnLanguage = aol.GetAddOnsLanguage("plugin_access_edit_own");
            PluginAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("plugin_access_delete_own");
            PluginAccessEditAllLanguage = aol.GetAddOnsLanguage("plugin_access_edit_all");
            PluginAccessDeleteAllLanguage = aol.GetAddOnsLanguage("plugin_access_delete_all");
            PluginSortIndexLanguage = aol.GetAddOnsLanguage("plugin_sort_index");
            PluginMenuQueryStringLanguage = aol.GetAddOnsLanguage("plugin_menu_query_string");
            PluginActiveLanguage = aol.GetAddOnsLanguage("plugin_active");
            PluginCacheDurationLanguage = aol.GetAddOnsLanguage("plugin_cache_duration");
            PluginCacheParametersLanguage = aol.GetAddOnsLanguage("plugin_cache_parameters");
            PluginUseLanguageLanguage = aol.GetAddOnsLanguage("plugin_use_language");
            PluginUseModuleLanguage = aol.GetAddOnsLanguage("plugin_use_module");
            PluginUsePluginLanguage = aol.GetAddOnsLanguage("plugin_use_plugin");
            PluginUseReplacePartLanguage = aol.GetAddOnsLanguage("plugin_use_replace_part");
            PluginUseFetchLanguage = aol.GetAddOnsLanguage("plugin_use_fetch");
            PluginUseItemLanguage = aol.GetAddOnsLanguage("plugin_use_item");
            PluginUseElanatLanguage = aol.GetAddOnsLanguage("plugin_use_elanat");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Plugin dum = new DataUse.Plugin();
                dum.FillCurrentPlugin(PluginIdValue);

                PluginCategoryValue = dum.PluginCategory;
                PluginLoadTypeOptionListSelectedValue = dum.PluginLoadType;
                PluginUseLanguageValue = dum.PluginUseLanguage.ZeroOneToBoolean();
                PluginUseModuleValue = dum.PluginUseModule.ZeroOneToBoolean();
                PluginUsePluginValue = dum.PluginUsePlugin.ZeroOneToBoolean();
                PluginUseReplacePartValue = dum.PluginUseReplacePart.ZeroOneToBoolean();
                PluginUseFetchValue = dum.PluginUseFetch.ZeroOneToBoolean();
                PluginUseItemValue = dum.PluginUseItem.ZeroOneToBoolean();
                PluginUseElanatValue = dum.PluginUseElanat.ZeroOneToBoolean();
                PluginCacheDurationValue = dum.PluginCacheDuration;
                PluginCacheParametersValue = dum.PluginCacheParameters;
                PluginPublicAccessAddValue = dum.PluginPublicAccessAdd.ZeroOneToBoolean();
                PluginPublicAccessEditOwnValue = dum.PluginPublicAccessEditOwn.ZeroOneToBoolean();
                PluginPublicAccessDeleteOwnValue = dum.PluginPublicAccessDeleteOwn.ZeroOneToBoolean();
                PluginPublicAccessEditAllValue = dum.PluginPublicAccessEditAll.ZeroOneToBoolean();
                PluginPublicAccessDeleteAllValue = dum.PluginPublicAccessDeleteAll.ZeroOneToBoolean();
                PluginPublicAccessShowValue = dum.PluginPublicAccessShow.ZeroOneToBoolean();
                PluginSortIndexValue = dum.PluginSortIndex;
                PluginActiveValue = dum.PluginActive.ZeroOneToBoolean();
            }

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

            ListClass.Plugin lcp = new ListClass.Plugin();

            // Set Plugin Access Show Selected Value
            lcp.FillPluginAccessShowListItem(PluginIdValue);
            PluginAccessShowTemplateValue = PluginAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lcp.PluginAccessShowListItem);

            // Set Plugin Access Add Selected Value
            lcp.FillPluginAccessAddListItem(PluginIdValue);
            PluginAccessAddTemplateValue = PluginAccessAddTemplateValue.HtmlInputSetCheckBoxListValue(lcp.PluginAccessAddListItem);

            // Set Plugin Access Delete Own Selected Value
            lcp.FillPluginAccessDeleteOwnListItem(PluginIdValue);
            PluginAccessDeleteOwnTemplateValue = PluginAccessDeleteOwnTemplateValue.HtmlInputSetCheckBoxListValue(lcp.PluginAccessDeleteOwnListItem);

            // Set Plugin Access EditOwn Selected Value
            lcp.FillPluginAccessEditOwnListItem(PluginIdValue);
            PluginAccessEditOwnTemplateValue = PluginAccessEditOwnTemplateValue.HtmlInputSetCheckBoxListValue(lcp.PluginAccessEditOwnListItem);

            // Set Plugin Access Delete All Selected Value
            lcp.FillPluginAccessDeleteAllListItem(PluginIdValue);
            PluginAccessDeleteAllTemplateValue = PluginAccessDeleteAllTemplateValue.HtmlInputSetCheckBoxListValue(lcp.PluginAccessDeleteAllListItem);

            // Set Plugin Access Edit All Selected Value
            lcp.FillPluginAccessEditAllListItem(PluginIdValue);
            PluginAccessEditAllTemplateValue = PluginAccessEditAllTemplateValue.HtmlInputSetCheckBoxListValue(lcp.PluginAccessEditAllListItem);

            // Set Plugin Menu Selected Value
            lcp.FillPluginMenuListItem(PluginIdValue);
            PluginMenuTemplateValue = PluginMenuTemplateValue.HtmlInputSetCheckBoxListValue(lcp.PluginMenuListItem);

            // Set Plugin Menu Query String
            SetPluginMenuQueryString(lcp.PluginMenuListItem, lcp.PluginMenuQueryStringListItem);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

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
            InputRequest.Add("hdn_PluginId", PluginIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/plugin/");

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

        public void SavePlugin(HttpContext context)
        {
            // Change Database Data
            DataUse.Plugin dum = new DataUse.Plugin();

            dum.PluginId = PluginIdValue;
            dum.PluginCategory = PluginCategoryValue;
            dum.PluginLoadType = PluginLoadTypeOptionListSelectedValue;
            dum.PluginUseLanguage = PluginUseLanguageValue.BooleanToZeroOne();
            dum.PluginUseModule = PluginUseModuleValue.BooleanToZeroOne();
            dum.PluginUsePlugin = PluginUsePluginValue.BooleanToZeroOne();
            dum.PluginUseReplacePart = PluginUseReplacePartValue.BooleanToZeroOne();
            dum.PluginUseFetch = PluginUseFetchValue.BooleanToZeroOne();
            dum.PluginUseItem = PluginUseItemValue.BooleanToZeroOne();
            dum.PluginUseElanat = PluginUseElanatValue.BooleanToZeroOne();
            dum.PluginCacheDuration = (PluginCacheDurationValue.IsNumber()) ? PluginCacheDurationValue : "0";
            dum.PluginCacheParameters = PluginCacheParametersValue;
            dum.PluginPublicAccessAdd = PluginPublicAccessAddValue.BooleanToZeroOne();
            dum.PluginPublicAccessEditOwn = PluginPublicAccessEditOwnValue.BooleanToZeroOne();
            dum.PluginPublicAccessDeleteOwn = PluginPublicAccessDeleteOwnValue.BooleanToZeroOne();
            dum.PluginPublicAccessEditAll = PluginPublicAccessEditAllValue.BooleanToZeroOne();
            dum.PluginPublicAccessDeleteAll = PluginPublicAccessDeleteAllValue.BooleanToZeroOne();
            dum.PluginPublicAccessShow = PluginPublicAccessShowValue.BooleanToZeroOne();
            dum.PluginSortIndex = PluginSortIndexValue;
            dum.PluginActive = PluginActiveValue.BooleanToZeroOne();

            // Edit Plugin
            dum.Edit();

            // Delete Menu Plugin
            dum.DeleteMenuPlugin(dum.PluginId);

            // Add Menu Plugin
            List<string> PluginQueryString = new List<string>();
            foreach (ListItem item in PluginMenuListItem)
                if (item.Selected)
                    PluginQueryString.Add(context.Request.Form["txt_PluginMenuQueryString_Add_" + item.Value].ToString());
            dum.AddMenuPlugin(dum.PluginId, PluginMenuListItem, PluginQueryString);

            // Delete Plugin Role Access
            dum.DeletePluginRoleAccess(dum.PluginId);

            // Set Plugin Role Access
            dum.SetPluginRoleAccess(dum.PluginId, PluginAccessShowListItem, PluginAccessAddListItem, PluginAccessEditOwnListItem, PluginAccessDeleteOwnListItem, PluginAccessEditAllListItem, PluginAccessDeleteAllListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_plugin", dum.PluginName);
        }

        protected void SetPluginMenuQueryString(List<ListItem> MenuListItem, List<ListItem> QueryStringListItem)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/plugin/template/text_box.xml"));

            string PluginMenuQueryStringInputTemplate = doc.SelectSingleNode("template_root/plugin_menu_query_string_input_for_add").InnerText;
            string SumPluginMenuQueryStringInputTemplate = "";
            string TmpPluginMenuQueryStringInputTemplate = "";

            foreach (ListItem item in MenuListItem)
            {
                if (!item.Selected)
                    continue;

                DataUse.Menu dum = new DataUse.Menu();

                TmpPluginMenuQueryStringInputTemplate = PluginMenuQueryStringInputTemplate;
                TmpPluginMenuQueryStringInputTemplate = TmpPluginMenuQueryStringInputTemplate.Replace("$_asp plugin_menu_value;", item.Value);
                TmpPluginMenuQueryStringInputTemplate = TmpPluginMenuQueryStringInputTemplate.Replace("$_asp plugin_menu_name;", dum.GetMenuName(item.Value));

                foreach (ListItem item2 in QueryStringListItem)
                    if (item2.Value == item.Value)
                    {
                        TmpPluginMenuQueryStringInputTemplate = TmpPluginMenuQueryStringInputTemplate.Replace("$_asp plugin_menu_query_string_value;", item2.Text);
                        break;
                    }

                SumPluginMenuQueryStringInputTemplate += TmpPluginMenuQueryStringInputTemplate;
            }

            PluginMenuQueryStringValue = SumPluginMenuQueryStringInputTemplate;
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/plugin/action/SuccessMessage.aspx");
        }
    }
}