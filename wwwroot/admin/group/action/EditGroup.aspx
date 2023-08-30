<%@ Page Controller="Elanat.ActionEditGroupController" Model="Elanat.ActionEditGroupModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditGroupLanguage%></title>
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
    <form id="frm_ActionEditGroup" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/group/action/EditGroup.aspx">

        <div class="el_part_row">
            <div id="div_EditGroupTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditGroupLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.GroupNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_GroupName" name="txt_GroupName" type="text" value="<%=model.GroupNameValue%>" class="el_text_input<%=model.GroupNameCssClass%>" <%=model.GroupNameAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_GroupActive" name="cbx_GroupActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GroupActiveValue)%> /><label for="cbx_GroupActive"><%=model.GroupActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.GroupRoleLanguage%>
            </div>
            <div class="el_item">
                <%=model.GroupRoleTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveGroup" name="btn_SaveGroup" type="submit" class="el_button_input" value="<%=model.SaveGroupLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditGroup')" />
            </div>
        </div>

        <input id="hdn_GroupId" name="hdn_GroupId" type="hidden" value="<%=model.GroupIdValue%>" />

    </form>
</body>
</html>
