<%@ Page Controller="Elanat.ExtraHelperContactOptionController" Model="Elanat.ExtraHelperContactOptionModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ContactOptionLanguage%></title>
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">

    <div class="el_head">
        <%=model.ContactOptionLanguage%>
    </div>

    <form id="frm_ExtraHelperContactOption" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/contact_option/Default.aspx">

        <div class="el_part_row">
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveName" name="cbx_ActiveName" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveNameValue)%> /><label for="cbx_ActiveName"><%=model.ActiveNameLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveLastName" name="cbx_ActiveLastName" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveLastNameValue)%> /><label for="cbx_ActiveLastName"><%=model.ActiveLastNameLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveEmail" name="cbx_ActiveEmail" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveEmailValue)%> /><label for="cbx_ActiveEmail"><%=model.ActiveEmailLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveTitle" name="cbx_ActiveTitle" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveTitleValue)%> /><label for="cbx_ActiveTitle"><%=model.ActiveTitleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveText" name="cbx_ActiveText" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveTextValue)%> /><label for="cbx_ActiveText"><%=model.ActiveTextLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveFile" name="cbx_ActiveFile" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveFileValue)%> /><label for="cbx_ActiveFile"><%=model.ActiveFileLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveType" name="cbx_ActiveType" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveTypeValue)%> /><label for="cbx_ActiveType"><%=model.ActiveTypeLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActivePhoneNumber" name="cbx_ActivePhoneNumber" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActivePhoneNumberValue)%> /><label for="cbx_ActivePhoneNumber"><%=model.ActivePhoneNumberLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveMobileNumber" name="cbx_ActiveMobileNumber" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveMobileNumberValue)%> /><label for="cbx_ActiveMobileNumber"><%=model.ActiveMobileNumberLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAddress" name="cbx_ActiveAddress" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAddressValue)%> /><label for="cbx_ActiveAddress"><%=model.ActiveAddressLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActivePostalCode" name="cbx_ActivePostalCode" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActivePostalCodeValue)%> /><label for="cbx_ActivePostalCode"><%=model.ActivePostalCodeLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAbout" name="cbx_ActiveAbout" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAboutValue)%> /><label for="cbx_ActiveAbout"><%=model.ActiveAboutLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveBirthday" name="cbx_ActiveBirthday" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveBirthdayValue)%> /><label for="cbx_ActiveBirthday"><%=model.ActiveBirthdayLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveGender" name="cbx_ActiveGender" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveGenderValue)%> /><label for="cbx_ActiveGender"><%=model.ActiveGenderLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveCountry" name="cbx_ActiveCountry" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveCountryValue)%> /><label for="cbx_ActiveCountry"><%=model.ActiveCountryLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveStateOrProvince" name="cbx_ActiveStateOrProvince" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveStateOrProvinceValue)%> /><label for="cbx_ActiveStateOrProvince"><%=model.ActiveStateOrProvinceLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveCity" name="cbx_ActiveCity" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveCityValue)%> /><label for="cbx_ActiveCity"><%=model.ActiveCityLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveZipCode" name="cbx_ActiveZipCode" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveZipCodeValue)%> /><label for="cbx_ActiveZipCode"><%=model.ActiveZipCodeLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActivePublicEmail" name="cbx_ActivePublicEmail" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActivePublicEmailValue)%> /><label for="cbx_ActivePublicEmail"><%=model.ActivePublicEmailLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveWebsite" name="cbx_ActiveWebsite" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveWebsiteValue)%> /><label for="cbx_ActiveWebsite"><%=model.ActiveWebsiteLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveContactOption" name="btn_SaveContactOption" type="submit" class="el_button_input" value="<%=model.SaveContactOptionLanguage%>" onclick="el_AjaxPostBack(this)" />
            </div>
        </div>

    </form>
</body>
</html>