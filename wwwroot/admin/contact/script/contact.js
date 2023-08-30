function el_EditContact(ContactId)
{
	var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_EditContact_" + ContactId;
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
    IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/contact/action/EditContact.aspx?contact_id=" + ContactId);
    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

async function el_DeleteContact(obj, ContactId)
{
	var OkClick = await el_Confirm(ContactLanguageVariant.Delete);
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/contact/action/DeleteContact.aspx?contact_id=" + ContactId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

function el_EditContact(ContactId)
{
	var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_EditContact_" + ContactId;
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
    IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/contact/action/EditContact.aspx?contact_id=" + ContactId);
    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

async function el_DeleteSelectedContact()
{
	var ArrayContactId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayContactId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(ContactLanguageVariant.Delete);
    if (OkClick)
	{
        var ArrayContactIdLength = ArrayContactId.length;
        var i = 0;
        while (i < ArrayContactIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    var RowItem = document.getElementById("cbx_Item" + ArrayContactId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/contact/action/DeleteContact.aspx?contact_id=" + ArrayContactId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

function el_AddContactResponse(ContactId)
{
	DivId = "div_contact_response_" + ContactId;
    if (!document.getElementById(DivId))
    {
        var DivTag = document.createElement("div");
        DivTag.id = DivId;
        DivTag.className = "el_hidden";
        var IframeTag = document.createElement("iframe");
        IframeTag.src = ElanatVariant.AdminDirectoryPath + "/contact/action/add_contact_response/AddContactResponse.aspx?contact_id=" + ContactId;
        IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)")

        DivTag.innerHTML = IframeTag.outerHTML;
        document.body.appendChild(DivTag);
        el_OpenBox(DivId);
    }
    else
        el_OpenBox(DivId);
}

function el_ViewContact(ContactId)
{
	if (!document.getElementById("div_ContactViewMore" + ContactId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
			{
                var DivTag = document.createElement("div");
                DivTag.id = "div_ContactViewMore" + ContactId;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/contact/action/GetContactViewMore.aspx?contact_id=" + ContactId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_ContactViewMore" + ContactId);
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

function el_SearchContact()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/contact/action/GetContactList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortContact(ColumnName, SearchedItem, IsDesc)
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

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/contact/action/GetContactList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}