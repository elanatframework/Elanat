<%@ Page Controller="Elanat.ActionEditDirectoryController" Model="Elanat.ActionEditDirectoryModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditDirectoryLanguage%></title>
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
    <form id="frm_ActionEditDirectory" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/file_manager/action/edit_directory/EditDirectory.aspx">
        <div class="el_part_row">
            <div id="div_EditDirectoryTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditDirectoryLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.DirectoryNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_DirectoryName" name="txt_DirectoryName" type="text" value="<%=model.DirectoryNameValue%>" class="el_text_input<%=model.DirectoryNameCssClass%>" <%=model.DirectoryNameAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_SaveDirectory" name="btn_SaveDirectory" type="submit" class="el_button_input" value="<%=model.SaveDirectoryLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditDirectory')" />
            </div>
        </div>

        <input id="hdn_DirectoryPath" name="hdn_DirectoryPath" type="hidden" value="<%=model.DirectoryPathValue%>" />
        <input id="hdn_DirectoryName" name="hdn_DirectoryName" type="hidden" value="<%=model.OldDirectoryNameValue%>" />

    </form>
</body>
</html>
