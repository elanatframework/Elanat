function el_EditAttachment(AttachmentId)
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_EditAttachment_" + AttachmentId;
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
	IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/attachment/action/EditAttachment.aspx?attachment_id=" + AttachmentId);
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

async function el_ActiveAttachment(obj, AttachmentId)
{
	var OkClick = await el_Confirm(AttachmentLanguageVariant.Active);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetInactive(obj, "el_InactiveAttachment(this, '" + AttachmentId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/attachment/action/ActiveAttachment.aspx?attachment_id=" + AttachmentId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_ActiveSelectedAttachment()
{
	var ArrayAttachmentId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayAttachmentId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(AttachmentLanguageVariant.Active);
    if (OkClick)
	{
        var ArrayAttachmentIdLength = ArrayAttachmentId.length;
        var i = 0;
        while (i < ArrayAttachmentIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayAttachmentId[i]).parentNode.getElementsByClassName("el_inactive")[0]) 
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayAttachmentId[i]).parentNode.getElementsByClassName("el_inactive")[0];
                        el_SetInactive(RowItem, "el_InactiveAttachment(this, '" + ArrayAttachmentId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/attachment/action/ActiveAttachment.aspx?attachment_id=" + ArrayAttachmentId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_InactiveAttachment(obj, AttachmentId)
{
	var OkClick = await el_Confirm(AttachmentLanguageVariant.InActive);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetActive(obj, "el_ActiveAttachment(this, '" + AttachmentId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/attachment/action/InactiveAttachment.aspx?attachment_id=" + AttachmentId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_InactiveSelectedAttachment()
{
	var OkClick = await el_Confirm(AttachmentLanguageVariant.InActive);

    if (!OkClick)
        return;

    var ArrayAttachmentId = new Array();

    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
    {
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
        {
            ArrayAttachmentId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var ArrayAttachmentIdLength = ArrayAttachmentId.length;
    var i = 0;
    while (i < ArrayAttachmentIdLength)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");


        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
            {
                if (document.getElementById("cbx_Item" + ArrayAttachmentId[i]).parentNode.getElementsByClassName("el_active")[0])
                {
                    var RowItem = document.getElementById("cbx_Item" + ArrayAttachmentId[i]).parentNode.getElementsByClassName("el_active")[0];
                    el_SetActive(RowItem, "el_ActiveAttachment(this, '" + ArrayAttachmentId[i] + "')");
                }
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/attachment/action/InactiveAttachment.aspx?attachment_id=" + ArrayAttachmentId[i], false);
        xmlhttp.send();
        i++;
    }
}

async function el_DeleteAttachment(obj, AttachmentId)
{
	var OkClick = await el_Confirm(AttachmentLanguageVariant.Delete);
    if (!OkClick)
        return;

	var xmlhttp = (window.XMLHttpRequest)? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

	xmlhttp.onreadystatechange = function ()
	{
		if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
			el_RemoveParentNode(obj);

		if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
		{
			el_Alert(LanguageVariant.ConnectionError, "problem");
		}
	}

	xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/attachment/action/DeleteAttachment.aspx?attachment_id=" + AttachmentId, false);
	xmlhttp.send();
}

async function el_DeleteSelectedAttachment()
{
	var ArrayAttachmentId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayAttachmentId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(AttachmentLanguageVariant.Delete);
    if (OkClick)
	{
        var ArrayAttachmentIdLength = ArrayAttachmentId.length;
        var i = 0;
        while (i < ArrayAttachmentIdLength)
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");


            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                {
                    var RowItem = document.getElementById("cbx_Item" + ArrayAttachmentId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/attachment/action/DeleteAttachment.aspx?attachment_id=" + ArrayAttachmentId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

function el_ViewAttachment(AttachmentId)
{
	if (!document.getElementById("div_AttachmentViewMore" + AttachmentId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
			{
                var DivTag = document.createElement("div");
                DivTag.id = "div_AttachmentViewMore" + AttachmentId;
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
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/attachment/action/GetAttachmentViewMore.aspx?attachment_id=" + AttachmentId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_AttachmentViewMore" + AttachmentId);
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

function el_SearchAttachment()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/attachment/action/GetAttachmentList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortAttachment(ColumnName, SearchedItem, IsDesc)
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
	
    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/attachment/action/GetAttachmentList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}