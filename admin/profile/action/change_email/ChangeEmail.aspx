<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeEmail.aspx.cs" Inherits="elanat.ActionChangeEmail" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EmailLanguage%></title>
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
        <%=model.EmailLanguage%>
    </div>

    <form id="frm_ActionChangeEmail" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_email/ChangeEmail.aspx">

        <div class="el_part_row">
            <div id="div_ChangeEmailTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeEmailLanguage%>
                <div class="el_dash"></div>
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
                <input id="txt_RepeatEmail" name="txt_RepeatEmail" type="text" value="<%=model.RepeatEmaiValue%>" class="el_text_input el_left_to_right<%=model.RepeatEmailCssClass%>" <%=model.RepeatEmailtAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_ChangeEmail" name="btn_ChangeEmail" type="submit" class="el_button_input" value="<%=model.ChangeEmailLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionChangeEmail')" />
            </div>
        </div>

    </form>

</body>
</html>