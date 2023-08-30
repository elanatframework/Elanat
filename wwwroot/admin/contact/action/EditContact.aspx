<%@ Page Controller="Elanat.ActionEditContactController" Model="Elanat.ActionEditContactModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditContactLanguage%></title>
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
    <form id="frm_ActionEditContact" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/contact/action/EditContact.aspx" enctype="multipart/form-data">

        <div class="el_part_row">
            <div id="div_EditContactTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditContactLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ContactGuestNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestName" name="txt_ContactGuestName" type="text" value="<%=model.ContactGuestNameValue%>" class="el_text_input<%=model.ContactGuestNameCssClass%>" <%=model.ContactGuestNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestRealNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestRealName" name="txt_ContactGuestRealName" type="text" value="<%=model.ContactGuestRealNameValue%>" class="el_text_input<%=model.ContactGuestRealNameCssClass%>" <%=model.ContactGuestRealNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestRealLastNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestRealLastName" name="txt_ContactGuestRealLastName" type="text" value="<%=model.ContactGuestRealLastNameValue%>" class="el_text_input<%=model.ContactGuestRealLastNameCssClass%>" <%=model.ContactGuestRealLastNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestEmailLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestEmail" name="txt_ContactGuestEmail" type="text" value="<%=model.ContactGuestEmailValue%>" class="el_text_input el_left_to_right<%=model.ContactGuestEmailCssClass%>" <%=model.ContactGuestEmailAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ContactType" name="ddlst_ContactType" class="el_alone_select_input<%=model.ContactTypeCssClass%>" <%=model.ContactTypeAttribute%>><%=model.ContactTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.ContactTitleLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactTitle" name="txt_ContactTitle" type="text" value="<%=model.ContactTitleValue%>" class="el_long_text_input<%=model.ContactTitleCssClass%>" <%=model.ContactTitleAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactTextLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_ContactContactText" name="txt_ContactText" class="el_textarea_input<%=model.ContactTextCssClass%>" <%=model.ContactTextAttribute%>><%=model.ContactTextValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.ContactGuestPhoneNumberLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestPhoneNumber" name="txt_ContactGuestPhoneNumber" type="text" value="<%=model.ContactGuestPhoneNumberValue%>" class="el_text_input el_left_to_right<%=model.ContactGuestPhoneNumberCssClass%>" <%=model.ContactGuestPhoneNumberAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestAddressLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_ContactGuestAddress" name="txt_ContactGuestAddress" class="el_textarea_input<%=model.ContactGuestAddressCssClass%>" <%=model.ContactGuestAddressAttribute%>><%=model.ContactGuestAddressValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.ContactGuestPostalCodeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestPostalCode" name="txt_ContactGuestPostalCode" type="text" value="<%=model.ContactGuestPostalCodeValue%>" class="el_text_input el_left_to_right<%=model.ContactGuestPostalCodeCssClass%>" <%=model.ContactGuestPostalCodeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestAboutLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_ContactGuestAbout" name="txt_ContactGuestAbout" class="el_textarea_input<%=model.ContactGuestAboutCssClass%>" <%=model.ContactGuestAboutAttribute%>><%=model.ContactGuestAboutValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.ContactGuestBirthdayLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ContactGuestBirthdayYear" name="ddlst_ContactGuestBirthdayYear" class="el_short_select_input<%=model.ContactGuestBirthdayYearCssClass%>" <%=model.ContactGuestBirthdayYearAttribute%>><%=model.ContactGuestBirthdayYearOptionListValue%></select><select id="ddlst_ContactGuestBirthdayMount" name="ddlst_ContactGuestBirthdayMount" class="el_short_select_input<%=model.ContactGuestBirthdayMountCssClass%>" <%=model.ContactGuestBirthdayMountAttribute%>><%=model.ContactGuestBirthdayMountOptionListValue%></select><select id="ddlst_ContactGuestBirthdayDay" name="ddlst_ContactGuestBirthdayDay" class="el_short_select_input<%=model.ContactGuestBirthdayDayCssClass%>" <%=model.ContactGuestBirthdayDayAttribute%>><%=model.ContactGuestBirthdayDayOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.ContactGuestGenderLanguage%>
            </div>
            <div class="el_item">
                <span class="el_radio_input"><input id="rdbtn_GenderMale" value="rdbtn_GenderMale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderMaleValue)%> /><label for="rdbtn_GenderMale"><%=model.MaleLanguage%></label></span>
                <span class="el_radio_input"><input id="rdbtn_GenderFemale" value="rdbtn_GenderFemale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderFemaleValue)%> /><label for="RadioButton1"><%=model.FemaleLanguage%></label></span>
                <span class="el_radio_input"><input id="rdbtn_GenderUnknown" value="rdbtn_GenderUnknown" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderUnknownValue)%> /><label for="RadioButton1"><%=model.UnknownLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ContactGuestWebsiteLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestWebsite" name="txt_ContactGuestWebsite" type="text" value="<%=model.ContactGuestWebsiteValue%>" class="el_text_input el_left_to_right<%=model.ContactGuestWebsiteCssClass%>" <%=model.ContactGuestWebsiteAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestPublicEmailLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestPublicEmail" name="txt_ContactGuestPublicEmail" type="text" value="<%=model.ContactGuestPublicEmailValue%>" class="el_text_input el_left_to_right<%=model.ContactGuestPublicEmailCssClass%>" <%=model.ContactGuestPublicEmailAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestCountryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestCountry" name="txt_ContactGuestCountry" type="text" value="<%=model.ContactGuestCountryValue%>" class="el_text_input<%=model.ContactGuestCountryCssClass%>" <%=model.ContactGuestCountryAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestStateOrProvinceLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestStateOrProvince" name="txt_ContactGuestStateOrProvince" type="text" value="<%=model.ContactGuestStateOrProvinceValue%>" class="el_text_input<%=model.ContactGuestStateOrProvinceCssClass%>" <%=model.ContactGuestStateOrProvinceAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestCityLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestCity" name="txt_ContactGuestCity" type="text" value="<%=model.ContactGuestCityValue%>" class="el_text_input<%=model.ContactGuestCityCssClass%>" <%=model.ContactGuestCityAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestMobileNumberLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestMobileNumber" name="txt_ContactGuestMobileNumber" type="text" value="<%=model.ContactGuestMobileNumberValue%>" class="el_text_input el_left_to_right<%=model.ContactGuestMobileNumberCssClass%>" <%=model.ContactGuestMobileNumberAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContactGuestZipCodeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactGuestZipCode" name="txt_ContactGuestZipCode" type="text" value="<%=model.ContactGuestZipCodeValue%>" class="el_text_input el_left_to_right<%=model.ContactGuestZipCodeCssClass%>" <%=model.ContactGuestZipCodeAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_DeleteContactFile" name="cbx_DeleteContactFile" type="checkbox" /><label for="cbx_DeleteContactFile"><%=model.DeleteContactFileLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.UploadPathLanguage%>
            </div>
            <div class="el_item">
                <input id="upd_UploadPath" name="upd_UploadPath" type="file" class="el_file_input" />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseUploadPath" name="cbx_UseUploadPath" type="checkbox" /><label for="cbx_UseUploadPath"><%=model.UseUploadPathLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="txt_UploadPath" name="txt_UploadPath" value="<%=model.UploadPathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
            </div>
            <div class="el_item">
                 <%=model.ContactDateSendLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactDateSend" name="txt_ContactDateSend" type="text" value="<%=model.ContactDateSendValue%>" class="el_text_input el_left_to_right<%=model.ContactDateSendCssClass%>" <%=model.ContactDateSendAttribute%> />
            </div>
            <div class="el_item">
                 <%=model.ContactTimeSendLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactTimeSend" name="txt_ContactTimeSend" type="text" value="<%=model.ContactTimeSendValue%>" class="el_text_input el_left_to_right<%=model.ContactTimeSendCssClass%>" <%=model.ContactTimeSendAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_SaveContact" name="btn_SaveContact" type="submit" class="el_button_input" value="<%=model.SaveContactLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditContact')" />
            </div>
        </div>

        <input id="hdn_ContactId" name="hdn_ContactId" type="hidden" value="<%=model.ContactIdValue%>" />
        <input id="hdn_ContactUploadDirectoryValue" name="hdn_ContactUploadDirectoryValue" type="hidden" value="<%=model.ContactUploadDirectoryValue%>" />
        <input id="hdn_ContactUploadFileValue" name="hdn_ContactUploadFileValue" type="hidden" value="<%=model.ContactUploadFileValue%>" />

    </form>
</body>
</html>