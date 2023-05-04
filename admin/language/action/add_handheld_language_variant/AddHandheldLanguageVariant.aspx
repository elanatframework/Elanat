<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHandheldLanguageVariant.aspx.cs" Inherits="elanat.ActionAddHandheldLanguageVariant" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.AddHandheldLanguageVariantLanguage%></title>
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
    <form id="frm_ActionAddHandheldLanguageVariant" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/language/action/add_handheld_language_variant/AddHandheldLanguageVariant.aspx" >

        <div class="el_part_row">
            <div id="div_AddHandheldLanguageVariant" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.AddHandheldLanguageVariantLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.HandheldLanguageVariantLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_HandheldLanguageVariant" name="txt_HandheldLanguageVariant" type="text" value="<%=model.HandheldLanguageVariantValue%>" class="el_text_input el_left_to_right<%=model.HandheldLanguageVariantCssClass%>" <%=model.HandheldLanguageVariantAttribute%> />
            </div>
            <div class="el_item">
                <%=model.HandheldLanguageInputAddValue%>
            </div>
            <div class="el_item">
                <input id="btn_AddHandheldLanguageVariant" name="btn_AddHandheldLanguageVariant" type="submit" class="el_button_input" value="<%=model.AddHandheldLanguageVariantLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionAddHandheldLanguageVariant')" />
            </div>
        </div>

    </form>
</body>
</html>