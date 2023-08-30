<%@ Page Controller="Elanat.ModuleInformationOptionController" Model="Elanat.ModuleInformationOptionModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.InformationOptionLanguage%></title>
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">

    <div class="el_head">
        <%=model.InformationOptionLanguage%>
    </div>

    <form id="frm_ModuleInformationOption" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/module/information/option/Default.aspx">

        <div class="el_part_row">
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveFootPrint" name="cbx_ActiveFootPrint" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveFootPrintValue)%> /><label for="cbx_ActiveFootPrint"><%=model.ActiveFootPrintLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveVisit" name="cbx_ActiveVisit" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveVisitValue)%> /><label for="cbx_ActiveVisit"><%=model.ActiveVisitLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveUser" name="cbx_ActiveUser" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveUserValue)%> /><label for="cbx_ActiveUser"><%=model.ActiveUserLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveContact" name="cbx_ActiveContact" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveContactValue)%> /><label for="cbx_ActiveContact"><%=model.ActiveContactLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveComment" name="cbx_ActiveComment" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveCommentValue)%> /><label for="cbx_ActiveComment"><%=model.ActiveCommentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveContent" name="cbx_ActiveContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveContentValue)%> /><label for="cbx_ActiveContent"><%=model.ActiveContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveActiveContent" name="cbx_ActiveActiveContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveActiveContentValue)%> /><label for="cbx_ActiveActiveContent"><%=model.ActiveActiveContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveInactiveContent" name="cbx_ActiveInactiveContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveInactiveContentValue)%> /><label for="cbx_ActiveInactiveContent"><%=model.ActiveInactiveContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveTrashContent" name="cbx_ActiveTrashContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveTrashContentValue)%> /><label for="cbx_ActiveTrashContent"><%=model.ActiveTrashContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveDraftContent" name="cbx_ActiveDraftContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveDraftContentValue)%> /><label for="cbx_ActiveDraftContent"><%=model.ActiveDraftContenLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveDelayContent" name="cbx_ActiveDelayContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveDelayContentValue)%> /><label for="cbx_ActiveDelayContent"><%=model.ActiveDelayContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAdminNoteContent" name="cbx_ActiveAdminNoteContent" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAdminNoteContentValue)%> /><label for="cbx_ActiveAdminNoteContent"><%=model.ActiveAdminNoteContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAttachment" name="cbx_ActiveAttachment" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAttachmentValue)%> /><label for="cbx_ActiveAttachment"><%=model.ActiveAttachmentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveLogError" name="cbx_ActiveLogError" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveLogErrorValue)%> /><label for="cbx_ActiveLogError"><%=model.ActiveLogErrorLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveUploadSize" name="cbx_ActiveUploadSize" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveUploadSizeValue)%> /><label for="cbx_ActiveUploadSize"><%=model.ActiveUploadSizeLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveTmpSize" name="cbx_ActiveTmpSize" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveTmpSizeValue)%> /><label for="cbx_ActiveTmpSize"><%=model.ActiveTmpSizeLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveInformationOption" name="btn_SaveInformationOption" type="submit" class="el_button_input" value="<%=model.SaveInformationOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ModuleInformationOption')" />
            </div>
        </div>

    </form>
</body>
</html>
