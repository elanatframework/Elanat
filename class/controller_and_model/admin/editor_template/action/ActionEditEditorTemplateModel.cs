using CodeBehind;

namespace Elanat
{
    public partial class ActionEditEditorTemplateModel : CodeBehindModel
    {
        public string EditEditorTemplateLanguage { get; set; }
        public string SaveEditorTemplateLanguage { get; set; }
        public string EditorTemplatePathLanguage { get; set; }
        public string UseEditorTemplatePathLanguage { get; set; }
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

        public bool IsFirstStart { get; set; } = true;
        public string EditorTemplateIdValue { get; set; }

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

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/editor_template/");
            SaveEditorTemplateLanguage = aol.GetAddOnsLanguage("save_editor_template");
            EditEditorTemplateLanguage = aol.GetAddOnsLanguage("edit_editor_template");
            EditorTemplateCategoryLanguage = aol.GetAddOnsLanguage("editor_template_category");
            EditorTemplateActiveLanguage = aol.GetAddOnsLanguage("editor_template_active");
            EditorTemplatePublicAccessShowLanguage = aol.GetAddOnsLanguage("editor_template_public_access_show");
            EditorTemplateAccessShowLanguage = aol.GetAddOnsLanguage("editor_template_access_show");
            EditorTemplateSortIndexLanguage = aol.GetAddOnsLanguage("editor_template_sort_index");
            EditorTemplateCacheDurationLanguage = aol.GetAddOnsLanguage("editor_template_cache_duration");
            EditorTemplateCacheParametersLanguage = aol.GetAddOnsLanguage("editor_template_cache_parameters");
            EditorTemplateUseLanguageLanguage = aol.GetAddOnsLanguage("editor_template_use_language");
            EditorTemplateUseModuleLanguage = aol.GetAddOnsLanguage("editor_template_use_module");
            EditorTemplateUsePluginLanguage = aol.GetAddOnsLanguage("editor_template_use_plugin");
            EditorTemplateUseReplacePartLanguage = aol.GetAddOnsLanguage("editor_template_use_replace_part");
            EditorTemplateUseFetchLanguage = aol.GetAddOnsLanguage("editor_template_use_fetch");
            EditorTemplateUseItemLanguage = aol.GetAddOnsLanguage("editor_template_use_item");
            EditorTemplateUseElanatLanguage = aol.GetAddOnsLanguage("editor_template_use_elanat");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.EditorTemplate dueh = new DataUse.EditorTemplate();
                dueh.FillCurrentEditorTemplate(EditorTemplateIdValue);

                EditorTemplateUseLanguageValue = dueh.EditorTemplateUseLanguage.ZeroOneToBoolean();
                EditorTemplateUseModuleValue = dueh.EditorTemplateUseModule.ZeroOneToBoolean();
                EditorTemplateUsePluginValue = dueh.EditorTemplateUsePlugin.ZeroOneToBoolean();
                EditorTemplateUseReplacePartValue = dueh.EditorTemplateUseReplacePart.ZeroOneToBoolean();
                EditorTemplateUseFetchValue = dueh.EditorTemplateUseFetch.ZeroOneToBoolean();
                EditorTemplateUseItemValue = dueh.EditorTemplateUseItem.ZeroOneToBoolean();
                EditorTemplateUseElanatValue = dueh.EditorTemplateUseElanat.ZeroOneToBoolean();
                EditorTemplateCacheDurationValue = dueh.EditorTemplateCacheDuration;
                EditorTemplateCacheParametersValue = dueh.EditorTemplateCacheParameters;
                EditorTemplateCategoryValue = dueh.EditorTemplateCategory;
                EditorTemplatePublicAccessShowValue = dueh.EditorTemplatePublicAccessShow.ZeroOneToBoolean();
                EditorTemplateSortIndexValue = dueh.EditorTemplateSortIndex;
                EditorTemplateActiveValue = dueh.EditorTemplateActive.ZeroOneToBoolean();
            }

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

            // Set Editor Template Access Show Selected Value
            ListClass.EditorTemplate lcet = new ListClass.EditorTemplate();
            lcet.FillEditorTemplateAccessShowListItem(EditorTemplateIdValue);
            EditorTemplateAccessShowTemplateValue = EditorTemplateAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lcet.EditorTemplateAccessShowListItem);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_EditorTemplateCategory", "");
            InputRequest.Add("txt_EditorTemplateCacheDuration", "");
            InputRequest.Add("txt_EditorTemplateCacheParameters", "");
            InputRequest.Add("txt_EditorTemplateSortIndex", "");
            InputRequest.Add("cbxlst_EditorTemplateAccessShow", EditorTemplateAccessShowListValue);
            InputRequest.Add("hdn_EditorTemplateId", EditorTemplateIdValue);


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

        public void SaveEditorTemplate()
        {
            // Change Database Data
            DataUse.EditorTemplate dueh = new DataUse.EditorTemplate();

            dueh.EditorTemplateId = EditorTemplateIdValue;
            dueh.EditorTemplateUseLanguage = EditorTemplateUseLanguageValue.BooleanToZeroOne();
            dueh.EditorTemplateUseModule = EditorTemplateUseModuleValue.BooleanToZeroOne();
            dueh.EditorTemplateUsePlugin = EditorTemplateUsePluginValue.BooleanToZeroOne();
            dueh.EditorTemplateUseReplacePart = EditorTemplateUseReplacePartValue.BooleanToZeroOne();
            dueh.EditorTemplateUseFetch = EditorTemplateUseFetchValue.BooleanToZeroOne();
            dueh.EditorTemplateUseItem = EditorTemplateUseItemValue.BooleanToZeroOne();
            dueh.EditorTemplateUseElanat = EditorTemplateUseElanatValue.BooleanToZeroOne();
            dueh.EditorTemplateCacheDuration = (EditorTemplateCacheDurationValue.IsNumber()) ? EditorTemplateCacheDurationValue : "0";
            dueh.EditorTemplateCacheParameters = EditorTemplateCacheParametersValue;
            dueh.EditorTemplateCategory = EditorTemplateCategoryValue;
            dueh.EditorTemplatePublicAccessShow = EditorTemplatePublicAccessShowValue.BooleanToZeroOne();
            dueh.EditorTemplateSortIndex = EditorTemplateSortIndexValue;
            dueh.EditorTemplateActive = EditorTemplateActiveValue.BooleanToZeroOne();

            // Edit EditorTemplate
            dueh.Edit();

            // Delete EditorTemplate Access Show
            dueh.DeleteEditorTemplateAccessShow(dueh.EditorTemplateId);

            // Set EditorTemplate Access Show
            dueh.SetEditorTemplateAccessShow(dueh.EditorTemplateId, EditorTemplateAccessShowListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_editor_template", dueh.EditorTemplateName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/editor_template/action/SuccessMessage.aspx");
        }
    }
}