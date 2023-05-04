<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddContactResponse.aspx.cs" Inherits="elanat.ActionAddContactResponse" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ContactResponseLanguage%></title>
    <!-- Start Client Variant -->
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/site_client_variant/"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/site_client_language_variant"></script>
    <!-- End Client Variant -->	
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
</head>
<body onload="el_PartPageLoad();">
    <div id="div_AddContactResponsePostBack">

        <div class="el_head">
            <%=model.ContactResponseLanguage%>
        </div>

        <form id="frm_ActionAddContactResponse" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/contact/action/add_contact_response/AddContactResponse.aspx">

            <div class="el_part_row">
                <div id="div_AddContactResponseTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddContactResponseLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.ContactTitleLanguage%>
                </div>
                <div class="el_item">
                    <%=model.ContactTitleValue%>
                </div>
                <div class="el_item">
                    <%=model.ContactTextLanguage%>
                </div>
                <div class="el_item">
                    <%=model.ContactTextValue%>
                </div>
                <div class="el_item">
                    <%=model.ContactResponseLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_ContactResponse" name="txt_ContactResponse" class="el_textarea_input"><%=model.ContactResponseValue%></textarea>
                </div>
                <div class="el_item">
                    <input id="btn_AddContactResponse" name="btn_AddContactResponse" type="submit" class="el_button_input" value="<%=model.AddContactResponseLanguage%>" onclick="el_AjaxPostBack(this, false, 'div_AddContactResponsePostBack')" />
                </div>
            </div>

            <input id="hdn_ContactId" name="hdn_ContactId" type="hidden" value="<%=model.ContactIdValue%>" />

        </form>
    </div>
</body>
</html>