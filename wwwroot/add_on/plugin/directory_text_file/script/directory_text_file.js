function el_OpenTextFile(FilePath)
{
    var DirectoryPath = document.getElementById("hdn_DirectoryPath").value;
    location.href = "?file_path=" + DirectoryPath + FilePath + "&current_add_on_path=" + DirectoryPath;
}

function el_SetTextAreaValue(TextareaId)
{
    var text = editor.getValue();

    document.getElementById(TextareaId).setAttribute("name", TextareaId);
    document.getElementById(TextareaId).value = text;
}

function el_SetCodeMirror(TextFilePath, MimeType)
{
    while(document.getElementById("div_FileTextBox").getElementsByClassName("CodeMirror").item(0))
        document.getElementById("div_FileTextBox").getElementsByClassName("CodeMirror").item(0).outerHTML = null;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function () 
	{
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "")
        {
            document.getElementById("txt_FileText").innerHTML = xmlhttp.responseText;
            
            editor = CodeMirror.fromTextArea(document.getElementById("txt_FileText"), { lineNumbers: true, matchBrackets: true, lineWrapping: true, mode: MimeType, });
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }
		
    xmlhttp.open("GET", ElanatVariant.SitePath + "add_on/plugin/directory_text_file/action/DirectoryTextFileSetCodeHighlighter.aspx?text_file_path=" + TextFilePath, false);
    xmlhttp.send();
}