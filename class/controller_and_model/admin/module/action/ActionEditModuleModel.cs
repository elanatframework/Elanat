using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionEditModuleModel : CodeBehindModel
    {
        public string EditModuleLanguage { get; set; }
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
        public string SaveModuleLanguage { get; set; }

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

        public bool IsFirstStart { get; set; } = true;
        public string ModuleIdValue { get; set; }
        public string ModuleMenuQueryStringValue { get; set; }

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

        public List<ListItem> ModuleMenuListItem = new List<ListItem>();
        public string ModuleMenuListValue { get; set; }
        public string ModuleMenuTemplateValue { get; set; }
        public List<ListItem> ModuleAccessShowListItem = new List<ListItem>();
        public string ModuleAccessShowListValue { get; set; }
        public string ModuleAccessShowTemplateValue { get; set; }
        public List<ListItem> ModuleAccessAddListItem = new List<ListItem>();
        public string ModuleAccessAddListValue { get; set; }
        public string ModuleAccessAddTemplateValue { get; set; }
        public List<ListItem> ModuleAccessEditOwnListItem = new List<ListItem>();
        public string ModuleAccessEditOwnListValue { get; set; }
        public string ModuleAccessEditOwnTemplateValue { get; set; }
        public List<ListItem> ModuleAccessDeleteOwnListItem = new List<ListItem>();
        public string ModuleAccessDeleteOwnListValue { get; set; }
        public string ModuleAccessDeleteOwnTemplateValue { get; set; }
        public List<ListItem> ModuleAccessEditAllListItem = new List<ListItem>();
        public string ModuleAccessEditAllListValue { get; set; }
        public string ModuleAccessEditAllTemplateValue { get; set; }
        public List<ListItem> ModuleAccessDeleteAllListItem = new List<ListItem>();
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

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/module/");
            SaveModuleLanguage = aol.GetAddOnsLanguage("save_module");
            EditModuleLanguage = aol.GetAddOnsLanguage("edit_module");
            ModuleCategoryLanguage = aol.GetAddOnsLanguage("module_category");
            ModuleLoadTypeLanguage = aol.GetAddOnsLanguage("module_load_type");
            ModuleAccessShowLanguage = aol.GetAddOnsLanguage("module_access_show");
            ModulePublicAccessShowLanguage = aol.GetAddOnsLanguage("module_public_access_show");
            ModulePublicAccessAddLanguage = aol.GetAddOnsLanguage("module_public_access_add");
            ModulePublicAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("module_public_access_delete_own");
            ModulePublicAccessDeleteAllLanguage = aol.GetAddOnsLanguage("module_public_access_delete_all");
            ModulePublicAccessEditOwnLanguage = aol.GetAddOnsLanguage("module_public_access_edit_own");
            ModulePublicAccessEditAllLanguage = aol.GetAddOnsLanguage("module_public_access_edit_all");
            ModuleAccessAddLanguage = aol.GetAddOnsLanguage("module_access_add"); ;
            ModuleAccessEditOwnLanguage = aol.GetAddOnsLanguage("module_access_edit_own");
            ModuleAccessDeleteOwnLanguage = aol.GetAddOnsLanguage("module_access_delete_own");
            ModuleAccessEditAllLanguage = aol.GetAddOnsLanguage("module_access_edit_all");
            ModuleAccessDeleteAllLanguage = aol.GetAddOnsLanguage("module_access_delete_all");
            ModuleSortIndexLanguage = aol.GetAddOnsLanguage("module_sort_index");
            ModuleMenuQueryStringLanguage = aol.GetAddOnsLanguage("module_menu_query_string");
            ModuleActiveLanguage = aol.GetAddOnsLanguage("module_active");
            ModuleCacheDurationLanguage = aol.GetAddOnsLanguage("module_cache_duration");
            ModuleCacheParametersLanguage = aol.GetAddOnsLanguage("module_cache_parameters");
            ModuleUseLanguageLanguage = aol.GetAddOnsLanguage("module_use_language");
            ModuleUseModuleLanguage = aol.GetAddOnsLanguage("module_use_module");
            ModuleUsePluginLanguage = aol.GetAddOnsLanguage("module_use_plugin");
            ModuleUseReplacePartLanguage = aol.GetAddOnsLanguage("module_use_replace_part");
            ModuleUseFetchLanguage = aol.GetAddOnsLanguage("module_use_fetch");
            ModuleUseItemLanguage = aol.GetAddOnsLanguage("module_use_item");
            ModuleUseElanatLanguage = aol.GetAddOnsLanguage("module_use_elanat");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Module dum = new DataUse.Module();
                dum.FillCurrentModule(ModuleIdValue);

                ModuleCategoryValue = dum.ModuleCategory;
                ModuleLoadTypeOptionListSelectedValue = dum.ModuleLoadType;
                ModuleUseLanguageValue = dum.ModuleUseLanguage.ZeroOneToBoolean();
                ModuleUseModuleValue = dum.ModuleUseModule.ZeroOneToBoolean();
                ModuleUsePluginValue = dum.ModuleUsePlugin.ZeroOneToBoolean();
                ModuleUseReplacePartValue = dum.ModuleUseReplacePart.ZeroOneToBoolean();
                ModuleUseFetchValue = dum.ModuleUseFetch.ZeroOneToBoolean();
                ModuleUseItemValue = dum.ModuleUseItem.ZeroOneToBoolean();
                ModuleUseElanatValue = dum.ModuleUseElanat.ZeroOneToBoolean();
                ModuleCacheDurationValue = dum.ModuleCacheDuration;
                ModuleCacheParametersValue = dum.ModuleCacheParameters;
                ModulePublicAccessAddValue = dum.ModulePublicAccessAdd.ZeroOneToBoolean();
                ModulePublicAccessEditOwnValue = dum.ModulePublicAccessEditOwn.ZeroOneToBoolean();
                ModulePublicAccessDeleteOwnValue = dum.ModulePublicAccessDeleteOwn.ZeroOneToBoolean();
                ModulePublicAccessEditAllValue = dum.ModulePublicAccessEditAll.ZeroOneToBoolean();
                ModulePublicAccessDeleteAllValue = dum.ModulePublicAccessDeleteAll.ZeroOneToBoolean();
                ModulePublicAccessShowValue = dum.ModulePublicAccessShow.ZeroOneToBoolean();
                ModuleSortIndexValue = dum.ModuleSortIndex;
                ModuleActiveValue = dum.ModuleActive.ZeroOneToBoolean();
            }

            // Set Page Loader Item
            ListClass.PageLoadType lcplt = new ListClass.PageLoadType();
            lcplt.FillPageLoadTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ModuleLoadTypeOptionListValue += lcplt.PageLoadTypeListItem.HtmlInputToOptionTag(ModuleLoadTypeOptionListSelectedValue);

            // Set Menu
            ListClass.Menu lcm = new ListClass.Menu();
            lcm.FillMenuListItem(StaticObject.GetCurrentSiteSiteId());
            HtmlCheckBoxList HtmlCheckBoxListMenu = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleMenu");
            HtmlCheckBoxListMenu.AddRange(lcm.MenuListItem);
            ModuleMenuTemplateValue = HtmlCheckBoxListMenu.GetValue();
            ModuleMenuListValue = HtmlCheckBoxListMenu.GetList();
            ModuleMenuTemplateValue = ModuleMenuTemplateValue.Replace("$_asp attribute;", ModuleMenuAttribute);
            ModuleMenuTemplateValue = ModuleMenuTemplateValue.Replace("$_asp css_class;", ModuleMenuCssClass);
            ModuleMenuTemplateValue = ModuleMenuTemplateValue.HtmlInputSetCheckBoxListValue(ModuleMenuListItem);

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Module Access Show
            HtmlCheckBoxList HtmlCheckBoxListGroupRole = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessShow");
            HtmlCheckBoxListGroupRole.AddRange(lcu.UserRoleListItem);
            ModuleAccessShowTemplateValue = HtmlCheckBoxListGroupRole.GetValue();
            ModuleAccessShowListValue = HtmlCheckBoxListGroupRole.GetList();
            ModuleAccessShowTemplateValue = ModuleAccessShowTemplateValue.Replace("$_asp attribute;", ModuleAccessShowAttribute);
            ModuleAccessShowTemplateValue = ModuleAccessShowTemplateValue.Replace("$_asp css_class;", ModuleAccessShowCssClass);
            ModuleAccessShowTemplateValue = ModuleAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessShowListItem);

            // Module Access Add
            HtmlCheckBoxList HtmlCheckBoxListAccessAdd = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessAdd");
            HtmlCheckBoxListAccessAdd.AddRange(lcu.UserRoleListItem);
            ModuleAccessAddTemplateValue = HtmlCheckBoxListAccessAdd.GetValue();
            ModuleAccessAddListValue = HtmlCheckBoxListAccessAdd.GetList();
            ModuleAccessAddTemplateValue = ModuleAccessAddTemplateValue.Replace("$_asp attribute;", ModuleAccessAddAttribute);
            ModuleAccessAddTemplateValue = ModuleAccessAddTemplateValue.Replace("$_asp css_class;", ModuleAccessAddCssClass);
            ModuleAccessAddTemplateValue = ModuleAccessAddTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessAddListItem);

            // Module Access Delete All
            HtmlCheckBoxList HtmlCheckBoxListAccessDeleteAll = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessDeleteAll");
            HtmlCheckBoxListAccessDeleteAll.AddRange(lcu.UserRoleListItem);
            ModuleAccessDeleteAllTemplateValue = HtmlCheckBoxListAccessDeleteAll.GetValue();
            ModuleAccessDeleteAllListValue = HtmlCheckBoxListAccessDeleteAll.GetList();
            ModuleAccessDeleteAllTemplateValue = ModuleAccessDeleteAllTemplateValue.Replace("$_asp attribute;", ModuleAccessDeleteAllAttribute);
            ModuleAccessDeleteAllTemplateValue = ModuleAccessDeleteAllTemplateValue.Replace("$_asp css_class;", ModuleAccessDeleteAllCssClass);
            ModuleAccessDeleteAllTemplateValue = ModuleAccessDeleteAllTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessDeleteAllListItem);

            // Module Access Delete Own
            HtmlCheckBoxList HtmlCheckBoxListAccessDeleteOwn = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessDeleteOwn");
            HtmlCheckBoxListAccessDeleteOwn.AddRange(lcu.UserRoleListItem);
            ModuleAccessDeleteOwnTemplateValue = HtmlCheckBoxListAccessDeleteOwn.GetValue();
            ModuleAccessDeleteOwnListValue = HtmlCheckBoxListAccessDeleteOwn.GetList();
            ModuleAccessDeleteOwnTemplateValue = ModuleAccessDeleteOwnTemplateValue.Replace("$_asp attribute;", ModuleAccessDeleteOwnAttribute);
            ModuleAccessDeleteOwnTemplateValue = ModuleAccessDeleteOwnTemplateValue.Replace("$_asp css_class;", ModuleAccessDeleteOwnCssClass);
            ModuleAccessDeleteOwnTemplateValue = ModuleAccessDeleteOwnTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessDeleteOwnListItem);

            // Module Access Edit All
            HtmlCheckBoxList HtmlCheckBoxListAccessEditAll = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessEditAll");
            HtmlCheckBoxListAccessEditAll.AddRange(lcu.UserRoleListItem);
            ModuleAccessEditAllTemplateValue = HtmlCheckBoxListAccessEditAll.GetValue();
            ModuleAccessEditAllListValue = HtmlCheckBoxListAccessEditAll.GetList();
            ModuleAccessEditAllTemplateValue = ModuleAccessEditAllTemplateValue.Replace("$_asp attribute;", ModuleAccessEditAllAttribute);
            ModuleAccessEditAllTemplateValue = ModuleAccessEditAllTemplateValue.Replace("$_asp css_class;", ModuleAccessEditAllCssClass);
            ModuleAccessEditAllTemplateValue = ModuleAccessEditAllTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessEditAllListItem);

            // Module Access Edit Own
            HtmlCheckBoxList HtmlCheckBoxListAccessEditOwn = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/module/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ModuleAccessEditOwn");
            HtmlCheckBoxListAccessEditOwn.AddRange(lcu.UserRoleListItem);
            ModuleAccessEditOwnTemplateValue = HtmlCheckBoxListAccessEditOwn.GetValue();
            ModuleAccessEditOwnListValue = HtmlCheckBoxListAccessEditOwn.GetList();
            ModuleAccessEditOwnTemplateValue = ModuleAccessEditOwnTemplateValue.Replace("$_asp attribute;", ModuleAccessEditOwnAttribute);
            ModuleAccessEditOwnTemplateValue = ModuleAccessEditOwnTemplateValue.Replace("$_asp css_class;", ModuleAccessEditOwnCssClass);
            ModuleAccessEditOwnTemplateValue = ModuleAccessEditOwnTemplateValue.HtmlInputSetCheckBoxListValue(ModuleAccessEditOwnListItem);

            ListClass.Module lcm2 = new ListClass.Module();

            // Set Module Access Show Selected Value
            lcm2.FillModuleAccessShowListItem(ModuleIdValue);
            ModuleAccessShowTemplateValue = ModuleAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lcm2.ModuleAccessShowListItem);

            // Set Module Access Add Selected Value
            lcm2.FillModuleAccessAddListItem(ModuleIdValue);
            ModuleAccessAddTemplateValue = ModuleAccessAddTemplateValue.HtmlInputSetCheckBoxListValue(lcm2.ModuleAccessAddListItem);

            // Set Module Access Delete Own Selected Value
            lcm2.FillModuleAccessDeleteOwnListItem(ModuleIdValue);
            ModuleAccessDeleteOwnTemplateValue = ModuleAccessDeleteOwnTemplateValue.HtmlInputSetCheckBoxListValue(lcm2.ModuleAccessDeleteOwnListItem);

            // Set Module Access EditOwn Selected Value
            lcm2.FillModuleAccessEditOwnListItem(ModuleIdValue);
            ModuleAccessEditOwnTemplateValue = ModuleAccessEditOwnTemplateValue.HtmlInputSetCheckBoxListValue(lcm2.ModuleAccessEditOwnListItem);

            // Set Module Access Delete All Selected Value
            lcm2.FillModuleAccessDeleteAllListItem(ModuleIdValue);
            ModuleAccessDeleteAllTemplateValue = ModuleAccessDeleteAllTemplateValue.HtmlInputSetCheckBoxListValue(lcm2.ModuleAccessDeleteAllListItem);

            // Set Module Access Edit All Selected Value
            lcm2.FillModuleAccessEditAllListItem(ModuleIdValue);
            ModuleAccessEditAllTemplateValue = ModuleAccessEditAllTemplateValue.HtmlInputSetCheckBoxListValue(lcm2.ModuleAccessEditAllListItem);

            // Set Module Menu Selected Value
            lcm2.FillModuleMenuListItem(ModuleIdValue);
            ModuleMenuTemplateValue = ModuleMenuTemplateValue.HtmlInputSetCheckBoxListValue(lcm2.ModuleMenuListItem);

            // Set Module Menu Query String
            SetModuleMenuQueryString(lcm2.ModuleMenuListItem, lcm2.ModuleMenuQueryStringListItem);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

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
            InputRequest.Add("hdn_ModuleId", ModuleIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/module/");

            ModuleCategoryAttribute += vc.ImportantInputAttribute.GetValue("txt_ModuleCategory");
            ModuleLoadTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ModuleLoadType");
            ModuleCacheDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_ModuleCacheDuration");
            ModuleCacheParametersAttribute += vc.ImportantInputAttribute.GetValue("txt_ModuleCacheParameters");
            ModuleSortIndexAttribute += vc.ImportantInputAttribute.GetValue("txt_ModuleSortIndex");
            ModuleMenuAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ModuleMenu");
            ModuleAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ModuleAccessShow");
            ModuleAccessAddAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ModuleAccessAdd");
            ModuleAccessDeleteOwnAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ModuleAccessDeleteOwn");
            ModuleAccessEditOwnAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ModuleAccessEditOwn");
            ModuleAccessDeleteAllAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ModuleAccessDeleteAll");
            ModuleAccessEditAllAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_ModuleAccessEditAll");

            ModuleCategoryCssClass = ModuleCategoryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ModuleCategory"));
            ModuleLoadTypeCssClass = ModuleLoadTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ModuleLoadType"));
            ModuleCacheDurationCssClass = ModuleCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ModuleCacheDuration"));
            ModuleCacheParametersCssClass = ModuleCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ModuleCacheParameters"));
            ModuleSortIndexCssClass = ModuleSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ModuleSortIndex"));
            ModuleMenuCssClass = ModuleMenuCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ModuleMenu"));
            ModuleAccessShowCssClass = ModuleAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ModuleAccessShow"));
            ModuleAccessAddCssClass = ModuleAccessAddCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ModuleAccessAdd"));
            ModuleAccessDeleteOwnCssClass = ModuleAccessDeleteOwnCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ModuleAccessDeleteOwn"));
            ModuleAccessEditOwnCssClass = ModuleAccessEditOwnCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ModuleAccessEditOwn"));
            ModuleAccessDeleteAllCssClass = ModuleAccessDeleteAllCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ModuleAccessDeleteAll"));
            ModuleAccessEditAllCssClass = ModuleAccessEditAllCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_ModuleAccessEditAll"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/module/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveModule(HttpContext context)
        {
            // Change Database Data
            DataUse.Module dum = new DataUse.Module();

            dum.ModuleId = ModuleIdValue;
            dum.ModuleCategory = ModuleCategoryValue;
            dum.ModuleLoadType = ModuleLoadTypeOptionListSelectedValue;
            dum.ModuleUseLanguage = ModuleUseLanguageValue.BooleanToZeroOne();
            dum.ModuleUseModule = ModuleUseModuleValue.BooleanToZeroOne();
            dum.ModuleUsePlugin = ModuleUsePluginValue.BooleanToZeroOne();
            dum.ModuleUseReplacePart = ModuleUseReplacePartValue.BooleanToZeroOne();
            dum.ModuleUseFetch = ModuleUseFetchValue.BooleanToZeroOne();
            dum.ModuleUseItem = ModuleUseItemValue.BooleanToZeroOne();
            dum.ModuleUseElanat = ModuleUseElanatValue.BooleanToZeroOne();
            dum.ModuleCacheDuration = (ModuleCacheDurationValue.IsNumber()) ? ModuleCacheDurationValue : "0";
            dum.ModuleCacheParameters = ModuleCacheParametersValue;
            dum.ModulePublicAccessAdd = ModulePublicAccessAddValue.BooleanToZeroOne();
            dum.ModulePublicAccessEditOwn = ModulePublicAccessEditOwnValue.BooleanToZeroOne();
            dum.ModulePublicAccessDeleteOwn = ModulePublicAccessDeleteOwnValue.BooleanToZeroOne();
            dum.ModulePublicAccessEditAll = ModulePublicAccessEditAllValue.BooleanToZeroOne();
            dum.ModulePublicAccessDeleteAll = ModulePublicAccessDeleteAllValue.BooleanToZeroOne();
            dum.ModulePublicAccessShow = ModulePublicAccessShowValue.BooleanToZeroOne();
            dum.ModuleSortIndex = ModuleSortIndexValue;
            dum.ModuleActive = ModuleActiveValue.BooleanToZeroOne();

            // Edit Module
            dum.Edit();

            // Delete Menu Module
            dum.DeleteMenuModule(dum.ModuleId);

            // Add Menu Module
            List<string> ModuleQueryString = new List<string>();
            foreach (ListItem item in ModuleMenuListItem)
                if (item.Selected)
                    ModuleQueryString.Add(context.Request.Form["txt_ModuleMenuQueryString_Add_" + item.Value].ToString());
            dum.AddMenuModule(dum.ModuleId, ModuleMenuListItem, ModuleQueryString);

            // Delete Module Role Access
            dum.DeleteModuleRoleAccess(dum.ModuleId);

            // Set Module Role Access
            dum.SetModuleRoleAccess(dum.ModuleId, ModuleAccessShowListItem, ModuleAccessAddListItem, ModuleAccessEditOwnListItem, ModuleAccessDeleteOwnListItem, ModuleAccessEditAllListItem, ModuleAccessDeleteAllListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_module", dum.ModuleName);
        }

        protected void SetModuleMenuQueryString(List<ListItem> MenuListItem, List<ListItem> QueryStringListItem)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/module/template/text_box.xml"));

            string ModuleMenuQueryStringInputTemplate = doc.SelectSingleNode("template_root/module_menu_query_string_input_for_add").InnerText;
            string SumModuleMenuQueryStringInputTemplate = "";
            string TmpModuleMenuQueryStringInputTemplate = "";

            foreach (ListItem item in MenuListItem)
            {
                if (!item.Selected)
                    continue;

                DataUse.Menu dum = new DataUse.Menu();

                TmpModuleMenuQueryStringInputTemplate = ModuleMenuQueryStringInputTemplate;
                TmpModuleMenuQueryStringInputTemplate = TmpModuleMenuQueryStringInputTemplate.Replace("$_asp module_menu_value;", item.Value);
                TmpModuleMenuQueryStringInputTemplate = TmpModuleMenuQueryStringInputTemplate.Replace("$_asp module_menu_name;", dum.GetMenuName(item.Value));

                foreach (ListItem item2 in QueryStringListItem)
                    if (item2.Value == item.Value)
                    {
                        TmpModuleMenuQueryStringInputTemplate = TmpModuleMenuQueryStringInputTemplate.Replace("$_asp module_menu_query_string_value;", item2.Text);
                        break;
                    }

                SumModuleMenuQueryStringInputTemplate += TmpModuleMenuQueryStringInputTemplate;
            }

            ModuleMenuQueryStringValue = SumModuleMenuQueryStringInputTemplate;
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/module/action/SuccessMessage.aspx");
        }
    }
}