<%@ Page Controller="Elanat.ActionChangeFilePermissionsController" Model="Elanat.ActionChangeFilePermissionsModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ChangeFilePermissionsLanguage%></title>
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
    <form id="frm_ActionChangeFilePermissions" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/file_manager/action/change_file_permissions/ChangeFilePermissions.aspx">

        <div class="el_part_row">
            <div id="div_EditFilePermissionsTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditFilePermissionsLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.FileNameLanguage%>
            </div>
            <div class="el_item">
                <%=model.FileNameValue%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_FullControl" name="cbx_FullControl" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.FullControlValue)%> /><label for="cbx_FullControl"><%=model.FullControlLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_Read" name="cbx_Read" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ReadValue)%> /><label for="cbx_Read"><%=model.ReadLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_Write" name="cbx_Write" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.WriteValue)%> /><label for="cbx_Write"><%=model.WriteLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_AppendData" name="cbx_AppendData" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AppendDataValue)%> /><label for="cbx_AppendData"><%=model.AppendDataLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ChangePermissions" name="cbx_ChangePermissions" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ChangePermissionsValue)%> /><label for="cbx_ChangePermissions"><%=model.ChangePermissionsLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_Delete" name="cbx_Delete" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.DeleteValue)%> /><label for="cbx_Delete"><%=model.DeleteLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ExecuteFile" name="cbx_ExecuteFile" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExecuteFileValue)%> /><label for="cbx_ExecuteFile"><%=model.ExecuteFileLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_Modify" name="cbx_Modify" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModifyValue)%> /><label for="cbx_Modify"><%=model.ModifyLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ReadAndExecute" name="cbx_ReadAndExecute" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ReadAndExecuteValue)%> /><label for="cbx_ReadAndExecute"><%=model.ReadAndExecuteLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ReadAttributes" name="cbx_ReadAttributes" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ReadAttributesValue)%> /><label for="cbx_ReadAttributes"><%=model.ReadAttributesLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ReadData" name="cbx_ReadData" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ReadDataValue)%> /><label for="cbx_ReadData"><%=model.ReadDataLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ReadExtendedAttributes" name="cbx_ReadExtendedAttributes" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ReadExtendedAttributesValue)%> /><label for="cbx_ReadExtendedAttributes"><%=model.ReadExtendedAttributesLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ReadPermissions" name="cbx_ReadPermissions" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ReadPermissionsValue)%> /><label for="cbx_ReadPermissions"><%=model.ReadPermissionsLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_TakeOwnership" name="cbx_TakeOwnership" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.TakeOwnershipValue)%> /><label for="cbx_TakeOwnership"><%=model.TakeOwnershipLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_WriteAttributes" name="cbx_WriteAttributes" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.WriteAttributesValue)%> /><label for="cbx_WriteAttributes"><%=model.WriteAttributesLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_WriteData" name="cbx_WriteData" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.WriteDataValue)%> /><label for="cbx_WriteData"><%=model.WriteDataLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_WriteExtendedAttributes" name="cbx_WriteExtendedAttributes" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.WriteExtendedAttributesValue)%> /><label for="cbx_WriteExtendedAttributes"><%=model.WriteExtendedAttributesLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveFilePermissions" name="btn_SaveFilePermissions" type="submit" class="el_button_input" value="<%=model.SaveFilePermissionsLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionChangeFilePermissions')" />
            </div>
        </div>

        <input id="hdn_FilePath" name="hdn_FilePath" type="hidden" value="<%=model.FilePathValue%>" />
        <input id="hdn_FileName" name="hdn_FileName" type="hidden" value="<%=model.FileNameValue%>" />

    </form>
</body>
</html>