<%@ Page Controller="Elanat.AdminFileManagerController" Model="Elanat.AdminFileManagerModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.FileManagerLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/file_manager/script/file_manager.js"></script>
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
<body onload="el_CreateWysiwyg(); el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.FileManagerLanguage%>
    </div>
    <div class="el_button_box">
        <input id="btn_NewFile" type="button" value="<%=model.NewFileLanguage%>" el_action="new_file" onclick="el_ShowHideSection(this, 'div_CreateFile'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_NewDirectory" type="button" value="<%=model.NewDirectoryLanguage%>" el_action="new_directory" onclick="el_ShowHideSection(this, 'div_CreateDirectory'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_UploadFile" type="button" value="<%=model.UploadFileLanguage%>" class="el_upload" el_action="upload_file" onclick="el_ShowHideSection(this, 'div_UploadFile'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_UploadFile" class="el_hidden">

        <form id="frm_AdminFileManagerUploadFile" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/file_manager/Default.aspx?directory=<%=model.PathHiddenValue%>" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_UploadFileTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.UploadFileLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.FilePathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_FilePath" name="upd_FilePath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_UseFilePath" name="cbx_UseFilePath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseFilePathValue)%> /><label for="cbx_UseFilePath"><%=model.UseFilePathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_FilePath" name="txt_FilePath" value="<%=model.FilePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <input id="btn_StartUpload" name="btn_StartUpload" type="submit" class="el_button_input" value="<%=model.StartUploadLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminFileManagerUploadFile')" />
                </div>
            </div>

            <input name="hdn_PathHidden" type="hidden" class="el_path_hidden" value="<%=model.PathHiddenValue%>" />

        </form>

    </div>

    <div id="div_CreateDirectory" class="el_hidden">

        <form id="frm_AdminFileManagerCreateDirectory" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/file_manager/Default.aspx?directory=<%=model.PathHiddenValue%>">

            <div class="el_part_row">
                <div id="div_CreateDirectoryTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.CreateDirectoryLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.DirectoryNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_DirectoryName" name="txt_DirectoryName" type="text" value="<%=model.DirectoryNameValue%>" class="el_text_input<%=model.DirectoryNameCssClass%>" <%=model.DirectoryNameAttribute%> />
                </div>
                <div class="el_item">
                    <input id="btn_CreateDirectory" name="btn_CreateDirectory" type="submit" class="el_button_input" value="<%=model.CreateDirectoryLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminFileManagerCreateDirectory')" />
                </div>
            </div>

            <input name="hdn_PathHidden" type="hidden" class="el_path_hidden" value="<%=model.PathHiddenValue%>" />

        </form>

    </div>

    <div id="div_CreateFile" class="el_hidden">

        <form id="frm_AdminFileManagerCreateFile" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/file_manager/Default.aspx?directory=<%=model.PathHiddenValue%>" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_CreateFileTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.CreateFileLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.FileNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_FileName" name="txt_FileName" type="text" value="<%=model.FileNameValue%>" class="el_text_input<%=model.FileNameCssClass%>" <%=model.FileNameAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.FileTextLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_FileText" name="txt_FileText" class="el_textarea_input<%=model.FileTextCssClass%>" <%=model.FileTextAttribute%>><%=model.FileTextValue%></textarea>
                </div>
                <div class="el_item">
                    <input id="btn_CreateFile" name="btn_CreateFile" type="submit" class="el_button_input" value="<%=model.CreateFileLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminFileManagerCreateFile')" />
                </div>
            </div>

            <input name="hdn_PathHidden" type="hidden" class="el_path_hidden" value="<%=model.PathHiddenValue%>" />

        </form>

    </div>

    <div class="el_part_row">
        <div id="div_FileManagerTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
            <%=model.FileManagerLanguage%>
            <div class="el_dash"></div>
        </div>
        <div class="el_item">
            <%=model.PathLanguage%>
        </div>
        <div class="el_item">
            <input id="txt_Path" name="txt_Path" type="text" value="<%=model.PathHiddenValue%>" class="el_long_text_input el_foreign_path" />
            <input id="hdn_PathHidden" name="hdn_PathHidden" type="hidden" class="el_path_hidden" value="<%=model.PathHiddenValue%>" />
            <input type="button" id="btn_GoToPath" class="el_button_input" onclick="el_GoToDirectoryPath()" value="→" />
        </div>
        <div class="el_item">
            <div class="el_directory_path">
                <%=model.PathValue%>
            </div>
        </div>
    </div>

    <div class="el_part_row">
        <div id="div_TableBox" class="el_item">
            <%=model.ContentValue%>
        </div>
    </div>

</body>
</html>