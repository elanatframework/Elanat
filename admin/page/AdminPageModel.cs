using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class AdminPageModel
    {
        public string PageQueryStringLanguage { get; set; }
        public string PageCacheDurationLanguage { get; set; }
        public string PageCacheParametersLanguage { get; set; }
        public string PageDescriptionMetaLanguage { get; set; }
        public string PageKeywordsMetaLanguage { get; set; }
        public string PageLoadTypeLanguage { get; set; }
        public string PagePathLanguage { get; set; }
        public string PageRevisitAfternMetaLanguage { get; set; }
        public string PageRightsMetaLanguage { get; set; }
        public string PageAccessShowLanguage { get; set; }
        public string PageSiteLanguage { get; set; }
        public string PageStaticHeadLanguage { get; set; }
        public string PageStyleLanguage { get; set; }
        public string PageTemplateeLanguage { get; set; }
        public string PageLanguage { get; set; }
        public string AddPageLanguage { get; set; }
        public string PageActiveLanguage { get; set; }
        public string PageLoadAloneLanguage { get; set; }
        public string UsePagePathLanguage { get; set; }
        public string PageShowLinkInSiteLanguage { get; set; }
        public string PageUseLanguageLanguage { get; set; }
        public string PageUseModuleLanguage { get; set; }
        public string PageUsePluginLanguage { get; set; }
        public string PageUseReplacePartLanguage { get; set; }
        public string PageUseFetchLanguage { get; set; }
        public string PageUseItemLanguage { get; set; }
        public string PageUseElanatLanguage { get; set; }
        public string PageUseAuthorMetaLanguage { get; set; }
        public string PageUseKeywordsMetaLanguage { get; set; }
        public string PageUseRevisitAfterMetaLanguage { get; set; }
        public string PageUseRightsMetaLanguage { get; set; }
        public string PageUseDescriptionMetaLanguage { get; set; }
        public string PagePublicAccessShowLanguage { get; set; }
        public string PageUseStaticHeadLanguage { get; set; }
        public string PageUseHtmlLanguage { get; set; }
        public string PageNameLanguage { get; set; }
        public string PageGlobalNameLanguage { get; set; }
        public string PageLoadTagLanguage { get; set; }
        public string PageUseLoadTagLanguage { get; set; }
        public string PriorityForPageLanguage { get; set; }
        public string PagePublicSiteLanguage { get; set; }
        public string PageTitleLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string PageUseLanguageMetaLanguage { get; set; }
        public string PageUseApplicationNameMetaLanguage { get; set; }
        public string PageUseGeneratorMetaLanguage { get; set; }
        public string PageUseJavascriptInactiveRefreshMetaLanguage { get; set; }
        public string PageCategoryLanguage { get; set; }
        public string PageUseClassificationMetaLanguage { get; set; }
        public string PageClassificationMetaLanguage { get; set; }
        public string PageUseCopyrightMetaLanguage { get; set; }
        public string PageCopyrightMetaLanguage { get; set; }
        public string PageUseRobotsMetaLanguage { get; set; }
        public string PageRobotsMetaLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool PriorityForPageValue { get; set; } = true;
        public bool PagePublicSiteValue { get; set; } = false;
        public bool PageActiveValue { get; set; } = false;
        public bool PageUseLanguageValue { get; set; } = false;
        public bool PageUsePluginValue { get; set; } = false;
        public bool PageUseModuleValue { get; set; } = false;
        public bool PageUseReplacePartValue { get; set; } = false;
        public bool PageUseFetchValue { get; set; } = false;
        public bool PageUseItemValue { get; set; } = false;
        public bool PageUseElanatValue { get; set; } = false;
        public bool PageShowLinkInSiteValue { get; set; } = false;
        public bool PageLoadAloneValue { get; set; } = false;
        public bool PageUseHtmlValue { get; set; } = false;
        public bool PageUseLanguageMetaValue { get; set; } = false;
        public bool PageUseApplicationNameMetaValue { get; set; } = false;
        public bool PageUseGeneratorMetaValue { get; set; } = false;
        public bool PageUseAuthorMetaValue { get; set; } = false;
        public bool PageUseJavascriptInactiveRefreshMetaValue { get; set; } = false;
        public bool PageUseRevisitAfterMetaValue { get; set; } = false;
        public bool PageUseStaticHeadValue { get; set; } = false;
        public bool PageUseLoadTagValue { get; set; } = false;
        public bool PageUseDescriptionMetaValue { get; set; } = false;
        public bool PageUseRightsMetaValue { get; set; } = false;
        public bool PageUseKeywordsMetaValue { get; set; } = false;
        public bool PageUseClassificationMetaValue { get; set; } = false;
        public bool PageUseCopyrightMetaValue { get; set; } = false;
        public bool PageUseRobotsMetaValue { get; set; } = false;
        public bool PagePublicAccessShowValue { get; set; } = false;

        public bool UsePagePathValue { get; set; } = false;
        public HttpPostedFile PagePathUploadValue { get; set; }
        public string PagePathTextValue { get; set; }

        public string PageLoadTypeOptionListValue { get; set; }
        public string PageLoadTypeOptionListSelectedValue { get; set; }
        public string PageStyleOptionListValue { get; set; }
        public string PageStyleOptionListSelectedValue { get; set; }
        public string PageTemplateOptionListValue { get; set; }
        public string PageTemplateOptionListSelectedValue { get; set; }

        public string PageGlobalNameValue { get; set; }
        public string PageNameValue { get; set; }
        public string PageTitleValue { get; set; }
        public string PageCategoryValue { get; set; }
        public string PageQueryStringValue { get; set; }
        public string PageCacheDurationValue { get; set; }
        public string PageCacheParametersValue { get; set; }
        public string PageRevisitAfternMetaValue { get; set; }
        public string PageStaticHeadValue { get; set; }
        public string PageLoadTagValue { get; set; }
        public string PageDescriptionMetaValue { get; set; }
        public string PageRightsMetaValue { get; set; }
        public string PageKeywordsMetaValue { get; set; }
        public string PageClassificationMetaValue { get; set; }
        public string PageCopyrightMetaValue { get; set; }
        public string PageRobotsMetaValue { get; set; }

        public string PageGlobalNameAttribute { get; set; }
        public string PageNameAttribute { get; set; }
        public string PageTitleAttribute { get; set; }
        public string PageCategoryAttribute { get; set; }
        public string PageQueryStringAttribute { get; set; }
        public string PageCacheDurationAttribute { get; set; }
        public string PageCacheParametersAttribute { get; set; }
        public string PageRevisitAfternMetaAttribute { get; set; }
        public string PageStaticHeadAttribute { get; set; }
        public string PageLoadTagAttribute { get; set; }
        public string PageDescriptionMetaAttribute { get; set; }
        public string PageRightsMetaAttribute { get; set; }
        public string PageKeywordsMetaAttribute { get; set; }
        public string PageClassificationMetaAttribute { get; set; }
        public string PageCopyrightMetaAttribute { get; set; }
        public string PageRobotsMetaAttribute { get; set; }
        public string PageLoadTypeAttribute { get; set; }
        public string PageStyleAttribute { get; set; }
        public string PageTemplateAttribute { get; set; }

        public string PageGlobalNameCssClass { get; set; }
        public string PageNameCssClass { get; set; }
        public string PageTitleCssClass { get; set; }
        public string PageCategoryCssClass { get; set; }
        public string PageQueryStringCssClass { get; set; }
        public string PageCacheDurationCssClass { get; set; }
        public string PageCacheParametersCssClass { get; set; }
        public string PageRevisitAfternMetaCssClass { get; set; }
        public string PageStaticHeadCssClass { get; set; }
        public string PageLoadTagCssClass { get; set; }
        public string PageDescriptionMetaCssClass { get; set; }
        public string PageRightsMetaCssClass { get; set; }
        public string PageKeywordsMetaCssClass { get; set; }
        public string PageClassificationMetaCssClass { get; set; }
        public string PageCopyrightMetaCssClass { get; set; }
        public string PageRobotsMetaCssClass { get; set; }
        public string PageLoadTypeCssClass { get; set; }
        public string PageStyleCssClass { get; set; }
        public string PageTemplateCssClass { get; set; }

        public ListItemCollection PageSiteListItem = new ListItemCollection();
        public string PageSiteListValue { get; set; }
        public string PageSiteTemplateValue { get; set; }
        public ListItemCollection PageAccessShowListItem = new ListItemCollection();
        public string PageAccessShowListValue { get; set; }
        public string PageAccessShowTemplateValue { get; set; }

        public string PageSiteAttribute { get; set; }
        public string PageSiteCssClass { get; set; }
        public string PageAccessShowAttribute { get; set; }
        public string PageAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/");
            PageQueryStringLanguage = aol.GetAddOnsLanguage("page_query_string");
            PageCacheDurationLanguage = aol.GetAddOnsLanguage("page_cache_duration");
            PageCacheParametersLanguage = aol.GetAddOnsLanguage("page_cache_parameters");
            PageDescriptionMetaLanguage = aol.GetAddOnsLanguage("page_description_meta");
            PageKeywordsMetaLanguage = aol.GetAddOnsLanguage("page_keywords_meta");
            PageLoadTypeLanguage = aol.GetAddOnsLanguage("page_load_type");
            PagePathLanguage = aol.GetAddOnsLanguage("page_path");
            PageRevisitAfternMetaLanguage = aol.GetAddOnsLanguage("page_revisit_after_meta");
            PageRightsMetaLanguage = aol.GetAddOnsLanguage("page_rights_meta");
            PageAccessShowLanguage = aol.GetAddOnsLanguage("page_access_show");
            PageSiteLanguage = aol.GetAddOnsLanguage("page_site");
            PageStaticHeadLanguage = aol.GetAddOnsLanguage("page_static_head");
            PageStyleLanguage = aol.GetAddOnsLanguage("page_style");
            PageTemplateeLanguage = aol.GetAddOnsLanguage("page_template");
            PageLanguage = aol.GetAddOnsLanguage("page");
            AddPageLanguage = aol.GetAddOnsLanguage("add_page");
            PageActiveLanguage = aol.GetAddOnsLanguage("page_active");
            PageLoadAloneLanguage = aol.GetAddOnsLanguage("page_load_alone");
            UsePagePathLanguage = aol.GetAddOnsLanguage("use_page_path");
            PageShowLinkInSiteLanguage = aol.GetAddOnsLanguage("page_show_link_in_site");
            PageUseLanguageLanguage = aol.GetAddOnsLanguage("page_use_language");
            PageUseModuleLanguage = aol.GetAddOnsLanguage("page_use_module");
            PageUsePluginLanguage = aol.GetAddOnsLanguage("page_use_plugin");
            PageUseReplacePartLanguage = aol.GetAddOnsLanguage("page_use_replace_part");
            PageUseFetchLanguage = aol.GetAddOnsLanguage("page_use_fetch");
            PageUseItemLanguage = aol.GetAddOnsLanguage("page_use_item");
            PageUseElanatLanguage = aol.GetAddOnsLanguage("page_use_elanat");
            PageUseAuthorMetaLanguage = aol.GetAddOnsLanguage("page_use_author_meta");
            PageUseKeywordsMetaLanguage = aol.GetAddOnsLanguage("page_use_keywords_meta");
            PageUseRevisitAfterMetaLanguage = aol.GetAddOnsLanguage("page_use_revisit_after_meta");
            PageUseRightsMetaLanguage = aol.GetAddOnsLanguage("page_use_rights_meta");
            PageUseDescriptionMetaLanguage = aol.GetAddOnsLanguage("page_use_description_meta");
            PagePublicAccessShowLanguage = aol.GetAddOnsLanguage("page_public_access_show");
            PageUseStaticHeadLanguage = aol.GetAddOnsLanguage("page_use_static_head");
            PageUseHtmlLanguage = aol.GetAddOnsLanguage("page_use_html");
            PageNameLanguage = aol.GetAddOnsLanguage("page_name");
            PageGlobalNameLanguage = aol.GetAddOnsLanguage("page_global_name");
            PageLoadTagLanguage = aol.GetAddOnsLanguage("page_load_tag");
            PageUseLoadTagLanguage = aol.GetAddOnsLanguage("page_use_load_tag");
            PriorityForPageLanguage = aol.GetAddOnsLanguage("priority_for_page");
            PagePublicSiteLanguage = aol.GetAddOnsLanguage("page_public_site");
            PageTitleLanguage = aol.GetAddOnsLanguage("page_title");
            AddLanguage = aol.GetAddOnsLanguage("add");
            PageUseLanguageMetaLanguage = aol.GetAddOnsLanguage("page_use_language_meta");
            PageUseApplicationNameMetaLanguage = aol.GetAddOnsLanguage("page_use_application_name_meta");
            PageUseGeneratorMetaLanguage = aol.GetAddOnsLanguage("page_use_generator_meta");
            PageUseJavascriptInactiveRefreshMetaLanguage = aol.GetAddOnsLanguage("page_use_javascript_inactive_refresh_meta");
            PageCategoryLanguage = aol.GetAddOnsLanguage("page_category");
            PageUseClassificationMetaLanguage = aol.GetAddOnsLanguage("page_use_classification_meta");
            PageClassificationMetaLanguage = aol.GetAddOnsLanguage("page_classification_meta");
            PageUseCopyrightMetaLanguage = aol.GetAddOnsLanguage("page_use_copyright_meta");
            PageCopyrightMetaLanguage = aol.GetAddOnsLanguage("page_copyright_meta");
            PageUseRobotsMetaLanguage = aol.GetAddOnsLanguage("page_use_robots_meta");
            PageRobotsMetaLanguage = aol.GetAddOnsLanguage("page_robots_meta");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Page Loader Item
            lc.FillPageLoadTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            PageLoadTypeOptionListValue += lc.PageLoadTypeListItem.HtmlInputToOptionTag(PageLoadTypeOptionListSelectedValue);

            // Set Site Item
            lc.FillSiteListItem();
            HtmlCheckBoxList HtmlCheckBoxListSite = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/page/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PageSite");
            HtmlCheckBoxListSite.AddRange(lc.SiteListItem);
            PageSiteTemplateValue = HtmlCheckBoxListSite.GetValue();
            PageSiteListValue = HtmlCheckBoxListSite.GetList();
            PageSiteTemplateValue = PageSiteTemplateValue.Replace("$_asp attribute;", PageSiteAttribute);
            PageSiteTemplateValue = PageSiteTemplateValue.Replace("$_asp css_class;", PageSiteCssClass);
            PageSiteTemplateValue = PageSiteTemplateValue.HtmlInputSetCheckBoxListValue(PageSiteListItem);

            // Set Site Style Item
            lc.FillSiteStyleListItem();
            PageStyleOptionListValue += PageStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            PageStyleOptionListValue += lc.SiteStyleListItem.HtmlInputToOptionTag(PageStyleOptionListSelectedValue);

            // Set Site Template Item
            lc.FillSiteTemplateListItem();
            PageTemplateOptionListValue += PageTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            PageTemplateOptionListValue += lc.SiteTemplateListItem.HtmlInputToOptionTag(PageTemplateOptionListSelectedValue);

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Page Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/page/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PageAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lc.UserRoleListItem);
            PageAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            PageAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            PageAccessShowTemplateValue = PageAccessShowTemplateValue.Replace("$_asp attribute;", PageAccessShowAttribute);
            PageAccessShowTemplateValue = PageAccessShowTemplateValue.Replace("$_asp css_class;", PageAccessShowCssClass);
            PageAccessShowTemplateValue = PageAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(PageAccessShowListItem);


            PageCacheDurationValue = "0";


            // Set Page Page List
            ActionGetPageListModel lm = new ActionGetPageListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_PageGlobalName", "");
            InputRequest.Add("txt_PageName", "");
            InputRequest.Add("txt_PageTitle", "");
            InputRequest.Add("txt_PageCategory", "");
            InputRequest.Add("txt_PageQueryString", "");
            InputRequest.Add("txt_PageCacheDuration", "");
            InputRequest.Add("txt_PageCacheParameters", "");
            InputRequest.Add("txt_PageRevisitAfternMeta", "");
            InputRequest.Add("txt_PageStaticHead", "");
            InputRequest.Add("txt_PageLoadTag", "");
            InputRequest.Add("txt_PageDescriptionMeta", "");
            InputRequest.Add("txt_PageRightsMeta", "");
            InputRequest.Add("txt_PageKeywordsMeta", "");
            InputRequest.Add("txt_PageClassificationMeta", "");
            InputRequest.Add("txt_PageCopyrightMeta", "");
            InputRequest.Add("txt_PageRobotsMeta", "");
            InputRequest.Add("ddlst_PageLoadType", PageLoadTypeOptionListValue);
            InputRequest.Add("ddlst_PageStyle", PageStyleOptionListValue);
            InputRequest.Add("ddlst_PageTemplate", PageTemplateOptionListValue);
            InputRequest.Add("cbxlst_PageSite", PageSiteListValue);
            InputRequest.Add("cbxlst_PageAccessShow", PageAccessShowListValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/page/");

            PageGlobalNameAttribute += vc.ImportantInputAttribute["txt_PageGlobalName"];
            PageNameAttribute += vc.ImportantInputAttribute["txt_PageName"];
            PageTitleAttribute += vc.ImportantInputAttribute["txt_PageTitle"];
            PageCategoryAttribute += vc.ImportantInputAttribute["txt_PageCategory"];
            PageQueryStringAttribute += vc.ImportantInputAttribute["txt_PageQueryString"];
            PageCacheDurationAttribute += vc.ImportantInputAttribute["txt_PageCacheDuration"];
            PageCacheParametersAttribute += vc.ImportantInputAttribute["txt_PageCacheParameters"];
            PageRevisitAfternMetaAttribute += vc.ImportantInputAttribute["txt_PageRevisitAfternMeta"];
            PageStaticHeadAttribute += vc.ImportantInputAttribute["txt_PageStaticHead"];
            PageLoadTagAttribute += vc.ImportantInputAttribute["txt_PageLoadTag"];
            PageDescriptionMetaAttribute += vc.ImportantInputAttribute["txt_PageDescriptionMeta"];
            PageRightsMetaAttribute += vc.ImportantInputAttribute["txt_PageRightsMeta"];
            PageKeywordsMetaAttribute += vc.ImportantInputAttribute["txt_PageKeywordsMeta"];
            PageClassificationMetaAttribute += vc.ImportantInputAttribute["txt_PageClassificationMeta"];
            PageCopyrightMetaAttribute += vc.ImportantInputAttribute["txt_PageCopyrightMeta"];
            PageRobotsMetaAttribute += vc.ImportantInputAttribute["txt_PageRobotsMeta"];
            PageLoadTypeAttribute += vc.ImportantInputAttribute["ddlst_PageLoadType"];
            PageStyleAttribute += vc.ImportantInputAttribute["ddlst_PageStyle"];
            PageTemplateAttribute += vc.ImportantInputAttribute["ddlst_PageTemplate"];
            PageSiteAttribute += vc.ImportantInputAttribute["cbxlst_PageSite"];
            PageAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_PageAccessShow"];

            PageGlobalNameCssClass = PageGlobalNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageGlobalName"]);
            PageNameCssClass = PageNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageName"]);
            PageTitleCssClass = PageTitleCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageTitle"]);
            PageCategoryCssClass = PageCategoryCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageCategory"]);
            PageQueryStringCssClass = PageQueryStringCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageQueryString"]);
            PageCacheParametersCssClass = PageCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageCacheParameters"]);
            PageCacheDurationCssClass = PageCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageCacheDuration"]);
            PageRevisitAfternMetaCssClass = PageRevisitAfternMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageRevisitAfternMeta"]);
            PageStaticHeadCssClass = PageStaticHeadCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageStaticHead"]);
            PageLoadTagCssClass = PageLoadTagCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageLoadTag"]);
            PageDescriptionMetaCssClass = PageDescriptionMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageDescriptionMeta"]);
            PageRightsMetaCssClass = PageRightsMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageRightsMeta"]);
            PageKeywordsMetaCssClass = PageKeywordsMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageKeywordsMeta"]);
            PageClassificationMetaCssClass = PageClassificationMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageClassificationMeta"]);
            PageCopyrightMetaCssClass = PageCopyrightMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageCopyrightMeta"]);
            PageRobotsMetaCssClass = PageRobotsMetaCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PageRobotsMeta"]);
            PageLoadTypeCssClass = PageLoadTypeCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_PageLoadType"]);
            PageStyleCssClass = PageStyleCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_PageStyle"]);
            PageTemplateCssClass = PageTemplateCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_PageTemplate"]);
            PageSiteCssClass = PageSiteCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_PageSite"]);
            PageAccessShowCssClass = PageAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_PageAccessShow"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/page/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //PageGlobalNameCssClass = PageGlobalNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageGlobalName"]);
                //PageNameCssClass = PageNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageName"]);
                //PageTitleCssClass = PageTitleCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageTitle"]);
                //PageCategoryCssClass = PageCategoryCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageCategory"]);
                //PageQueryStringCssClass = PageQueryStringCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageQueryString"]);
                //PageCacheDurationCssClass = PageCacheDurationCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageCacheDuration"]);
                //PageCacheParametersCssClass = PageCacheParametersCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageCacheParameters"]);
                //PageRevisitAfternMetaCssClass = PageRevisitAfternMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageRevisitAfternMeta"]);
                //PageStaticHeadCssClass = PageStaticHeadCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageStaticHead"]);
                //PageLoadTagCssClass = PageLoadTagCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageLoadTag"]);
                //PageDescriptionMetaCssClass = PageDescriptionMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageDescriptionMeta"]);
                //PageRightsMetaCssClass = PageRightsMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageRightsMeta"]);
                //PageKeywordsMetaCssClass = PageKeywordsMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageKeywordsMeta"]);
                //PageClassificationMetaCssClass = PageClassificationMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageClassificationMeta"]);
                //PageCopyrightMetaCssClass = PageCopyrightMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageCopyrightMeta"]);
                //PageRobotsMetaCssClass = PageRobotsMetaCssClass.AddHtmlClass(vc.WarningFieldClass["txt_PageRobotsMeta"]);
                //PageLoadTypeCssClass = PageLoadTypeCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_PageLoadType"]);
                //PageStyleCssClass = PageStyleCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_PageStyle"]);
                //PageTemplateCssClass = PageTemplateCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_PageTemplate"]);
                //PageSiteCssClass = PageSiteCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_PageSite"]);
                //PageAccessShowCssClass = PageAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_PageAccessShow"]);
            }
        }

        public void AddPage()
        {
            string PageDirectoryPath = "";
            string PageFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";
            string PageGlobalName = "";

            // If Use Page Path
            if (UsePagePathValue)
            {
                if (string.IsNullOrEmpty(PagePathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_page_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/"), "problem");

                System.Net.WebClient webClient = new System.Net.WebClient();

                PageFilePhysicalName = System.IO.Path.GetFileName(PagePathTextValue);

                FileExtension = System.IO.Path.GetExtension(PageFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), System.IO.Path.GetFileNameWithoutExtension(PagePathTextValue));

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(PagePathTextValue, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PageFilePhysicalName));
            }
            else
            {
                if (!PagePathUploadValue.HtmlInputHasFile())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_page_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/"), "problem");

                PageFilePhysicalName = PagePathUploadValue.FileName;

                FileExtension = System.IO.Path.GetExtension(PageFilePhysicalName);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), System.IO.Path.GetFileNameWithoutExtension(PageFilePhysicalName));

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                PagePathUploadValue.SaveAs(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PageFilePhysicalName));
            }

            // Check Page File Size
            double FileSize = new FileInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PageFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_page").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");
            }

            XmlDocument CatalogDocument = new XmlDocument();
            bool PriorityForPage = PriorityForPageValue;

            bool HasDll = false;

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            // Extract Zip File
            if (FileExtension == ".zip")
            {
                ZipFileSocket zfs = new ZipFileSocket();
                zfs.UnZip(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PageFilePhysicalName), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/page")))
                {
                    // Delete Physical File
                    Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/"), "warning");
                }

                CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/page/catalog.xml"));
                XmlNode TmpPageCatalog = CatalogDocument.SelectSingleNode("/page_catalog_root");


                // Unique Value To Column Check
                DataUse.Common common = new DataUse.Common();
                if (common.ExistValueToColumnCheck("el_page", "page_name", TmpPageCatalog["page_name"].Attributes["value"].Value))
                {
                    // Delete Physical File
                    Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("page_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/"), "problem");
                }

                if (common.ExistValueToColumnCheck("el_page", "page_global_name", TmpPageCatalog["page_global_name"].Attributes["value"].Value))
                {
                    // Delete Physical File
                    Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("page_global_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/"), "problem");
                }


                PageDirectoryPath = CatalogDocument.SelectSingleNode("page_catalog_root/page_directory_path").Attributes["value"].Value;
                PageDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/"), PageDirectoryPath);

                if (PageDirectoryPath != CatalogDocument.SelectSingleNode("page_catalog_root/page_directory_path").Attributes["value"].Value)
                    rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

                Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/page/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/" + PageDirectoryPath));

                // If "root" Directory Exist
                if (Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
                {
                    if (Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                        if (StaticObject.AdminDirectoryPath != "admin")
                            Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));


                    // Move "root/bin" Path To "root/App_Data/elanat_system_data/tmp_bin" Path
                    ReCompileIssues rci = new ReCompileIssues();
                    rci.PreparingAddOnBinDll(DirectoryName);
                    rci.AddTmpBinAddOnToTmpBinFileList(rci.BinFileName, TmpPageCatalog["page_name"].Attributes["value"].Value, "page", PageDirectoryPath);
                    HasDll = (rci.BinFileName.Count > 0);


                    // Create Uninstall List
                    DirectoryInfo directory = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"));

                    XmlDocument EmptyPaternDocument = new XmlDocument();
                    EmptyPaternDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/uninstall/uninstall.xml"));

                    XmlNode FilePathList = EmptyPaternDocument.SelectSingleNode("uninstall_root/file_path_list");
                                        
                    foreach (FileInfo file in directory.GetFiles("*.*", System.IO.SearchOption.AllDirectories))
                    {
                        XmlElement FilePathElement = EmptyPaternDocument.CreateElement("file_path");
                        FilePathElement.InnerText = file.FullName.Replace(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), @"\");
                        FilePathList.AppendChild(FilePathElement);
                    }

                    EmptyPaternDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/" + PageDirectoryPath + "/uninstall.xml"));

                    FileAndDirectory.DirectoryCopy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + ""), true);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(PageNameValue))
                    PageNameValue = PageFilePhysicalName.GetTextBeforeLastValue(".");

                string PagePath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/"), PageGlobalNameValue);
                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                // Create New Catalog Document
                XmlDocument NewCatalogDocument = new XmlDocument();
                NewCatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/page/catalog.xml"));

                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_global_name").Attributes["value"].Value = (string.IsNullOrEmpty(PageGlobalNameValue)) ? DirectoryName : PageGlobalNameValue;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_name").Attributes["value"].Value = PageNameValue;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_directory_path").Attributes["value"].Value = PagePath;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_physical_name").Attributes["value"].Value = PageFilePhysicalName;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_replace").Attributes["use_language"].Value = PageUseLanguageValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_replace").Attributes["use_replace_part"].Value = PageUseReplacePartValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_replace").Attributes["use_module"].Value = PageUseModuleValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_replace").Attributes["use_plugin"].Value = PageUsePluginValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_replace").Attributes["use_elanat"].Value = PageUseElanatValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_replace").Attributes["use_item"].Value = PageUseItemValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_replace").Attributes["use_fetch"].Value = PageUseFetchValue.BooleanToTrueFalse();
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_cache_parameters").InnerText = PageCacheParametersValue;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_author").Attributes["value"].Value = ccoc.UserSiteName;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_best_load_status").Attributes["value"].Value = PageLoadTypeOptionListSelectedValue;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_release_date").Attributes["value"].Value = DateAndTime.GetDate("yyyy/MM/dd");
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_title").InnerText = PageTitleValue;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_static_head").InnerText = PageStaticHeadValue;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_load_tag").InnerText = PageLoadTagValue;
                NewCatalogDocument.SelectSingleNode("page_catalog_root/page_category").Attributes["value"].Value = PageCategoryValue.SpaceToUnderline();

                PageGlobalName = PageGlobalNameValue;

                // if (dbdr.dr != null && dbdr.dr.HasRows)Directory Name Exist In page Directory, Get New Directory Name
                PageGlobalName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/"), PageGlobalName);

                FileAndDirectory.DirectoryCopy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/" + PageGlobalName), true);
                PriorityForPage = false;
                PageDirectoryPath = PageGlobalName;

                NewCatalogDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/" + PageGlobalName + "/catalog.xml"));


                // Set Page Default Image
                System.IO.File.Copy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/page/image.png"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/" + PageGlobalName + "/image.png"));
            }

            // Delete Physical File
            Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.Page dup = new DataUse.Page();

            CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/" + PageDirectoryPath + "/catalog.xml"));
            XmlNode PageCatalog = CatalogDocument.SelectSingleNode("page_catalog_root");

            dup.PageName = (PriorityForPage) ? PageCatalog["page_name"].Attributes["value"].Value : PageNameValue;
            dup.PageGlobalName = (PriorityForPage) ? PageCatalog["page_global_name"].Attributes["value"].Value : PageGlobalNameValue;
            dup.UserId = StaticObject.GetCurrentUserId();
            dup.PagePublicSite = PagePublicSiteValue.BooleanToZeroOne();
            dup.PageTitle = (PriorityForPage) ? PageCatalog["page_title"].InnerText : PageTitleValue;
            dup.PageDateCreate = DateAndTime.GetDate("yyyy/MM/dd");
            dup.PageTimeCreate = DateAndTime.GetTime("HH:mm:ss");
            dup.PageActive = PageActiveValue.BooleanToZeroOne();
            dup.PageDirectoryPath = PageCatalog["page_directory_path"].Attributes["value"].Value;
            dup.PagePhysicalName = PageCatalog["page_physical_name"].Attributes["value"].Value;
            dup.PageUseLanguage = (PriorityForPage) ? PageCatalog["page_replace"].Attributes["use_language"].Value.TrueFalseToZeroOne() : PageUseLanguageValue.BooleanToZeroOne();
            dup.PageUseModule = (PriorityForPage) ? PageCatalog["page_replace"].Attributes["use_module"].Value.TrueFalseToZeroOne() : PageUseModuleValue.BooleanToZeroOne();
            dup.PageUsePlugin = (PriorityForPage) ? PageCatalog["page_replace"].Attributes["use_plugin"].Value.TrueFalseToZeroOne() : PageUsePluginValue.BooleanToZeroOne();
            dup.PageUseReplacePart = (PriorityForPage) ? PageCatalog["page_replace"].Attributes["use_replace_part"].Value.TrueFalseToZeroOne() : PageUseReplacePartValue.BooleanToZeroOne();
            dup.PageUseFetch = (PriorityForPage) ? PageCatalog["page_replace"].Attributes["use_fetch"].Value.TrueFalseToZeroOne() : PageUseFetchValue.BooleanToZeroOne();
            dup.PageUseItem = (PriorityForPage) ? PageCatalog["page_replace"].Attributes["use_item"].Value.TrueFalseToZeroOne() : PageUseItemValue.BooleanToZeroOne();
            dup.PageUseElanat = (PriorityForPage) ? PageCatalog["page_replace"].Attributes["use_elanat"].Value.TrueFalseToZeroOne() : PageUseElanatValue.BooleanToZeroOne();
            dup.PageUseLoadTag = PageUseLoadTagValue.BooleanToZeroOne();
            dup.PageUseStaticHead = PageUseStaticHeadValue.BooleanToZeroOne();
            dup.PageShowLinkInSite = PageShowLinkInSiteValue.BooleanToZeroOne();
            dup.PageLoadType = (PriorityForPage) ? PageCatalog["page_best_load_status"].Attributes["value"].Value : PageLoadTypeOptionListSelectedValue;
            dup.PageLoadTag = (PriorityForPage) ? PageCatalog["page_load_tag"].InnerXml.Replace("<![CDATA[", "").Replace("]]>", "") : PageLoadTagValue;
            dup.PageStaticHead = (PriorityForPage) ? PageCatalog["page_static_head"].InnerXml.Replace("<![CDATA[", "").Replace("]]>", "") : PageStaticHeadValue;
            dup.SiteStyleId = PageStyleOptionListSelectedValue;
            dup.SiteTemplateId = PageTemplateOptionListSelectedValue;
            dup.PageLoadAlone = PageLoadAloneValue.BooleanToZeroOne();
            dup.PageCacheDuration = (PageCacheDurationValue.IsNumber()) ? PageCacheDurationValue : "0";
            dup.PageCacheParameters = (PriorityForPage) ? PageCatalog["page_cache_parameters"].InnerText : PageCacheParametersValue;
            dup.PageUseDescriptionMeta = PageUseDescriptionMetaValue.BooleanToZeroOne();
            dup.PageUseRevisitAfterMeta = PageUseRevisitAfterMetaValue.BooleanToZeroOne();
            dup.PageUseRightsMeta = PageUseRightsMetaValue.BooleanToZeroOne();
            dup.PageUseKeywordsMeta = PageUseKeywordsMetaValue.BooleanToZeroOne();
            dup.PageUseAuthorMeta = PageUseAuthorMetaValue.BooleanToZeroOne();
            dup.PageUseClassificationMeta = PageUseClassificationMetaValue.BooleanToZeroOne();
            dup.PageUseCopyrightMeta = PageUseCopyrightMetaValue.BooleanToZeroOne();
            dup.PageUseLanguageMeta = PageUseLanguageMetaValue.BooleanToZeroOne();
            dup.PageUseRobotsMeta = PageUseRobotsMetaValue.BooleanToZeroOne();
            dup.PageUseApplicationNameMeta = PageUseApplicationNameMetaValue.BooleanToZeroOne();
            dup.PageUseGeneratorMeta = PageUseGeneratorMetaValue.BooleanToZeroOne();
            dup.PageUseJavascriptInactiveRefreshMeta = PageUseJavascriptInactiveRefreshMetaValue.BooleanToZeroOne();
            dup.PageRobotsMeta = PageRobotsMetaValue;
            dup.PageCopyrightMeta = PageCopyrightMetaValue;
            dup.PageClassificationMeta = PageClassificationMetaValue;
            dup.PageDescriptionMeta = PageDescriptionMetaValue;
            dup.PageRevisitAfterMeta = PageRevisitAfternMetaValue;
            dup.PageRightsMeta = PageRightsMetaValue;
            dup.PageKeywordsMeta = PageKeywordsMetaValue;
            dup.PageUseHtml = PageUseHtmlValue.BooleanToZeroOne();
            dup.PagePublicAccessShow = PagePublicAccessShowValue.BooleanToZeroOne();
            dup.PageQueryString = PageQueryStringValue;
            dup.PageVisit = "0";
            dup.PageCategory = (PriorityForPage) ? PageCatalog["page_category"].Attributes["value"].Value.SpaceToUnderline() : PageCategoryValue.SpaceToUnderline();

            // Add Page
            dup.AddWithFillReturnDr();

            // Set Page Access Show
            dup.SetPageAccessShow(dup.PageId, PageAccessShowListItem);

            // Set Page Site
            dup.SetPageSite(dup.PageId, PageSiteListItem);


            try { dup.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_page", dup.PageGlobalName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("page_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/page/action/PageNewRow.aspx?page_id=" + dup.PageId, "div_TableBox");

            if (HasDll)
                rf.SetTmpBinAlert();

            rf.RedirectToResponseFormPage();
        }
    }
}
