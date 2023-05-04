<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMenu.aspx.cs" Inherits="elanat.ActionEditMenu" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditMenuLanguage%><</title>
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
    <form id="frm_ActionEditMenu" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/menu/action/EditMenu.aspx">

        <div class="el_part_row">
            <div id="div_EditMenuTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditMenuLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.MenuNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_MenuName" name="txt_MenuName" type="text" value="<%=model.MenuNameValue%>" class="el_text_input<%=model.MenuNameCssClass%>" <%=model.MenuNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MenuLocationLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_MenuLocation" name="ddlst_MenuLocation" class="el_alone_select_input<%=model.MenuLocationCssClass%>" <%=model.MenuLocationAttribute%>><%=model.MenuLocationOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.MenuSiteLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_MenuSite" name="ddlst_MenuSite" class="el_alone_select_input<%=model.MenuSiteCssClass%>" <%=model.MenuSiteAttribute%>><%=model.MenuSiteOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_MenuUseBox" name="cbx_MenuUseBox" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.MenuUseBoxValue)%> /><label for="cbx_MenuUseBox"><%=model.MenuUseBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_MenuActive" name="cbx_MenuActive" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.MenuActiveValue)%> /><label for="cbx_MenuActive"><%=model.MenuActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.MenuSortIndexLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_MenuSortIndex" name="txt_MenuSortIndex" type="number" value="<%=model.MenuSortIndexValue%>" class="el_text_input<%=model.MenuSortIndexCssClass%>" <%=model.MenuSortIndexAttribute%> />
            </div>
            <div class="el_item">
                <%=model.MenuAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_MenuPublicAccessShow" name="cbx_MenuPublicAccessShow" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.MenuPublicAccessShowValue)%> /><label for="cbx_MenuPublicAccessShow"><%=model.MenuPublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.MenuAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveMenu" name="btn_SaveMenu" type="submit" class="el_button_input" value="<%=model.SaveMenuLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionEditMenu')" />
            </div>
        </div>

        <input id="hdn_MenuId" name="hdn_MenuId" type="hidden" value="<%=model.MenuIdValue%>" />

    </form>
</body>
</html>