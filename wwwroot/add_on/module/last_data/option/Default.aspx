<%@ Page Controller="Elanat.ModuleLastDataOptionController" Model="Elanat.ModuleLastDataOptionModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.LastDataOptionLanguage%></title>
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">

    <div class="el_head">
        <%=model.LastDataOptionLanguage%>
    </div>

    <form id="frm_ModuleLastDataOption" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/module/last_data/option/Default.aspx">

        <div class="el_part_row">
            <div class="el_item">
                <%=model.ContactCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactCount" name="txt_ContactCount" type="number" value="<%=model.ContactCountValue%>" class="el_text_input<%=model.ContactCountCssClass%>" <%=model.ContactCountAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveContact" name="cbx_ActiveContact" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveContactValue)%> /><label for="cbx_ActiveContact"><%=model.ActiveContactLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.CommentCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CommentCount" name="txt_CommentCount" type="number" value="<%=model.CommentCountValue%>" class="el_text_input<%=model.CommentCountCssClass%>" <%=model.CommentCountAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveComment" name="cbx_ActiveComment" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveCommentValue)%> /><label for="cbx_ActiveComment"><%=model.ActiveCommentLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.AttachmentCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_AttachmentCount" name="txt_AttachmentCount" type="number" value="<%=model.AttachmentCountValue%>" class="el_text_input<%=model.AttachmentCountCssClass%>" <%=model.AttachmentCountAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAttachment" name="cbx_ActiveAttachment" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAttachmentValue)%> /><label for="cbx_ActiveAttachment"><%=model.ActiveAttachmentLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ContentCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContentCount" name="txt_ContentCount" type="number" value="<%=model.ContentCountValue%>" class="el_text_input<%=model.ContentCountCssClass%>" <%=model.ContentCountAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveContent" name="cbx_ActiveContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveContentValue)%> /><label for="cbx_ActiveContent"><%=model.ActiveContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.FootPrintCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_FootPrintCount" name="txt_FootPrintCount" type="number" value="<%=model.FootPrintCountValue%>" class="el_text_input<%=model.FootPrintCountCssClass%>" <%=model.FootPrintCountAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveFootPrint" name="cbx_ActiveFootPrint" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveFootPrintValue)%> /><label for="cbx_ActiveFootPrint"><%=model.ActiveFootPrintLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.UserSignUpCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserSignUpCount" name="txt_UserSignUpCount" type="number" value="<%=model.UserSignUpCountValue%>" class="el_text_input<%=model.UserSignUpCountCssClass%>" <%=model.UserSignUpCountAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveUserSignUp" name="cbx_ActiveUserSignUp" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveUserSignUpValue)%> /><label for="cbx_ActiveUserSignUp"><%=model.ActiveUserSignUpLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ActiveUserCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ActiveUserCount" name="txt_ActiveUserCount" type="number" value="<%=model.ActiveUserCountValue%>" class="el_text_input<%=model.ActiveUserCountCssClass%>" <%=model.ActiveUserCountAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveActiveUser" name="cbx_ActiveActiveUser" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveActiveUserValue)%> /><label for="cbx_ActiveActiveUser"><%=model.ActiveActiveUserLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveLastDataOption" name="btn_SaveLastDataOption" type="submit" class="el_button_input" value="<%=model.SaveTodayActivityOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ModuleLastDataOption')" />
            </div>
        </div>

    </form>
</body>
</html>