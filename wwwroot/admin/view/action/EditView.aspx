<%@ Page Controller="Elanat.ActionEditViewController" Model="Elanat.ActionEditViewModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditViewLanguage%></title>
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
    <form id="frm_ActionEditView" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/view/action/EditView.aspx">

        <div class="el_part_row">
            <div id="div_EditViewTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditViewLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ViewNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewName" name="txt_ViewName" type="text" value="<%=model.ViewNameValue%>" class="el_text_input<%=model.ViewNameCssClass%>" <%=model.ViewNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewMatchTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ViewMatchType" name="ddlst_ViewMatchType" class="el_alone_select_input<%=model.ViewMatchTypeCssClass%>" <%=model.ViewMatchTypeAttribute%>><%=model.ViewMatchTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.ViewQueryStringLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewQueryString" name="txt_ViewQueryString" type="text" value="<%=model.ViewQueryStringValue%>" class="el_long_text_input el_left_to_right<%=model.ViewQueryStringCssClass%>" <%=model.ViewQueryStringAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewBackgroundColor" name="txt_ViewBackgroundColor" type="text" value="<%=model.ViewBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.ViewBackgroundColorCssClass%>" <%=model.ViewBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewFontSizeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewFontSize" name="txt_ViewFontSize" type="number" value="<%=model.ViewFontSizeValue%>" class="el_text_input<%=model.ViewFontSizeCssClass%>" <%=model.ViewFontSizeAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewIncludeHeaderBarPart" name="cbx_ViewIncludeHeaderBarPart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewIncludeHeaderBarPartValue)%> /><label for="cbx_ViewIncludeHeaderBarPart"><%=model.ViewIncludeHeaderBarPartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowHeaderBarLeft" name="cbx_ViewShowHeaderBarLeft" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowHeaderBarLeftValue)%> /><label for="cbx_ViewShowHeaderBarLeft"><%=model.ViewShowHeaderBarLeftLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowHeaderBarRight" name="cbx_ViewShowHeaderBarRight" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowHeaderBarRightValue)%> /><label for="cbx_ViewShowHeaderBarRight"><%=model.ViewShowHeaderBarRightLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowHeaderBarBox" name="cbx_ViewShowHeaderBarBox" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowHeaderBarBoxValue)%> /><label for="cbx_ViewShowHeaderBarBox"><%=model.ViewShowHeaderBarBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillHeaderBarLeft" name="cbx_ViewFillHeaderBarLeft" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillHeaderBarLeftValue)%> /><label for="cbx_ViewFillHeaderBarLeft"><%=model.ViewFillHeaderBarLeftLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillHeaderBarRight" name="cbx_ViewFillHeaderBarRight" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillHeaderBarRightValue)%> /><label for="cbx_ViewFillHeaderBarRight"><%=model.ViewFillHeaderBarRightLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillHeaderBarBox" name="cbx_ViewFillHeaderBarBox" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillHeaderBarBoxValue)%> /><label for="cbx_ViewFillHeaderBarBox"><%=model.ViewFillHeaderBarBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewIncludeHeaderPart" name="cbx_ViewIncludeHeaderPart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewIncludeHeaderPartValue)%> /><label for="cbx_ViewIncludeHeaderPart"><%=model.ViewIncludeHeaderPartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowHeaderMenu" name="cbx_ViewShowHeaderMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowHeaderMenuValue)%> /><label for="cbx_ViewShowHeaderMenu"><%=model.ViewShowHeaderMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowHeader1" name="cbx_ViewShowHeader1" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowHeader1Value)%> /><label for="cbx_ViewShowHeader1"><%=model.ViewShowHeader1Language%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowHeader2" name="cbx_ViewShowHeader2" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowHeader2Value)%> /><label for="cbx_ViewShowHeader2"><%=model.ViewShowHeader2Language%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillHeaderMenu" name="cbx_ViewFillHeaderMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillHeaderMenuValue)%> /><label for="cbx_ViewFillHeaderMenu"><%=model.ViewFillHeaderMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillHeader1" name="cbx_ViewFillHeader1" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillHeader1Value)%> /><label for="cbx_ViewFillHeader1"><%=model.ViewFillHeader1Language%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillHeader2" name="cbx_ViewFillHeader2" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillHeader2Value)%> /><label for="cbx_ViewFillHeader2"><%=model.ViewFillHeader2Language%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewIncludeMenuPart" name="cbx_ViewIncludeMenuPart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewIncludeMenuPartValue)%> /><label for="cbx_ViewIncludeMenuPart"><%=model.ViewIncludeMenuPartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowMenu" name="cbx_ViewShowMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowMenuValue)%> /><label for="cbx_ViewShowMenu"><%=model.ViewShowMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillMenu" name="cbx_ViewFillMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillMenuValue)%> /><label for="cbx_ViewFillMenu"><%=model.ViewFillMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewIncludeMainPart" name="cbx_ViewIncludeMainPart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewIncludeMainPartValue)%> /><label for="cbx_ViewIncludeMainPart"><%=model.ViewIncludeMainPartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowAfterHeader" name="cbx_ViewShowAfterHeader" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowAfterHeaderValue)%> /><label for="cbx_ViewShowAfterHeader"><%=model.ViewShowAfterHeaderLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowBeforeContent" name="cbx_ViewShowBeforeContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowBeforeContentValue)%> /><label for="cbx_ViewShowBeforeContent"><%=model.ViewShowBeforeContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowAfterContent" name="cbx_ViewShowAfterContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowAfterContentValue)%> /><label for="cbx_ViewShowAfterContent"><%=model.ViewShowAfterContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowLeftMenu" name="cbx_ViewShowLeftMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowLeftMenuValue)%> /><label for="cbx_ViewShowLeftMenu"><%=model.ViewShowLeftMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowRightMenu" name="cbx_ViewShowRightMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowRightMenuValue)%> /><label for="cbx_ViewShowRightMenu"><%=model.ViewShowRightMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowBeforeFooter" name="cbx_ViewShowBeforeFooter" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowBeforeFooterValue)%> /><label for="cbx_ViewShowBeforeFooter"><%=model.ViewShowBeforeFooterLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillAfterHeader" name="cbx_ViewFillAfterHeader" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillAfterHeaderValue)%> /><label for="cbx_ViewFillAfterHeader"><%=model.ViewFillAfterHeaderLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillBeforeContent" name="cbx_ViewFillBeforeContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillBeforeContentValue)%> /><label for="cbx_ViewFillBeforeContent"><%=model.ViewFillBeforeContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillAfterContent" name="cbx_ViewFillAfterContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillAfterContentValue)%> /><label for="cbx_ViewFillAfterContent"><%=model.ViewFillAfterContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillLeftMenu" name="cbx_ViewFillLeftMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillLeftMenuValue)%> /><label for="cbx_ViewFillLeftMenu"><%=model.ViewFillLeftMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillRightMenu" name="cbx_ViewFillRightMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillRightMenuValue)%> /><label for="cbx_ViewFillRightMenu"><%=model.ViewFillRightMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillBeforeFooter" name="cbx_ViewFillBeforeFooter" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillBeforeFooterValue)%> /><label for="cbx_ViewFillBeforeFooter"><%=model.ViewFillBeforeFooterLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewIncludeFooterPart" name="cbx_ViewIncludeFooterPart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewIncludeFooterPartValue)%> /><label for="cbx_ViewIncludeFooterPart"><%=model.ViewIncludeFooterPartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowFooterMenu" name="cbx_ViewShowFooterMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowFooterMenuValue)%> /><label for="cbx_ViewShowFooterMenu"><%=model.ViewShowFooterMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowFooter1" name="cbx_ViewShowFooter1" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowFooter1Value)%> /><label for="cbx_ViewShowFooter1"><%=model.ViewShowFooter1Language%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowFooter2" name="cbx_ViewShowFooter2" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowFooter2Value)%> /><label for="cbx_ViewShowFooter2"><%=model.ViewShowFooter2Language%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillFooterMenu" name="cbx_ViewFillFooterMenu" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillFooterMenuValue)%> /><label for="cbx_ViewFillFooterMenu"><%=model.ViewFillFooterMenuLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillFooter1" name="cbx_ViewFillFooter1" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillFooter1Value)%> /><label for="cbx_ViewFillFooter1"><%=model.ViewFillFooter1Language%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillFooter2" name="cbx_ViewFillFooter2" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillFooter2Value)%> /><label for="cbx_ViewFillFooter2"><%=model.ViewFillFooter2Language%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewIncludeFooterBarPart" name="cbx_ViewIncludeFooterBarPart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewIncludeFooterBarPartValue)%> /><label for="cbx_ViewIncludeFooterBarPart"><%=model.ViewIncludeFooterBarPartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowFooterBarLeft" name="cbx_ViewShowFooterBarLeft" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowFooterBarLeftValue)%> /><label for="cbx_ViewShowFooterBarLeft"><%=model.ViewShowFooterBarLeftLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowFooterBarRight" name="cbx_ViewShowFooterBarRight" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowFooterBarRightValue)%> /><label for="cbx_ViewShowFooterBarRight"><%=model.ViewShowFooterBarRightLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewShowFooterBarBox" name="cbx_ViewShowFooterBarBox" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewShowFooterBarBoxValue)%> /><label for="cbx_ViewShowFooterBarBox"><%=model.ViewShowFooterBarBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillFooterBarLeft" name="cbx_ViewFillFooterBarLeft" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillFooterBarLeftValue)%> /><label for="cbx_ViewFillFooterBarLeft"><%=model.ViewFillFooterBarLeftLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillFooterBarRight" name="cbx_ViewFillFooterBarRight" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillFooterBarRightValue)%> /><label for="cbx_ViewFillFooterBarRight"><%=model.ViewFillFooterBarRightLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewFillFooterBarBox" name="cbx_ViewFillFooterBarBox" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewFillFooterBarBoxValue)%> /><label for="cbx_ViewFillFooterBarBox"><%=model.ViewFillFooterBarBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ViewCommonLightTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewCommonLightTextColor" name="txt_ViewCommonLightTextColor" type="text" value="<%=model.ViewCommonLightTextColorValue%>" class="el_text_input el_left_to_right<%=model.ViewCommonLightTextColorCssClass%>" <%=model.ViewCommonLightTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewCommonMiddleTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewCommonMiddleTextColor" name="txt_ViewCommonMiddleTextColor" type="text" value="<%=model.ViewCommonMiddleTextColorValue%>" class="el_text_input el_left_to_right<%=model.ViewCommonMiddleTextColorCssClass%>" <%=model.ViewCommonMiddleTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewCommonDarkTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewCommonDarkTextColor" name="txt_ViewCommonDarkTextColor" type="text" value="<%=model.ViewCommonDarkTextColorValue%>" class="el_text_input el_left_to_right<%=model.ViewCommonDarkTextColorCssClass%>" <%=model.ViewCommonDarkTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewNaturalLightTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewNaturalLightTextColor" name="txt_ViewNaturalLightTextColor" type="text" value="<%=model.ViewNaturalLightTextColorValue%>" class="el_text_input el_left_to_right<%=model.ViewNaturalLightTextColorCssClass%>" <%=model.ViewNaturalLightTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewNaturalMiddleTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewNaturalMiddleTextColor" name="txt_ViewNaturalMiddleTextColor" type="text" value="<%=model.ViewNaturalMiddleTextColorValue%>" class="el_text_input el_left_to_right<%=model.ViewNaturalMiddleTextColorCssClass%>" <%=model.ViewNaturalMiddleTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewNaturalDarkTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewNaturalDarkTextColor" name="txt_ViewNaturalDarkTextColor" type="text" value="<%=model.ViewNaturalDarkTextColorValue%>" class="el_text_input el_left_to_right<%=model.ViewNaturalDarkTextColorCssClass%>" <%=model.ViewNaturalDarkTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewCommonLightBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewCommonLightBackgroundColor" name="txt_ViewCommonLightBackgroundColor" type="text" value="<%=model.ViewCommonLightBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.ViewCommonLightBackgroundColorCssClass%>" <%=model.ViewCommonLightBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewCommonMiddleBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewCommonMiddleBackgroundColor" name="txt_ViewCommonMiddleBackgroundColor" type="text" value="<%=model.ViewCommonMiddleBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.ViewCommonMiddleBackgroundColorCssClass%>" <%=model.ViewCommonMiddleBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewCommonDarkBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewCommonDarkBackgroundColor" name="txt_ViewCommonDarkBackgroundColor" type="text" value="<%=model.ViewCommonDarkBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.ViewCommonDarkBackgroundColorCssClass%>" <%=model.ViewCommonDarkBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewNaturalLightBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewNaturalLightBackgroundColor" name="txt_ViewNaturalLightBackgroundColor" type="text" value="<%=model.ViewNaturalLightBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.ViewNaturalLightBackgroundColorCssClass%>" <%=model.ViewNaturalLightBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewNaturalMiddleBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewNaturalMiddleBackgroundColor" name="txt_ViewNaturalMiddleBackgroundColor" type="text" value="<%=model.ViewNaturalMiddleBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.ViewNaturalMiddleBackgroundColorCssClass%>" <%=model.ViewNaturalMiddleBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewNaturalDarkBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ViewNaturalDarkBackgroundColor" name="txt_ViewNaturalDarkBackgroundColor" type="text" value="<%=model.ViewNaturalDarkBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.ViewNaturalDarkBackgroundColorCssClass%>" <%=model.ViewNaturalDarkBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ViewSiteStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ViewSiteStyle" name="ddlst_ViewSiteStyle" class="el_alone_select_input<%=model.ViewSiteStyleCssClass%>" <%=model.ViewSiteStyleAttribute%>><%=model.ViewSiteStyleOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.ViewSiteTemplateLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ViewSiteTemplate" name="ddlst_ViewSiteTemplate" class="el_alone_select_input<%=model.ViewSiteTemplateCssClass%>" <%=model.ViewSiteTemplateAttribute%>><%=model.ViewSiteTemplateOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.ViewStaticHeadLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_ViewStaticHead" name="txt_ViewStaticHead" class="el_textarea_input el_left_to_right<%=model.ViewStaticHeadCssClass%>" <%=model.ViewStaticHeadAttribute%>><%=model.ViewStaticHeadValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ViewActive" name="cbx_ViewActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ViewActiveValue)%> /><label for="cbx_ViewActive"><%=model.ViewActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveView" name="btn_SaveView" type="submit" class="el_button_input" value="<%=model.SaveViewLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditView')" />
            </div>
        </div>

        <input id="hdn_ViewId" name="hdn_ViewId" type="hidden" value="<%=model.ViewIdValue%>" />

    </form>
</body>
</html>