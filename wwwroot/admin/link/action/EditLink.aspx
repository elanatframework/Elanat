<%@ Page Controller="Elanat.ActionEditLinkController" Model="Elanat.ActionEditLinkModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditLinkLanguage%></title>
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
    <form id="frm_ActionEditLink" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/link/action/EditLink.aspx">

        <div class="el_part_row">
            <div id="div_EditLinkTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditLinkLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.LinkValueLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_LinkValue" name="txt_LinkValue" type="text" value="<%=model.LinkValueValue%>" class="el_text_input<%=model.LinkValueCssClass%>" <%=model.LinkValueAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LinkTitleLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_LinkTitle" name="txt_LinkTitle" type="text" value="<%=model.LinkTitleValue%>" class="el_long_text_input<%=model.LinkTitleCssClass%>" <%=model.LinkTitleAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LinkHrefLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_LinkHref" name="txt_LinkHref" type="text" value="<%=model.LinkHrefValue%>" class="el_long_text_input el_left_to_right<%=model.LinkHrefCssClass%>" <%=model.LinkHrefAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LinkRelLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_LinkRel" name="txt_LinkRel" type="text" value="<%=model.LinkRelValue%>" class="el_text_input<%=model.LinkRelCssClass%>" <%=model.LinkRelAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LinkProtocolLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_LinkProtocol" name="ddlst_LinkProtocol" class="el_alone_select_input<%=model.LinkProtocolCssClass%>" <%=model.LinkProtocolAttribute%>><%=model.LinkProtocolOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.LinkTargetLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_LinkTarget" name="ddlst_LinkTarget" class="el_alone_select_input<%=model.LinkTargetCssClass%>" <%=model.LinkTargetAttribute%>><%=model.LinkTargetOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_LinkActive" name="cbx_LinkActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.LinkActiveValue)%> /><label for="cbx_LinkActive"><%=model.LinkActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.LinkSortIndexLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_LinkSortIndex" name="txt_LinkSortIndex" type="number" value="<%=model.LinkSortIndexValue%>" class="el_text_input<%=model.LinkSortIndexCssClass%>" <%=model.LinkSortIndexAttribute%> />
            </div>
            <div class="el_item">
                <%=model.LinkMenuLanguage%>
            </div>
            <div class="el_item">
                <%=model.LinkMenuTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveLink" name="btn_SaveLink" type="submit" class="el_button_input" value="<%=model.SaveLinkLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditLink')" />
            </div>
        </div>

        <input id="hdn_LinkId" name="hdn_LinkId" type="hidden" value="<%=model.LinkIdValue%>" />

    </form>
</body>
</html>