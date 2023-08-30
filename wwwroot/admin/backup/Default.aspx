<%@ Page Controller="Elanat.AdminBackupController" Model="Elanat.AdminBackupModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.BackupLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/backup/script/backup.js"></script>
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
        <%=model.BackupLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_MakeBackupItem" type="button" value="<%=model.MakeBackupLanguage%>" class="el_add" el_action="make_backup" onclick="el_ShowHideSection(this, 'div_MakeBackupItem'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_UploadBackupItem" type="button" value="<%=model.UploadBackupLanguage%>" class="el_upload" el_action="upload_backup" onclick="el_ShowHideSection(this, 'div_UploadBackupItem'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_MakeBackupItem" class="el_hidden"">

        <form id="frm_AdminMakeBackup" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/backup/Default.aspx">

            <div class="el_part_row">
                <div id="div_MakeBackupTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.MakeBackupLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_DataBase" name="cbx_DataBase" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.DataBaseValue)%> /><label for="cbx_DataBase"><%=model.DataBaseLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_AllFileAndDirectory" name="cbx_AllFileAndDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AllFileAndDirectoryValue)%> /><label for="cbx_AllFileAndDirectory"><%=model.AllFileAndDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_ActionDirectory" name="cbx_ActionDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActionDirectoryValue)%> /><label for="cbx_ActionDirectory""><%=model.ActionDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_AdminDirectory" name="cbx_AdminDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AdminDirectoryValue)%> /><label for="cbx_AdminDirectory"><%=model.AdminDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_AddOnDirectory" name="cbx_AddOnDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AddOnDirectoryValue)%> /><label for="cbx_AddOnDirectory"><%=model.AddOnDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_AppDataDirectory" name="cbx_AppDataDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AppDataDirectoryValue)%> /><label for="cbx_AppDataDirectory"><%=model.AppDataDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_BinDirectory" name="cbx_BinDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.BinDirectoryValue)%> /><label for="cbx_BinDirectory""><%=model.BinDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_ClientDirectory" name="cbx_ClientDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ClientDirectoryValue)%> /><label for="cbx_ClientDirectory"><%=model.ClientDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_IncludeDirectory" name="cbx_IncludeDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.IncludeDirectoryValue)%> /><label for="cbx_IncludeDirectory"><%=model.IncludeDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_LanguageDirectory" name="cbx_LanguageDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.LanguageDirectoryValue)%> /><label for="cbx_LanguageDirectory"><%=model.LanguageDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_MemberDirectory" name="cbx_MemberDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.MemberDirectoryValue)%> /><label for="cbx_MemberDirectory"><%=model.MemberDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_PageDirectory" name="cbx_PageDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PageDirectoryValue)%> /><label for="cbx_PageDirectory"><%=model.PageDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_TemplateDirectory" name="cbx_TemplateDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.TemplateDirectoryValue)%> /><label for="cbx_TemplateDirectory"><%=model.TemplateDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_UploadDirectory" name="cbx_UploadDirectory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UploadDirectoryValue)%> /><label for="cbx_UploadDirectory"><%=model.UploadDirectoryLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_RobotsTxtFile" name="cbx_RobotsTxtFile" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.RobotsTxtFileValue)%> /><label for="cbx_RobotsTxtFile"><%=model.RobotsTxtFileLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="btn_StartBackup" name="btn_StartBackup" type="submit" class="el_button_input" value="<%=model.StartBackupLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminMakeBackup')" />
                </div>
            </div>

        </form>

    </div>

    <div id="div_UploadBackupItem" class="el_hidden">

        <form id="frm_AdminUploadBackup" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/backup/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_UploadBackupHead" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.UploadBackupLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.BackupPathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_BackupPath" name="upd_BackupPath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_UseBackupPath" name="cbx_UseBackupPath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseBackupPathValue)%> /><label for="cbx_UseBackupPath"><%=model.UseBackupPathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_BackupPath" name="txt_BackupPath" value="<%=model.BackupPathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <input id="btn_StartUpload" name="btn_StartUpload" type="submit" class="el_button_input" value="<%=model.StartUploadLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminUploadBackup')" />
                </div>
            </div>

        </form>

    </div>

    <div class="el_part_row">
        <div id="div_TableBox"  class="el_item">
            <%=model.ContentValue%>
        </div>
    </div>

</body>
</html>