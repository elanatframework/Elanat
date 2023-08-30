function el_CodeMirrorIssues()
{
    var ConfigText = editor.getValue();

    document.getElementById("txt_Config").value = ConfigText;
}

function el_SetCodeMirror(obj, ConfigName, MimeType)
{
    document.getElementById("div_ConfigName").innerText = obj.value;

    while(document.getElementById("div_ConfigBox").getElementsByClassName("CodeMirror").item(0))
        document.getElementById("div_ConfigBox").getElementsByClassName("CodeMirror").item(0).outerHTML = null;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function () 
	{
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "")
        {
            document.getElementById("txt_Config").innerHTML = xmlhttp.responseText;
            
            editor = CodeMirror.fromTextArea(document.getElementById("txt_Config"), { lineNumbers: true, matchBrackets: true, lineWrapping: true, mode: MimeType, });

            editor.setValue(document.getElementById("txt_Config").innerText); 
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }
		
    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/configuration/action/ConfigurationSetConfig.aspx?config_name=" + ConfigName, false);
    xmlhttp.send();
}

function el_SetConfigCodeMirror(ConfigName)
{
    var TmpButton = document.createElement("input");
    TmpButton.value = ConfigName;
    TmpButton.setAttribute("onclick", "el_SetCodeMirror(this, 'config', 'text/xml')");
    TmpButton.click();
}
