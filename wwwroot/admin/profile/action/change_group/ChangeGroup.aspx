<%@ Page Controller="Elanat.ActionChangeGroupController" Model="Elanat.ActionChangeGroupModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.GroupLanguage%></title>
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
        <%=model.GroupLanguage%>
    </div>

    <form id="frm_ActionChangeGroup" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_group/ChangeGroup.aspx">

        <div class="el_part_row">
            <div id="div_ChangeGroupTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeGroupLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserGroupLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserGroup" name="ddlst_UserGroup" class="el_alone_select_input<%=model.UserGroupCssClass%>" <%=model.UserGroupAttribute%>>
                    <%=model.UserGroupOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <input id="btn_ChangeGroup" name="btn_ChangeGroup" type="submit" class="el_button_input" value="<%=model.ChangeGroupLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionChangeGroup')" />
            </div>
        </div>

    </form>

</body>
</html>