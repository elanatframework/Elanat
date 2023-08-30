<%@ Page Controller="Elanat.ActionAddLanguageVariantController" Model="Elanat.ActionAddLanguageVariantModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title></title>
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
    <form id="frm_ActionAddLanguageVariant" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/language/action/add_language_variant/AddLanguageVariant.aspx" >

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
                <input id="btn_AddLanguageVariant" name="btn_AddLanguageVariant" type="submit" class="el_button_input" value="<%=model.AddLanguageVariantLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionAddLanguageVariant')" />
            </div>
        </div>

    </form>
</body>
</html>