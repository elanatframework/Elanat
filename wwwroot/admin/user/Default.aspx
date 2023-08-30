<%@ Page Controller="Elanat.AdminUserController" Model="Elanat.AdminUserModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.UserLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/user/script/user.js"></script>
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
        <%=model.UserLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_user" onclick="el_ShowHideSection(this, 'div_AddUser'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddUser" class="el_hidden">

        <form id="frm_AdminUser" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/user/Default.aspx">

            <div class="el_part_row">
                <div id="div_AddUserTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddUserLanguage%>
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
                    <%=model.UserPasswordLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_UserPassword" name="txt_UserPassword" type="password" autocomplete="off" readonly="true" onfocus="this.removeAttribute('readonly');" value="<%=model.UserPasswordValue%>" class="el_text_input<%=model.UserPasswordCssClass%>" <%=model.UserPasswordAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.RepeatPasswordLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_RepeatPassword" name="txt_RepeatPassword" type="password" autocomplete="off" readonly="true" onfocus="this.removeAttribute('readonly');" value="<%=model.RepeatPasswordValue%>" class="el_text_input<%=model.RepeatPasswordCssClass%>" <%=model.RepeatPasswordAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.UserEmailLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_UserEmail" name="txt_UserEmail" type="text" value="<%=model.UserEmailValue%>" class="el_text_input el_left_to_right<%=model.UserEmailCssClass%>" <%=model.UserEmailAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.RepeatEmailLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_RepeatEmail" name="txt_RepeatEmail" type="text" value="<%=model.RepeatEmailValue%>" class="el_text_input el_left_to_right<%=model.RepeatEmailCssClass%>" <%=model.RepeatEmailAttribute%> />
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
                    <textarea id="txt_UserAddress" name="txt_UserAddress" class="el_textarea_input<%=model.UserAddressCssClass%>" <%=model.UserAddressAttribute%>><%=model.UserAddressValue%></textarea>
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
                    <textarea id="txt_UserAbout" name="txt_UserAbout" class="el_textarea_input<%=model.UserAboutCssClass%>" <%=model.UserAboutAttribute%>><%=model.UserAboutValue%></textarea>
                </div>
                <div class="el_item">
                    <%=model.UserBirthdayLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_UserBirthdayYear" name="ddlst_UserBirthdayYear" class="el_short_select_input<%=model.UserBirthdayYearCssClass%>" <%=model.UserBirthdayYearAttribute%>><%=model.UserBirthdayYearOptionListValue%></select><select id="ddlst_UserBirthdayMount" name="ddlst_UserBirthdayMount" class="el_short_select_input<%=model.UserBirthdayMountCssClass%>" <%=model.UserBirthdayMountAttribute%>><%=model.UserBirthdayMountOptionListValue%></select><select id="ddlst_UserBirthdayDay" name="ddlst_UserBirthdayDay" class="el_short_select_input<%=model.UserBirthdayDayCssClass%>" <%=model.UserBirthdayDayAttribute%>><%=model.UserBirthdayDayOptionListValue%></select>
                </div>
                <div class="el_item">
                    <%=model.UserGenderLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_radio_input">
                        <input id="rdbtn_GenderMale" value="rdbtn_GenderMale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderMaleValue)%> /><label for="rdbtn_GenderMale"><%=model.GenderMaleLanguage%></label></span>
                    <span class="el_radio_input">
                        <input id="rdbtn_GenderFemale" value="rdbtn_GenderFemale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderFemaleValue)%> /><label for="rdbtn_Gender"><%=model.GenderFemaleLanguage%></label></span>
                    <span class="el_radio_input">
                        <input id="rdbtn_GenderUnknown" value="rdbtn_GenderUnknown" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderUnknownValue)%> /><label for="rdbtn_GenderUnknown"><%=model.GenderUnknownLanguage%></label></span>
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
                    <textarea id="txt_UserOtherInfo" name="txt_UserOtherInfo" class="el_textarea_input<%=model.UserOtherInfoCssClass%>" <%=model.UserOtherInfoAttribute%>><%=model.UserOtherInfoValue%></textarea>
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
                    <%=model.UserGroupLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_UserGroup" name="ddlst_UserGroup" class="el_alone_select_input<%=model.UserGroupCssClass%>" <%=model.UserGroupAttribute%>><%=model.UserGroupOptionListValue%></select>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_UserActive" name="cbx_UserActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UserActiveValue)%> /><label for="cbx_UserActive"><%=model.UserActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_UserEmailIsConfirm" name="cbx_UserEmailIsConfirm" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UserEmailIsConfirmValue)%> /><label for="cbx_UserEmailIsConfirm"><%=model.UserEmailIsConfirmLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="btn_AddUser" name="btn_AddUser" type="submit" class="el_button_input" value="<%=model.AddUserLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminUser')" />
                </div>
            </div>

        </form>

    </div>

    <div class="el_part_row">
        <div id="div_TableBox" class="el_item">
            <%=model.ContentValue%>
        </div>
    </div>

</body>
</html>