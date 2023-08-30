function el_EditPage(PageId)
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_EditPage_" + PageId;
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/page/action/EditPage.aspx?page_id=" + PageId);
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

function el_EditPageTextFile(PageId, PagePhysicalPath)
{
	var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_EditPageTextFile_" + PageId;
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
    IframeTag.setAttribute("src", ElanatVariant.SitePath + "add_on/plugin/directory_text_file/Default.aspx?directory_path=" + ElanatVariant.SitePath + "page/" + PagePhysicalPath + "/");
    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

async function el_ActivePage(obj, PageId)
{
	var OkClick = await el_Confirm(PageLanguageVariant.Active);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetInactive(obj, "el_InactivePage(this, '" + PageId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/ActivePage.aspx?page_id=" + PageId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_ActiveSelectedPage()
{
	var ArrayPageId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
	{
            ArrayPageId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(PageLanguageVariant.Active);
    if (OkClick)
	{
        var ArrayPageIdLength = ArrayPageId.length;
        var i = 0;
        while (i < ArrayPageIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayPageId[i]).parentNode.getElementsByClassName("el_inactive")[0]) 
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayPageId[i]).parentNode.getElementsByClassName("el_inactive")[0];
                        el_SetInactive(RowItem, "el_InactivePage(this, '" + ArrayPageId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/ActivePage.aspx?page_id=" + ArrayPageId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_InactivePage(obj, PageId)
{
	var OkClick = await el_Confirm(PageLanguageVariant.InActive);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetActive(obj, "el_ActivePage(this, '" + PageId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/InactivePage.aspx?page_id=" + PageId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_InactiveSelectedPage()
{
	var ArrayPageId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayPageId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(PageLanguageVariant.InActive);
    if (OkClick)
	{
        var ArrayPageIdLength = ArrayPageId.length;
        var i = 0;
        while (i < ArrayPageIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayPageId[i]).parentNode.getElementsByClassName("el_active")[0]) 
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayPageId[i]).parentNode.getElementsByClassName("el_active")[0];
                        el_SetActive(RowItem, "el_ActivePage(this, '" + ArrayPageId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/InactivePage.aspx?page_id=" + ArrayPageId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_DeletePage(obj, PageId)
{
	var OkClick = await el_Confirm(PageLanguageVariant.Delete);
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/DeletePage.aspx?page_id=" + PageId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteSelectedPage()
{
	var ArrayPageId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayPageId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(PageLanguageVariant.Delete);
    if (OkClick)
	{
        var ArrayPageIdLength = ArrayPageId.length;
        var i = 0;
        while (i < ArrayPageIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    var RowItem = document.getElementById("cbx_Item" + ArrayPageId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/DeletePage.aspx?page_id=" + ArrayPageId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

function el_ViewPage(PageId)
{
	if (!document.getElementById("div_PageViewMore" + PageId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
			{
                var DivTag = document.createElement("div");
                DivTag.id = "div_PageViewMore" + PageId;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/GetPageViewMore.aspx?page_id=" + PageId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_PageViewMore" + PageId);
}

function el_ViewPageInformation(PageDirectoryPath)
{
	if (!document.getElementById("div_ViewPageInformation" + PageDirectoryPath))
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
			{
                var DivTag = document.createElement("div");
                DivTag.id = "div_ViewPageInformation" + PageDirectoryPath;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/GetPageInformation.aspx?page_directory_path=" + PageDirectoryPath, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_ViewPageInformation" + PageDirectoryPath);
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

function el_SearchPage()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/GetPageList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortPage(ColumnName, SearchedItem, IsDesc)
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
	
    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/page/action/GetPageList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}
