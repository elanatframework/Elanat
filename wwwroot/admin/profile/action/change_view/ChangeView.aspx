<%@ Page Controller="Elanat.ActionChangeViewController" Model="Elanat.ActionChangeViewModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ViewLanguage%></title>
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
        <%=model.ViewLanguage%>
    </div>

    <form id="frm_ActionChangeView" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_view/ChangeView.aspx">

        <div class="el_part_row">
            <div id="div_ChangeView" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeViewLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserBackgroundColor" name="txt_UserBackgroundColor" type="text" value="<%=model.UserBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.UserBackgroundColorCssClass%>" <%=model.UserBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserFontSizeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserFontSize" name="txt_UserFontSize" type="number" value="<%=model.UserFontSizeValue%>" class="el_text_input el_left_to_right<%=model.UserFontSizeCssClass%>" <%=model.UserFontSizeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserCommonLightBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserCommonLightBackgroundColor" name="txt_UserCommonLightBackgroundColor" type="text" value="<%=model.UserCommonLightBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.UserCommonLightBackgroundColorCssClass%>" <%=model.UserCommonLightBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserCommonLightTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserCommonLightTextColor" name="txt_UserCommonLightTextColor" type="text" value="<%=model.UserCommonLightTextColorValue%>" class="el_text_input el_left_to_right<%=model.UserCommonLightTextColorCssClass%>" <%=model.UserCommonLightTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserCommonMiddleBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserCommonMiddleBackgroundColor" name="txt_UserCommonMiddleBackgroundColor" type="text" value="<%=model.UserCommonMiddleBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.UserCommonMiddleBackgroundColorCssClass%>" <%=model.UserCommonMiddleBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserCommonMiddleTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserCommonMiddleTextColor" name="txt_UserCommonMiddleTextColor" type="text" value="<%=model.UserCommonMiddleTextColorValue%>" class="el_text_input el_left_to_right<%=model.UserCommonMiddleTextColorCssClass%>" <%=model.UserCommonMiddleTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserCommonDarkBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserCommonDarkBackgroundColor" name="txt_UserCommonDarkBackgroundColor" type="text" value="<%=model.UserCommonDarkBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.UserCommonDarkBackgroundColorCssClass%>" <%=model.UserCommonDarkBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserCommonDarkTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserCommonDarkTextColor" name="txt_UserCommonDarkTextColor" type="text" value="<%=model.UserCommonDarkTextColorValue%>" class="el_text_input el_left_to_right<%=model.UserCommonDarkTextColorCssClass%>" <%=model.UserCommonDarkTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserNaturalLightBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserNaturalLightBackgroundColor" name="txt_UserNaturalLightBackgroundColor" type="text" value="<%=model.UserNaturalLightBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.UserNaturalLightBackgroundColorCssClass%>" <%=model.UserNaturalLightBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserNaturalLightTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserNaturalLightTextColor" name="txt_UserNaturalLightTextColor" type="text" value="<%=model.UserNaturalLightTextColorValue%>" class="el_text_input el_left_to_right<%=model.UserNaturalLightTextColorCssClass%>" <%=model.UserNaturalLightTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserNaturalMiddleBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserNaturalMiddleBackgroundColor" name="txt_UserNaturalMiddleBackgroundColor" type="text" value="<%=model.UserNaturalMiddleBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.UserNaturalMiddleBackgroundColorCssClass%>" <%=model.UserNaturalMiddleBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserNaturalMiddleTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserNaturalMiddleTextColor" name="txt_UserNaturalMiddleTextColor" type="text" value="<%=model.UserNaturalMiddleTextColorValue%>" class="el_text_input el_left_to_right<%=model.UserNaturalMiddleTextColorCssClass%>" <%=model.UserNaturalMiddleTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserNaturalDarkBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserNaturalDarkBackgroundColor" name="txt_UserNaturalDarkBackgroundColor" type="text" value="<%=model.UserNaturalDarkBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.UserNaturalDarkBackgroundColorCssClass%>" <%=model.UserNaturalDarkBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserNaturalDarkTextColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserNaturalDarkTextColor" name="txt_UserNaturalDarkTextColor" type="text" value="<%=model.UserNaturalDarkTextColorValue%>" class="el_text_input el_left_to_right<%=model.UserNaturalDarkTextColorCssClass%>" <%=model.UserNaturalDarkTextColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserInfoBackgroundColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserInfoBackgroundColor" name="txt_UserInfoBackgroundColor" type="text" value="<%=model.UserInfoBackgroundColorValue%>" class="el_text_input el_left_to_right<%=model.UserInfoBackgroundColorCssClass%>" <%=model.UserInfoBackgroundColorAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserInfoFontColorLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserInfoFontColor" name="txt_UserInfoFontColor" type="text" value="<%=model.UserInfoFontColorValue%>" class="el_text_input el_left_to_right<%=model.UserInfoFontColorCssClass%>" <%=model.UserInfoFontColorAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserAvatarInUserInfo" name="cbx_ShowUserAvatarInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserAvatarInUserInfoValue)%> /><label for="cbx_ShowUserAvatarInUserInfo"><%=model.ShowUserAvatarInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserOnlineInUserInfo" name="cbx_ShowUserOnlineInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserOnlineInUserInfoValue)%> /><label for="cbx_ShowUserOnlineInUserInfo"><%=model.ShowUserOnlineInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserEmailInUserInfo" name="cbx_ShowUserEmailInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserEmailInUserInfoValue)%> /><label for="cbx_ShowUserEmailInUserInfo"><%=model.ShowUserEmailInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserBirthdayInUserInfo" name="cbx_ShowUserBirthdayInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserBirthdayInUserInfoValue)%> /><label for="cbx_ShowUserBirthdayInUserInfo"><%=model.ShowUserBirthdayInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserGenderInUserInfo" name="cbx_ShowUserGenderInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserGenderInUserInfoValue)%> /><label for="cbx_ShowUserGenderInUserInfo"><%=model.ShowUserGenderInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserPhoneNumberInUserInfo" name="cbx_ShowUserPhoneNumberInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserPhoneNumberInUserInfoValue)%> /><label for="cbx_ShowUserPhoneNumberInUserInfo"><%=model.ShowUserPhoneNumberInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserMobileNumberInUserInfo" name="cbx_ShowUserMobileNumberInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserMobileNumberInUserInfoValue)%> /><label for="cbx_ShowUserMobileNumberInUserInfo"><%=model.ShowUserMobileNumberInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserCountryInUserInfo" name="cbx_ShowUserCountryInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserCountryInUserInfoValue)%> /><label for="cbx_ShowUserCountryInUserInfo"><%=model.ShowUserCountryInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserStateOrProvinceInUserInfo" name="cbx_ShowUserStateOrProvinceInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserStateOrProvinceInUserInfoValue)%> /><label for="cbx_ShowUserStateOrProvinceInUserInfo"><%=model.ShowUserStateOrProvinceInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserCityInUserInfo" name="cbx_ShowUserCityInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserCityInUserInfoValue)%> /><label for="cbx_ShowUserCityInUserInfo"><%=model.ShowUserCityInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserZipCodeInUserInfo" name="cbx_ShowUserZipCodeInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserZipCodeInUserInfoValue)%> /><label for="cbx_ShowUserZipCodeInUserInfo"><%=model.ShowUserZipCodeInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserPostalCodeInUserInfo" name="cbx_ShowUserPostalCodeInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserPostalCodeInUserInfoValue)%> /><label for="cbx_ShowUserPostalCodeInUserInfo"><%=model.ShowUserPostalCodeInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserAddressInUserInfo" name="cbx_ShowUserAddressInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserAddressInUserInfoValue)%> /><label for="cbx_ShowUserAddressInUserInfo"><%=model.ShowUserAddressInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserWebsiteInUserInfo" name="cbx_ShowUserWebsiteInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserWebsiteInUserInfoValue)%> /><label for="cbx_ShowUserWebsiteInUserInfo"><%=model.ShowUserWebsiteInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowUserLastLoginInUserInfo" name="cbx_ShowUserLastLoginInUserInfo" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowUserLastLoginInUserInfoValue)%> /><label for="cbx_ShowUserLastLoginInUserInfo"><%=model.ShowUserLastLoginInUserInfoLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_ChangeView" name="btn_ChangeView" type="submit" class="el_button_input" value="<%=model.ChangeViewLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionChangeView')" />
            </div>
        </div>

    </form>

</body>
</html>