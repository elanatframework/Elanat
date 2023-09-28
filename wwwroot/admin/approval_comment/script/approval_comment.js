function el_EditComment(CommentId)
{
	var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_EditComment_" + CommentId;
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
    IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/comment/action/EditComment.aspx?comment_id=" + CommentId);
    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

function el_AddCommentReply(ContentId, CommentId)
{
	DivId = "div_comment_reply_" + CommentId;
    if (!document.getElementById(DivId))
	{

        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
            {
                var DivTag = document.createElement("div");
                DivTag.id = DivId;
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

        xmlhttp.open("GET", ElanatVariant.SitePath + "page/comment/?content_id=" + ContentId + "&comment_id=" + CommentId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox(DivId);
}

async function el_ApprovalComment(obj, CommentId) 
{
	var OkClick = await el_Confirm(CommentLanguageVariant.Approval);
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/approval_comment/action/ApprovalComment.aspx?comment_id=" + CommentId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_ApprovalSelectedComment()
{
	var ArrayCommentId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
    {
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
        {
            ArrayCommentId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(CommentLanguageVariant.Approval);
    if (OkClick)
    {
        var ArrayCommentIdLength = ArrayCommentId.length;
        var i = 0;
        while (i < ArrayCommentIdLength)
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    if (document.getElementById("cbx_Item" + ArrayCommentId[i]))
                    {
                        var RowItem = document.getElementById("cbx_Item" + ArrayCommentId[i]);
                        el_RemoveParentNode(RowItem);
                    }
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/approval_comment/action/ApprovalComment.aspx?comment_id=" + ArrayCommentId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

async function el_DeleteComment(obj, CommentId)
{
	var OkClick = await el_Confirm(CommentLanguageVariant.Delete);
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
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/approval_comment/action/DeleteComment.aspx?comment_id=" + CommentId, false);
        xmlhttp.send();
    }
    else
	    return false;
}

async function el_DeleteSelectedComment()
{
	var ArrayCommentId = new Array();
    var CheckBoxItemLength = document.getElementsByClassName("el_cbx_item").length;
    var i = 0;
    var ia = 0;
    while (i < CheckBoxItemLength)
    {
        var CheckBoxItem = document.getElementsByClassName("el_cbx_item")[i];
        if (CheckBoxItem.checked)
        {
            ArrayCommentId[ia] = CheckBoxItem.id.replace("cbx_Item", "");
            ia++;
        }
        i++;
    }

    var OkClick = await el_Confirm(CommentLanguageVariant.Delete);
    if (OkClick)
    {
        var ArrayCommentIdLength = ArrayCommentId.length;
        var i = 0;
        while (i < ArrayCommentIdLength)
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    var RowItem = document.getElementById("cbx_Item" + ArrayCommentId[i]);
                    el_RemoveParentNode(RowItem);
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/approval_comment/action/DeleteComment.aspx?comment_id=" + ArrayCommentId[i], false);
            xmlhttp.send();
            i++;
        }
    }
    else
	    return false;
}

function el_ViewComment(CommentId)
{
	if (!document.getElementById("div_CommentViewMore" + CommentId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false") 
			{
                var DivTag = document.createElement("div");
                DivTag.id = "div_CommentViewMore" + CommentId;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/approval_comment/action/GetCommentViewMore.aspx?comment_id=" + CommentId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_CommentViewMore" + CommentId);
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

function el_SearchComment()
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

        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/approval_comment/action/GetCommentList.aspx?search=" + SearchValue, false);
        xmlhttp.send();
    }
}

function el_SortComment(ColumnName, SearchedItem, IsDesc)
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
	
    var SortType = "false";
    if (IsDesc)
        SortType = "true";
    var SearchValue = "";
    if (SearchedItem != "$_searched_item;")
        SearchValue = "&search=" + SearchedItem;

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/approval_comment/action/GetCommentList.aspx?column_name=" + ColumnName + "&is_desc=" + SortType + SearchValue, false);
    xmlhttp.send();
}

function el_RepeatComment(CommentId)
{
	location.href = ElanatVariant.AdminDirectoryPath + "/add_comment/Default.aspx?comment=" + CommentId;
}