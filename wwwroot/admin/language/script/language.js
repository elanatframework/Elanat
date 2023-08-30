function el_EditLanguage(LanguageId)
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_EditLanguage_" + LanguageId;
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/language/action/EditLanguage.aspx?language_id=" + LanguageId);
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

async function el_ActiveLanguage(obj, LanguageId)
{
	var OkClick = await el_Confirm(LanguageLanguageVariant.Active);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetInactive(obj, "el_InactiveLanguage(this, '" + LanguageId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/ActiveLanguage.aspx?language_id=" + LanguageId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_ActiveSelectedLanguage()
{
	var ArrayLanguageId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayLanguageId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(LanguageLanguageVariant.Active);
    if (OkClick)
{
        var ArrayLanguageIdLength = ArrayLanguageId.length;
        var i = 0;
        while (i < ArrayLanguageIdLength)
{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayLanguageId[i]).parentNode.getElementsByClassName("el_inactive")[0]) 
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayLanguageId[i]).parentNode.getElementsByClassName("el_inactive")[0];
                        el_SetInactive(RowItem, "el_InactiveLanguage(this, '" + ArrayLanguageId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/ActiveLanguage.aspx?language_id=" + ArrayLanguageId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_InactiveLanguage(obj, LanguageId)
{
	var OkClick = await el_Confirm(LanguageLanguageVariant.InActive);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetActive(obj, "el_ActiveLanguage(this, '" + LanguageId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/InactiveLanguage.aspx?language_id=" + LanguageId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_InactiveSelectedLanguage()
{
	var ArrayLanguageId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayLanguageId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(LanguageLanguageVariant.InActive);
    if (OkClick)
	{
        var ArrayLanguageIdLength = ArrayLanguageId.length;
        var i = 0;
        while (i < ArrayLanguageIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayLanguageId[i]).parentNode.getElementsByClassName("el_active")[0]) 
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayLanguageId[i]).parentNode.getElementsByClassName("el_active")[0];
                        el_SetActive(RowItem, "el_ActiveLanguage(this, '" + ArrayLanguageId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                };
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/InactiveLanguage.aspx?language_id=" + ArrayLanguageId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_DeleteLanguage(obj, LanguageId)
{
	var OkClick = await el_Confirm(LanguageLanguageVariant.Delete);
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/DeleteLanguage.aspx?language_id=" + LanguageId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteSelectedLanguage()
{
	var ArrayLanguageId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayLanguageId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(LanguageLanguageVariant.Delete);
    if (OkClick)
	{
        var ArrayLanguageIdLength = ArrayLanguageId.length;
        var i = 0;
        while (i < ArrayLanguageIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    var RowItem = document.getElementById("cbx_Item" + ArrayLanguageId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/DeleteLanguage.aspx?language_id=" + ArrayLanguageId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

function el_ViewLanguage(LanguageId)
{
	if (!document.getElementById("div_LanguageViewMore" + LanguageId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
			{
                var DivTag = document.createElement("div");
                DivTag.id = "div_LanguageViewMore" + LanguageId;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/GetLanguageViewMore.aspx?language_id=" + LanguageId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_LanguageViewMore" + LanguageId);
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

function el_SearchLanguage()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/GetLanguageList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortLanguage(ColumnName, SearchedItem, IsDesc)
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
	
    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/GetLanguageList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}

function el_AddHandheldLanguageVariant()
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_AddHandheldLanguageVariant";
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/language/action/add_handheld_language_variant/AddHandheldLanguageVariant.aspx");
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

function el_AddLanguageVariant()
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_AddLanguageVariant";
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/language/action/add_language_variant/AddLanguageVariant.aspx");
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

function el_EditHandheldLanguageVariant()
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_EditHandheldLanguageVariant";
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/language/action/edit_handheld_language_variant/EditHandheldLanguageVariant.aspx");
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

function el_EditLanguageVariant()
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_EditLanguageVariant";
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/language/action/edit_language_variant/EditLanguageVariant.aspx");
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

function el_SetLanguageVariant(obj)
{
    var LanguageVariant = obj.value;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function () 
	{
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
		{
            var LanguageVariant = document.getElementById("div_LanguageVariant");
            LanguageVariant.innerHTML = xmlhttp.responseText;
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/edit_language_variant/action/LanguageVariant.aspx?language_variant_value=" + LanguageVariant, false);
    xmlhttp.send();
}

function el_SetHandheldLanguageVariant(obj)
{
    var HandheldLanguageVariant = obj.value;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function () 
	{
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
		{
            var HandheldLanguageVariant = document.getElementById("div_HandheldLanguageVariant");
            HandheldLanguageVariant.innerHTML = xmlhttp.responseText;
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/language/action/edit_handheld_language_variant/action/HandheldLanguageVariant.aspx?handheld_language_variant_value=" + HandheldLanguageVariant, false);
    xmlhttp.send();
}

function el_CleanLanguageVariantList()
{
    document.getElementById("div_LanguageVariantList").innerHTML = null;
}

function el_CleanHandheldLanguageVariantList()
{
    document.getElementById("div_HandheldLanguageVariantList").innerHTML = null;
}

function el_DeleteLanguageListBox()
{
    LanguageVariantListBox = document.getElementById("lstx_LanguageVariant");
    LanguageVariantListBox.remove(LanguageVariantListBox.selectedIndex); 
}

function el_DeleteHandheldLanguageListBox()
{
    HandheldLanguageVariantListBox = document.getElementById("lstx_HandheldLanguageVariant");
    HandheldLanguageVariantListBox.remove(HandheldLanguageVariantListBox.selectedIndex); 
}