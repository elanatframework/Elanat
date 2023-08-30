<%@ Page Controller="Elanat.AdminPropertiesController" Model="Elanat.AdminPropertiesModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.PropertiesLanguage%></title>
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
<body onload="el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.PropertiesLanguage%>
    </div>

    <form id="frm_AdminProperties" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/properties/Default.aspx">

        <div class="el_part_row">
            <div id="div_PropertiesTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.PropertiesLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ContentInMainPageLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContentInMainPage" name="txt_ContentInMainPage" type="number" value="<%=model.ContentInMainPageValue%>" class="el_text_input<%=model.ContentInMainPageCssClass%>" <%=model.ContentInMainPageAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContentPerPageLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContentPerPage" name="txt_ContentPerPage" type="number" value="<%=model.ContentPerPageValue%>" class="el_text_input<%=model.ContentPerPageCssClass%>" <%=model.ContentPerPageAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentInContentLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentInContent" name="txt_CommentInContent" type="number" value="<%=model.CommentInContentValue%>" class="el_text_input<%=model.CommentInContentCssClass%>" <%=model.CommentInContentAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentReplyInCommentLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentReplyInComment" name="txt_CommentReplyInComment" type="number" value="<%=model.CommentReplyInCommentValue%>" class="el_text_input<%=model.CommentReplyInCommentCssClass%>" <%=model.CommentReplyInCommentAttribute%> />
            </div>
            <div class="el_item">
                <%=model.RowInMainTableLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_RowInMainTable" name="txt_RowInMainTable" type="number" value="<%=model.RowInMainTableValue%>" class="el_text_input<%=model.RowInMainTableCssClass%>" <%=model.RowInMainTableAttribute%> />
            </div>
            <div class="el_item">
                <%=model.RowPerTableLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_RowPerTable" name="txt_RowPerTable" type="number" value="<%=model.RowPerTableValue%>" class="el_text_input<%=model.RowPerTableCssClass%>" <%=model.RowPerTableAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseSiteAutoResize" name="cbx_UseSiteAutoResize" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseSiteAutoResizeValue)%> /><label for="cbx_UseSiteAutoResize"><%=model.UseSiteAutoResizeLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseReadMore" name="cbx_UseReadMore" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseReadMoreValue)%> /><label for="cbx_UseReadMore"><%=model.UseReadMoreLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ReadMoreStatusLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ReadMoreStatus" name="ddlst_ReadMoreStatus" class="el_alone_select_input<%=model.ReadMoreStatusCssClass%>" <%=model.ReadMoreStatusAttribute%>><%=model.ReadMoreStatusOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.ContentTextCharacterLengthLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContentTextCharacterLength" name="txt_ContentTextCharacterLength" type="number" value="<%=model.ContentTextCharacterLengthValue%>" class="el_text_input<%=model.ContentTextCharacterLengthCssClass%>" <%=model.ContentTextCharacterLengthAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowAllSubCategoryWhenSelectFatherCategory" name="cbx_ShowAllSubCategoryWhenSelectFatherCategory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowAllSubCategoryWhenSelectFatherCategoryValue)%> /><label for="cbx_ShowAllSubCategoryWhenSelectFatherCategory"><%=model.ShowAllSubCategoryWhenSelectFatherCategoryLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SitePathLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SitePath" name="txt_SitePath" type="text" value="<%=model.SitePathValue%>" class="el_text_input el_left_to_right<%=model.SitePathCssClass%>" <%=model.SitePathAttribute%> />
            </div>
            <div class="el_item">
                <%=model.NullLanguageSuffixLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_NullLanguageSuffix" name="txt_NullLanguageSuffix" type="text" value="<%=model.NullLanguageSuffixValue%>" class="el_text_input el_left_to_right<%=model.NullLanguageSuffixCssClass%>" <%=model.NullLanguageSuffixAttribute%> />
            </div>
            <div class="el_item">
                <%=model.DefaultSiteLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultSite" name="ddlst_DefaultSite" class="el_alone_select_input<%=model.DefaultSiteCssClass%>" <%=model.DefaultSiteAttribute%>><%=model.DefaultSiteOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultPageLanguage%>
            </div>                
			<div class="el_item">
                <select id="ddlst_DefaultPage" name="ddlst_DefaultPage" class="el_alone_select_input<%=model.DefaultPageCssClass%>" <%=model.DefaultPageAttribute%>><%=model.DefaultPageOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultSiteLanguageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultSiteLanguage" name="ddlst_DefaultSiteLanguage" class="el_alone_select_input<%=model.DefaultSiteLanguageCssClass%>" <%=model.DefaultSiteLanguageAttribute%>><%=model.DefaultSiteLanguageOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultAdminLanguageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultAdminLanguage" name="ddlst_DefaultAdminLanguage" class="el_alone_select_input<%=model.DefaultAdminLanguageCssClass%>" <%=model.DefaultAdminLanguageAttribute%>><%=model.DefaultAdminLanguageOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultSiteStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultSiteStyle" name="ddlst_DefaultSiteStyle" class="el_alone_select_input<%=model.DefaultSiteStyleCssClass%>" <%=model.DefaultSiteStyleAttribute%>><%=model.DefaultSiteStyleOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultSiteTemplateLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultSiteTemplate" name="ddlst_DefaultSiteTemplate" class="el_alone_select_input<%=model.DefaultSiteTemplateCssClass%>" <%=model.DefaultSiteTemplateAttribute%>><%=model.DefaultSiteTemplateOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultAdminStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultAdminStyle" name="ddlst_DefaultAdminStyle" class="el_alone_select_input<%=model.DefaultAdminStyleCssClass%>" <%=model.DefaultAdminStyleAttribute%>><%=model.DefaultAdminStyleOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultAdminTemplateLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultAdminTemplate" name="ddlst_DefaultAdminTemplate" class="el_alone_select_input<%=model.DefaultAdminTemplateCssClass%>" <%=model.DefaultAdminTemplateAttribute%>><%=model.DefaultAdminTemplateOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultSystemLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultSystem" name="ddlst_DefaultSystem" class="el_alone_select_input<%=model.DefaultSystemCssClass%>" <%=model.DefaultSystemAttribute%>><%=model.DefaultSystemOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultComponentLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultComponent" name="ddlst_DefaultComponent" class="el_alone_select_input<%=model.DefaultComponentCssClass%>" <%=model.DefaultComponentAttribute%>><%=model.DefaultComponentOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUseCookieMessageAlert" name="cbx_ShowUseCookieMessageAlert" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUseCookieMessageAlertValue)%> /><label for="cbx_ShowUseCookieMessageAlert"><%=model.ShowUseCookieMessageAlertLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseViewStyle" name="cbx_UseViewStyle" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseViewStyleValue)%> /><label for="cbx_UseViewStyle"><%=model.UseViewStyleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CreateExternalLinkForSiteViewStyle" name="cbx_CreateExternalLinkForSiteViewStyle" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CreateExternalLinkForSiteViewStyleValue)%> /><label for="cbx_CreateExternalLinkForSiteViewStyle"><%=model.CreateExternalLinkForSiteViewStyleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CreateExternalLinkForAdminViewStyle" name="cbx_CreateExternalLinkForAdminViewStyle" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CreateExternalLinkForAdminViewStyleValue)%> /><label for="cbx_CreateExternalLinkForAdminViewStyle"><%=model.CreateExternalLinkForAdminViewStyleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CreateExternalLinkForUserViewStyle" name="cbx_CreateExternalLinkForUserViewStyle" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CreateExternalLinkForUserViewStyleValue)%> /><label for="cbx_CreateExternalLinkForUserViewStyle"><%=model.CreateExternalLinkForUserViewStyleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CreateExternalLinkForCurrentViewStyle" name="cbx_CreateExternalLinkForCurrentViewStyle" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CreateExternalLinkForCurrentViewStyleValue)%> /><label for="cbx_CreateExternalLinkForCurrentViewStyle"><%=model.CreateExternalLinkForCurrentViewStyleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseSiteClientVariant" name="cbx_UseSiteClientVariant" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseSiteClientVariantValue)%> /><label for="cbx_UseSiteClientVariant"><%=model.UseSiteClientVariantLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CreateExternalLinkForSiteClientVariant" name="cbx_CreateExternalLinkForSiteClientVariant" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CreateExternalLinkForSiteClientVariantValue)%> /><label for="cbx_CreateExternalLinkForSiteClientVariant"><%=model.CreateExternalLinkForSiteClientVariantLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseAdminClientVariant" name="cbx_UseAdminClientVariant" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseAdminClientVariantValue)%> /><label for="cbx_UseAdminClientVariant"><%=model.UseAdminClientVariantLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CreateExternalLinkForAdminClientVariant" name="cbx_CreateExternalLinkForAdminClientVariant" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CreateExternalLinkForAdminClientVariantValue)%> /><label for="cbx_CreateExternalLinkForAdminClientVariant"><%=model.CreateExternalLinkForAdminClientVariantLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseSiteClientLanguageVariant" name="cbx_UseSiteClientLanguageVariant" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseSiteClientLanguageVariantValue)%> /><label for="cbx_UseSiteClientLanguageVariant"><%=model.UseSiteClientLanguageVariantLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CreateExternalLinkForSiteClientLanguageVariant" name="cbx_CreateExternalLinkForSiteClientLanguageVariant" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CreateExternalLinkForSiteClientLanguageVariantValue)%> /><label for="cbx_CreateExternalLinkForSiteClientLanguageVariant"><%=model.CreateExternalLinkForSiteClientLanguageVariantLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseAdminClientLanguageVariant" name="cbx_UseAdminClientLanguageVariant" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseAdminClientLanguageVariantValue)%> /><label for="cbx_UseAdminClientLanguageVariant"><%=model.UseAdminClientLanguageVariantLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CreateExternalLinkForAdminClientLanguageVariant" name="cbx_CreateExternalLinkForAdminClientLanguageVariant" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CreateExternalLinkForAdminClientLanguageVariantValue)%> /><label for="cbx_CreateExternalLinkForAdminClientLanguageVariant"><%=model.CreateExternalLinkForAdminClientLanguageVariantLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveContentPageNumber" name="cbx_ActiveContentPageNumber" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveContentPageNumberValue)%> /><label for="cbx_ActiveContentPageNumber"><%=model.ActiveContentPageNumberLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseAjaxForContentPageNumber" name="cbx_UseAjaxForContentPageNumber" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseAjaxForContentPageNumberValue)%> /><label for="cbx_UseAjaxForContentPageNumber"><%=model.UseAjaxForContentPageNumberLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ContentPageNumberLocationLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ContentPageNumberLocation" name="ddlst_ContentPageNumberLocation" class="el_alone_select_input<%=model.ContentPageNumberLocationCssClass%>" <%=model.ContentPageNumberLocationAttribute%>><%=model.ContentPageNumberLocationOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowCommentInAddCommentBox" name="cbx_ShowCommentInAddCommentBox" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowCommentInAddCommentBoxValue)%> /><label for="cbx_ShowCommentInAddCommentBox"><%=model.ShowCommentInAddCommentBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <select id="ddlst_CommentInAddCommentBoxLocation" name="ddlst_CommentInAddCommentBoxLocation" class="el_alone_select_input<%=model.CommentInAddCommentBoxLocationCssClass%>" <%=model.CommentInAddCommentBoxLocationAttribute%>><%=model.CommentInAddCommentBoxLocationOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveServerRefresh" name="cbx_ActiveServerRefresh" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveServerRefreshValue)%> /><label for="cbx_ActiveServerRefresh"><%=model.ActiveServerRefreshLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveScheduledDelay" name="cbx_ActiveScheduledDelay" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveScheduledDelayValue)%> /><label for="cbx_ActiveScheduledDelay"><%=model.ActiveScheduledDelayLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveScheduledLoad" name="cbx_ActiveScheduledLoad" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveScheduledLoadValue)%> /><label for="cbx_ActiveScheduledLoad"><%=model.ActiveScheduledLoadLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveScheduledTimer" name="cbx_ActiveScheduledTimer" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveScheduledTimerValue)%> /><label for="cbx_ActiveScheduledTimer"><%=model.ActiveScheduledTimerLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveScheduledTasks" name="cbx_ActiveScheduledTasks" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveScheduledTasksValue)%> /><label for="cbx_ActiveScheduledTasks"><%=model.ActiveScheduledTasksLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAddPluginVariantNote" name="cbx_ActiveAddPluginVariantNote" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAddPluginVariantNoteValue)%> /><label for="cbx_ActiveAddPluginVariantNote"><%=model.ActiveAddPluginVariantNoteLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAddModuleVariantNote" name="cbx_ActiveAddModuleVariantNote" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAddModuleVariantNoteValue)%> /><label for="cbx_ActiveAddModuleVariantNote"><%=model.ActiveAddModuleVariantNoteLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAddFetchVariantNote" name="cbx_ActiveAddFetchVariantNote" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAddFetchVariantNoteValue)%> /><label for="cbx_ActiveAddFetchVariantNote"><%=model.ActiveAddFetchVariantNoteLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAddItemVariantNote" name="cbx_ActiveAddItemVariantNote" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAddItemVariantNoteValue)%> /><label for="cbx_ActiveAddItemVariantNote"><%=model.ActiveAddItemVariantNoteLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.CornHourDurationLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CornHourDuration" name="txt_CornHourDuration" type="number" value="<%=model.CornHourDurationValue%>" class="el_text_input<%=model.CornHourDurationCssClass%>" <%=model.CornHourDurationAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_SaveProperties" name="btn_SaveProperties" type="submit" class="el_button_input" value="<%=model.SavePropertiesLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminProperties')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminView" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/properties/Default.aspx">

        <div class="el_part_row">
            <div id="div_ViewTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ViewLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowSiteName" name="cbx_ShowSiteName" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowSiteNameValue)%> /><label for="cbx_ShowSiteName"><%=model.ShowSiteNameLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowSiteSlogonName" name="cbx_ShowSiteSlogonName" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowSiteSlogonNameValue)%> /><label for="cbx_ShowSiteSlogonName"><%=model.ShowSiteSlogonNameLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowContentKeywordsInContentInMainPage" name="cbx_ShowContentKeywordsInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowContentKeywordsInContentInMainPageValue)%> /><label for="cbx_ShowContentKeywordsInContentInMainPage"><%=model.ShowContentKeywordsInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowAttachmentInContentInMainPage" name="cbx_ShowAttachmentInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowAttachmentInContentInMainPageValue)%> /><label for="cbx_ShowAttachmentInContentInMainPage"><%=model.ShowAttachmentInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowCommentInContentInMainPage" name="cbx_ShowCommentInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowCommentInContentInMainPageValue)%> /><label for="cbx_ShowCommentInContentInMainPage"><%=model.ShowCommentInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowAddCommentInContentInMainPage" name="cbx_ShowAddCommentInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowAddCommentInContentInMainPageValue)%> /><label for="cbx_ShowAddCommentInContentInMainPage"><%=model.ShowAddCommentInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.AddCommentLoadTypeInMainPageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_AddCommentLoadTypeInMainPage" name="ddlst_AddCommentLoadTypeInMainPage" class="el_alone_select_input<%=model.AddCommentLoadTypeInMainPageCssClass%>" <%=model.AddCommentLoadTypeInMainPageAttribute%>><%=model.AddCommentLoadTypeInMainPageOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowAddContentReplyInContentInMainPage" name="cbx_ShowAddContentReplyInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowAddContentReplyInContentInMainPageValue)%> /><label for="cbx_ShowAddContentReplyInContentInMainPage"><%=model.ShowAddContentReplyInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.AddContentReplyLoadTypeInMainPageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_AddContentReplyLoadTypeInMainPage" name="ddlst_AddContentReplyLoadTypeInMainPage" class="el_alone_select_input<%=model.AddContentReplyLoadTypeInMainPageCssClass%>" <%=model.AddContentReplyLoadTypeInMainPageAttribute%>><%=model.AddContentReplyLoadTypeInMainPageOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowContentReplyInContentInMainPage" name="cbx_ShowContentReplyInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowContentReplyInContentInMainPageValue)%> /><label for="cbx_ShowContentReplyInContentInMainPage"><%=model.ShowContentReplyInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowAuthorNameInContentInMainPage" name="cbx_ShowAuthorNameInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowAuthorNameInContentInMainPageValue)%> /><label for="cbx_ShowAuthorNameInContentInMainPage"><%=model.ShowAuthorNameInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowCategoryNameInContentInMainPage" name="cbx_ShowCategoryNameInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowCategoryNameInContentInMainPageValue)%> /><label for="cbx_ShowCategoryNameInContentInMainPage"><%=model.ShowCategoryNameInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowTitleInContentInMainPage" name="cbx_ShowTitleInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowTitleInContentInMainPageValue)%> /><label for="cbx_ShowTitleInContentInMainPage"><%=model.ShowTitleInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowDateInContentInMainPage" name="cbx_ShowDateInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowDateInContentInMainPageValue)%> /><label for="cbx_ShowDateInContentInMainPage"><%=model.ShowDateInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowTimeInContentInMainPage" name="cbx_ShowTimeInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowTimeInContentInMainPageValue)%> /><label for="cbx_ShowTimeInContentInMainPage"><%=model.ShowTimeInContentInMainPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowVisitInContentInMainPage" name="cbx_ShowVisitInContentInMainPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowVisitInContentInMainPageValue)%> /><label for="cbx_ShowVisitInContentInMainPage"><%=model.ShowVisitInContentInMainPageLanguage%></label></span>
            </div>
		    <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowContentKeywordsInContentInContentPage" name="cbx_ShowContentKeywordsInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowContentKeywordsInContentInContentPageValue)%> /><label for="cbx_ShowContentKeywordsInContentInContentPage"><%=model.ShowContentKeywordsInContentInContentPageLanguage%></label></span>
            </div>
		    <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowAttachmentInContentInContentPage" name="cbx_ShowAttachmentInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowAttachmentInContentInContentPageValue)%> /><label for="cbx_ShowAttachmentInContentInContentPage"><%=model.ShowAttachmentInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowCommentInContentInContentPage" name="cbx_ShowCommentInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowCommentInContentInContentPageValue)%> /><label for="cbx_ShowCommentInContentInContentPage"><%=model.ShowCommentInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowAddCommentInContentInContentPage" name="cbx_ShowAddCommentInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowAddCommentInContentInContentPageValue)%> /><label for="cbx_ShowAddCommentInContentInContentPage"><%=model.ShowAddCommentInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.AddCommentLoadTypeInContentPageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_AddCommentLoadTypeInContentPage" name="ddlst_AddCommentLoadTypeInContentPage" class="el_alone_select_input<%=model.AddCommentLoadTypeInContentPageCssClass%>" <%=model.AddCommentLoadTypeInContentPageAttribute%>><%=model.AddCommentLoadTypeInContentPageOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowAddContentReplyInContentInContentPage" name="cbx_ShowAddContentReplyInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowAddContentReplyInContentInContentPageValue)%> /><label for="cbx_ShowAddContentReplyInContentInContentPage"><%=model.ShowAddContentReplyInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.AddContentReplyLoadTypeInContentPageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_AddContentReplyLoadTypeInContentPage" name="ddlst_AddContentReplyLoadTypeInContentPage" class="el_alone_select_input<%=model.AddContentReplyLoadTypeInContentPageCssClass%>" <%=model.AddContentReplyLoadTypeInContentPageAttribute%>><%=model.AddContentReplyLoadTypeInContentPageOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowContentReplyInContentInContentPage" name="cbx_ShowContentReplyInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowContentReplyInContentInContentPageValue)%> /><label for="cbx_ShowContentReplyInContentInContentPage"><%=model.ShowContentReplyInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowAuthorNameInContentInContentPage" name="cbx_ShowAuthorNameInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowAuthorNameInContentInContentPageValue)%> /><label for="cbx_ShowAuthorNameInContentInContentPage"><%=model.ShowAuthorNameInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowCategoryNameInContentInContentPage" name="cbx_ShowCategoryNameInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowCategoryNameInContentInContentPageValue)%> /><label for="cbx_ShowCategoryNameInContentInContentPage"><%=model.ShowCategoryNameInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowTitleInContentInContentPage" name="cbx_ShowTitleInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowTitleInContentInContentPageValue)%> /><label for="cbx_ShowTitleInContentInContentPage"><%=model.ShowTitleInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowDateInContentInContentPage" name="cbx_ShowDateInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowDateInContentInContentPageValue)%> /><label for="cbx_ShowDateInContentInContentPage"><%=model.ShowDateInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowTimeInContentInContentPage" name="cbx_ShowTimeInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowTimeInContentInContentPageValue)%> /><label for="cbx_ShowTimeInContentInContentPage"><%=model.ShowTimeInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowVisitInContentInContentPage" name="cbx_ShowVisitInContentInContentPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowVisitInContentInContentPageValue)%> /><label for="cbx_ShowVisitInContentInContentPage"><%=model.ShowVisitInContentInContentPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveView" name="btn_SaveView" type="submit" class="el_button_input" value="<%=model.SaveViewLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminView')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminInclude" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/properties/Default.aspx">

        <div class="el_part_row">
            <div id="div_IncludeTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.IncludeLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.IncludeBoxLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_IncludeBox" name="ddlst_IncludeBox" class="el_alone_select_input<%=model.IncludeBoxCssClass%>" <%=model.IncludeBoxAttribute%>><%=model.IncludeBoxOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.IncludeCaptchaLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_IncludeCaptcha" name="ddlst_IncludeCaptcha" class="el_alone_select_input<%=model.IncludeCaptchaCssClass%>" <%=model.IncludeCaptchaAttribute%>><%=model.IncludeCaptchaOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.IncludeCalendarLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_IncludeCalendar" name="ddlst_IncludeCalendar" class="el_alone_select_input<%=model.IncludeCalendarCssClass%>" <%=model.IncludeCalendarAttribute%>><%=model.IncludeCalendarOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.IncludeFileViewerLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_IncludeFileViewer" name="ddlst_IncludeFileViewer" class="el_alone_select_input<%=model.IncludeFileViewerCssClass%>" <%=model.IncludeFileViewerAttribute%>><%=model.IncludeFileViewerOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.IncludeWysiwygLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_IncludeWysiwyg" name="ddlst_IncludeWysiwyg" class="el_alone_select_input<%=model.IncludeWysiwygCssClass%>" <%=model.IncludeWysiwygAttribute%>><%=model.IncludeWysiwygOptionListValue%></select>
            </div>
            <div class="el_item">
                <input id="btn_SaveInclude" name="btn_SaveInclude" type="submit" class="el_button_input" value="<%=model.SaveIncludeLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminInclude')" />
            </div>
        </div>

    </form>

</body>
</html>