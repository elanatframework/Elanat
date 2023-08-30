function el_EditView(ViewId)
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_EditView_" + ViewId;
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/view/action/EditView.aspx?view_id=" + ViewId);
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

async function el_ActiveView(obj, ViewId)
{
	var OkClick = await el_Confirm(ViewLanguageVariant.Active);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetInactive(obj, "el_InactiveView(this, '" + ViewId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/view/action/ActiveView.aspx?view_id=" + ViewId, false);
        xmlhttp.send();
    }
    else
        return false;
}

async function el_ActiveSelectedView()
{
	var ArrayViewId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayViewId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(ViewLanguageVariant.Active);
    if (OkClick)
	{
        var ArrayViewIdLength = ArrayViewId.length;
        var i = 0;
        while (i < ArrayViewIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayViewId[i]).parentNode.getElementsByClassName("el_inactive")[0])
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayViewId[i]).parentNode.getElementsByClassName("el_inactive")[0];
                        el_SetInactive(RowItem, "el_InactiveView(this, '" + ArrayViewId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/view/action/ActiveView.aspx?view_id=" + ArrayViewId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
        return false;
}

async function el_InactiveView(obj, ViewId)
{
	var OkClick = await el_Confirm(ViewLanguageVariant.InActive);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetActive(obj, "el_ActiveView(this, '" + ViewId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/view/action/InactiveView.aspx?view_id=" + ViewId, false);
        xmlhttp.send();
    }
    else
        return false;
}

async function el_InactiveSelectedView()
{
	var ArrayViewId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayViewId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(ViewLanguageVariant.InActive);
    if (OkClick)
	{
        var ArrayViewIdLength = ArrayViewId.length;
        var i = 0;
        while (i < ArrayViewIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");;

            xmlhttp.onreadystatechange = function ()
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayViewId[i]).parentNode.getElementsByClassName("el_active")[0]) 
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayViewId[i]).parentNode.getElementsByClassName("el_active")[0];
                        el_SetActive(RowItem, "el_ActiveView(this, '" + ArrayViewId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/view/action/InactiveView.aspx?view_id=" + ArrayViewId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
        return false;
}

async function el_DeleteView(obj, ViewId)
{
	var OkClick = await el_Confirm(ViewLanguageVariant.Delete);
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/view/action/DeleteView.aspx?view_id=" + ViewId, false);
        xmlhttp.send();
    }
    else
        return false;
}

async function el_DeleteSelectedView()
{
	var ArrayViewId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayViewId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(ViewLanguageVariant.Delete);
    if (OkClick)
	{
        var ArrayViewIdLength = ArrayViewId.length;
        var i = 0;
        while (i < ArrayViewIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    var RowItem = document.getElementById("cbx_Item" + ArrayViewId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/view/action/DeleteView.aspx?view_id=" + ArrayViewId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
        return false;
}

function el_ViewView(ViewId)
{
	if (!document.getElementById("div_ViewViewMore" + ViewId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
			{
                var DivTag = document.createElement("div");
                DivTag.id = "div_ViewViewMore" + ViewId;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/view/action/GetViewViewMore.aspx?view_id=" + ViewId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_ViewViewMore" + ViewId);
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

function el_SearchView()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/view/action/GetViewList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortView(ColumnName, SearchedItem, IsDesc)
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

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/view/action/GetViewList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}

function el_SetUniqueMatchType(obj)
{
    if (obj.value == "none_query" || obj.value == "all_query")
        document.getElementById("txt_ViewQueryString").value = obj.value;
    else if (document.getElementById("txt_ViewQueryString").value == "none_query" || document.getElementById("txt_ViewQueryString").value == "all_query")
        document.getElementById("txt_ViewQueryString").value = "";
}