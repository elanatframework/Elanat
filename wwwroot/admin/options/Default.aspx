<%@ Page Controller="Elanat.AdminOptionsController" Model="Elanat.AdminOptionsModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.OptionsLanguage%></title>
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
        <%=model.OptionsLanguage%>
    </div>

    <form id="frm_AdminSecurity" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/options/Default.aspx">

         <div class="el_part_row">
            <div id="div_SecurityTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.SecurityLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_InactiveSite" name="cbx_InactiveSite" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.InactiveSiteValue)%> /><label for="cbx_InactiveSite"><%=model.InactiveSiteLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.AdminDirectoryPathLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_AdminDirectoryPath" name="txt_AdminDirectoryPath" type="text" value="<%=model.AdminDirectoryPathValue%>" class="el_text_input el_left_to_right<%=model.AdminDirectoryPathCssClass%>" <%=model.AdminDirectoryPathAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LockLoginDirectoryPathLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_LockLoginDirectoryPath" name="txt_LockLoginDirectoryPath" type="text" value="<%=model.LockLoginDirectoryPathValue%>" class="el_text_input el_left_to_right<%=model.LockLoginDirectoryPathCssClass%>" <%=model.LockLoginDirectoryPathAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_JustUseHttpsForSite" name="cbx_JustUseHttpsForSite" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.JustUseHttpsForSiteValue)%> /><label for="cbx_JustUseHttpsForSite"><%=model.JustUseHttpsForSiteLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_JustUseHttpsForAdmin" name="cbx_JustUseHttpsForAdmin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.JustUseHttpsForAdminValue)%> /><label for="cbx_JustUseHttpsForAdmin"><%=model.JustUseHttpsForAdminLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_JustUseHttpsForLoginPage" name="cbx_JustUseHttpsForLoginPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.JustUseHttpsForLoginPageValue)%> /><label for="cbx_JustUseHttpsForLoginPage"><%=model.JustUseHttpsForLoginPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_LockLoginForFirstLogin" name="cbx_LockLoginForFirstLogin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.LockLoginForFirstLoginValue)%> /><label for="cbx_LockLoginForFirstLogin"><%=model.LockLoginForFirstLoginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseSensitivityCaseCaptcha" name="cbx_UseSensitivityCaseCaptcha" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseSensitivityCaseCaptchaValue)%> /><label for="cbx_UseSensitivityCaseCaptcha"><%=model.UseSensitivityCaseCaptchaLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SecretKeyLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SecretKey" name="txt_SecretKey" type="password" autocomplete="off" readonly="true" onfocus="this.removeAttribute('readonly');" value="<%=model.SecretKeyValue%>" class="el_text_input<%=model.SecretKeyCssClass%>" <%=model.SecretKeyAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SystemAccessCodeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SystemAccessCode" name="txt_SystemAccessCode" type="password" autocomplete="off" readonly="true" onfocus="this.removeAttribute('readonly');" value="<%=model.SystemAccessCodeValue%>" class="el_text_input<%=model.SystemAccessCodeCssClass%>" <%=model.SystemAccessCodeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LockLoginPasswordLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_LockLoginPassword" name="txt_LockLoginPassword" type="password" autocomplete="off" readonly="true" onfocus="this.removeAttribute('readonly');" value="<%=model.LockLoginPasswordValue%>" class="el_text_input<%=model.LockLoginPasswordCssClass%>" <%=model.LockLoginPasswordAttribute%> />
            </div>
            <div class="el_item">
                <%=model.NewPasswordLengthLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_NewPasswordLength" name="txt_NewPasswordLength" type="number" value="<%=model.NewPasswordLengthValue%>" class="el_text_input<%=model.NewPasswordLengthCssClass%>" <%=model.NewPasswordLengthAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_JustUseHttps" name="cbx_JustUseHttps" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.JustUseHttpsValue)%> /><label for="cbx_JustUseHttps"><%=model.JustUseHttpsLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SaveLogsError" name="cbx_SaveLogsError" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SaveLogsErrorValue)%> /><label for="cbx_SaveLogsError"><%=model.SaveLogsErrorLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseEmailActivation" name="cbx_UseEmailActivation" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseEmailActivationValue)%> /><label for="cbx_UseEmailActivation"><%=model.UseEmailActivationLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseAdminActivation" name="cbx_UseAdminActivation" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseAdminActivationValue)%> /><label for="cbx_UseAdminActivation"><%=model.UseAdminActivationLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseSecretKeyForLogin" name="cbx_UseSecretKeyForLogin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseSecretKeyForLoginValue)%> /><label for="cbx_UseSecretKeyForLogin"><%=model.UseSecretKeyForLoginLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.DataBaseNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_DataBaseName" name="txt_DataBaseName" type="text" value="<%=model.DataBaseNameValue%>" class="el_text_input el_left_to_right<%=model.DataBaseNameCssClass%>" <%=model.DataBaseNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ConectionStringLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ConectionString" name="txt_ConectionString" type="text" value="<%=model.ConectionStringValue%>" class="el_long_text_input<%=model.ConectionStringCssClass%>" <%=model.ConectionStringAttribute%> />
            </div>
            <div class="el_item">
                <%=model.DefaultGroupLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultGroup" name="ddlst_DefaultGroup" class="el_alone_select_input<%=model.DefaultGroupCssClass%>" <%=model.DefaultGroupAttribute%>><%=model.DefaultGroupOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.GuestGroupLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_GuestGroup" name="ddlst_GuestGroup" class="el_alone_select_input<%=model.GuestGroupCssClass%>" <%=model.GuestGroupAttribute%>><%=model.GuestGroupOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.UserSecureValueSizeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserSecureValueSize" name="txt_UserSecureValueSize" type="number" value="<%=model.UserSecureValueSizeValue%>" class="el_text_input<%=model.UserSecureValueSizeCssClass%>" <%=model.UserSecureValueSizeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.NewRandomTextValueCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_NewRandomTextValueCount" name="txt_NewRandomTextValueCount" type="number" value="<%=model.NewRandomTextValueCountValue%>" class="el_text_input<%=model.NewRandomTextValueCountCssClass%>" <%=model.NewRandomTextValueCountAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaNoiseLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaNoise" name="txt_CaptchaNoise" type="number" value="<%=model.CaptchaNoiseValue%>" class="el_text_input<%=model.CaptchaNoiseCssClass%>" <%=model.CaptchaNoiseAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaCharacterCountFromLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaCharacterCountFrom" name="txt_CaptchaCharacterCountFrom" type="number" value="<%=model.CaptchaCharacterCountFromValue%>" class="el_text_input<%=model.CaptchaCharacterCountFromCssClass%>" <%=model.CaptchaCharacterCountFromAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaCharacterCountToLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaCharacterCountTo" name="txt_CaptchaCharacterCountTo" type="number" value="<%=model.CaptchaCharacterCountToValue%>" class="el_text_input<%=model.CaptchaCharacterCountToCssClass%>" <%=model.CaptchaCharacterCountToAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaCharacterLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaCharacter" name="txt_CaptchaCharacter" type="text" value="<%=model.CaptchaCharacterValue%>" class="el_long_text_input<%=model.CaptchaCharacterCssClass%>" <%=model.CaptchaCharacterAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaFontLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaFont" name="txt_CaptchaFont" type="text" value="<%=model.CaptchaFontValue%>" class="el_text_input el_left_to_right<%=model.CaptchaFontCssClass%>" <%=model.CaptchaFontAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaFontSizeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaFontSize" name="txt_CaptchaFontSize" type="number" value="<%=model.CaptchaFontSizeValue%>" class="el_text_input<%=model.CaptchaFontSizeCssClass%>" <%=model.CaptchaFontSizeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaRotateTransformLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaRotateTransform" name="txt_CaptchaRotateTransform" type="number" value="<%=model.CaptchaRotateTransformValue%>" class="el_text_input<%=model.CaptchaRotateTransformCssClass%>" <%=model.CaptchaRotateTransformAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaWidthLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaWidth" name="txt_CaptchaWidth" type="number" value="<%=model.CaptchaWidthValue%>" class="el_text_input<%=model.CaptchaWidthCssClass%>" <%=model.CaptchaWidthAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaHeightLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaHeight" name="txt_CaptchaHeight" type="number" value="<%=model.CaptchaHeightValue%>" class="el_text_input<%=model.CaptchaHeightCssClass%>" <%=model.CaptchaHeightAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaRepeatTimeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaRepeatTime" name="txt_CaptchaRepeatTime" type="number" value="<%=model.CaptchaRepeatTimeValue%>" class="el_text_input<%=model.CaptchaRepeatTimeCssClass%>" <%=model.CaptchaRepeatTimeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaAdminReleaseCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaAdminReleaseCount" name="txt_CaptchaAdminReleaseCount" type="number" value="<%=model.CaptchaAdminReleaseCountValue%>" class="el_text_input<%=model.CaptchaAdminReleaseCountCssClass%>" <%=model.CaptchaAdminReleaseCountAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaMemberReleaseCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaMemberReleaseCount" name="txt_CaptchaMemberReleaseCount" type="number" value="<%=model.CaptchaMemberReleaseCountValue%>" class="el_text_input<%=model.CaptchaMemberReleaseCountCssClass%>" <%=model.CaptchaMemberReleaseCountAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaGuestReleaseCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CaptchaGuestReleaseCount" name="txt_CaptchaGuestReleaseCount" type="number" value="<%=model.CaptchaGuestReleaseCountValue%>" class="el_text_input<%=model.CaptchaGuestReleaseCountCssClass%>" <%=model.CaptchaGuestReleaseCountAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseRobotDetection" name="cbx_UseRobotDetection" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseRobotDetectionValue)%> /><label for="cbx_UseRobotDetection"><%=model.UseRobotDetectionLanguage%></label></span>
            </div>
	        <div class="el_item">
		        <%=model.RobotDetectionIpBlockDurationLanguage%>
	        </div>
	        <div class="el_item">
		        <input id="txt_RobotDetectionIpBlockDuration" name="txt_RobotDetectionIpBlockDuration" type="number" value="<%=model.RobotDetectionIpBlockDurationValue%>" class="el_text_input<%=model.RobotDetectionIpBlockDurationCssClass%>" <%=model.RobotDetectionIpBlockDurationAttribute%> />
	        </div>
	        <div class="el_item">
		        <%=model.RobotDetectionResetTimeDurationLanguage%>
	        </div>
	        <div class="el_item">
		        <input id="txt_RobotDetectionResetTimeDuration" name="txt_RobotDetectionResetTimeDuration" type="number" value="<%=model.RobotDetectionResetTimeDurationValue%>" class="el_text_input<%=model.RobotDetectionResetTimeDurationCssClass%>" <%=model.RobotDetectionResetTimeDurationAttribute%> />
	        </div>
	        <div class="el_item">
		        <%=model.RobotDetectionAdminRequestCountLanguage%>
	        </div>
	        <div class="el_item">
		        <input id="txt_RobotDetectionAdminRequestCount" name="txt_RobotDetectionAdminRequestCount" type="number" value="<%=model.RobotDetectionAdminRequestCountValue%>" class="el_text_input<%=model.RobotDetectionAdminRequestCountCssClass%>" <%=model.RobotDetectionAdminRequestCountAttribute%> />
	        </div>
	        <div class="el_item">
		        <%=model.RobotDetectionAdminRequestAfterShowCaptchaCountLanguage%>
	        </div>
	        <div class="el_item">
		        <input id="txt_RobotDetectionAdminRequestAfterShowCaptchaCount" name="txt_RobotDetectionAdminRequestAfterShowCaptchaCount" type="number" value="<%=model.RobotDetectionAdminRequestAfterShowCaptchaCountValue%>" class="el_text_input<%=model.RobotDetectionAdminRequestAfterShowCaptchaCountCssClass%>" <%=model.RobotDetectionAdminRequestAfterShowCaptchaCountAttribute%> />
	        </div>
	        <div class="el_item">
		        <%=model.RobotDetectionMemberRequestCountLanguage%>
	        </div>
	        <div class="el_item">
		        <input id="txt_RobotDetectionMemberRequestCount" name="txt_RobotDetectionMemberRequestCount" type="number" value="<%=model.RobotDetectionMemberRequestCountValue%>" class="el_text_input<%=model.RobotDetectionMemberRequestCountCssClass%>" <%=model.RobotDetectionMemberRequestCountAttribute%> />
	        </div>
	        <div class="el_item">
		        <%=model.RobotDetectionMemberRequestAfterShowCaptchaCountLanguage%>
	        </div>
	        <div class="el_item">
		        <input id="txt_RobotDetectionMemberRequestAfterShowCaptchaCount" name="txt_RobotDetectionMemberRequestAfterShowCaptchaCount" type="number" value="<%=model.RobotDetectionMemberRequestAfterShowCaptchaCountValue%>" class="el_text_input<%=model.RobotDetectionMemberRequestAfterShowCaptchaCountCssClass%>" <%=model.RobotDetectionMemberRequestAfterShowCaptchaCountAttribute%> />
	        </div>
	        <div class="el_item">
		        <%=model.RobotDetectionGuestRequestCountLanguage%>
	        </div>
	        <div class="el_item">
		        <input id="txt_RobotDetectionGuestRequestCount" name="txt_RobotDetectionGuestRequestCount" type="number" value="<%=model.RobotDetectionGuestRequestCountValue%>" class="el_text_input<%=model.RobotDetectionGuestRequestCountCssClass%>" <%=model.RobotDetectionGuestRequestCountAttribute%> />
	        </div>
	        <div class="el_item">
		        <%=model.RobotDetectionGuestRequestAfterShowCaptchaCountLanguage%>
	        </div>
	        <div class="el_item">
		        <input id="txt_RobotDetectionGuestRequestAfterShowCaptchaCount" name="txt_RobotDetectionGuestRequestAfterShowCaptchaCount" type="number" value="<%=model.RobotDetectionGuestRequestAfterShowCaptchaCountValue%>" class="el_text_input<%=model.RobotDetectionGuestRequestAfterShowCaptchaCountCssClass%>" <%=model.RobotDetectionGuestRequestAfterShowCaptchaCountAttribute%> />
	        </div>
            <div class="el_item">
                <%=model.AdminLifeTimeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_AdminLifeTime" name="txt_AdminLifeTime" type="number" value="<%=model.AdminLifeTimeValue%>" class="el_text_input<%=model.AdminLifeTimeCssClass%>" <%=model.AdminLifeTimeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MemberLifeTimeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_MemberLifeTime" name="txt_MemberLifeTime" type="number" value="<%=model.MemberLifeTimeValue%>" class="el_text_input<%=model.MemberLifeTimeCssClass%>" <%=model.MemberLifeTimeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.GuestLifeTimeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_GuestLifeTime" name="txt_GuestLifeTime" type="number" value="<%=model.GuestLifeTimeValue%>" class="el_text_input<%=model.GuestLifeTimeCssClass%>" <%=model.GuestLifeTimeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SessionLifeTimeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SessionLifeTime" name="txt_SessionLifeTime" type="number" value="<%=model.SessionLifeTimeValue%>" class="el_text_input<%=model.SessionLifeTimeCssClass%>" <%=model.SessionLifeTimeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CookieLifeTimeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CookieLifeTime" name="txt_CookieLifeTime" type="number" value="<%=model.CookieLifeTimeValue%>" class="el_text_input<%=model.CookieLifeTimeCssClass%>" <%=model.CookieLifeTimeAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_SaveSecurity" name="btn_SaveSecurity" type="submit" class="el_button_input" value="<%=model.SaveSecurityLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminSecurity')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminDebug" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/options/Default.aspx">

        <div class="el_part_row">
            <div id="div_DebugTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.DebugLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_WriteLogsError" name="cbx_WriteLogsError" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.WriteLogsErrorValue)%> /><label for="cbx_WriteLogsError"><%=model.WriteLogsErrorLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseVariantDebug" name="cbx_UseVariantDebug" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseVariantDebugValue)%> /><label for="cbx_UseVariantDebug"><%=model.UseVariantDebugLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveDebug" name="btn_SaveDebug" type="submit" class="el_button_input" value="<%=model.SaveDebugLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminDebug')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminActive" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/options/Default.aspx">

        <div class="el_part_row">
            <div id="div_ActiveTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ActiveLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_LoginActive" name="cbx_LoginActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.LoginActiveValue)%> /><label for="cbx_LoginActive"><%=model.LoginActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SignUpActive" name="cbx_SignUpActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SignUpActiveValue)%> /><label for="cbx_SignUpActive"><%=model.SignUpActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_AddComment" name="cbx_AddComment" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AddCommentValue)%> /><label for="cbx_AddComment"><%=model.AddCommentLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveActive" name="btn_SaveActive" type="submit" class="el_button_input" value="<%=model.SaveActiveLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminActive')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminEmail" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/options/Default.aspx">
            
        <div class="el_part_row">
            <div id="div_EmailTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EmailLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.EmailHostLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_EmailHost" name="txt_EmailHost" type="text" value="<%=model.EmailHostValue%>" class="el_text_input el_left_to_right<%=model.EmailHostCssClass%>" <%=model.EmailHostAttribute%> />
            </div>
            <div class="el_item">
                <%=model.EmailPortLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_EmailPort" name="txt_EmailPort" type="number" value="<%=model.EmailPortValue%>" class="el_text_input<%=model.EmailPortCssClass%>" <%=model.EmailPortAttribute%> />
            </div>
            <div class="el_item">
                <%=model.EmailUserNameLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_EmailUserName" name="txt_EmailUserName" type="text" value="<%=model.EmailUserNameValue%>" class="el_text_input<%=model.EmailUserNameCssClass%>" <%=model.EmailUserNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.EmailPasswordLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_EmailPassword" name="txt_EmailPassword" type="text" value="<%=model.EmailPasswordValue%>" class="el_text_input<%=model.EmailPasswordCssClass%>" <%=model.EmailPasswordAttribute%> />
            </div>
            <div class="el_item">
                <%=model.EmailSenderLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_EmailSender" name="txt_EmailSender" type="text" value="<%=model.EmailSenderValue%>" class="el_text_input el_left_to_right<%=model.EmailSenderCssClass%>" <%=model.EmailSenderAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TextBeforeEmailSubjectLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_TextBeforeEmailSubject" name="txt_TextBeforeEmailSubject" type="text" value="<%=model.TextBeforeEmailSubjectValue%>" class="el_long_text_input<%=model.TextBeforeEmailSubjectCssClass%>" <%=model.TextBeforeEmailSubjectAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TextAfterEmailSubjectLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_TextAfterEmailSubject" name="txt_TextAfterEmailSubject" type="text" value="<%=model.TextAfterEmailSubjectValue%>" class="el_long_text_input<%=model.TextAfterEmailSubjectCssClass%>" <%=model.TextAfterEmailSubjectAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TextBeforeEmailBodyLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_TextBeforeEmailBody" name="txt_TextBeforeEmailBody" class="el_textarea_input<%=model.TextBeforeEmailBodyCssClass%>" <%=model.TextBeforeEmailBodyAttribute%>><%=model.TextBeforeEmailBodyValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.TextAfterEmailBodyLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_TextAfterEmailBody" name="txt_TextAfterEmailBody" class="el_textarea_input<%=model.TextAfterEmailBodyCssClass%>" <%=model.TextAfterEmailBodyAttribute%>><%=model.TextAfterEmailBodyValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EmailUseHttps" name="cbx_EmailUseHttps" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EmailUseHttpsValue)%> /><label for="cbx_EmailUseHttps"><%=model.EmailUseHttpsLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveEmail" name="btn_SaveEmail" type="submit" class="el_button_input" value="<%=model.SaveEmailLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminEmail')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminDateAndTime" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/options/Default.aspx">

        <div class="el_part_row">
            <div id="div_DateAndTimeTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.DateAndTimeLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.DateFormatLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_DateFormat" name="txt_DateFormat" type="text" value="<%=model.DateFormatValue%>" class="el_text_input el_left_to_right<%=model.DateFormatCssClass%>" <%=model.DateFormatAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TimeFormatLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_TimeFormat" name="txt_TimeFormat" type="text" value="<%=model.TimeFormatValue%>" class="el_text_input el_left_to_right<%=model.TimeFormatCssClass%>" <%=model.TimeFormatAttribute%> />
            </div>
            <div class="el_item">
                <%=model.DayDifferenceLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_DayDifference" name="txt_DayDifference" type="number" value="<%=model.DayDifferenceValue%>" class="el_text_input<%=model.DayDifferenceCssClass%>" <%=model.DayDifferenceAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TimeHoursDifferenceLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_TimeHoursDifference" name="txt_TimeHoursDifference" type="number" value="<%=model.TimeHoursDifferenceValue%>" class="el_text_input<%=model.TimeHoursDifferenceCssClass%>" <%=model.TimeHoursDifferenceAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TimeMinutesDifferenceLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_TimeMinutesDifference" name="txt_TimeMinutesDifference" type="number" value="<%=model.TimeMinutesDifferenceValue%>" class="el_text_input<%=model.TimeMinutesDifferenceCssClass%>" <%=model.TimeMinutesDifferenceAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CalendarLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_Calendar" name="ddlst_Calendar" class="el_alone_select_input<%=model.CalendarCssClass%>" <%=model.CalendarAttribute%>><%=model.CalendarOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.FirstDayOfWeekLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_FirstDayOfWeek" name="ddlst_FirstDayOfWeek" class="el_alone_select_input<%=model.FirstDayOfWeekCssClass%>" <%=model.FirstDayOfWeekAttribute%>><%=model.FirstDayOfWeekOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.TimeZoneLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_TimeZone" name="ddlst_TimeZone" class="el_alone_select_input<%=model.TimeZoneCssClass%>" <%=model.TimeZoneAttribute%>><%=model.TimeZoneOptionListValue%></select>
            </div>
            <div class="el_item">
                <input id="btn_SaveDateAndTime" name="btn_SaveDateAndTime" type="submit" class="el_button_input" value="<%=model.SaveDateAndTimeLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminDateAndTime')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminFileAndDirectory" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/options/Default.aspx">

        <div class="el_part_row">
            <div id="div_FileAndDirectoryTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.FileAndDirectoryLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForBackupLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForBackup" name="txt_MaximumSizeForBackup" type="number" value="<%=model.MaximumSizeForBackupValue%>" class="el_text_input<%=model.MaximumSizeForBackupCssClass%>" <%=model.MaximumSizeForBackupAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForUploadLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForUpload" name="txt_MaximumSizeForUpload" type="number" value="<%=model.MaximumSizeForUploadValue%>" class="el_text_input<%=model.MaximumSizeForUploadCssClass%>" <%=model.MaximumSizeForUploadAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForAttachmentLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForAttachment" name="txt_MaximumSizeForAttachment" type="number" value="<%=model.MaximumSizeForAttachmentValue%>" class="el_text_input<%=model.MaximumSizeForAttachmentCssClass%>" <%=model.MaximumSizeForAttachmentAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForPluginLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForPlugin" name="txt_MaximumSizeForPlugin" type="number" value="<%=model.MaximumSizeForPluginValue%>" class="el_text_input<%=model.MaximumSizeForPluginCssClass%>" <%=model.MaximumSizeForPluginAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForModuleLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForModule" name="txt_MaximumSizeForModule" type="number" value="<%=model.MaximumSizeForModuleValue%>" class="el_text_input<%=model.MaximumSizeForModuleCssClass%>" <%=model.MaximumSizeForModuleAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForComponentLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForComponent" name="txt_MaximumSizeForComponent" type="number" value="<%=model.MaximumSizeForComponentValue%>" class="el_text_input<%=model.MaximumSizeForComponentCssClass%>" <%=model.MaximumSizeForComponentAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForExtraHelperLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForExtraHelper" name="txt_MaximumSizeForExtraHelper" type="number" value="<%=model.MaximumSizeForExtraHelperValue%>" class="el_text_input<%=model.MaximumSizeForExtraHelperCssClass%>" <%=model.MaximumSizeForExtraHelperAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForEditorTemplateLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForEditorTemplate" name="txt_MaximumSizeForEditorTemplate" type="number" value="<%=model.MaximumSizeForEditorTemplateValue%>" class="el_text_input<%=model.MaximumSizeForEditorTemplateCssClass%>" <%=model.MaximumSizeForEditorTemplateAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForPatchLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForPatch" name="txt_MaximumSizeForPatch" type="number" value="<%=model.MaximumSizeForPatchValue%>" class="el_text_input<%=model.MaximumSizeForPatchCssClass%>" <%=model.MaximumSizeForPatchAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForFetchLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForFetch" name="txt_MaximumSizeForFetch" type="number" value="<%=model.MaximumSizeForFetchValue%>" class="el_text_input<%=model.MaximumSizeForFetchCssClass%>" <%=model.MaximumSizeForFetchAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForSiteTemplateLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForSiteTemplate" name="txt_MaximumSizeForSiteTemplate" type="number" value="<%=model.MaximumSizeForSiteTemplateValue%>" class="el_text_input<%=model.MaximumSizeForSiteTemplateCssClass%>" <%=model.MaximumSizeForSiteTemplateAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForSiteStyleLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForSiteStyle" name="txt_MaximumSizeForSiteStyle" type="number" value="<%=model.MaximumSizeForSiteStyleValue%>" class="el_text_input<%=model.MaximumSizeForSiteStyleCssClass%>" <%=model.MaximumSizeForSiteStyleAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForAdminTemplateLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForAdminTemplate" name="txt_MaximumSizeForAdminTemplate" type="number" value="<%=model.MaximumSizeForAdminTemplateValue%>" class="el_text_input<%=model.MaximumSizeForAdminTemplateCssClass%>" <%=model.MaximumSizeForAdminTemplateAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForAdminStyleLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForAdminStyle" name="txt_MaximumSizeForAdminStyle" type="number" value="<%=model.MaximumSizeForAdminStyleValue%>" class="el_text_input<%=model.MaximumSizeForAdminStyleCssClass%>" <%=model.MaximumSizeForAdminStyleAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForCommentLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForComment" name="txt_MaximumSizeForComment" type="number" value="<%=model.MaximumSizeForCommentValue%>" class="el_text_input<%=model.MaximumSizeForCommentCssClass%>" <%=model.MaximumSizeForCommentAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForContactLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForContact" name="txt_MaximumSizeForContact" type="number" value="<%=model.MaximumSizeForContactValue%>" class="el_text_input<%=model.MaximumSizeForContactCssClass%>" <%=model.MaximumSizeForContactAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForPageLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForPage" name="txt_MaximumSizeForPage" type="number" value="<%=model.MaximumSizeForPageValue%>" class="el_text_input<%=model.MaximumSizeForPageCssClass%>" <%=model.MaximumSizeForPageAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForLanguageLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForLanguage" name="txt_MaximumSizeForLanguage" type="number" value="<%=model.MaximumSizeForLanguageValue%>" class="el_text_input<%=model.MaximumSizeForLanguageCssClass%>" <%=model.MaximumSizeForLanguageAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForContentAvatarLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForContentAvatar" name="txt_MaximumSizeForContentAvatar" type="number" value="<%=model.MaximumSizeForContentAvatarValue%>" class="el_text_input<%=model.MaximumSizeForContentAvatarCssClass%>" <%=model.MaximumSizeForContentAvatarAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForUserAvatarLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForUserAvatar" name="txt_MaximumSizeForUserAvatar" type="number" value="<%=model.MaximumSizeForUserAvatarValue%>" class="el_text_input<%=model.MaximumSizeForUserAvatarCssClass%>" <%=model.MaximumSizeForUserAvatarAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MaximumSizeForUserUploadLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MaximumSizeForUserUpload" name="txt_MaximumSizeForUserUpload" type="number" value="<%=model.MaximumSizeForUserUploadValue%>" class="el_text_input<%=model.MaximumSizeForUserUploadCssClass%>" <%=model.MaximumSizeForUserUploadAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ThumbnailImageHeightLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_ThumbnailImageHeight" name="txt_ThumbnailImageHeight" type="number" value="<%=model.ThumbnailImageHeightValue%>" class="el_text_input<%=model.ThumbnailImageHeightCssClass%>" <%=model.ThumbnailImageHeightAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ThumbnailImageWidthLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_ThumbnailImageWidth" name="txt_ThumbnailImageWidth" type="number" value="<%=model.ThumbnailImageWidthValue%>" class="el_text_input<%=model.ThumbnailImageWidthCssClass%>" <%=model.ThumbnailImageWidthAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_AutoCreateThumbnailImage" name="cbx_AutoCreateThumbnailImage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AutoCreateThumbnailImageValue)%> /><label for="cbx_AutoCreateThumbnailImage"><%=model.AutoCreateThumbnailImageLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveFileAndDirectory" name="btn_SaveFileAndDirectory" type="submit" class="el_button_input" value="<%=model.SaveFileAndDirectoryLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminFileAndDirectory')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminCashe" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/options/Default.aspx">

        <div class="el_part_row">
            <div id="div_CacheTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.CacheLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseSiteMainCache" name="cbx_UseSiteMainCache" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseSiteMainCacheValue)%> /><label for="cbx_UseSiteMainCache"><%=model.UseSiteMainCacheLanguage%></label></span>
            </div>
            <div class="el_item">
	            <%=model.SiteMainCacheParametersLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_SiteMainCacheParameters" name="txt_SiteMainCacheParameters" type="text" value="<%=model.SiteMainCacheParametersValue%>" class="el_long_text_input el_left_to_right<%=model.SiteMainCacheParametersCssClass%>" <%=model.SiteMainCacheParametersAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseAdminMainCache" name="cbx_UseAdminMainCache" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseAdminMainCacheValue)%> /><label for="cbx_UseAdminMainCache"><%=model.UseAdminMainCacheLanguage%></label></span>
            </div>
            <div class="el_item">
	            <%=model.AdminMainCacheParametersLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_AdminMainCacheParameters" name="txt_AdminMainCacheParameters" type="text" value="<%=model.AdminMainCacheParametersValue%>" class="el_long_text_input el_left_to_right<%=model.AdminMainCacheParametersCssClass%>" <%=model.AdminMainCacheParametersAttribute%> />
            </div>
            <div class="el_item">
                <%=model.AdminRoleCacheTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_AdminRoleCacheType" name="ddlst_AdminRoleCacheType" class="el_alone_select_input<%=model.AdminRoleCacheTypeCssClass%>" <%=model.AdminRoleCacheTypeAttribute%>><%=model.AdminRoleCacheTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.AdminRoleCacheLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_AdminRoleCache" name="txt_AdminRoleCache" type="number" value="<%=model.AdminRoleCacheValue%>" class="el_text_input<%=model.AdminRoleCacheCssClass%>" <%=model.AdminRoleCacheAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MemberRoleCacheTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_MemberRoleCacheType" name="ddlst_MemberRoleCacheType" class="el_alone_select_input<%=model.MemberRoleCacheTypeCssClass%>" <%=model.MemberRoleCacheTypeAttribute%>><%=model.MemberRoleCacheTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.MemberRoleCacheLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MemberRoleCache" name="txt_MemberRoleCache" type="number" value="<%=model.MemberRoleCacheValue%>" class="el_text_input<%=model.MemberRoleCacheCssClass%>" <%=model.MemberRoleCacheAttribute%> />
            </div>
            <div class="el_item">
                <%=model.GuestRoleCacheTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_GuestRoleCacheType" name="ddlst_GuestRoleCacheType" class="el_alone_select_input<%=model.GuestRoleCacheTypeCssClass%>" <%=model.GuestRoleCacheTypeAttribute%>><%=model.GuestRoleCacheTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.GuestRoleCacheLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_GuestRoleCache" name="txt_GuestRoleCache" type="number" value="<%=model.GuestRoleCacheValue%>" class="el_text_input<%=model.GuestRoleCacheCssClass%>" <%=model.GuestRoleCacheAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ClientCacheForDynamicPageCacheLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_ClientCacheForDynamicPageCache" name="txt_ClientCacheForDynamicPageCache" type="number" value="<%=model.ClientCacheForDynamicPageCacheValue%>" class="el_text_input<%=model.ClientCacheForDynamicPageCacheCssClass%>" <%=model.ClientCacheForDynamicPageCacheAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseClientCacheForDynamicPage" name="cbx_UseClientCacheForDynamicPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseClientCacheForDynamicPageValue)%> /><label for="cbx_UseClientCacheForDynamicPage"><%=model.UseClientCacheForDynamicPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CheckServerCache" name="cbx_CheckServerCache" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CheckServerCacheValue)%> /><label for="cbx_CheckServerCache"><%=model.CheckServerCacheLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ClientCacheForStaticPageCacheLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_ClientCacheForStaticPageCache" name="txt_ClientCacheForStaticPageCache" type="number" value="<%=model.ClientCacheForStaticPageCacheValue%>" class="el_text_input<%=model.ClientCacheForStaticPageCacheCssClass%>" <%=model.ClientCacheForStaticPageCacheAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseClientCacheForStaticPage" name="cbx_UseClientCacheForStaticPage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseClientCacheForStaticPageValue)%> /><label for="cbx_UseClientCacheForStaticPage"><%=model.UseClientCacheForStaticPageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CheckLastModified" name="cbx_CheckLastModified" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CheckLastModifiedValue)%> /><label for="cbx_CheckLastModified"><%=model.CheckLastModifiedLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_TextCreatorUseServerCache" name="cbx_TextCreatorUseServerCache" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.TextCreatorUseServerCacheValue)%> /><label for="cbx_TextCreatorUseServerCache"><%=model.TextCreatorUseServerCacheLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_TextCreatorUseClientCache" name="cbx_TextCreatorUseClientCache" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.TextCreatorUseClientCacheValue)%> /><label for="cbx_TextCreatorUseClientCache"><%=model.TextCreatorUseClientCacheLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.TextCreatorCacheTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_TextCreatorCacheType" name="ddlst_TextCreatorCacheType" class="el_alone_select_input<%=model.TextCreatorCacheTypeCssClass%>" <%=model.TextCreatorCacheTypeAttribute%>><%=model.TextCreatorCacheTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.TextCreatorServerCacheDurationLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_TextCreatorServerCacheDuration" name="txt_TextCreatorServerCacheDuration" type="number" value="<%=model.TextCreatorServerCacheDurationValue%>" class="el_text_input<%=model.TextCreatorServerCacheDurationCssClass%>" <%=model.TextCreatorServerCacheDurationAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TextCreatorClientCacheDurationLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_TextCreatorClientCacheDuration" name="txt_TextCreatorClientCacheDuration" type="number" value="<%=model.TextCreatorClientCacheDurationValue%>" class="el_text_input<%=model.TextCreatorClientCacheDurationCssClass%>" <%=model.TextCreatorClientCacheDurationAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_SaveCache" name="btn_SaveCache" type="submit" class="el_button_input" value="<%=model.SaveCacheLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminCashe')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminDelay" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/options/Default.aspx">

        <div class="el_part_row">
            <div id="div_DelayTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.DelayLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.MainDelayLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_MainDelay" name="txt_MainDelay" type="number" value="<%=model.MainDelayValue%>" class="el_text_input<%=model.MainDelayCssClass%>" <%=model.MainDelayAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SignUpDelayLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_SignUpDelay" name="txt_SignUpDelay" type="number" value="<%=model.SignUpDelayValue%>" class="el_text_input<%=model.SignUpDelayCssClass%>" <%=model.SignUpDelayAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LoginDelayLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_LoginDelay" name="txt_LoginDelay" type="number" value="<%=model.LoginDelayValue%>" class="el_text_input<%=model.LoginDelayCssClass%>" <%=model.LoginDelayAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LockLoginPageDelayLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_LockLoginPageDelay" name="txt_LockLoginPageDelay" type="number" value="<%=model.LockLoginPageDelayValue%>" class="el_text_input<%=model.LockLoginPageDelayCssClass%>" <%=model.LockLoginPageDelayAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CaptchaDelayLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_CaptchaDelay" name="txt_CaptchaDelay" type="number" value="<%=model.CaptchaDelayValue%>" class="el_text_input<%=model.CaptchaDelayCssClass%>" <%=model.CaptchaDelayAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ShowProtectionContentDelayLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_ShowProtectionContentDelay" name="txt_ShowProtectionContentDelay" type="number" value="<%=model.ShowProtectionContentDelayValue%>" class="el_text_input<%=model.ShowProtectionContentDelayCssClass%>" <%=model.ShowProtectionContentDelayAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ShowProtectionAttachmentDelayLanguage%>
            </div>
            <div class="el_item">
 				<input id="txt_ShowProtectionAttachmentDelay" name="txt_ShowProtectionAttachmentDelay" type="number" value="<%=model.ShowProtectionAttachmentDelayValue%>" class="el_text_input<%=model.ShowProtectionAttachmentDelayCssClass%>" <%=model.ShowProtectionAttachmentDelayAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_SaveDelay" name="btn_SaveDelay" type="submit" class="el_button_input" value="<%=model.SaveDelayLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminDelay')" />
            </div>
        </div>

    </form>

</body>
</html>