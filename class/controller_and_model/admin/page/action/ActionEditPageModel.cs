using CodeBehind;

namespace Elanat
{
    public partial class ActionEditPageModel : CodeBehindModel
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
        public string EditPageLanguage { get; set; }
        public string SavePageLanguage { get; set; }
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
        public string PagePublicSiteLanguage { get; set; }
        public string PageTitleLanguage { get; set; }
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

        public bool IsFirstStart { get; set; } = true;
        public string PageIdValue { get; set; }

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
        public IFormFile PagePathUploadValue { get; set; }
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

        public List<ListItem> PageSiteListItem = new List<ListItem>();
        public string PageSiteListValue { get; set; }
        public string PageSiteTemplateValue { get; set; }
        public List<ListItem> PageAccessShowListItem = new List<ListItem>();
        public string PageAccessShowListValue { get; set; }
        public string PageAccessShowTemplateValue { get; set; }

        public string PageSiteAttribute { get; set; }
        public string PageSiteCssClass { get; set; }
        public string PageAccessShowAttribute { get; set; }
        public string PageAccessShowCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/");
            SavePageLanguage = aol.GetAddOnsLanguage("save_page");
            EditPageLanguage = aol.GetAddOnsLanguage("edit_page");
            PageQueryStringLanguage = aol.GetAddOnsLanguage("page_query_string");
            PageCacheDurationLanguage = aol.GetAddOnsLanguage("page_cache_duration");
            PageCacheParametersLanguage = aol.GetAddOnsLanguage("page_cache_parameters");
            PageDescriptionMetaLanguage = aol.GetAddOnsLanguage("page_description_meta");
            PageKeywordsMetaLanguage = aol.GetAddOnsLanguage("page_keywords_meta");
            PageLoadTypeLanguage = aol.GetAddOnsLanguage("page_load_type");
            PageRevisitAfternMetaLanguage = aol.GetAddOnsLanguage("page_revisit_after_meta");
            PageRightsMetaLanguage = aol.GetAddOnsLanguage("page_rights_meta");
            PageAccessShowLanguage = aol.GetAddOnsLanguage("page_access_show");
            PageSiteLanguage = aol.GetAddOnsLanguage("page_site");
            PageStaticHeadLanguage = aol.GetAddOnsLanguage("page_static_head");
            PageStyleLanguage = aol.GetAddOnsLanguage("page_style");
            PageTemplateeLanguage = aol.GetAddOnsLanguage("page_template");
            PageActiveLanguage = aol.GetAddOnsLanguage("page_active");
            PageLoadAloneLanguage = aol.GetAddOnsLanguage("page_load_alone");
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
            PagePublicSiteLanguage = aol.GetAddOnsLanguage("page_public_site");
            PageTitleLanguage = aol.GetAddOnsLanguage("page_title");
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


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Page dup = new DataUse.Page();
                dup.FillCurrentPage(PageIdValue);

