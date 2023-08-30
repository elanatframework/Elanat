<%@ Page Controller="Elanat.AdminRoleController" Model="Elanat.AdminRoleModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.RoleLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/role/script/role.js"></script>
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
        <%=model.RoleLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_role" onclick="el_ShowHideSection(this, 'div_AddRole'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddRole" class="el_hidden">

        <form id="frm_AdminRole" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/role/Default.aspx">

            <div class="el_part_row">
                <div id="div_AddRoleTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddRoleLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.RoleNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_RoleName" name="txt_RoleName" type="text" value="<%=model.RoleNameValue%>" class="el_text_input<%=model.RoleNameCssClass%>" <%=model.RoleNameAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.RoleTypeLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_RoleType" name="ddlst_RoleType" class="el_alone_select_input<%=model.RoleTypeCssClass%>" <%=model.RoleTypeAttribute%>><%=model.RoleTypeOptionListValue%></select>
                </div>
                <div class="el_item">
                    <%=model.RoleBitColumnAccessLanguage%>
                </div>
                <div class="el_item">
                    <%=model.RoleBitColumnAccessTemplateValue%>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_RoleActive" name="cbx_RoleActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.RoleActiveValue)%> /><label for="cbx_RoleActive"><%=model.RoleActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="btn_AddRole" name="btn_AddRole" type="submit" class="el_button_input" value="<%=model.AddRoleLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminRole')" />
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
