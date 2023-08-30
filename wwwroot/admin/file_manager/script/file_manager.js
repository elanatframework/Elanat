function el_EditFileDirectory(FileDirectoryPath, FileDirectoryName, FileDirectoryType)
{
	var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_EditFileDirectoryName_" + FileDirectoryName;
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");

    if (FileDirectoryType == "directory")
        IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/file_manager/action/edit_directory/EditDirectory.aspx?directory_path=" + FileDirectoryPath + "&directory_name=" + FileDirectoryName);
    else
        IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/file_manager/action/edit_file/EditFile.aspx?file_path=" + FileDirectoryPath + "&file_name=" + FileDirectoryName + "&file_type=" + FileDirectoryType);

    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

function el_SetPermissions(FileDirectoryPath, FileDirectoryName, FileDirectoryType)
{
	var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_SetPermissionsDirectoryName_" + FileDirectoryName;
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");

    if (FileDirectoryType == "directory")
        IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/file_manager/action/change_directory_permissions/ChangeDirectoryPermissions.aspx?directory_path=" + FileDirectoryPath + "&directory_name=" + FileDirectoryName);
    else
        IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/file_manager/action/change_file_permissions/ChangeFilePermissions.aspx?file_path=" + FileDirectoryPath + "&file_name=" + FileDirectoryName);

    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

async function el_DeleteFileDirectory(obj, FileType, FilePath)
{
	var OkClick = await el_Confirm(FileLanguageVariant.Delete);
    if (OkClick)
    {
        var xmlhttp = (window.XMLHttpRequest)? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        if (FileType != "directory")
            FileType = "file";

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_RemoveParentNode(obj);

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/DeleteFileDirectory.aspx?" + FileType + "_path=" + FilePath, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteSelectedFileDirectory()
{
	var OkClick = await el_Confirm(FileLanguageVariant.Delete);
    if (OkClick)
    {
        var ArrayFileId = new Array();
        var ArrayFileType = new Array();
        var ArrayFilePath = new Array();
        var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
        var i = 0;
        var ia = 0;
        while (i < CheckBoxItemLength) 
        {
            var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];

            if (CheckBoxItem.checked) 
            {
                ArrayFileId[ia] = CheckBoxItem.id;
                ArrayFileType[ia] = (CheckBoxItem.getAttribute("file_type") == "directory")? "directory" : "file";
                ArrayFilePath[ia] = CheckBoxItem.getAttribute("file_path");

                ia++;
            }
            i++;
        }

        var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        var i = 0;
        while (i < ArrayFileId.length)
        {
            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                    el_RemoveParentNode(document.getElementById(ArrayFileId[i]));

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }

            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/DeleteFileDirectory.aspx?" + ArrayFileType[i] + "_path=" + ArrayFilePath[i], false);
            xmlhttp.send();

            i++;
        }
    }
    else
	    return false;
}

function el_SelectAllItem(obj)
{
	var CheckCheckedUnchecked = null;
    if (obj.checked)
        CheckCheckedUnchecked = "cheched";

    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        CheckBoxItem.checked = CheckCheckedUnchecked;
        i++;
    }
}

function el_SearchFileDirectory(CurrentPath)
{
	var SearchValue = document.getElementById("txt_Search").value;
    if (SearchValue != "")
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
			{
                var SearchBox = document.getElementById("div_TableBox");
                SearchBox.innerHTML = xmlhttp.responseText;
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/GetFileDirectoryList.aspx?search=" + SearchValue + "&directory=" + CurrentPath, false);
        xmlhttp.send();
    }
}

function el_SortFileDirectory(ColumnName, SearchedItem, CurrentPath, IsDesc)
{
	var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function () 
	{
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
		{
            var SearchBox = document.getElementById("div_TableBox");
            SearchBox.innerHTML = xmlhttp.responseText;
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }
	
    var SortType = (IsDesc) ? "true" : "false";

    var SearchValue = (SearchedItem != "$_searched_item;")? "&search=" + SearchedItem : "";

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/GetFileDirectoryList.aspx?column_name=" + ColumnName + "&directory=" + CurrentPath + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}

function el_DownloadFile(FileName, FilePath)
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_DownloadFile_" + FileName;
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/file_manager/action/DownloadFile.aspx?file_path=" + FilePath);
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
}

function el_DownloadSelectedFile()
{
	var ArrayFileId = new Array();
	var ArrayFilePath = new Array();
	var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
	var i = 0;
	var ia = 0;
	while (i < CheckBoxItemLength) 
	{
		var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
		if (CheckBoxItem.checked)
		{
			ArrayFileId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
			ArrayFilePath[ia] = CheckBoxItem.getAttribute("file_path");
			ia++;
		}
		i++;
	}

	var i = 0;
	while (i < ArrayFileId.length)
	{
		el_DownloadFile(ArrayFileId[i], ArrayFilePath[i]);
		i++;
	}
}

async function el_ZipSelectedFileDirectory()
{
	var OkClick = await el_Confirm(FileLanguageVariant.Zip);
	if (OkClick)
	{
		var ArrayFilePath = new Array();
		var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
		var i = 0;
		var ia = 0;
		while (i < CheckBoxItemLength)
		{
			var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];

			if (CheckBoxItem.checked)
			{
				ArrayFilePath[ia] = CheckBoxItem.getAttribute("file_path");

				if (CheckBoxItem.getAttribute("file_type") == "directory")
					ArrayFilePath[ia] += "/";

				ia++;
			}
			i++;
		}

		var ZipPath = document.getElementById("hdn_PathHidden").value;
		if (ZipPath == '/')
			ZipPath = '';

		var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

		xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/ZipFileDirectory.aspx?file_directory_path=" + ArrayFilePath.join("$") + '&zip_path=' + ZipPath + '/new_zip.zip', false);
		xmlhttp.send();
	}
	else
	    return false;
}

async function el_UnZipSelectedFileDirectory()
{
	var OkClick = await el_Confirm(FileLanguageVariant.UnZip);
	if (OkClick)
	{
		var ArrayZipFilePath = new Array();
		var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
		var i = 0;
		var ia = 0;

		while (i < CheckBoxItemLength)
		{
			var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];

			if (CheckBoxItem.checked)
			{
				ArrayZipFilePath[ia] = CheckBoxItem.getAttribute("file_path");

				ia++;
			}
			i++;
		}

		var UseOverwriteExtractExistingFile = await el_Confirm(FileLanguageVariant.UseOverwriteExtractExistingFile)? "true" : "false";

		var i = 0;
		while (i < ArrayZipFilePath.length)
		{
			var UnZipPath = document.getElementById("hdn_PathHidden").value;

			var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

			xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/UnZipFileDirectory.aspx?zip_path=" + ArrayZipFilePath[i] + '&un_zip_path=' + UnZipPath + '&use_overwrite_extract_existing_file=' + UseOverwriteExtractExistingFile, false);
			xmlhttp.send();

			i++;
		}
	}
	else
	    return false;
}

