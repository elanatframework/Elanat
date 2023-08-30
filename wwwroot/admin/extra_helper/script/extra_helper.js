function el_EditExtraHelper(ExtraHelperId)
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_EditExtraHelper_" + ExtraHelperId;
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/EditExtraHelper.aspx?extra_helper_id=" + ExtraHelperId);
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

function el_EditExtraHelperTextFile(ExtraHelperId, ExtraHelperDirectoryPath)
{
	var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_EditExtraHelperTextFile_" + ExtraHelperId;
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
    IframeTag.setAttribute("src", ElanatVariant.SitePath + "add_on/plugin/directory_text_file/Default.aspx?directory_path=" + ElanatVariant.SitePath + "add_on/extra_helper/" + ExtraHelperDirectoryPath + "/");
    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

async function el_ActiveExtraHelper(obj, ExtraHelperId)
{
	var OkClick = await el_Confirm(ExtraHelperLanguageVariant.Active);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetInactive(obj, "el_InactiveExtraHelper(this, '" + ExtraHelperId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/ActiveExtraHelper.aspx?extra_helper_id=" + ExtraHelperId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_ActiveSelectedExtraHelper()
{
	var ArrayExtraHelperId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayExtraHelperId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(ExtraHelperLanguageVariant.Active);
    if (OkClick)
	{
        var ArrayExtraHelperIdLength = ArrayExtraHelperId.length;
        var i = 0;
        while (i < ArrayExtraHelperIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
				{
                    if (document.getElementById("cbx_Item" + ArrayExtraHelperId[i]).parentNode.getElementsByClassName("el_inactive")[0])
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayExtraHelperId[i]).parentNode.getElementsByClassName("el_inactive")[0];
                        el_SetInactive(RowItem, "el_InactiveExtraHelper(this, '" + ArrayExtraHelperId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/ActiveExtraHelper.aspx?extra_helper_id=" + ArrayExtraHelperId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_InactiveExtraHelper(obj, ExtraHelperId)
{
	var OkClick = await el_Confirm(ExtraHelperLanguageVariant.InActive);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetActive(obj, "el_ActiveExtraHelper(this, '" + ExtraHelperId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/InactiveExtraHelper.aspx?extra_helper_id=" + ExtraHelperId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_InactiveSelectedExtraHelper()
{
	var ArrayExtraHelperId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayExtraHelperId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(ExtraHelperLanguageVariant.InActive);
    if (OkClick)
	{
        var ArrayExtraHelperIdLength = ArrayExtraHelperId.length;
        var i = 0;
        while (i < ArrayExtraHelperIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayExtraHelperId[i]).parentNode.getElementsByClassName("el_active")[0])
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayExtraHelperId[i]).parentNode.getElementsByClassName("el_active")[0];
                        el_SetActive(RowItem, "el_ActiveExtraHelper(this, '" + ArrayExtraHelperId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/InactiveExtraHelper.aspx?extra_helper_id=" + ArrayExtraHelperId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_DeleteExtraHelper(obj, ExtraHelperId)
{
	var OkClick = await el_Confirm(ExtraHelperLanguageVariant.Delete);
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/DeleteExtraHelper.aspx?extra_helper_id=" + ExtraHelperId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteSelectedExtraHelper()
{
	var ArrayExtraHelperId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayExtraHelperId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(ExtraHelperLanguageVariant.Delete);
    if (OkClick)
	{
        var ArrayExtraHelperIdLength = ArrayExtraHelperId.length;
        var i = 0;
        while (i < ArrayExtraHelperIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    var RowItem = document.getElementById("cbx_Item" + ArrayExtraHelperId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/DeleteExtraHelper.aspx?extra_helper_id=" + ArrayExtraHelperId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

function el_ViewExtraHelper(ExtraHelperId)
{
	if (!document.getElementById("div_ExtraHelperViewMore" + ExtraHelperId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
			{
                var DivTag = document.createElement("div");
                DivTag.id = "div_ExtraHelperViewMore" + ExtraHelperId;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/GetExtraHelperViewMore.aspx?extra_helper_id=" + ExtraHelperId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_ExtraHelperViewMore" + ExtraHelperId);
}

function el_ViewExtraHelperInformation(ExtraHelperDirectoryPath)
{
	if (!document.getElementById("div_ViewExtraHelperInformation" + ExtraHelperDirectoryPath))
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
            {
                var DivTag = document.createElement("div");
                DivTag.id = "div_ViewExtraHelperInformation" + ExtraHelperDirectoryPath;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/GetExtraHelperInformation.aspx?extra_helper_directory_path=" + ExtraHelperDirectoryPath, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_ViewExtraHelperInformation" + ExtraHelperDirectoryPath);
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

function el_SearchExtraHelper()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/GetExtraHelperList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortExtraHelper(ColumnName, SearchedItem, IsDesc)
{
	var xmlhttp = (window.XMLHttpRequest)? xmlhttp = new XMLHttpRequest() : xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");

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
	
    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/extra_helper/action/GetExtraHelperList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}