                PageNameValue = dup.PageName;
                PageGlobalNameValue = dup.PageGlobalName;
                PagePublicSiteValue = dup.PagePublicSite.ZeroOneToBoolean();
                PageTitleValue = dup.PageTitle;
                PageActiveValue = dup.PageActive.ZeroOneToBoolean();
                PageUseLanguageValue = dup.PageUseLanguage.ZeroOneToBoolean();
                PageUseModuleValue = dup.PageUseModule.ZeroOneToBoolean();
                PageUsePluginValue = dup.PageUsePlugin.ZeroOneToBoolean();
                PageUseReplacePartValue = dup.PageUseReplacePart.ZeroOneToBoolean();
                PageUseFetchValue = dup.PageUseFetch.ZeroOneToBoolean();
                PageUseItemValue = dup.PageUseItem.ZeroOneToBoolean();
                PageUseElanatValue = dup.PageUseElanat.ZeroOneToBoolean();
                PageUseLoadTagValue = dup.PageUseLoadTag.ZeroOneToBoolean();
                PageUseStaticHeadValue = dup.PageUseStaticHead.ZeroOneToBoolean();
                PageShowLinkInSiteValue = dup.PageShowLinkInSite.ZeroOneToBoolean();
                PageLoadTypeOptionListSelectedValue = dup.PageLoadType;
                PageLoadTagValue = dup.PageLoadTag;
                PageStaticHeadValue = dup.PageStaticHead;
                PageStyleOptionListSelectedValue = dup.SiteStyleId;
                PageTemplateOptionListSelectedValue = dup.SiteTemplateId;
                PageLoadAloneValue = dup.PageLoadAlone.ZeroOneToBoolean();
                PageCacheDurationValue = dup.PageCacheDuration;
                PageCacheParametersValue = dup.PageCacheParameters;
                PageUseDescriptionMetaValue = dup.PageUseDescriptionMeta.ZeroOneToBoolean();
                PageUseRevisitAfterMetaValue = dup.PageUseRevisitAfterMeta.ZeroOneToBoolean();
                PageUseRightsMetaValue = dup.PageUseRightsMeta.ZeroOneToBoolean();
                PageUseKeywordsMetaValue = dup.PageUseKeywordsMeta.ZeroOneToBoolean();
                PageUseAuthorMetaValue = dup.PageUseAuthorMeta.ZeroOneToBoolean();
                PageUseClassificationMetaValue = dup.PageUseClassificationMeta.ZeroOneToBoolean();
                PageUseCopyrightMetaValue = dup.PageUseCopyrightMeta.ZeroOneToBoolean();
                PageUseLanguageMetaValue = dup.PageUseLanguageMeta.ZeroOneToBoolean();
                PageUseRobotsMetaValue = dup.PageUseRobotsMeta.ZeroOneToBoolean();
                PageUseApplicationNameMetaValue = dup.PageUseApplicationNameMeta.ZeroOneToBoolean();
                PageUseGeneratorMetaValue = dup.PageUseGeneratorMeta.ZeroOneToBoolean();
                PageUseJavascriptInactiveRefreshMetaValue = dup.PageUseJavascriptInactiveRefreshMeta.ZeroOneToBoolean();
                PageRobotsMetaValue = dup.PageRobotsMeta;
                PageCopyrightMetaValue = dup.PageCopyrightMeta;
                PageClassificationMetaValue = dup.PageClassificationMeta;
                PageDescriptionMetaValue = dup.PageDescriptionMeta;
                PageRevisitAfternMetaValue = dup.PageRevisitAfterMeta;
                PageRightsMetaValue = dup.PageRightsMeta;
                PageKeywordsMetaValue = dup.PageKeywordsMeta;
                PageUseHtmlValue = dup.PageUseHtml.ZeroOneToBoolean();
                PagePublicAccessShowValue = dup.PagePublicAccessShow.ZeroOneToBoolean();
                PageQueryStringValue = dup.PageQueryString;
                PageCategoryValue = dup.PageCategory;
            }


            // Set Page Loader Item
            ListClass.PageLoadType lcplt = new ListClass.PageLoadType();
            lcplt.FillPageLoadTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            PageLoadTypeOptionListValue += lcplt.PageLoadTypeListItem.HtmlInputToOptionTag(PageLoadTypeOptionListSelectedValue);

            // Set Site Item
            ListClass.Site lcs = new ListClass.Site();
            lcs.FillSiteListItem();
            HtmlCheckBoxList HtmlCheckBoxListSite = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/page/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PageSite");
            HtmlCheckBoxListSite.AddRange(lcs.SiteListItem);
            PageSiteTemplateValue = HtmlCheckBoxListSite.GetValue();
            PageSiteListValue = HtmlCheckBoxListSite.GetList();
            PageSiteTemplateValue = PageSiteTemplateValue.Replace("$_asp attribute;", PageSiteAttribute);
            PageSiteTemplateValue = PageSiteTemplateValue.Replace("$_asp css_class;", PageSiteCssClass);
            PageSiteTemplateValue = PageSiteTemplateValue.HtmlInputSetCheckBoxListValue(PageSiteListItem);

            // Set Page Site Selected Value
            ListClass.Page lcp = new ListClass.Page();
            lcp.FillPageSiteListItem(PageIdValue);
            PageSiteTemplateValue = PageSiteTemplateValue.HtmlInputSetCheckBoxListValue(lcp.PageSiteListItem);

            // Set Site Style Item
            ListClass.SiteStyle lcss = new ListClass.SiteStyle();
            lcss.FillSiteStyleListItem();
            PageStyleOptionListValue += PageStyleOptionListValue.HtmlInputAddOptionTag("", "0");
            PageStyleOptionListValue += lcss.SiteStyleListItem.HtmlInputToOptionTag(PageStyleOptionListSelectedValue);

            // Set Site Template Item
            ListClass.SiteTemplate lcst = new ListClass.SiteTemplate();
            lcst.FillSiteTemplateListItem();
            PageTemplateOptionListValue += PageTemplateOptionListValue.HtmlInputAddOptionTag("", "0");
            PageTemplateOptionListValue += lcst.SiteTemplateListItem.HtmlInputToOptionTag(PageTemplateOptionListSelectedValue);

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Page Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/page/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_PageAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lcu.UserRoleListItem);
            PageAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            PageAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            PageAccessShowTemplateValue = PageAccessShowTemplateValue.Replace("$_asp attribute;", PageAccessShowAttribute);
            PageAccessShowTemplateValue = PageAccessShowTemplateValue.Replace("$_asp css_class;", PageAccessShowCssClass);
            PageAccessShowTemplateValue = PageAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(PageAccessShowListItem);

            // Set Page Access Show Selected Value
            lcp.FillPageAccessShowListItem(PageIdValue);
            PageAccessShowTemplateValue = PageAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lcp.PageAccessShowListItem);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

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
            InputRequest.Add("hdn_PageId", PageIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/page/", "edit");

            PageGlobalNameAttribute += vc.ImportantInputAttribute.GetValue("txt_PageGlobalName");
            PageNameAttribute += vc.ImportantInputAttribute.GetValue("txt_PageName");
            PageTitleAttribute += vc.ImportantInputAttribute.GetValue("txt_PageTitle");
            PageCategoryAttribute += vc.ImportantInputAttribute.GetValue("txt_PageCategory");
            PageQueryStringAttribute += vc.ImportantInputAttribute.GetValue("txt_PageQueryString");
            PageCacheDurationAttribute += vc.ImportantInputAttribute.GetValue("txt_PageCacheDuration");
            PageCacheParametersAttribute += vc.ImportantInputAttribute.GetValue("txt_PageCacheParameters");
            PageRevisitAfternMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_PageRevisitAfternMeta");
            PageStaticHeadAttribute += vc.ImportantInputAttribute.GetValue("txt_PageStaticHead");
            PageLoadTagAttribute += vc.ImportantInputAttribute.GetValue("txt_PageLoadTag");
            PageDescriptionMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_PageDescriptionMeta");
            PageRightsMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_PageRightsMeta");
            PageKeywordsMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_PageKeywordsMeta");
            PageClassificationMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_PageClassificationMeta");
            PageCopyrightMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_PageCopyrightMeta");
            PageRobotsMetaAttribute += vc.ImportantInputAttribute.GetValue("txt_PageRobotsMeta");
            PageLoadTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_PageLoadType");
            PageStyleAttribute += vc.ImportantInputAttribute.GetValue("ddlst_PageStyle");
            PageTemplateAttribute += vc.ImportantInputAttribute.GetValue("ddlst_PageTemplate");
            PageSiteAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_PageSite");
            PageAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_PageAccessShow");

            PageGlobalNameCssClass = PageGlobalNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageGlobalName"));
            PageNameCssClass = PageNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageName"));
            PageTitleCssClass = PageTitleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageTitle"));
            PageCategoryCssClass = PageCategoryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageCategory"));
            PageQueryStringCssClass = PageQueryStringCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageQueryString"));
            PageCacheParametersCssClass = PageCacheParametersCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageCacheParameters"));
            PageCacheDurationCssClass = PageCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageCacheDuration"));
            PageRevisitAfternMetaCssClass = PageRevisitAfternMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageRevisitAfternMeta"));
            PageStaticHeadCssClass = PageStaticHeadCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageStaticHead"));
            PageLoadTagCssClass = PageLoadTagCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageLoadTag"));
            PageDescriptionMetaCssClass = PageDescriptionMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageDescriptionMeta"));
            PageRightsMetaCssClass = PageRightsMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageRightsMeta"));
            PageKeywordsMetaCssClass = PageKeywordsMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageKeywordsMeta"));
            PageClassificationMetaCssClass = PageClassificationMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageClassificationMeta"));
            PageCopyrightMetaCssClass = PageCopyrightMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageCopyrightMeta"));
            PageRobotsMetaCssClass = PageRobotsMetaCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PageRobotsMeta"));
            PageLoadTypeCssClass = PageLoadTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_PageLoadType"));
            PageStyleCssClass = PageStyleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_PageStyle"));
            PageTemplateCssClass = PageTemplateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_PageTemplate"));
            PageSiteCssClass = PageSiteCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_PageSite"));
            PageAccessShowCssClass = PageAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_PageAccessShow"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit", StaticObject.AdminPath + "/page/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SavePage()
        {
            DataUse.Page dup = new DataUse.Page();

            // Change Database Data
            dup.PageId = PageIdValue;
            dup.PageName = PageNameValue;
            dup.PageGlobalName = PageGlobalNameValue;
            dup.PagePublicSite = PagePublicSiteValue.BooleanToZeroOne();
            dup.PageTitle = PageTitleValue;
            dup.PageActive = PageActiveValue.BooleanToZeroOne();
            dup.PageUseLanguage = PageUseLanguageValue.BooleanToZeroOne();
            dup.PageUseModule = PageUseModuleValue.BooleanToZeroOne();
            dup.PageUsePlugin = PageUsePluginValue.BooleanToZeroOne();
            dup.PageUseReplacePart = PageUseReplacePartValue.BooleanToZeroOne();
            dup.PageUseFetch = PageUseFetchValue.BooleanToZeroOne();
            dup.PageUseItem = PageUseItemValue.BooleanToZeroOne();
            dup.PageUseElanat = PageUseElanatValue.BooleanToZeroOne();
            dup.PageUseLoadTag = PageUseLoadTagValue.BooleanToZeroOne();
            dup.PageUseStaticHead = PageUseStaticHeadValue.BooleanToZeroOne();
            dup.PageShowLinkInSite = PageShowLinkInSiteValue.BooleanToZeroOne();
            dup.PageLoadType = PageLoadTypeOptionListSelectedValue;
            dup.PageLoadTag = PageLoadTagValue;
            dup.PageStaticHead = PageStaticHeadValue;
            dup.SiteStyleId = PageStyleOptionListSelectedValue;
            dup.SiteTemplateId = PageTemplateOptionListSelectedValue;
            dup.PageLoadAlone = PageLoadAloneValue.BooleanToZeroOne();
            dup.PageCacheDuration = (PageCacheDurationValue.IsNumber()) ? PageCacheDurationValue : "0";
            dup.PageCacheParameters = PageCacheParametersValue;
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
            dup.PageCategory = PageCategoryValue;

            // Edit Page
            dup.Edit();

            // Delete Page Access Show
            dup.DeletePageAccessShow(dup.PageId);

            // Set Page Access Show
            dup.SetPageAccessShow(dup.PageId, PageAccessShowListItem);

            // Delete Page Site
            dup.DeletePageSite(dup.PageId);

            // Set Page Site
            dup.SetPageSite(dup.PageId, PageSiteListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_page", dup.PageName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/page/action/SuccessMessage.aspx");
        }

        public void ExistValueToColumnPageGlobalNameErrorView()
        {
            Write(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("page_global_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/")));
        }

        public void ExistValueToColumnPageNameErrorView()
        {
            Write(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("page_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/")));
        }
    }
}