async function el_CutSelectedFileDirectory()
{
	var OkClick = await el_Confirm(FileLanguageVariant.Cut);
	if (OkClick)
	{
		var ArrayFileDirectoryPath = new Array();
		var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
		var i = 0;
		var ia = 0;
		while (i < CheckBoxItemLength)
		{
			var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];

			if (CheckBoxItem.checked)
			{
				ArrayFileDirectoryPath[ia] = CheckBoxItem.getAttribute("file_path");

				if (CheckBoxItem.getAttribute("file_type") == "directory")
					ArrayFileDirectoryPath[ia] += "/";

				ia++;
			}
			i++;
		}

		var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

		xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/CutFileDirectory.aspx?file_directory_path=" + ArrayFileDirectoryPath.join("$"), false);
		xmlhttp.send();
	}
	else
	    return false;
}

async function el_CopySelectedFileDirectory()
{
	var OkClick = await el_Confirm(FileLanguageVariant.Copy);
	if (OkClick)
	{
		var ArrayFileDirectoryPath = new Array();
		var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
		var i = 0;
		var ia = 0;
		while (i < CheckBoxItemLength)
		{
			var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];

			if (CheckBoxItem.checked)
			{
				ArrayFileDirectoryPath[ia] = CheckBoxItem.getAttribute("file_path");

				if (CheckBoxItem.getAttribute("file_type") == "directory")
					ArrayFileDirectoryPath[ia] += "/";

				ia++;
			}
			i++;
		}

		var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

		xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/CopyFileDirectory.aspx?file_directory_path=" + ArrayFileDirectoryPath.join("$"), false);
		xmlhttp.send();
	}
	else
	    return false;
}

