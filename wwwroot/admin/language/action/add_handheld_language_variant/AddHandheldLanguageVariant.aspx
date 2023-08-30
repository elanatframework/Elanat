<%@ Page Controller="Elanat.ActionAddHandheldLanguageVariantController" Model="Elanat.ActionAddHandheldLanguageVariantModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.AddHandheldLanguageVariantLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/language/script/language.js"></script>
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
    <form id="frm_ActionAddHandheldLanguageVariant" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/language/action/add_handheld_language_variant/AddHandheldLanguageVariant.aspx" >

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
                <input id="btn_AddHandheldLanguageVariant" name="btn_AddHandheldLanguageVariant" type="submit" class="el_button_input" value="<%=model.AddHandheldLanguageVariantLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionAddHandheldLanguageVariant')" />
            </div>
        </div>

    </form>
</body>
</html>