<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFile.aspx.cs" Inherits="elanat.ActionEditFile" validateRequest="false" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditFileLanguage%></title>
    <script src="<%=elanat.AspxHtmlValue.AdminPath()%>/file_manager/script/file_manager.js"></script>
    <!-- Start Client Variant -->
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant"></script>
    <!-- End Client Variant -->	
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=elanat.AspxHtmlValue.CurrentBoxTag()%>

    <!-- Start Code Highlighter -->	
    <link rel="stylesheet" href="/include/code_highlighter/codemirror-5.4/lib/codemirror.css" />
    <script src="/include/code_highlighter/codemirror-5.4/lib/codemirror.js"></script>

    <script src="/include/code_highlighter/codemirror-5.4/mode/javascript/javascript.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/htmlembedded/htmlembedded.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/xml/xml.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/css/css.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/php/php.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/perl/perl.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/python/python.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/ruby/ruby.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/htmlmixed/htmlmixed.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/addon/comment/comment.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/addon/comment/continuecomment.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/addon/mode/multiplex.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/addon/edit/matchbrackets.js"></script>
    <!-- End Code Highlighter -->	
</head>
<body onload="el_PartPageLoad();el_SetCodeMirror('<%=model.OldFilePathValue%>', '<%=model.MimeTypeValue%>');">
    <form id="frm_ActionEditFile" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/file_manager/action/edit_file/EditFile.aspx">

        <div class="el_part_row">
            <div id="div_EditFileTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditFileLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.FileNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_FileName" name="txt_FileName" type="text" value="<%=model.FileNameValue%>" class="el_text_input<%=model.FileNameCssClass%>" <%=model.FileNameAttribute%> />
            </div>
            <div id="div_FileTextPanel" class="<%=model.FileTextPanelCssClass%>">
                <div class="el_item">
                    <%=model.FileTextLanguage%>
                </div>
                <div class="el_item el_left_to_right">
                    <div id="div_FileTextBox">
                        <textarea id="txt_FileText" name="txt_FileText" class="el_textarea_input<%=model.FileTextCssClass%>" <%=model.FileTextAttribute%>></textarea>
                    </div>
                </div>
            </div>
            <div class="el_item">
                <input id="btn_SaveFile" name="btn_SaveFile" type="submit" class="el_button_input" value="<%=model.SaveFileLanguage%>" onclick="el_SetTextAreaValue('txt_FileText');el_AjaxPostBack(this, false, 'frm_ActionEditFile')" />
            </div>
        </div>

        <input id="hdn_FilePath" name="hdn_FilePath" type="hidden" value="<%=model.OldFilePathValue%>" />
        <input id="hdn_FileName" name="hdn_FileName" type="hidden" value="<%=model.OldFileNameValue%>" />
        <input id="hdn_FileType" name="hdn_FileType" type="hidden" value="<%=model.FileTypeValue%>" />
        <input id="hdn_MimeType" name="hdn_MimeType" type="hidden" value="<%=model.MimeTypeValue%>" />

    </form>

    <script>
        var editor;
    </script>

</body>
</html>