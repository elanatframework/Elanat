using CodeBehind;

namespace Elanat
{
    public partial class ActionEditComponentModel : CodeBehindModel
    {
        public string EditComponentLanguage { get; set; }
        public string SaveComponentLanguage { get; set; }
        public string ComponentPathLanguage { get; set; }
        public string UseComponentPathLanguage { get; set; }
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

        public bool IsFirstStart { get; set; } = true;
        public string ComponentIdValue { get; set; }

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

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/");
            SaveComponentLanguage = aol.GetAddOnsLanguage("save_component");
            EditComponentLanguage = aol.GetAddOnsLanguage("edit_component");
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
            ComponentCacheDurationLanguage = aol.GetAddOnsLanguage("component_cache_duration");
            ComponentCacheParametersLanguage = aol.GetAddOnsLanguage("component_cache_parameters");
            ComponentUseLanguageLanguage = aol.GetAddOnsLanguage("component_use_language");
            ComponentUseModuleLanguage = aol.GetAddOnsLanguage("component_use_module");
            ComponentUsePluginLanguage = aol.GetAddOnsLanguage("component_use_plugin");
            ComponentUseReplacePartLanguage = aol.GetAddOnsLanguage("component_use_replace_part");
            ComponentUseFetchLanguage = aol.GetAddOnsLanguage("component_use_fetch");
            ComponentUseItemLanguage = aol.GetAddOnsLanguage("component_use_item");
            ComponentUseElanatLanguage = aol.GetAddOnsLanguage("component_use_elanat");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Component duc = new DataUse.Component();
                duc.FillCurrentComponent(ComponentIdValue);

                ComponentCategoryValue = duc.ComponentCategory;
                ComponentLoadTypeOptionListSelectedValue = duc.ComponentLoadType;
                ComponentUseLanguageValue = duc.ComponentUseLanguage.ZeroOneToBoolean();
                ComponentUseModuleValue = duc.ComponentUseModule.ZeroOneToBoolean();
                ComponentUsePluginValue = duc.ComponentUsePlugin.ZeroOneToBoolean();
                ComponentUseReplacePartValue = duc.ComponentUseReplacePart.ZeroOneToBoolean();
                ComponentUseFetchValue = duc.ComponentUseFetch.ZeroOneToBoolean();
                ComponentUseItemValue = duc.ComponentUseItem.ZeroOneToBoolean();
                ComponentUseElanatValue = duc.ComponentUseElanat.ZeroOneToBoolean();
                ComponentCacheDurationValue = duc.ComponentCacheDuration;
                ComponentCacheParametersValue = duc.ComponentCacheParameters;
                ComponentPublicAccessAddValue = duc.ComponentPublicAccessAdd.ZeroOneToBoolean();
                ComponentPublicAccessEditOwnValue = duc.ComponentPublicAccessEditOwn.ZeroOneToBoolean();
                ComponentPublicAccessDeleteOwnValue = duc.ComponentPublicAccessDeleteOwn.ZeroOneToBoolean();
                ComponentPublicAccessEditAllValue = duc.ComponentPublicAccessEditAll.ZeroOneToBoolean();
                ComponentPublicAccessDeleteAllValue = duc.ComponentPublicAccessDeleteAll.ZeroOneToBoolean();
                ComponentPublicAccessShowValue = duc.ComponentPublicAccessShow.ZeroOneToBoolean();
                ComponentSortIndexValue = duc.ComponentSortIndex;
                ComponentActiveValue = duc.ComponentActive.ZeroOneToBoolean();
            }

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

            ListClass.Component lcc = new ListClass.Component();

