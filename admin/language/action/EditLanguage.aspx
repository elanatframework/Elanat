<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditLanguage.aspx.cs" Inherits="elanat.ActionEditLanguage" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditLanguageLanguage%>l></title>
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
    <form id="frm_ActionEditLanguage" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/language/action/EditLanguage.aspx">

        <div class="el_part_row">
            <div id="div_EditLanguageTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditLanguageLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_LanguageActive" name="cbx_LanguageActive" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.LanguageActiveValue)%> /><label for="cbx_LanguageIsActive"><%=model.LanguageActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ShowLinkInSite" name="cbx_ShowLinkInSite" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowLinkInSiteValue)%> /><label for="cbx_ShowLinkInSite"><%=model.ShowLinkInSiteLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.LanguageDefaultSiteLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_LanguageDefaultSite" name="ddlst_LanguageDefaultSite" class="el_alone_select_input<%=model.LanguageDefaultSiteCssClass%>" <%=model.LanguageDefaultSiteAttribute%>><%=model.LanguageDefaultSiteOptionListValue%></select>
            </div>
            <div class="el_item">
                <input id="btn_SaveLanguage" name="btn_SaveLanguage" type="submit" class="el_button_input" value="<%=model.SaveLanguageLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionEditLanguage')" />
            </div>
        </div>

        <input id="hdn_LanguageId" name="hdn_LanguageId" type="hidden" value="<%=model.LanguageIdValue%>" />

    </form>
</body>
</html>