﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionEditExtraHelperModel
    {
        public string EditExtraHelperLanguage { get; set; }
        public string SaveExtraHelperLanguage { get; set; }
        public string ExtraHelperPathLanguage { get; set; }
        public string UseExtraHelperPathLanguage { get; set; }
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

        public bool IsFirstStart { get; set; } = true;
        public string ExtraHelperIdValue { get; set; }

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

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/extra_helper/");
            SaveExtraHelperLanguage = aol.GetAddOnsLanguage("save_extra_helper");
            EditExtraHelperLanguage = aol.GetAddOnsLanguage("edit_extra_helper");
            ExtraHelperCategoryLanguage = aol.GetAddOnsLanguage("extra_helper_category");
            ExtraHelperActiveLanguage = aol.GetAddOnsLanguage("extra_helper_active");
            ExtraHelperPublicAccessShowLanguage = aol.GetAddOnsLanguage("extra_helper_public_access_show");
            ExtraHelperAccessShowLanguage = aol.GetAddOnsLanguage("extra_helper_access_show");
            ExtraHelperSortIndexLanguage = aol.GetAddOnsLanguage("extra_helper_sort_index");
            ExtraHelperCacheDurationLanguage = aol.GetAddOnsLanguage("extra_helper_cache_duration");
            ExtraHelperCacheParametersLanguage = aol.GetAddOnsLanguage("extra_helper_cache_parameters");
            ExtraHelperUseLanguageLanguage = aol.GetAddOnsLanguage("extra_helper_use_language");
            ExtraHelperUseModuleLanguage = aol.GetAddOnsLanguage("extra_helper_use_module");
            ExtraHelperUsePluginLanguage = aol.GetAddOnsLanguage("extra_helper_use_plugin");
            ExtraHelperUseReplacePartLanguage = aol.GetAddOnsLanguage("extra_helper_use_replace_part");
            ExtraHelperUseFetchLanguage = aol.GetAddOnsLanguage("extra_helper_use_fetch");
            ExtraHelperUseItemLanguage = aol.GetAddOnsLanguage("extra_helper_use_item");
            ExtraHelperUseElanatLanguage = aol.GetAddOnsLanguage("extra_helper_use_elanat");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();
                dueh.FillCurrentExtraHelper(ExtraHelperIdValue);

                ExtraHelperUseLanguageValue = dueh.ExtraHelperUseLanguage.ZeroOneToBoolean();
                ExtraHelperUseModuleValue = dueh.ExtraHelperUseModule.ZeroOneToBoolean();
                ExtraHelperUsePluginValue = dueh.ExtraHelperUsePlugin.ZeroOneToBoolean();
                ExtraHelperUseReplacePartValue = dueh.ExtraHelperUseReplacePart.ZeroOneToBoolean();
                ExtraHelperUseFetchValue = dueh.ExtraHelperUseFetch.ZeroOneToBoolean();
                ExtraHelperUseItemValue = dueh.ExtraHelperUseItem.ZeroOneToBoolean();
                ExtraHelperUseElanatValue = dueh.ExtraHelperUseElanat.ZeroOneToBoolean();
                ExtraHelperCacheDurationValue = dueh.ExtraHelperCacheDuration;
                ExtraHelperCacheParametersValue = dueh.ExtraHelperCacheParameters;
                ExtraHelperCategoryValue = dueh.ExtraHelperCategory;
                ExtraHelperPublicAccessShowValue = dueh.ExtraHelperPublicAccessShow.ZeroOneToBoolean();
                ExtraHelperSortIndexValue = dueh.ExtraHelperSortIndex;
                ExtraHelperActiveValue = dueh.ExtraHelperActive.ZeroOneToBoolean();
            }

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

            // Set Extra Helper Access Show Selected Value
            lc.FillExtraHelperAccessShowListItem(ExtraHelperIdValue);
            ExtraHelperAccessShowTemplateValue = ExtraHelperAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lc.ExtraHelperAccessShowListItem);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_ExtraHelperCategory", "");
            InputRequest.Add("txt_ExtraHelperCacheDuration", "");
            InputRequest.Add("txt_ExtraHelperCacheParameters", "");
            InputRequest.Add("txt_ExtraHelperSortIndex", "");
            InputRequest.Add("cbxlst_ExtraHelperAccessShow", ExtraHelperAccessShowListValue);
            InputRequest.Add("hdn_ExtraHelperId", ExtraHelperIdValue);


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

        public void SaveExtraHelper()
        {
            // Change Database Data
            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();

            dueh.ExtraHelperId = ExtraHelperIdValue;
            dueh.ExtraHelperUseLanguage = ExtraHelperUseLanguageValue.BooleanToZeroOne();
            dueh.ExtraHelperUseModule = ExtraHelperUseModuleValue.BooleanToZeroOne();
            dueh.ExtraHelperUsePlugin = ExtraHelperUsePluginValue.BooleanToZeroOne();
            dueh.ExtraHelperUseReplacePart = ExtraHelperUseReplacePartValue.BooleanToZeroOne();
            dueh.ExtraHelperUseFetch = ExtraHelperUseFetchValue.BooleanToZeroOne();
            dueh.ExtraHelperUseItem = ExtraHelperUseItemValue.BooleanToZeroOne();
            dueh.ExtraHelperUseElanat = ExtraHelperUseElanatValue.BooleanToZeroOne();
            dueh.ExtraHelperCacheDuration = (ExtraHelperCacheDurationValue.IsNumber()) ? ExtraHelperCacheDurationValue : "0";
            dueh.ExtraHelperCacheParameters = ExtraHelperCacheParametersValue;
            dueh.ExtraHelperCategory = ExtraHelperCategoryValue;
            dueh.ExtraHelperPublicAccessShow = ExtraHelperPublicAccessShowValue.BooleanToZeroOne();
            dueh.ExtraHelperSortIndex = ExtraHelperSortIndexValue;
            dueh.ExtraHelperActive = ExtraHelperActiveValue.BooleanToZeroOne();

            // Edit ExtraHelper
            dueh.Edit();

            // Delete ExtraHelper Access Show
            dueh.DeleteExtraHelperAccessShow(dueh.ExtraHelperId);

            // Set ExtraHelper Access Show
            dueh.SetExtraHelperAccessShow(dueh.ExtraHelperId, ExtraHelperAccessShowListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_extra_helper", dueh.ExtraHelperName);
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/extra_helper/action/SuccessMessage.aspx");
        }
    }
}