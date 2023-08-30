function el_EditPatchTextFile(PatchId, PatchPhysicalPath)
{
	var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_EditPatchTextFile_" + PatchId;
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
    IframeTag.setAttribute("src", ElanatVariant.SitePath + "add_on/plugin/directory_text_file/Default.aspx?directory_path=" + ElanatVariant.SitePath + "add_on/patch/" + PatchPhysicalPath + "/");
    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

async function el_ActivePatch(obj, PatchId)
{
	var OkClick = await el_Confirm(PatchLanguageVariant.Active);
    if (OkClick)
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetInactive(obj, "el_InactivePatch(this, '" + PatchId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/ActivePatch.aspx?patch_id=" + PatchId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_ActiveSelectedPatch()
{
	var ArrayPatchId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
    {
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
        {
            ArrayPatchId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(PatchLanguageVariant.Active);
    if (OkClick)
    {
        var ArrayPatchIdLength = ArrayPatchId.length;
        var i = 0;
        while (i < ArrayPatchIdLength)
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                {
                    if (document.getElementById("cbx_Item" + ArrayPatchId[i]).parentNode.getElementsByClassName("el_inactive")[0])
                    {
                        var RowItem = document.getElementById("cbx_Item" + ArrayPatchId[i]).parentNode.getElementsByClassName("el_inactive")[0];
                        el_SetInactive(RowItem, "el_InactivePatch(this, '" + ArrayPatchId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/ActivePatch.aspx?patch_id=" + ArrayPatchId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_InactivePatch(obj, PatchId)
{
	var OkClick = await el_Confirm(PatchLanguageVariant.InActive);
    if (OkClick)
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetActive(obj, "el_ActivePatch(this, '" + PatchId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/InactivePatch.aspx?patch_id=" + PatchId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_InactiveSelectedPatch()
{
	var ArrayPatchId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
    {
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
        {
            ArrayPatchId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(PatchLanguageVariant.InActive);
    if (OkClick)
    {
        var ArrayPatchIdLength = ArrayPatchId.length;
        var i = 0;
        while (i < ArrayPatchIdLength)
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                {
                    if (document.getElementById("cbx_Item" + ArrayPatchId[i]).parentNode.getElementsByClassName("el_active")[0])
                    {
                        var RowItem = document.getElementById("cbx_Item" + ArrayPatchId[i]).parentNode.getElementsByClassName("el_active")[0];
                        el_SetActive(RowItem, "el_ActivePatch(this, '" + ArrayPatchId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/InactivePatch.aspx?patch_id=" + ArrayPatchId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_DeletePatch(obj, PatchId)
{
	var OkClick = await el_Confirm(PatchLanguageVariant.Delete);
    if (OkClick)
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_RemoveParentNode(obj);

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/DeletePatch.aspx?patch_id=" + PatchId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteSelectedPatch()
{
	var ArrayPatchId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
    {
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
        {
            ArrayPatchId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(PatchLanguageVariant.Delete);
    if (OkClick)
    {
        var ArrayPatchIdLength = ArrayPatchId.length;
        var i = 0;
        while (i < ArrayPatchIdLength)
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                {
                    var RowItem = document.getElementById("cbx_Item" + ArrayPatchId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/DeletePatch.aspx?patch_id=" + ArrayPatchId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

function el_ViewPatch(PatchId)
{
	if (!document.getElementById("div_PatchViewMore" + PatchId))
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
            {
                var DivTag = document.createElement("div");
                DivTag.id = "div_PatchViewMore" + PatchId;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/GetPatchViewMore.aspx?patch_id=" + PatchId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_PatchViewMore" + PatchId);
}

function el_ViewPatchInformation(PatchDirectoryPath)
{
	if (!document.getElementById("div_ViewPatchInformation" + PatchDirectoryPath))
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
            {
                var DivTag = document.createElement("div");
                DivTag.id = "div_ViewPatchInformation" + PatchDirectoryPath;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/GetPatchInformation.aspx?patch_directory_path=" + PatchDirectoryPath, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_ViewPatchInformation" + PatchDirectoryPath);
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

function el_SearchPatch()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/GetPatchList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortPatch(ColumnName, SearchedItem, IsDesc)
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
	
    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/patch/action/GetPatchList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}