            // Set Component Access Show Selected Value
            lcc.FillComponentAccessShowListItem(ComponentIdValue);
            ComponentAccessShowTemplateValue = ComponentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lcc.ComponentAccessShowListItem);

            // Set Component Access Add Selected Value
            lcc.FillComponentAccessAddListItem(ComponentIdValue);
            ComponentAccessAddTemplateValue = ComponentAccessAddTemplateValue.HtmlInputSetCheckBoxListValue(lcc.ComponentAccessAddListItem);

            // Set Component Access Delete Own Selected Value
            lcc.FillComponentAccessDeleteOwnListItem(ComponentIdValue);
            ComponentAccessDeleteOwnTemplateValue = ComponentAccessDeleteOwnTemplateValue.HtmlInputSetCheckBoxListValue(lcc.ComponentAccessDeleteOwnListItem);

            // Set Component Access EditOwn Selected Value
            lcc.FillComponentAccessEditOwnListItem(ComponentIdValue);
            ComponentAccessEditOwnTemplateValue = ComponentAccessEditOwnTemplateValue.HtmlInputSetCheckBoxListValue(lcc.ComponentAccessEditOwnListItem);

            // Set Component Access Delete All Selected Value
            lcc.FillComponentAccessDeleteAllListItem(ComponentIdValue);
            ComponentAccessDeleteAllTemplateValue = ComponentAccessDeleteAllTemplateValue.HtmlInputSetCheckBoxListValue(lcc.ComponentAccessDeleteAllListItem);

            // Set Component Access Edit All Selected Value
            lcc.FillComponentAccessEditAllListItem(ComponentIdValue);
            ComponentAccessEditAllTemplateValue = ComponentAccessEditAllTemplateValue.HtmlInputSetCheckBoxListValue(lcc.ComponentAccessEditAllListItem);
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
            InputRequest.Add("hdn_ComponentId", ComponentIdValue);

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

        public void SaveComponent()
        {
            // Change Database Data
            DataUse.Component duc = new DataUse.Component();

            duc.ComponentId = ComponentIdValue;
            duc.ComponentCategory = ComponentCategoryValue;
            duc.ComponentLoadType = ComponentLoadTypeOptionListSelectedValue;
            duc.ComponentUseLanguage = ComponentUseLanguageValue.BooleanToZeroOne();
            duc.ComponentUseModule = ComponentUseModuleValue.BooleanToZeroOne();
            duc.ComponentUsePlugin = ComponentUsePluginValue.BooleanToZeroOne();
            duc.ComponentUseReplacePart = ComponentUseReplacePartValue.BooleanToZeroOne();
            duc.ComponentUseFetch = ComponentUseFetchValue.BooleanToZeroOne();
            duc.ComponentUseItem = ComponentUseItemValue.BooleanToZeroOne();
            duc.ComponentUseElanat = ComponentUseElanatValue.BooleanToZeroOne();
            duc.ComponentCacheDuration = (ComponentCacheDurationValue.IsNumber()) ? ComponentCacheDurationValue : "0";
            duc.ComponentCacheParameters = ComponentCacheParametersValue;
            duc.ComponentPublicAccessAdd = ComponentPublicAccessAddValue.BooleanToZeroOne();
            duc.ComponentPublicAccessEditOwn = ComponentPublicAccessEditOwnValue.BooleanToZeroOne();
            duc.ComponentPublicAccessDeleteOwn = ComponentPublicAccessDeleteOwnValue.BooleanToZeroOne();
            duc.ComponentPublicAccessEditAll = ComponentPublicAccessEditAllValue.BooleanToZeroOne();
            duc.ComponentPublicAccessDeleteAll = ComponentPublicAccessDeleteAllValue.BooleanToZeroOne();
            duc.ComponentPublicAccessShow = ComponentPublicAccessShowValue.BooleanToZeroOne();
            duc.ComponentSortIndex = ComponentSortIndexValue;
            duc.ComponentActive = ComponentActiveValue.BooleanToZeroOne();

            // Edit Component
            duc.Edit();

            // Delete Component Role Access
            duc.DeleteComponentRoleAccess(duc.ComponentId);

            // Set Component Role Access
            duc.SetComponentRoleAccess(duc.ComponentId, ComponentAccessShowListItem, ComponentAccessAddListItem, ComponentAccessEditOwnListItem, ComponentAccessDeleteOwnListItem, ComponentAccessEditAllListItem, ComponentAccessDeleteAllListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_component", duc.ComponentName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/component/action/SuccessMessage.aspx");
        }
    }
}