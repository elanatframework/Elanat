<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLanguageVariant.aspx.cs" Inherits="elanat.ActionAddLanguageVariant" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title></title>
    <script src="<%=elanat.AspxHtmlValue.AdminPath()%>/language/script/language.js"></script>
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
    <form id="frm_ActionAddLanguageVariant" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/language/action/add_language_variant/AddLanguageVariant.aspx" >

        <div class="el_part_row">
            <div id="div_AddLanguageVariant" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.AddLanguageVariantLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.LanguageVariantLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_LanguageVariant" name="txt_LanguageVariant" type="text" value="<%=model.LanguageVariantValue%>" class="el_text_input el_left_to_right<%=model.LanguageVariantCssClass%>" <%=model.LanguageVariantAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LanguageInputAddValue%>
            </div>
            <div class="el_item">
                <input id="btn_AddLanguageVariant" name="btn_AddLanguageVariant" type="submit" class="el_button_input" value="<%=model.AddLanguageVariantLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionAddLanguageVariant')" />
            </div>
        </div>

    </form>
</body>
</html>