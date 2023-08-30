<%@ Page Controller="Elanat.ActionEditSiteController" Model="Elanat.ActionEditSiteModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditSiteLanguage%></title>
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
    <form id="frm_ActionEditSite" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/site/action/EditSite.aspx">

        <div class="el_part_row">
            <div id="div_EditSiteTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditSiteLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.SiteNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteName" name="txt_SiteName" type="text" value="<%=model.SiteNameValue%>" class="el_text_input<%=model.SiteNameCssClass%>" <%=model.SiteNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteGlobalNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteGlobalName" name="txt_SiteGlobalName" type="text" value="<%=model.SiteGlobalNameValue%>" class="el_text_input<%=model.SiteGlobalNameCssClass%>" <%=model.SiteGlobalNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteSloganNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteSloganName" name="txt_SiteSloganName" type="text" value="<%=model.SiteSloganNameValue%>" class="el_text_input<%=model.SiteSloganNameCssClass%>" <%=model.SiteSloganNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteLanguageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SiteLanguage" name="ddlst_SiteLanguage" class="el_alone_select_input<%=model.SiteLanguageCssClass%>" <%=model.SiteLanguageAttribute%>><%=model.SiteLanguageOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.SiteDefaultPageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SiteDefaultPage" name="ddlst_SiteDefaultPage" class="el_alone_select_input<%=model.SiteDefaultPageCssClass%>" <%=model.SiteDefaultPageAttribute%>><%=model.SiteDefaultPageOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.SiteTitleLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteTitle" name="txt_SiteTitle" type="text" value="<%=model.SiteTitleValue%>" class="el_text_input<%=model.SiteTitleCssClass%>" <%=model.SiteTitleAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SiteActive" name="cbx_SiteActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SiteActiveValue)%> /><label for="cbx_SiteActive"><%=model.SiteActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SiteShowLinkInSite" name="cbx_SiteShowLinkInSite" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SiteShowLinkInSiteValue)%> /><label for="cbx_SiteShowLinkInSite"><%=model.SiteShowLinkInSiteLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SiteSiteStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SiteSiteStyle" name="ddlst_SiteSiteStyle" class="el_alone_select_input<%=model.SiteSiteStyleCssClass%>" <%=model.SiteSiteStyleAttribute%>><%=model.SiteSiteStyleOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.SiteSiteTemplateeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SiteSiteTemplate" name="ddlst_SiteSiteTemplate" class="el_alone_select_input<%=model.SiteSiteTemplateCssClass%>" <%=model.SiteSiteTemplateAttribute%>><%=model.SiteSiteTemplateOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.SiteAdminStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SiteAdminStyle" name="ddlst_SiteAdminStyle" class="el_alone_select_input<%=model.SiteAdminStyleCssClass%>" <%=model.SiteAdminStyleAttribute%>><%=model.SiteAdminStyleOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.SiteAdminTemplateLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SiteAdminTemplate" name="ddlst_SiteAdminTemplate" class="el_alone_select_input<%=model.SiteAdminTemplateCssClass%>" <%=model.SiteAdminTemplateAttribute%>><%=model.SiteAdminTemplateOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.SiteCalendarLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SiteCalendar" name="ddlst_SiteCalendar" class="el_alone_select_input<%=model.SiteCalendarCssClass%>" <%=model.SiteCalendarAttribute%>><%=model.SiteCalendarOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.SiteFirstDayOfWeekLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SiteFirstDayOfWeek" name="ddlst_SiteFirstDayOfWeek" class="el_alone_select_input<%=model.SiteFirstDayOfWeekCssClass%>" <%=model.SiteFirstDayOfWeekAttribute%>><%=model.SiteFirstDayOfWeekOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.SiteDateFormatLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteDateFormat" name="txt_SiteDateFormat" type="text" value="<%=model.SiteDateFormatValue%>" class="el_text_input el_left_to_right<%=model.SiteDateFormatCssClass%>" <%=model.SiteDateFormatAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteTimeFormatLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteTimeFormat" name="txt_SiteTimeFormat" type="text" value="<%=model.SiteTimeFormatValue%>" class="el_text_input el_left_to_right<%=model.SiteTimeFormatCssClass%>" <%=model.SiteTimeFormatAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteTimeZoneLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SiteTimeZone" name="ddlst_SiteTimeZone" class="el_alone_select_input<%=model.SiteTimeZoneCssClass%>" <%=model.SiteTimeZoneAttribute%>><%=model.SiteTimeZoneOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.SiteAddressLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_SiteAddress" name="txt_SiteAddress" class="el_textarea_input<%=model.SiteAddressCssClass%>" <%=model.SiteAddressAttribute%>><%=model.SiteAddressValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.SitePhoneNumberLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SitePhoneNumber" name="txt_SitePhoneNumber" type="text" value="<%=model.SitePhoneNumberValue%>" class="el_text_input el_left_to_right<%=model.SitePhoneNumberCssClass%>" <%=model.SitePhoneNumberAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteEmailLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteEmail" name="txt_SiteEmail" type="text" value="<%=model.SiteEmailValue%>" class="el_text_input el_left_to_right<%=model.SiteEmailCssClass%>" <%=model.SiteEmailAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteActivitiesLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_SiteActivities" name="txt_SiteActivities" class="el_textarea_input<%=model.SiteActivitiesCssClass%>" <%=model.SiteActivitiesAttribute%>><%=model.SiteActivitiesValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.SiteOtherInfoLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_SiteOtherInfo" name="txt_SiteOtherInfo" class="el_textarea_input<%=model.SiteOtherInfoCssClass%>" <%=model.SiteOtherInfoAttribute%>><%=model.SiteOtherInfoValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.SiteStaticHeadLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_SiteStaticHead" name="txt_SiteStaticHead" class="el_textarea_input el_left_to_right<%=model.SiteStaticHeadCssClass%>" <%=model.SiteStaticHeadAttribute%>><%=model.SiteStaticHeadValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SiteUseDescriptionMeta" name="cbx_SiteUseDescriptionMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SiteUseDescriptionMetaValue)%> /><label for="cbx_SiteUseDescriptionMeta"><%=model.SiteUseDescriptionMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SiteDescriptionMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_SiteDescriptionMeta" name="txt_SiteDescriptionMeta" class="el_textarea_input<%=model.SiteDescriptionMetaCssClass%>" <%=model.SiteDescriptionMetaAttribute%>><%=model.SiteDescriptionMetaValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SiteUseRightsMeta" name="cbx_SiteUseRightsMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SiteUseRightsMetaValue)%> /><label for="cbx_SiteUseRightsMeta"><%=model.SiteUseRightsMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SiteRightsMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_SiteRightsMeta" name="txt_SiteRightsMeta" class="el_textarea_input<%=model.SiteRightsMetaCssClass%>" <%=model.SiteRightsMetaAttribute%>><%=model.SiteRightsMetaValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SiteUseKeywordsMeta" name="cbx_SiteUseKeywordsMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SiteUseKeywordsMetaValue)%> /><label for="cbx_SiteUseKeywordsMeta"><%=model.SiteUseKeywordsMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SiteKeywordsMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_SiteKeywordsMeta" name="txt_SiteKeywordsMeta" class="el_textarea_input<%=model.SiteKeywordsMetaCssClass%>" <%=model.SiteKeywordsMetaAttribute%>><%=model.SiteKeywordsMetaValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SiteUseClassificationMeta" name="cbx_SiteUseClassificationMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SiteUseClassificationMetaValue)%> /><label for="cbx_SiteUseClassificationMeta"><%=model.SiteUseClassificationMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SiteClassificationMetaLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_SiteClassificationMeta" name="txt_SiteClassificationMeta" class="el_textarea_input<%=model.SiteClassificationMetaCssClass%>" <%=model.SiteClassificationMetaAttribute%>><%=model.SiteClassificationMetaValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SiteUseRevisitAfterMeta" name="cbx_SiteUseRevisitAfterMeta" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SiteUseRevisitAfterMetaValue)%> /><label for="cbx_SiteUseRevisitAfterMeta"><%=model.SiteUseRevisitAfterMetaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SiteRevisitAfterMetaLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteRevisitAfterMeta" name="txt_SiteRevisitAfterMeta" type="text" value="<%=model.SiteRevisitAfterMetaValue%>" class="el_text_input el_left_to_right<%=model.SiteRevisitAfterMetaCssClass%>" <%=model.SiteRevisitAfterMetaAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteDateCreateLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteDateCreate" name="txt_SiteDateCreate" type="text" value="<%=model.SiteDateCreateValue%>" class="el_text_input el_left_to_right<%=model.SiteDateCreateCssClass%>" <%=model.SiteDateCreateAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteTimeCreateLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteTimeCreate" name="txt_SiteTimeCreate" type="text" value="<%=model.SiteTimeCreateValue%>" class="el_text_input el_left_to_right<%=model.SiteTimeCreateCssClass%>" <%=model.SiteTimeCreateAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteVisitLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SiteVisit" name="txt_SiteVisit" type="number" value="<%=model.SiteVisitValue%>" class="el_text_input<%=model.SiteVisitCssClass%>" <%=model.SiteVisitAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SiteAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SitePublicAccessShow" name="cbx_SitePublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SitePublicAccessShowValue)%> /><label for="cbx_SitePublicAccessShow"><%=model.SitePublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SiteAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveSite" name="btn_SaveSite" type="submit" class="el_button_input" value="<%=model.SaveSiteLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditSite')" />
            </div>
        </div>

        <input id="hdn_SiteId" name="hdn_SiteId" type="hidden" value="<%=model.SiteIdValue%>" />

    </form>
</body>
</html>