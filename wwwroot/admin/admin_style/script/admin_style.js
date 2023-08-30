function el_EditAdminStyleTextFile(AdminStyleId, AdminStyleDirectoryPath)
{
	var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_EditAdminStyleTextFile_" + AdminStyleId;
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
    IframeTag.setAttribute("src", ElanatVariant.SitePath + "add_on/plugin/directory_text_file/Default.aspx?directory_path=" + ElanatVariant.SitePath + "client/style/admin/" + AdminStyleDirectoryPath + "/");
    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

async function el_ActiveAdminStyle(obj, AdminStyleId) 
{
	var OkClick = await el_Confirm(AdminStyleLanguageVariant.Active);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetInactive(obj, "el_InactiveAdminStyle(this, '" + AdminStyleId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/ActiveAdminStyle.aspx?admin_style_id=" + AdminStyleId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_ActiveSelectedAdminStyle()
{
	var ArrayAdminStyleId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayAdminStyleId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(AdminStyleLanguageVariant.Active);
    if (OkClick)
	{
        var ArrayAdminStyleIdLength = ArrayAdminStyleId.length;
        var i = 0;
        while (i < ArrayAdminStyleIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                {
                    if (document.getElementById("cbx_Item" + ArrayAdminStyleId[i]).parentNode.getElementsByClassName("el_inactive")[0])
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayAdminStyleId[i]).parentNode.getElementsByClassName("el_inactive")[0];
                        el_SetInactive(RowItem, "el_InactiveAdminStyle(this, '" + ArrayAdminStyleId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }

            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/ActiveAdminStyle.aspx?admin_style_id=" + ArrayAdminStyleId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_InactiveAdminStyle(obj, AdminStyleId) 
{
	var OkClick = await el_Confirm(AdminStyleLanguageVariant.InActive);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetActive(obj, "el_ActiveAdminStyle(this, '" + AdminStyleId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/InactiveAdminStyle.aspx?admin_style_id=" + AdminStyleId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_InactiveSelectedAdminStyle() 
{
	var ArrayAdminStyleId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayAdminStyleId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(AdminStyleLanguageVariant.InActive);
    if (OkClick)
	{
        var ArrayAdminStyleIdLength = ArrayAdminStyleId.length;
        var i = 0;
        while (i < ArrayAdminStyleIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                {
                    if (document.getElementById("cbx_Item" + ArrayAdminStyleId[i]).parentNode.getElementsByClassName("el_active")[0])
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayAdminStyleId[i]).parentNode.getElementsByClassName("el_active")[0];
                        el_SetActive(RowItem, "el_ActiveAdminStyle(this, '" + ArrayAdminStyleId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }

            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/InactiveAdminStyle.aspx?admin_style_id=" + ArrayAdminStyleId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_DeleteAdminStyle(obj, AdminStyleId) 
{
	var OkClick = await el_Confirm(AdminStyleLanguageVariant.Delete);
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/DeleteAdminStyle.aspx?admin_style_id=" + AdminStyleId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteSelectedAdminStyle() 
{
	var ArrayAdminStyleId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayAdminStyleId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(AdminStyleLanguageVariant.Delete);
    if (OkClick)
	{
        var ArrayAdminStyleIdLength = ArrayAdminStyleId.length;
        var i = 0;
        while (i < ArrayAdminStyleIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                {
                    var RowItem = document.getElementById("cbx_Item" + ArrayAdminStyleId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }

            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/DeleteAdminStyle.aspx?admin_style_id=" + ArrayAdminStyleId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

function el_ViewAdminStyle(AdminStyleId) 
{
	if (!document.getElementById("div_AdminStyleViewMore" + AdminStyleId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
            {
                var DivTag = document.createElement("div");
                DivTag.id = "div_AdminStyleViewMore" + AdminStyleId;
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/GetAdminStyleViewMore.aspx?admin_style_id=" + AdminStyleId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_AdminStyleViewMore" + AdminStyleId);
}

function el_ViewAdminStyleInformation(AdminStyleDirectoryPath)
{
	if (!document.getElementById("div_ViewAdminStyleInformation" + AdminStyleDirectoryPath))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
            {
                var DivTag = document.createElement("div");
                DivTag.id = "div_ViewAdminStyleInformation" + AdminStyleDirectoryPath;
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/GetAdminStyleInformation.aspx?admin_style_directory_path=" + AdminStyleDirectoryPath, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_ViewAdminStyleInformation" + AdminStyleDirectoryPath);
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

function el_SearchAdminStyle()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/GetAdminStyleList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortAdminStyle(ColumnName, SearchedItem, IsDesc)
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

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/admin_style/action/GetAdminStyleList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}