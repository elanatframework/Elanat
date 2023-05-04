﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeProfile.aspx.cs" Inherits="elanat.ActionChangeProfile" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ProfileLanguage%></title>
    <!-- Start Client Variant -->
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant"></script>
    <!-- End Client Variant -->	
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=elanat.AspxHtmlValue.CurrentBoxTag()%>
</head>
<body onload="el_RunAction(); el_PartPageLoad();">


    <div class="el_head">
        <%=model.ProfileLanguage%>
    </div>

    <form id="frm_ActionChangeProfile" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_profile/ChangeProfile.aspx">

        <div class="el_part_row">
            <div id="div_ChangeProfileHead" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeProfileLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserName" name="txt_UserName" type="text" value="<%=model.UserNameValue%>" class="el_text_input<%=model.UserNameCssClass%>" <%=model.UserNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserSiteNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserSiteName" name="txt_UserSiteName" type="text" value="<%=model.UserSiteNameValue%>" class="el_text_input<%=model.UserSiteNameCssClass%>" <%=model.UserSiteNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserRealNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserRealName" name="txt_UserRealName" type="text" value="<%=model.UserRealNameValue%>" class="el_text_input<%=model.UserRealNameCssClass%>" <%=model.UserRealNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserRealLastNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserRealLastName" name="txt_UserRealLastName" type="text" value="<%=model.UserRealLastNameValue%>" class="el_text_input<%=model.UserRealLastNameCssClass%>" <%=model.UserRealLastNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserPhoneNumberLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserPhoneNumber" name="txt_UserPhoneNumber" type="text" value="<%=model.UserPhoneNumberValue%>" class="el_text_input el_left_to_right<%=model.UserPhoneNumberCssClass%>" <%=model.UserPhoneNumberAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserAddressLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_UserAddress" name="txt_UserAddress" class="el_textarea_input"><%=model.UserAddressValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.UserPostalCodeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserPostalCode" name="txt_UserPostalCode" type="text" value="<%=model.UserPostalCodeValue%>" class="el_text_input el_left_to_right<%=model.UserPostalCodeCssClass%>" <%=model.UserPostalCodeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserAboutLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_UserAbout" name="txt_UserAbout" class="el_textarea_input"><%=model.UserAboutValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.UserBirthdayLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_BirthdayYear" name="ddlst_BirthdayYear" class="el_short_select_input<%=model.BirthdayYearCssClass%>" <%=model.BirthdayYearAttribute%>><%=model.BirthdayYearOptionListValue%></select><select id="ddlst_BirthdayMount" name="ddlst_BirthdayMount" class="el_short_select_input<%=model.BirthdayMountCssClass%>" <%=model.BirthdayMountAttribute%>><%=model.BirthdayMountOptionListValue%></select><select id="ddlst_BirthdayDay" name="ddlst_BirthdayDay" class="el_short_select_input<%=model.BirthdayDayCssClass%>" <%=model.BirthdayDayAttribute%>><%=model.BirthdayDayOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.UserGenderLanguage%>
            </div>
            <div class="el_item">
                <span class="el_radio_input"><input id="rdbtn_GenderMale" value="rdbtn_GenderMale" name="rdbtn_Gender" type="radio" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderMaleValue)%> /><label for="rdbtn_GenderMale"><%=model.MaleLanguage%></label></span>
                <span class="el_radio_input"><input id="rdbtn_GenderFemale" value="rdbtn_GenderFemale" name="rdbtn_Gender" type="radio"<%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderFemaleValue)%> /><label for="RadioButton1"><%=model.FemaleLanguage%></label></span>
                <span class="el_radio_input"><input id="rdbtn_GenderUnknown" value="rdbtn_GenderUnknown" name="rdbtn_Gender" type="radio"<%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderUnknownValue)%> /><label for="RadioButton1"><%=model.UnknownLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.UserPublicEmailLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserPublicEmail" name="txt_UserPublicEmail" type="text" value="<%=model.UserPublicEmailValue%>" class="el_text_input el_left_to_right<%=model.UserPublicEmailCssClass%>" <%=model.UserPublicEmailAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserMobileNumberLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserMobileNumber" name="txt_UserMobileNumber" type="text" value="<%=model.UserMobileNumberValue%>" class="el_text_input el_left_to_right<%=model.UserMobileNumberCssClass%>" <%=model.UserMobileNumberAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserZipCodeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserZipCode" name="txt_UserZipCode" type="text" value="<%=model.UserZipCodeValue%>" class="el_text_input el_left_to_right<%=model.UserZipCodeCssClass%>" <%=model.UserZipCodeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserOtherInfoLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_UserOtherInfo" name="txt_UserOtherInfo" class="el_textarea_input"><%=model.UserOtherInfoValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.UserCountryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserCountry" name="txt_UserCountry" type="text" value="<%=model.UserCountryValue%>" class="el_text_input<%=model.UserCountryCssClass%>" <%=model.UserCountryAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserStateOrProvinceLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserStateOrProvince" name="txt_UserStateOrProvince" type="text" value="<%=model.UserStateOrProvinceValue%>" class="el_text_input<%=model.UserStateOrProvinceCssClass%>" <%=model.UserStateOrProvinceAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserCityLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserCity" name="txt_UserCity" type="text" value="<%=model.UserCityValue%>" class="el_text_input<%=model.UserCityCssClass%>" <%=model.UserCityAttribute%> />
            </div>
            <div class="el_item">
                <%=model.UserWebsiteLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserWebsite" name="txt_UserWebsite" type="text" value="<%=model.UserWebsiteValue%>" class="el_text_input el_left_to_right<%=model.UserWebsiteCssClass%>" <%=model.UserWebsiteAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_ChangeProfile" name="btn_ChangeProfile" type="submit" class="el_button_input" value="<%=model.ChangeProfileLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionChangeProfile')" />
            </div>
        </div>

    </form>

</body>
</html>