async function el_PasteSelectedFileDirectory()
{
	var OkClick = await el_Confirm(FileLanguageVariant.Paste);
	if (OkClick)
	{
		var DirectoryPath = document.getElementById("hdn_PathHidden").value;

		var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

		xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/PasteFileDirectory.aspx?directory_path=" + DirectoryPath, false);
		xmlhttp.send();
	}
	else
	    return false;
}

function el_ViewFileDirectory(FileDirectoryName, FileDirectoryPath)
{
	if (!document.getElementById("div_FileDirectoryViewMore" + FileDirectoryName))
	{
		var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

		xmlhttp.onreadystatechange = function ()
		{
		    if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
			{
				var DivTag = document.createElement("div");
				DivTag.id = "div_FileDirectoryViewMore" + FileDirectoryName;
				DivTag.className = "el_hidden";
				DivTag.innerHTML = xmlhttp.responseText;
				document.body.appendChild(DivTag);
				el_OpenBox(DivTag.id);
			}

			if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
			{
				el_Alert(LanguageVariant.ConnectionError, "problem");
			}
		}
		
		xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/GetFileDirectoryViewMore.aspx?file_directory_path=" + FileDirectoryPath, false);
		xmlhttp.send();
	}
	else
		el_OpenBox("div_LinkViewMore" + LinkId);
}

function el_OpenFileDirectory(Type, Name, Path)
{
	if (Type == "directory")
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
	    {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
		    {
                var TableBox = document.getElementById("div_TableBox");
                TableBox.innerHTML = xmlhttp.responseText;

                document.getElementById("txt_Path").value = Path;
                document.getElementsByClassName("el_directory_path").item(0).innerHTML = "";


                // Set Hidden Input Value
                var PathHiddenList = document.getElementsByClassName("el_path_hidden");
                var PathHiddenListCount = PathHiddenList.length;

                for (var i = 0; i < PathHiddenListCount; i++)
                {
                    document.getElementsByClassName("el_path_hidden").item(i).value = Path;
                }


                el_SetIframeAutoHeight();


                // Set Hyperlink Directory Path
                var SubDirectoryList = Path.split("/");
                var SubDirectoryListCount = SubDirectoryList.length;
                var DirectoryPath = "";
                var PathHyperlinkValue = "<a href='#' onclick='el_OpenFileDirectory(&apos;directory&apos;,&apos;/&apos;,&apos;/&apos;)'>root</a>";
                for (var i = 0; i < SubDirectoryListCount; i++)
                {
                    if (SubDirectoryList[i] == "")
                        continue;

                    DirectoryPath += "/" + SubDirectoryList[i];
                    PathHyperlinkValue += "<div class='el_slash'>/</div>" + "<a href='#' onclick='el_OpenFileDirectory(&apos;directory&apos;,&apos;" + SubDirectoryList[i] + "&apos;,&apos;" + DirectoryPath + "&apos;)'>" + SubDirectoryList[i] + "</a>";
                }

                document.getElementsByClassName("el_directory_path").item(0).innerHTML = PathHyperlinkValue;
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/file_manager/action/GetFileDirectoryList.aspx?directory=" + Path, false);
        xmlhttp.send();
    }
    else
        el_ViewFile(Name, Path);
}

function el_GoToDirectoryPath()
{
	var Path = document.getElementById("txt_Path").value;
    el_OpenFileDirectory("directory", "", Path);
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