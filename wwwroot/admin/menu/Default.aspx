<%@ Page Controller="Elanat.AdminMenuController" Model="Elanat.AdminMenuModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.MenuLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/menu/script/menu.js"></script>
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
<body onload="el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.MenuLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_menu" onclick="el_ShowHideSection(this, 'div_AddMenu'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddMenu" class="el_hidden">

        <form id="frm_AdminMenu" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/menu/Default.aspx">

            <div class="el_part_row">
                <div id="div_AddMenuTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddMenuLanguage%>
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
                    <span class="el_checkbox_input">
                        <input id="cbx_MenuUseBox" name="cbx_MenuUseBox" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.MenuUseBoxValue)%> /><label for="cbx_MenuUseBox"><%=model.MenuUseBoxLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_MenuActive" name="cbx_MenuActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.MenuActiveValue)%> /><label for="cbx_MenuActive"><%=model.MenuActiveLanguage%></label></span>
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
                    <span class="el_checkbox_input">
                        <input id="cbx_MenuPublicAccessShow" name="cbx_MenuPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.MenuPublicAccessShowValue)%> /><label for="cbx_MenuPublicAccessShow"><%=model.MenuPublicAccessShowLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.MenuAccessShowTemplateValue%>
                </div>
                <div class="el_item">
                    <input id="btn_AddMenu" name="btn_AddMenu" type="submit" class="el_button_input" value="<%=model.AddMenuLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminMenu')" />
                </div>
            </div>

        </form>

    </div>

    <div class="el_part_row">
        <div id="div_TableBox" class="el_item">
            <%=model.ContentValue%>
        </div>
    </div>

</body>
</html>