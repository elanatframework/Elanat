<%@ Page Controller="Elanat.ActionEditCommentController" Model="Elanat.ActionEditCommentModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditCommentLanguage%></title>
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
    <form id="frm_ActionEditComment" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/comment/action/EditComment.aspx" enctype="multipart/form-data">

        <div class="el_part_row">
            <div id="div_EditCommentTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditCommentLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ContentIdLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContentId" name="txt_ContentId" type="number" value="<%=model.ContentIdValue%>" class="el_text_input<%=model.ContentIdCssClass%>" <%=model.ContentIdAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_IsCommentReply" name="cbx_IsCommentReply" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.IsCommentReplyValue)%> /><label for="cbx_IsCommentReply"><%=model.IsCommentReplyLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ParentCommentLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ParentComment" name="txt_ParentComment" type="number" value="<%=model.ParentCommentValue%>" class="el_text_input<%=model.ParentCommentCssClass%>" <%=model.ParentCommentAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CommentActive" name="cbx_CommentActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CommentActiveValue)%> /><label for="cbx_CommentActive"><%=model.CommentActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.CommentGuestNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestName" name="txt_CommentGuestName" type="text" value="<%=model.CommentGuestNameValue%>" class="el_text_input<%=model.CommentGuestNameCssClass%>" <%=model.CommentGuestNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestRealNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestRealName" name="txt_CommentGuestRealName" type="text" value="<%=model.CommentGuestRealNameValue%>" class="el_text_input<%=model.CommentGuestRealNameCssClass%>" <%=model.CommentGuestRealNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestRealLastNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestRealLastName" name="txt_CommentGuestRealLastName" type="text" value="<%=model.CommentGuestRealLastNameValue%>" class="el_text_input<%=model.CommentGuestRealLastNameCssClass%>" <%=model.CommentGuestRealLastNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestEmailLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestEmail" name="txt_CommentGuestEmail" type="text" value="<%=model.CommentGuestEmailValue%>" class="el_text_input el_left_to_right<%=model.CommentGuestEmailCssClass%>" <%=model.CommentGuestEmailAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_CommentType" name="ddlst_CommentType" class="el_alone_select_input<%=model.CommentTypeCssClass%>" <%=model.CommentTypeAttribute%>><%=model.CommentTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.CommentTitleLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentTitle" name="txt_CommentTitle" type="text" value="<%=model.CommentTitleValue%>" class="el_long_text_input<%=model.CommentTitleCssClass%>" <%=model.CommentTitleAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentTextLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_CommentCommentText" name="txt_CommentText" class="el_textarea_input<%=model.CommentTextCssClass%>" <%=model.CommentTextAttribute%>><%=model.CommentTextValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.CommentGuestPhoneNumberLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestPhoneNumber" name="txt_CommentGuestPhoneNumber" type="text" value="<%=model.CommentGuestPhoneNumberValue%>" class="el_text_input el_left_to_right<%=model.CommentGuestPhoneNumberCssClass%>" <%=model.CommentGuestPhoneNumberAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestAddressLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_CommentGuestAddress" name="txt_CommentGuestAddress" class="el_textarea_input<%=model.CommentGuestAddressCssClass%>" <%=model.CommentGuestAddressAttribute%>><%=model.CommentGuestAddressValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.CommentGuestPostalCodeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestPostalCode" name="txt_CommentGuestPostalCode" type="text" value="<%=model.CommentGuestPostalCodeValue%>" class="el_text_input el_left_to_right<%=model.CommentGuestPostalCodeCssClass%>" <%=model.CommentGuestPostalCodeAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestAboutLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_CommentGuestAbout" name="txt_CommentGuestAbout" class="el_textarea_input<%=model.CommentGuestAboutCssClass%>" <%=model.CommentGuestAboutAttribute%>><%=model.CommentGuestAboutValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.CommentGuestBirthdayLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_CommentGuestBirthdayYear" name="ddlst_CommentGuestBirthdayYear" class="el_short_select_input<%=model.CommentGuestBirthdayYearCssClass%>" <%=model.CommentGuestBirthdayYearAttribute%>><%=model.CommentGuestBirthdayYearOptionListValue%></select><select id="ddlst_CommentGuestBirthdayMount" name="ddlst_CommentGuestBirthdayMount" class="el_short_select_input<%=model.CommentGuestBirthdayMountCssClass%>" <%=model.CommentGuestBirthdayMountAttribute%>><%=model.CommentGuestBirthdayMountOptionListValue%></select><select id="ddlst_CommentGuestBirthdayDay" name="ddlst_CommentGuestBirthdayDay" class="el_short_select_input<%=model.CommentGuestBirthdayDayCssClass%>" <%=model.CommentGuestBirthdayDayAttribute%>><%=model.CommentGuestBirthdayDayOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.CommentGuestGenderLanguage%>
            </div>
            <div class="el_item">
                <span class="el_radio_input"><input id="rdbtn_GenderMale" value="rdbtn_GenderMale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderMaleValue)%> /><label for="rdbtn_GenderMale"><%=model.MaleLanguage%></label></span>
                <span class="el_radio_input"><input id="rdbtn_GenderFemale" value="rdbtn_GenderFemale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderFemaleValue)%> /><label for="RadioButton1"><%=model.FemaleLanguage%></label></span>
                <span class="el_radio_input"><input id="rdbtn_GenderUnknown" value="rdbtn_GenderUnknown" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderUnknownValue)%> /><label for="RadioButton1"><%=model.UnknownLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.CommentGuestWebsiteLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestWebsite" name="txt_CommentGuestWebsite" type="text" value="<%=model.CommentGuestWebsiteValue%>" class="el_text_input el_left_to_right<%=model.CommentGuestWebsiteCssClass%>" <%=model.CommentGuestWebsiteAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestPublicEmailLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestPublicEmail" name="txt_CommentGuestPublicEmail" type="text" value="<%=model.CommentGuestPublicEmailValue%>" class="el_text_input el_left_to_right<%=model.CommentGuestPublicEmailCssClass%>" <%=model.CommentGuestPublicEmailAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestCountryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestCountry" name="txt_CommentGuestCountry" type="text" value="<%=model.CommentGuestCountryValue%>" class="el_text_input<%=model.CommentGuestCountryCssClass%>" <%=model.CommentGuestCountryAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestStateOrProvinceLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestStateOrProvince" name="txt_CommentGuestStateOrProvince" type="text" value="<%=model.CommentGuestStateOrProvinceValue%>" class="el_text_input<%=model.CommentGuestStateOrProvinceCssClass%>" <%=model.CommentGuestStateOrProvinceAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestCityLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestCity" name="txt_CommentGuestCity" type="text" value="<%=model.CommentGuestCityValue%>" class="el_text_input<%=model.CommentGuestCityCssClass%>" <%=model.CommentGuestCityAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestMobileNumberLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestMobileNumber" name="txt_CommentGuestMobileNumber" type="text" value="<%=model.CommentGuestMobileNumberValue%>" class="el_text_input el_left_to_right<%=model.CommentGuestMobileNumberCssClass%>" <%=model.CommentGuestMobileNumberAttribute%> />
            </div>
            <div class="el_item">
                <%=model.CommentGuestZipCodeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentGuestZipCode" name="txt_CommentGuestZipCode" type="text" value="<%=model.CommentGuestZipCodeValue%>" class="el_text_input el_left_to_right<%=model.CommentGuestZipCodeCssClass%>" <%=model.CommentGuestZipCodeAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_DeleteCommentFile" name="cbx_DeleteCommentFile" type="checkbox" /><label for="cbx_DeleteCommentFile"><%=model.DeleteCommentFileLanguage%></label></span>
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
                 <%=model.CommentDateSendLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentDateSend" name="txt_CommentDateSend" type="text" value="<%=model.CommentDateSendValue%>" class="el_text_input el_left_to_right<%=model.CommentDateSendCssClass%>" <%=model.CommentDateSendAttribute%> />
            </div>
            <div class="el_item">
                 <%=model.CommentTimeSendLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentTimeSend" name="txt_CommentTimeSend" type="text" value="<%=model.CommentTimeSendValue%>" class="el_text_input el_left_to_right<%=model.CommentTimeSendCssClass%>" <%=model.CommentTimeSendAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_SaveComment" name="btn_SaveComment" type="submit" class="el_button_input" value="<%=model.SaveCommentLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditComment')" />
            </div>
        </div>

        <input id="hdn_CommentId" name="hdn_CommentId" type="hidden" value="<%=model.CommentIdValue%>" />
        <input id="hdn_CommentUploadDirectoryValue" name="hdn_CommentUploadDirectoryValue" type="hidden" value="<%=model.CommentUploadDirectoryValue%>" />
        <input id="hdn_CommentUploadFileValue" name="hdn_CommentUploadFileValue" type="hidden" value="<%=model.CommentUploadFileValue%>" />

    </form>
</body>
</html>