<%@ Page Controller="Elanat.AdminContentReplyController" Model="Elanat.AdminContentReplyModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ContentReplyLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/content_reply/script/content_reply.js"></script>
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
<body onload="el_CreateWysiwyg(); el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.ContentReplyLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_content_reply" onclick="el_ShowHideSection(this, 'div_AddContentReply'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddContentReply" class="el_hidden">

        <form id="frm_AdminContentReply" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/content_reply/Default.aspx">

            <div class="el_part_row">
                <div id="div_AddContentReplyTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddContentReplyLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.ContentIdLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentId" name="txt_ContentId" type="number" value="<%=model.ContentIdValue%>" class="el_text_input<%=model.ContentIdCssClass%>" <%=model.ContentIdAttribute%> />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ContentReplyActive" name="cbx_ContentReplyActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ContentReplyActiveValue)%> /><label for="cbx_ContentReplyActive"><%=model.ContentReplyActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestName" name="txt_ContentReplyGuestName" type="text" value="<%=model.ContentReplyGuestNameValue%>" class="el_text_input<%=model.ContentReplyGuestNameCssClass%>" <%=model.ContentReplyGuestNameAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestRealNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestRealName" name="txt_ContentReplyGuestRealName" type="text" value="<%=model.ContentReplyGuestRealNameValue%>" class="el_text_input<%=model.ContentReplyGuestRealNameCssClass%>" <%=model.ContentReplyGuestRealNameAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestRealLastNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestRealLastName" name="txt_ContentReplyGuestRealLastName" type="text" value="<%=model.ContentReplyGuestRealLastNameValue%>" class="el_text_input<%=model.ContentReplyGuestRealLastNameCssClass%>" <%=model.ContentReplyGuestRealLastNameAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestEmailLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestEmail" name="txt_ContentReplyGuestEmail" type="text" value="<%=model.ContentReplyGuestEmailValue%>" class="el_text_input el_left_to_right<%=model.ContentReplyGuestEmailCssClass%>" <%=model.ContentReplyGuestEmailAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyTypeLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_ContentReplyType" name="ddlst_ContentReplyType" class="el_alone_select_input<%=model.ContentReplyTypeCssClass%>" <%=model.ContentReplyTypeAttribute%>><%=model.ContentReplyTypeOptionListValue%></select>
                </div>
                <div class="el_item">
                    <%=model.ContentReplyTextLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_ContentReplyContentReplyText" name="txt_ContentReplyText" class="el_textarea_input<%=model.ContentReplyTextCssClass%>" <%=model.ContentReplyTextAttribute%>><%=model.ContentReplyTextValue%></textarea>
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestPhoneNumberLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestPhoneNumber" name="txt_ContentReplyGuestPhoneNumber" type="text" value="<%=model.ContentReplyGuestPhoneNumberValue%>" class="el_text_input el_left_to_right<%=model.ContentReplyGuestPhoneNumberCssClass%>" <%=model.ContentReplyGuestPhoneNumberAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestAddressLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_ContentReplyGuestAddress" name="txt_ContentReplyGuestAddress" class="el_textarea_input<%=model.ContentReplyGuestAddressCssClass%>" <%=model.ContentReplyGuestAddressAttribute%>><%=model.ContentReplyGuestAddressValue%></textarea>
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestPostalCodeLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestPostalCode" name="txt_ContentReplyGuestPostalCode" type="text" value="<%=model.ContentReplyGuestPostalCodeValue%>" class="el_text_input el_left_to_right<%=model.ContentReplyGuestPostalCodeCssClass%>" <%=model.ContentReplyGuestPostalCodeAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestAboutLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_ContentReplyGuestAbout" name="txt_ContentReplyGuestAbout" class="el_textarea_input<%=model.ContentReplyGuestAboutCssClass%>" <%=model.ContentReplyGuestAboutAttribute%>><%=model.ContentReplyGuestAboutValue%></textarea>
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestBirthdayLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_ContentReplyGuestBirthdayYear" name="ddlst_ContentReplyGuestBirthdayYear" class="el_short_select_input<%=model.ContentReplyGuestBirthdayYearCssClass%>" <%=model.ContentReplyGuestBirthdayYearAttribute%>><%=model.ContentReplyGuestBirthdayYearOptionListValue%></select><select id="ddlst_ContentReplyGuestBirthdayMount" name="ddlst_ContentReplyGuestBirthdayMount" class="el_short_select_input<%=model.ContentReplyGuestBirthdayMountCssClass%>" <%=model.ContentReplyGuestBirthdayMountAttribute%>><%=model.ContentReplyGuestBirthdayMountOptionListValue%></select><select id="ddlst_ContentReplyGuestBirthdayDay" name="ddlst_ContentReplyGuestBirthdayDay" class="el_short_select_input<%=model.ContentReplyGuestBirthdayDayCssClass%>" <%=model.ContentReplyGuestBirthdayDayAttribute%>><%=model.ContentReplyGuestBirthdayDayOptionListValue%></select>
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestGenderLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_radio_input">
                        <input id="rdbtn_GenderMale" value="rdbtn_GenderMale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderMaleValue)%> /><label for="rdbtn_GenderMale"><%=model.MaleLanguage%></label></span>
                    <span class="el_radio_input">
                        <input id="rdbtn_GenderFemale" value="rdbtn_GenderFemale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderFemaleValue)%> /><label for="RadioButton1"><%=model.FemaleLanguage%></label></span>
                    <span class="el_radio_input">
                        <input id="rdbtn_GenderUnknown" value="rdbtn_GenderUnknown" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderUnknownValue)%> /><label for="RadioButton1"><%=model.UnknownLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestWebsiteLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestWebsite" name="txt_ContentReplyGuestWebsite" type="text" value="<%=model.ContentReplyGuestWebsiteValue%>" class="el_text_input el_left_to_right<%=model.ContentReplyGuestWebsiteCssClass%>" <%=model.ContentReplyGuestWebsiteAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestPublicEmailLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestPublicEmail" name="txt_ContentReplyGuestPublicEmail" type="text" value="<%=model.ContentReplyGuestPublicEmailValue%>" class="el_text_input el_left_to_right<%=model.ContentReplyGuestPublicEmailCssClass%>" <%=model.ContentReplyGuestPublicEmailAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestCountryLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestCountry" name="txt_ContentReplyGuestCountry" type="text" value="<%=model.ContentReplyGuestCountryValue%>" class="el_text_input<%=model.ContentReplyGuestCountryCssClass%>" <%=model.ContentReplyGuestCountryAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestStateOrProvinceLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestStateOrProvince" name="txt_ContentReplyGuestStateOrProvince" type="text" value="<%=model.ContentReplyGuestStateOrProvinceValue%>" class="el_text_input<%=model.ContentReplyGuestStateOrProvinceCssClass%>" <%=model.ContentReplyGuestStateOrProvinceAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestCityLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestCity" name="txt_ContentReplyGuestCity" type="text" value="<%=model.ContentReplyGuestCityValue%>" class="el_text_input<%=model.ContentReplyGuestCityCssClass%>" <%=model.ContentReplyGuestCityAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestMobileNumberLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestMobileNumber" name="txt_ContentReplyGuestMobileNumber" type="text" value="<%=model.ContentReplyGuestMobileNumberValue%>" class="el_text_input el_left_to_right<%=model.ContentReplyGuestMobileNumberCssClass%>" <%=model.ContentReplyGuestMobileNumberAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentReplyGuestZipCodeLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentReplyGuestZipCode" name="txt_ContentReplyGuestZipCode" type="text" value="<%=model.ContentReplyGuestZipCodeValue%>" class="el_text_input el_left_to_right<%=model.ContentReplyGuestZipCodeCssClass%>" <%=model.ContentReplyGuestZipCodeAttribute%> />
                </div>
                <div class="el_item">
                    <input id="btn_AddContentReply" name="btn_AddContentReply" type="submit" class="el_button_input" value="<%=model.AddContentReplyLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminContentReply')" />
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