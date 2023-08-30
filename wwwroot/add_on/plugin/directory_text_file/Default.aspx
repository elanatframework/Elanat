<%@ Page Controller="Elanat.PluginDirectoryTextFileController" Model="Elanat.PluginDirectoryTextFileModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.DirectoryTextFileLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/plugin/directory_text_file/script/directory_text_file.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/plugin/directory_text_file/style/directory_text_file.css" />
    <!-- Start Client Variant -->	
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <%=Elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <%=Elanat.AspxHtmlValue.CurrentBoxTag()%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />


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
<body id="Body" onload="el_PartPageLoad();el_SetCodeMirror('<%=model.FilePathValue%>', '<%=model.MimeTypeValue%>');">
        
    <div class="el_head">
        <%=model.DirectoryTextFileLanguage%>
    </div>

    <form id="frm_PluginDirectoryTextFile" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/plugin/directory_text_file/Default.aspx" >

        <div id="pnl_ShowFileListMode" class="<%=model.ShowFileListModeClass%>">
            <div class="el_part_row">
                <div id="div_FileList" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.FileListLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item el_left_to_right">
                    <%=model.DirectoryTextFileValue%>
                </div>
            </div>
        </div>

        <div id="pnl_EditFileMode" class="<%=model.EditFileModeClass%>">
            <div class="el_part_row">
                <div class="el_item">
                    <div class="el_box_text_value">
						<div class="el_text"><%=model.FileNameLanguage%>:</div>
						<div class="el_side_value"><%=model.FileNameValue%></div>
					</div>
                    <div class="el_box_text_value">
						<div class="el_text"><%=model.FilePathLanguage%>:</div>
						<div class="el_side_value"><%=model.FilePathValue%></div>
					</div>
                    <div class="el_box_text_value">
						<div class="el_text"><%=model.FileSizeLanguage%>:</div>
						<div class="el_side_value"><%=model.FileSizeValue%></div>
					</div>
                    <div class="el_box_text_value">
						<div class="el_text"><%=model.LastAccessLanguage%>:</div>
						<div class="el_side_value"><%=model.LastAccessValue%></div>
					</div>
                    <div class="el_box_text_value">
						<div class="el_text"><%=model.LastModifyLanguage%>:</div>
						<div class="el_side_value"><%=model.LastModifyValue%></div>
					</div>
                </div>
                <div class="el_item el_left_to_right">
                    <div id="div_FileTextBox">
                        <textarea id="txt_FileText" name="txt_FileText" class="el_textarea_input"></textarea>
                    </div>
                </div>
                <div class="el_item">
                    <input id="btn_SaveFile" name="btn_SaveFile" type="submit" class="el_button_input" value="<%=model.SaveFileLanguage%>" onclick="el_SetTextAreaValue('txt_FileText');el_AjaxPostBack(this, false, 'frm_PluginDirectoryTextFile')" />
                    <input id="btn_Return" name="btn_Return" type="submit" class="el_button_input" value="<%=model.ReturnLanguage%>" onclick="el_DeleteInnerValue('Body');el_AjaxPostBack(this)" />
                </div>
                <input id="hdn_DirectoryPath" name="hdn_DirectoryPath" type="hidden" value="<%=model.DirectoryPathValue%>" />
                <input id="hdn_FilePath" name="hdn_FilePath" type="hidden" value="<%=model.FilePathValue%>" />
            </div>
        </div>

    </form>    
        
    <script>
        var editor;
    </script>

</body>
</html>
