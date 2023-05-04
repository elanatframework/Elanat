<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAttachment.aspx.cs" Inherits="elanat.ActionEditAttachment" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditAttachmentLanguage%></title>
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
<body onload="el_PartPageLoad();">
    <form id="frm_ActionEditAttachment" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/attachment/action/EditAttachment.aspx">

        <div class="el_part_row">
            <div id="div_EditAttachmentTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditAttachmentLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.AttachmentNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_AttachmentName" name="txt_AttachmentName" type="text" value="<%=model.AttachmentNameValue%>" class="el_text_input<%=model.AttachmentNameCssClass%>" <%=model.AttachmentNameAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_AttachmentActive" name="cbx_AttachmentActive" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AttachmentActiveValue)%> /><label for="cbx_AttachmentActive"><%=model.AttachmentActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.AttachmentAboutLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_AttachmentAbout" name="txt_AttachmentAbout" class="el_textarea_input<%=model.AttachmentAboutCssClass%>" <%=model.AttachmentAboutAttribute%>><%=model.AttachmentAboutValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.AttachmentPasswordLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_AttachmentPassword" name="txt_AttachmentPassword" type="password" autocomplete="off" readonly="true" onfocus="this.removeAttribute('readonly');" class="el_text_input<%=model.AttachmentPasswordCssClass%>" <%=model.AttachmentPasswordAttribute%> />
            </div>
            <div class="el_item">
                <%=model.AttachmentContentLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_AttachmentContent" name="txt_AttachmentContent" class="el_list_number_input<%=model.AttachmentContentCssClass%>" <%=model.AttachmentContentAttribute%>><%=model.AttachmentContentValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.AttachmentAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input">
                    <input id="cbx_AttachmentPublicAccessShow" name="cbx_AttachmentPublicAccessShow" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AttachmentPublicAccessShowValue)%> /><label for="cbx_AttachmentPublicAccessShow"><%=model.AttachmentPublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.AttachmentAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveAttachment" name="btn_SaveAttachment" type="submit" class="el_button_input" value="<%=model.SaveAttachmentLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionEditAttachment')" />
            </div>
        </div>

        <input id="hdn_AttachmentId" name="hdn_AttachmentId" type="hidden" value="<%=model.AttachmentIdValue%>" />

    </form>
</body>
</html>