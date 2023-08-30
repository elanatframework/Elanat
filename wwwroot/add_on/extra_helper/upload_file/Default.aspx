<%@ Page Controller="Elanat.ExtraHelperUploadFileController" Model="Elanat.ExtraHelperUploadFileModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.UploadFileLanguage%></title>
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">
    <form id="frm_ExtraHelperUploadFile" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/upload_file/Default.aspx" enctype="multipart/form-data">

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
                <span class="el_checkbox_input"><input id="cbx_UseFilePath" name="cbx_UseFilePath" type="checkbox" /><label for="cbx_UseFilePath"><%=model.UseFilePathLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="txt_FilePath" name="txt_FilePath" type="text" value="<%=model.FilePathTextValue%>" class="el_long_text_input el_foreign_path" />
            </div>
            <div class="el_item">
                <input id="btn_StartUpload" name="btn_StartUpload" type="submit" class="el_button_input" value="<%=model.StartUploadLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ExtraHelperUploadFile')" />
            </div>
        </div>

    </form>
</body>
</html>