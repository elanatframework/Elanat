<%@ Page Controller="Elanat.ActionEditPageController" Model="Elanat.ActionEditPageModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditPageLanguage%></title>
    <!-- Start Client Variant -->
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=Elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=Elanat.AspxHtmlValue.CurrentBoxTag()%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">
    <form id="frm_ActionEditPage" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/page/action/EditPage.aspx">

        <div class="el_part_row">
            <div id="div_EditPageTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                 <%=model.EditPageLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.PageGlobalNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PageGlobalName" name="txt_PageGlobalName" type="text" value="<%=model.PageGlobalNameValue%>" class="el_text_input<%=model.PageGlobalNameCssClass%>" <%=model.PageGlobalNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.PageNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PageName" name="txt_PageName" type="text" value="<%=model.PageNameValue%>" class="el_text_input<%=model.PageNameCssClass%>" <%=model.PageNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.PageTitleLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PageTitle" name="txt_PageTitle" type="text" value="<%=model.PageTitleValue%>" class="el_long_text_input<%=model.PageTitleCssClass%>" <%=model.PageTitleAttribute%> />
            </div>
            <div class="el_item">
                <%=model.PageCategoryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PageCategory" name="txt_PageCategory" type="text" value="<%=model.PageCategoryValue%>" class="el_text_input<%=model.PageCategoryCssClass%>" <%=model.PageCategoryAttribute%> />
            </div>
            <div class="el_item">
                <%=model.PageQueryStringLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PageQueryString" name="txt_PageQueryString" type="text" value="<%=model.PageQueryStringValue%>" class="el_text_input<%=model.PageQueryStringCssClass%>" <%=model.PageQueryStringAttribute%> />
            </div>
            <div class="el_item">
                <%=model.PageLoadTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_PageLoadType" name="ddlst_PageLoadType" class="el_alone_select_input<%=model.PageLoadTypeCssClass%>" <%=model.PageLoadTypeAttribute%>><%=model.PageLoadTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PagePublicSite" name="cbx_PagePublicSite" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PagePublicSiteValue)%> /><label for="cbx_PagePublicSite"><%=model.PagePublicSiteLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageSiteLanguage%>
            </div>
            <div class="el_item">
                <%=model.PageSiteTemplateValue%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageActive" name="cbx_PageActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageActiveValue)%> /><label for="cbx_PageActive"><%=model.PageActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseLanguage" name="cbx_PageUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseLanguageValue)%> /><label for="cbx_PageUseLanguage"><%=model.PageUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseModule" name="cbx_PageUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseModuleValue)%> /><label for="cbx_PageUseModule"><%=model.PageUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUsePlugin" name="cbx_PageUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUsePluginValue)%> /><label for="cbx_PageUsePlugin"><%=model.PageUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseReplacePart" name="cbx_PageUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseReplacePartValue)%> /><label for="cbx_PageUseReplacePart"><%=model.PageUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseFetch" name="cbx_PageUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseFetchValue)%> /><label for="cbx_PageUseFetch"><%=model.PageUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseItem" name="cbx_PageUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseItemValue)%> /><label for="cbx_PageUseItem"><%=model.PageUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseElanat" name="cbx_PageUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseElanatValue)%> /><label for="cbx_PageUseElanat"><%=model.PageUseElanatLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageShowLinkInSite" name="cbx_PageShowLinkInSite" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageShowLinkInSiteValue)%> /><label for="cbx_PageShowLinkInSite"><%=model.PageShowLinkInSiteLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageLoadAlone" name="cbx_PageLoadAlone" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageLoadAloneValue)%> /><label for="cbx_PageLoadAlone"><%=model.PageLoadAloneLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseHtml" name="cbx_PageUseHtml" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseHtmlValue)%> /><label for="cbx_PageUseHtml"><%=model.PageUseHtmlLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseLanguageMeta" name="cbx_PageUseLanguageMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseLanguageMetaValue)%> /><label for="cbx_PageUseLanguageMeta"><%=model.PageUseLanguageMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseApplicationNameMeta" name="cbx_PageUseApplicationNameMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseApplicationNameMetaValue)%> /><label for="cbx_PageUseApplicationNameMeta"><%=model.PageUseApplicationNameMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseGeneratorMeta" name="cbx_PageUseGeneratorMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseGeneratorMetaValue)%> /><label for="cbx_PageUseGeneratorMeta"><%=model.PageUseGeneratorMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseAuthorMeta" name="cbx_PageUseAuthorMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseAuthorMetaValue)%> /><label for="cbx_PageUseAuthorMeta"><%=model.PageUseAuthorMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseJavascriptInactiveRefreshMeta" name="cbx_PageUseJavascriptInactiveRefreshMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseJavascriptInactiveRefreshMetaValue)%> /><label for="cbx_PageUseJavascriptInactiveRefreshMeta"><%=model.PageUseJavascriptInactiveRefreshMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_PageStyle" name="ddlst_PageStyle" class="el_alone_select_input<%=model.PageStyleCssClass%>" <%=model.PageStyleAttribute%>><%=model.PageStyleOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.PageTemplateeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_PageTemplate" name="ddlst_PageTemplate" class="el_alone_select_input<%=model.PageTemplateCssClass%>" <%=model.PageTemplateAttribute%>><%=model.PageTemplateOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.PageCacheDurationLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PageCacheDuration" name="txt_PageCacheDuration" type="number" value="<%=model.PageCacheDurationValue%>" class="el_text_input<%=model.PageCacheDurationCssClass%>" <%=model.PageCacheDurationAttribute%> />
            </div>
            <div class="el_item">
	            <%=model.PageCacheParametersLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PageCacheParameters" name="txt_PageCacheParameters" type="text" value="<%=model.PageCacheParametersValue%>" class="el_long_text_input el_left_to_right<%=model.PageCacheParametersCssClass%>" <%=model.PageCacheParametersAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseRevisitAfterMeta" name="cbx_PageUseRevisitAfterMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseRevisitAfterMetaValue)%> /><label for="cbx_PageUseRevisitAfterMeta"><%=model.PageUseRevisitAfterMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageRevisitAfternMetaLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PageRevisitAfternMeta" name="txt_PageRevisitAfternMeta" type="text" value="<%=model.PageRevisitAfternMetaValue%>" class="el_text_input el_left_to_right<%=model.PageRevisitAfternMetaCssClass%>" <%=model.PageRevisitAfternMetaAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseStaticHead" name="cbx_PageUseStaticHead" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseStaticHeadValue)%> /><label for="cbx_PageUseStaticHead"><%=model.PageUseStaticHeadLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageStaticHeadLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_PageStaticHead" name="txt_PageStaticHead" class="el_textarea_input el_left_to_right<%=model.PageStaticHeadCssClass%>" <%=model.PageStaticHeadAttribute%>><%=model.PageStaticHeadValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseLoadTag" name="cbx_PageUseLoadTag" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseLoadTagValue)%> /><label for="cbx_PageUseLoadTag"><%=model.PageUseLoadTagLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageLoadTagLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_PageLoadTag" name="txt_PageLoadTag" class="el_textarea_input el_left_to_right<%=model.PageLoadTagCssClass%>" <%=model.PageLoadTagAttribute%>><%=model.PageLoadTagValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseDescriptionMeta" name="cbx_PageUseDescriptionMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseDescriptionMetaValue)%> /><label for="cbx_PageUseDescriptionMeta"><%=model.PageUseDescriptionMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageDescriptionMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_PageDescriptionMeta" name="txt_PageDescriptionMeta" class="el_textarea_input<%=model.PageDescriptionMetaCssClass%>" <%=model.PageDescriptionMetaAttribute%>><%=model.PageDescriptionMetaValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseRightsMeta" name="cbx_PageUseRightsMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseRightsMetaValue)%> /><label for="cbx_PageUseRightsMeta"><%=model.PageUseRightsMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageRightsMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_PageRightsMeta" name="txt_PageRightsMeta" class="el_textarea_input<%=model.PageRightsMetaCssClass%>" <%=model.PageRightsMetaAttribute%>><%=model.PageRightsMetaValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseKeywordsMeta" name="cbx_PageUseKeywordsMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseKeywordsMetaValue)%> /><label for="cbx_PageUseKeywordsMeta"><%=model.PageUseKeywordsMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageKeywordsMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_PageKeywordsMeta" name="txt_PageKeywordsMeta" class="el_textarea_input<%=model.PageKeywordsMetaCssClass%>" <%=model.PageKeywordsMetaAttribute%>><%=model.PageKeywordsMetaValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseClassificationMeta" name="cbx_PageUseClassificationMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseClassificationMetaValue)%> /><label for="cbx_PageUseClassificationMeta"><%=model.PageUseClassificationMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageClassificationMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_PageClassificationMeta" name="txt_PageClassificationMeta" class="el_textarea_input<%=model.PageClassificationMetaCssClass%>" <%=model.PageClassificationMetaAttribute%>><%=model.PageClassificationMetaValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseCopyrightMeta" name="cbx_PageUseCopyrightMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseCopyrightMetaValue)%> /><label for="cbx_PageUseCopyrightMeta"><%=model.PageUseCopyrightMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageCopyrightMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_PageCopyrightMeta" name="txt_PageCopyrightMeta" class="el_textarea_input<%=model.PageCopyrightMetaCssClass%>" <%=model.PageCopyrightMetaAttribute%>><%=model.PageCopyrightMetaValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PageUseRobotsMeta" name="cbx_PageUseRobotsMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageUseRobotsMetaValue)%> /><label for="cbx_PageUseRobotsMeta"><%=model.PageUseRobotsMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageRobotsMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_PageRobotsMeta" name="txt_PageRobotsMeta" class="el_textarea_input<%=model.PageRobotsMetaCssClass%>" <%=model.PageRobotsMetaAttribute%>><%=model.PageRobotsMetaValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.PageAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PagePublicAccessShow" name="cbx_PagePublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PagePublicAccessShowValue)%> /><label for="cbx_PagePublicAccessShow"><%=model.PagePublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PageAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SavePage" name="btn_SavePage" type="submit" class="el_button_input" value="<%=model.SavePageLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditPage')" />
            </div>
        </div>

        <input id="hdn_PageId" name="hdn_PageId" type="hidden" value="<%=model.PageIdValue%>" />

    </form>
</body>
</html>