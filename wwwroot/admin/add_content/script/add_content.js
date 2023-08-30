function el_AddReadMoreToWysiwyg()
{
    el_InsertContentToWysiwyg("<hr class=\"el_read_more\">");
}

function el_GetContentIcon()
{
    var ImageContentIcon = document.getElementById("img_ContentIcon");
    var DropDownContentIcon = document.getElementById("ddlst_ContentIcon");
    ImageContentIcon.setAttribute("src", ElanatVariant.SitePath + "client/image/content_icon/" + DropDownContentIcon.value + ".png");
}

function el_ViewContentAvatarList(Path)
{
    var IframeTag = document.createElement("iframe");
    IframeTag.id = "div_ContentAvatarList";
    IframeTag.setAttribute("onload", "el_IframeAutoHeight(this)");
    IframeTag.setAttribute("scrolling", "no");
    IframeTag.setAttribute("src", ElanatVariant.AdminDirectoryPath + "/add_content/action/get_content_avatar_list/Default.aspx?path=" + Path);
    IframeTag.className = "el_hidden";
    document.body.appendChild(IframeTag);
    el_OpenBox(IframeTag.id);
}

function el_ViewEditorTemplateList()
{
    DivId = 'div_EditorTemplateList';
    if (!document.getElementById(DivId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200)
            {
                var DivTag = document.createElement("div");
                DivTag.id = DivId;
                DivTag.className = "el_hidden";
                DivTag.innerHTML = xmlhttp.responseText;
                document.body.appendChild(DivTag);
                el_OpenBox(DivId);
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }

        xmlhttp.open("GET", ElanatVariant.SitePath + "action/show_editor_template_list/Default.aspx", false);
        xmlhttp.send();
    }
    else
        el_OpenBox(DivId);
}

function el_ChangeContentType(obj)
{
    var Url = window.location.href;
    
    if (Url.Contains("content_type="))
    {
        var ContentTypeValue = Url.GetTextAfter("content_type=");

        if (ContentTypeValue.Contains("&"))
            ContentTypeValue = ContentTypeValue.GetTextBefore("&");

        Url = Url.replace("content_type=" + ContentTypeValue, "content_type=" + obj.value);
        window.location = Url;

        return;
    }

    window.location = (el_CheckExistQueryStringInUrl())?  Url + "&content_type=" + obj.value : Url + "?content_type=" + obj.value;
}

function el_TinyMceIssues()
{
    // Ajax Postback Error
    if (!document.getElementById("txt_ContentText_ifr"))
        return;

    var TinyMCEIframe = document.getElementById("txt_ContentText_ifr");
    var ContentText = TinyMCEIframe.contentWindow.document.getElementById("tinymce").innerHTML;

    document.getElementById("txt_ContentText").value = ContentText;
}