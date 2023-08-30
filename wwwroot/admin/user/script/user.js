function el_EditUser(UserId) 
{
	var IframeTag = document.createElement("iframe");
	IframeTag.id = "div_EditUser_" + UserId;
	IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
	IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/user/action/EditUser.aspx?user_id=" + UserId);
	IframeTag.className = "el_hidden";
	document.body.appendChild(IframeTag);
	el_OpenBox(IframeTag.id);
}

async function el_ActiveUser(obj, UserId)
{
	var OkClick = await el_Confirm(UserLanguageVariant.Active);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetInactive(obj, "el_InactiveUser(this, '" + UserId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/ActiveUser.aspx?user_id=" + UserId, false);
        xmlhttp.send();
    }
    else
        return false;
}

async function el_ActiveSelectedUser()
{
	var ArrayUserId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayUserId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(UserLanguageVariant.Active);
    if (OkClick)
	{
        var ArrayUserIdLength = ArrayUserId.length;
        var i = 0;
        while (i < ArrayUserIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayUserId[i]).parentNode.getElementsByClassName("el_inactive")[0])
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayUserId[i]).parentNode.getElementsByClassName("el_inactive")[0];
                        el_SetInactive(RowItem, "el_InactiveUser(this, '" + ArrayUserId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/ActiveUser.aspx?user_id=" + ArrayUserId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_InactiveUser(obj, UserId)
{
	var OkClick = await el_Confirm(UserLanguageVariant.InActive);
    if (OkClick)
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                el_SetActive(obj, "el_ActiveUser(this, '" + UserId + "')");

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/InactiveUser.aspx?user_id=" + UserId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_InactiveSelectedUser()
{
	var ArrayUserId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayUserId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(UserLanguageVariant.InActive);
    if (OkClick)
	{
        var ArrayUserIdLength = ArrayUserId.length;
        var i = 0;
        while (i < ArrayUserIdLength)
		{
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayUserId[i]).parentNode.getElementsByClassName("el_active")[0])
					{
                        var RowItem = document.getElementById("cbx_Item" + ArrayUserId[i]).parentNode.getElementsByClassName("el_active")[0];
                        el_SetActive(RowItem, "el_ActiveUser(this, '" + ArrayUserId[i] + "')");
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/InactiveUser.aspx?user_id=" + ArrayUserId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_DeleteUser(obj, UserId)
{
	var OkClick = await el_Confirm(UserLanguageVariant.Delete);
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/DeleteUser.aspx?user_id=" + UserId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteSelectedUser()
{
	var ArrayUserId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
    {
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
        {
            ArrayUserId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(UserLanguageVariant.Delete);
    if (OkClick)
    {
        var ArrayUserIdLength = ArrayUserId.length;
        var i = 0;
        while (i < ArrayUserIdLength)
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
            {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
                {
                    var RowItem = document.getElementById("cbx_Item" + ArrayUserId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/DeleteUser.aspx?user_id=" + ArrayUserId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_DeleteUserFootPrint(UserId)
{
	var OkClick = await el_Confirm(UserLanguageVariant.DeleteFootPrint);
    if (OkClick)
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
            {
                el_Alert(UserLanguageVariant.UserFootPrintWasDelete, "success");
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/DeleteUserFootPrint.aspx?user_id=" + UserId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteSelectedUserFootPrint() 
{
	var ArrayUserId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
	{
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
		{
            ArrayUserId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(UserLanguageVariant.DeleteFootPrint);
    if (OkClick)
	{
        var ArrayUserIdLength = ArrayUserId.length;
        var i = 0;
        while (i < ArrayUserIdLength)
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    var RowItem = document.getElementById("cbx_Item" + ArrayUserId[i]);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/DeleteUserFootPrint.aspx?user_id=" + ArrayUserId[i], false);
            xmlhttp.send();
            i++;
        }

        if (i > 0)
            el_Alert(UserLanguageVariant.AllUsersFootPrintWasDeleted, "success");
    }
    else
	    return false;
}

function el_ViewUser(UserId)
{
	if (!document.getElementById("div_UserViewMore" + UserId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
			{
                var DivTag = document.createElement("div");
                DivTag.id = "div_UserViewMore" + UserId;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/GetUserViewMore.aspx?user_id=" + UserId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_UserViewMore" + UserId);
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

function el_SearchUser()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/GetUserList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortUser(ColumnName, SearchedItem, IsDesc)
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

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/user/action/GetUserList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}