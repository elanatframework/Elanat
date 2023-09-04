/* Start Extension Methods */
String.prototype.toDOM = function ()
{
    var d = document
        , i
        , a = d.createElement("div")
        , b = d.createDocumentFragment();
    a.innerHTML = this;
    while (i = a.firstChild)
        b.appendChild(i);

    return b;
};

String.IsNullOrEmpty = function (Text)
{
    return (Text == null)
};

String.prototype.DeleteHtmlClass = function(ClassName)
{
    var ClassText = this;

    if (String.IsNullOrEmpty(ClassText))
        return "";

    var ClassNameIndex = ClassText.indexOf(ClassName);

    var Space = (ClassNameIndex == 0) ? "" : " ";
        
    ClassText = ClassText.replace(Space + ClassName, "");

    if (!String.IsNullOrEmpty(ClassText))
        if (ClassText[0] == ' ')
            ClassText = ClassText.slice(1);

    return ClassText;
};

String.prototype.AddHtmlClass = function (ClassName)
{
    var ClassText = this;

    if (String.IsNullOrEmpty(ClassText))
        return "";
    
    if (ClassText.Contains(ClassName))
        return ClassText;

    return ClassText + " " + ClassName;
}

String.prototype.Contains = function (Text)
{
    var MainText = this;

    if (String.IsNullOrEmpty(Text))
        return false;

    if (MainText.indexOf(Text) > -1)
        return true;

    return false;
}

String.prototype.Replace = function (SearchValue, ReplaceValue)
{
    var MainText = this;
    
    if (String.IsNullOrEmpty(MainText))
        return MainText;

    if (String.IsNullOrEmpty(SearchValue))
        return MainText;

    while (MainText.indexOf(SearchValue) > -1)
        MainText = MainText.replace(SearchValue, ReplaceValue);

    return MainText;
}

String.prototype.GetTextAfter = function (Text)
{
    var MainText = this;

    if (String.IsNullOrEmpty(Text))
        return false;

    if (!MainText.Contains(Text))
        return false;

    if (MainText.indexOf(Text) > -1)
        return MainText.substring(MainText.indexOf(Text) +  Text.length);

    return false;
}

String.prototype.GetTextBefore = function (Text)
{
    var MainText = this;

    if (String.IsNullOrEmpty(Text))
        return false;

    if (!MainText.Contains(Text))
        return false;

    if (MainText.indexOf(Text) > -1)
        return MainText.substring(0 ,MainText.indexOf(Text));

    return false;
}

Number.prototype.DecreaseToJavaScriptLength = function ()
{
    var ItemLength = this;

    if (window.XMLHttpRequest)
    {
        if (ItemLength < 3)
            return 0;

        return Number((ItemLength - 1) / 2);
    }
    else
        return ItemLength;
}

Number.prototype.IncreaseToJavaScriptLength = function ()
{
    var ItemLength = this;

    if (window.XMLHttpRequest)
    {
        if (ItemLength == 0)
            return 1;

        return Number((ItemLength * 2) + 1);
    }
    else
        return ItemLength
}

/* End Extension Methods */

/* Start Common Methods */

function el_DeleteInnerValue(Id)
{
	document.getElementById(Id).innerHTML = "";
}

/* End Common Methods */

/* Start Load Captcha */

function el_LoadCaptcha()
{
    var CaptchaValueArray = document.getElementsByClassName("el_captcha_value");
    var CaptchaValueArrayLength = CaptchaValueArray.length;
    
    for (var i = 0; i < CaptchaValueArrayLength; i++)
    {
        if (CaptchaValueArray.item(i).getElementsByClassName("el_captcha_box")[0])
            CaptchaValueArray.item(i).getElementsByClassName("el_image_re_captcha")[0].click();
        else
            el_LoadCaptchaPage(i);
    }
}

function el_LoadCaptchaPage(CaptchaIndex)
{
    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200)
        {
            var DivTag = document.createElement("div");
            DivTag.innerHTML = xmlhttp.responseText;

            el_AppendJavaScriptTag(xmlhttp.responseText);

            if (document.getElementsByClassName("el_captcha_value").item(CaptchaIndex))
                document.getElementsByClassName("el_captcha_value").item(CaptchaIndex).innerHTML = DivTag.outerHTML;

            if (document.getElementById("txt_Captcha"))
                document.getElementById("txt_Captcha").value = "";
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200)) {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", ElanatVariant.SitePath + "action/show_captcha/Default.aspx", true);
    xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xmlhttp.send();
}

/* End Load Captcha */


/* Start Page Part Load */

function el_PartPageLoad()
{
	el_OpenAjaxLoading();

    el_EventListener();

	el_CloseAjaxLoading();
}

/* End Page Part Load */


/* Start Page Load After Submit */

function el_SetContextToTagId(FromTag, ToTag)
{
    var PageContext = document.createElement("div");
    PageContext.id = "div_ContextTmp";
    PageContext.innerHTML = FromTag;

    document.getElementById(ToTag).appendChild(PageContext);
    document.getElementById("div_ContextTmp").outerHTML = document.getElementById("div_ContextTmp").innerHTML;
}

/* End Page Load After Submit */


/* Start Event Listener */

function el_EventListener()
{
    var InputList = document.body.getElementsByTagName("*");
    var InputListCount = InputList.length;

    for (var i = 0; i < InputListCount; i++)
        if (InputList[i].hasAttribute("onclick"))
            InputList[i].addEventListener("click", el_OpenAjaxLoading);


    var SelectList = document.body.getElementsByTagName("select");
    var SelectListCount = SelectList.length;
    
    for (var i = 0; i < SelectListCount; i++)
        SelectList[i].addEventListener("change", el_OpenAjaxLoading);
}

/* End Event Listener */

/* Start Ajax Loading */

TimeoutVariable = null;

async function el_OpenAjaxLoading()
{
    var div = document.createElement("div");
    div.id = "div_AjaxLoading";
    div.className = "el_ajax_loading";

    var img = document.createElement("img");
    img.src = ElanatVariant.SitePath + "client/image/ajax/loading.gif";

    div.appendChild(img);

    if (el_PageLoadWithIframeCheck())
        parent.document.body.appendChild(div);
    else
        document.body.appendChild(div);

    TimeoutVariable = setTimeout(function () { el_CloseAjaxLoading() }, 500);
}

function el_CloseAjaxLoading()
{
    TimeoutVariable = setTimeout(function () { el_DeleteAjaxLoadingTag() }, 500);
}

function el_DeleteAjaxLoadingTag()
{
    if (el_PageLoadWithIframeCheck())
        while (parent.document.getElementsByClassName("el_ajax_loading")[0])
        {
            var elem = parent.document.getElementsByClassName("el_ajax_loading")[0];
            elem.parentNode.removeChild(elem);
            window.clearInterval(TimeoutVariable);
        }
    else
        while (document.getElementsByClassName("el_ajax_loading")[0])
        {
            var elem = document.getElementsByClassName("el_ajax_loading")[0];
            elem.parentNode.removeChild(elem);
            window.clearInterval(TimeoutVariable);
        }
}

function el_CloseAllParentAjaxLoading()
{
    TimeoutVariable = setTimeout(function () { el_DeleteAllParentAjaxLoadingTag() }, 500);
}

function el_DeleteAllParentAjaxLoadingTag()
{
    var Body = document.body;

    ParentExist = true;
    while (ParentExist)
    {
        while (Body.getElementsByClassName("el_ajax_loading")[0])
        {
            var elem = Body.getElementsByClassName("el_ajax_loading")[0];
            elem.parentNode.removeChild(elem);
            window.clearInterval(TimeoutVariable);
        }

        if (Body.parentNode)
            Body = Body.parentNode;
        else
            ParentExist = false;
    }
}

function el_OpenSyncAjaxLoading()
{
    var div = document.createElement("div");
    div.id = "div_SyncAjaxLoading";
    div.className = "el_sync_ajax_loading";

    var img = document.createElement("img");
    img.src = ElanatVariant.SitePath + "client/image/ajax/loading.gif";

    div.appendChild(img);

    if (el_PageLoadWithIframeCheck())
        parent.document.body.appendChild(div);
    else
        document.body.appendChild(div);
}

function el_DeleteSyncAjaxLoadingTag()
{
    if (el_PageLoadWithIframeCheck())
        while (parent.document.getElementsByClassName("el_sync_ajax_loading")[0])
        {
            var elem = parent.document.getElementsByClassName("el_sync_ajax_loading")[0];
            elem.parentNode.removeChild(elem);
        }
    else
        while (document.getElementsByClassName("el_sync_ajax_loading")[0])
        {
            var elem = document.getElementsByClassName("el_sync_ajax_loading")[0];
            elem.parentNode.removeChild(elem);
        }
}

/* End Ajax Loading */

function el_ListBoxAutoSize(obj)
{
    var OptionCount = obj.options.length;
    obj.setAttribute("size", OptionCount);
}

function el_ListBoxAutoSizeByListBoxId(ListBoxId)
{
    var OptionCount = document.getElementById(ListBoxId).options.length;
    document.getElementById(ListBoxId).setAttribute("size", OptionCount);
}

function el_ServerMethod(argumentString)
{
    __doPostBack('<%= Page.ClientID %>', argumentString);
}

/* Start Section */

function el_ShowHideSection(obj, TagId)
{
    if (!obj.className.Contains("el_button_selected"))
        el_ShowSection(obj, TagId);
    else
        el_HideSection(obj, TagId);
}

function el_ShowSection(obj, TagId)
{
    document.getElementById(TagId).className = document.getElementById(TagId).className.DeleteHtmlClass("el_hidden");
    obj.className = obj.className.AddHtmlClass("el_button_selected");
}

function el_HideSection(obj, TagId)
{
    document.getElementById(TagId).className = document.getElementById(TagId).className.AddHtmlClass("el_hidden");
    obj.className = obj.className.DeleteHtmlClass("el_button_selected");
}

/* End Section */


/* Start Header Bar */

function el_ShowHideHeaderBarBox()
{	
    var Box = document.getElementById("div_HeaderBarBox");
    if (Box.className.Contains("el_hidden"))
        Box.className = Box.className.DeleteHtmlClass("el_hidden");
    else
        Box.className = Box.className.AddHtmlClass("el_hidden");
}

function el_OpenLanguageListBox()
{	
    var LanguageListBox = document.getElementById("div_LanguageListBox");
    if (LanguageListBox.className == "el_language_list_box_show")
        LanguageListBox.className = "el_language_list_box_hide";
    else
        LanguageListBox.className = "el_language_list_box_show";
}
        
/* End Header Bar */

/* Start Elanat Alert */
function el_RemoveParentNode(obj)
{
    el_OpenAjaxLoading();

	var elem = obj.parentNode;
    elem.parentNode.removeChild(elem);

    el_CloseAjaxLoading();
}
/* End Elanat Alert */

function el_SetActive(obj, ObjectFunction)
{
	obj.className = "el_inactive";
    obj.setAttribute("onclick", ObjectFunction);
}

function el_SetInactive(obj, ObjectFunction)
{
	obj.className = "el_active";
    obj.setAttribute("onclick", ObjectFunction);
}

/* Start Path */

function el_SetQueryStringToPath(Variant, Value)
{
	var Url = window.location.href;
    window.location = (el_CheckExistQueryStringInUrl())?  Url + "&" + Variant + "=" + Value : Url + "?" + Variant + "=" + Value;
}

function el_GoToPath(Path)
{
	window.location = Path;
}

function el_GotoCategory(obj)
{
	window.location = obj.value;
}

function el_GoToSearch()
{
	var SearchedValue = document.getElementById("txt_SearchInput").value;
    window.location = ElanatVariant.SitePath + "page_content/search/?search=" + SearchedValue + "&type=both";
}

function el_GoToSearchByEnterKey(e)
{
    if (e.keyCode == 13)
        document.getElementById("img_Search").click();
}

function el_GoToSite(obj, IsAdminPath)
{
    if (IsAdminPath)
        window.location = ElanatVariant.AdminDirectoryPath + "/?site=" + obj.value;
    else
        window.location = ElanatVariant.SitePath + "site/" + obj.value;
}

function el_GoToLanguage(obj, IsAdminPath)
{
	if (IsAdminPath)
        window.location = ElanatVariant.AdminDirectoryPath + "/?language=" + obj.value;
    else
        window.location = ElanatVariant.SitePath + "lang/" + obj.value;
}

/* End Path */

function el_Refresh()
{
	location.reload(ElanatVariant.ServerRefresh);
}

function el_IframeAutoHeight(obj)
{
	var PlusHeight = (obj.contentWindow.document.body.scrollHeight / 20) + 30;

    obj.style.height = (obj.contentWindow.document.body.scrollHeight + PlusHeight) + "px";
}
/* Start Search */

function el_Search()
{
	var SearchedValue = document.getElementById("txt_Search").value;
    window.location = "?search=" + SearchedValue;
}

/* End Search */

/* Start Cookie */

function el_GetCookie(CookieName)
{	
    var name = CookieName + "=";
    var ca = document.cookie.split(';');

    for (var i = 0; i < ca.length; i++)
    {
        var c = ca[i];
        while (c.charAt(0) == ' ')
            c = c.substring(1);

        if (c.indexOf(name) == 0)
            return c.substring(name.length, c.length);
    }
    return null;
}

function el_GetAllCookieName()
{
    var CookieNameArray = document.cookie.split(';');

    for (var i = 0; i < CookieNameArray.length; i++)
    {
        while (CookieNameArray[i].charAt(0) == ' ')
            CookieNameArray[i] = CookieNameArray[i].substring(1);

        CookieNameArray[i] = CookieNameArray[i].substring(0, CookieNameArray[i].indexOf("="));
    }

    return CookieNameArray;
}

function el_GetCookieLength()
{
    return document.cookie.split(';').length;          
}

function el_SetCookie(CookieName, CookieValue, DayExpiresDuration, ValidDomain) 
{
    var DomainString = ValidDomain ? ("; domain=" + ValidDomain) : '';
    document.cookie = CookieName + "=" + encodeURIComponent(CookieValue) + "; max-age=" + 60 * 60 * 24 * DayExpiresDuration + "; path=/" + DomainString;
}

function el_DeleteCookie(CookieName)
{
    el_SetCookie(CookieName, null, 0, false);
}

function el_DeleteAllCookie()
{
    var Cookie = document.cookie.split("; ");
    for (i in Cookie)
        document.cookie = /^[^=]+/.exec(Cookie[i])[0] + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
}

/* End Cookie */

/* Start Rating */

function el_ZoneRatingMouseMove(obj)
{
    var RatingLl = obj.getElementsByTagName("li");

    var Star1 = RatingLl[0];
    var Star2 = RatingLl[1];
    var Star3 = RatingLl[2];
    var Star4 = RatingLl[3];
    var Star5 = RatingLl[4];

    Star1.className = "el_Star1";
    Star2.className = "el_Star2";
    Star3.className = "el_Star3";
    Star4.className = "el_Star4";
    Star5.className = "el_Star5";
}

function el_SetRatingMouseMove(obj, Value) 
{
    var RatingLl = obj.parentElement.getElementsByTagName("li");

    var Star1 = RatingLl[0];
    var Star2 = RatingLl[1];
    var Star3 = RatingLl[2];
    var Star4 = RatingLl[3];
    var Star5 = RatingLl[4];

    switch (Value) 
	{
        case 1: Star1.className = "el_star_gold"; Star2.className = "el_star_none"; Star3.className = "el_star_none"; Star4.className = "el_star_none"; Star5.className = "el_star_none"; break;
        case 2: Star1.className = "el_star_gold"; Star2.className = "el_star_gold"; Star3.className = "el_star_none"; Star4.className = "el_star_none"; Star5.className = "el_star_none"; break;
        case 3: Star1.className = "el_star_gold"; Star2.className = "el_star_gold"; Star3.className = "el_star_gold"; Star4.className = "el_star_none"; Star5.className = "el_star_none"; break;
        case 4: Star1.className = "el_star_gold"; Star2.className = "el_star_gold"; Star3.className = "el_star_gold"; Star4.className = "el_star_gold"; Star5.className = "el_star_none"; break;
        case 5: Star1.className = "el_star_gold"; Star2.className = "el_star_gold"; Star3.className = "el_star_gold"; Star4.className = "el_star_gold"; Star5.className = "el_star_gold"; break;
    }
}

function el_SetZoneRating()
{
    var RatingLength = document.getElementsByClassName("el_rating").length;
    var i = 0;

    while (i < RatingLength)
	{
        var Rating = document.getElementsByClassName("el_rating").item(i);
        el_ZoneRatingMouseMove(Rating);
        i++;
    }
}

/* End Rating */

function el_GetQueryStrings() 
{ 
    var assoc = {};
    var decode = function (s){ return decodeURIComponent(s.replace(/\+/g, " ")); };
    var queryString = location.search.substring(1);
    var keyValues = queryString.split('&');

    for (var i in keyValues)
	{
        var key = keyValues[i].split('=');
        if (key.length > 1)
		{
            assoc[decode(key[0])] = decode(key[1]);
        }
    }

    return assoc;
}

function el_GetArrayFromQueryString(QueryString)
{
    var assoc = {};
    var decode = function (s) { return decodeURIComponent(s.replace(/\+/g, " ")); };
    var keyValues = QueryString.split('&');

    for (var i in keyValues)
    {
        var key = keyValues[i].split('=');
        if (key.length > 1) {
            assoc[decode(key[0])] = decode(key[1]);
        }
    }

    return assoc;
}

function el_LoadXMLDoc(FileName)
{
    var xhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xhttp.open("GET", FileName, false);
    xhttp.send(null);
    return xhttp.responseXML;
}

/* Start Hxtra Html Input */

function el_ShowDropDownList(obj) 
{
	obj.setAttribute("onclick", "el_HideDropDownList(this)");
    var DropDownMenu = obj.parentElement.parentElement;
    DropDownMenu.getElementsByClassName("el_drop_down_menu").item(0).className += " el_show";
}

function el_HideDropDownList(obj) 
{
	obj.setAttribute("onclick", "el_ShowDropDownList(this)");
    var DropDownMenu = obj.parentElement.parentElement;
    DropDownMenu.getElementsByClassName("el_drop_down_menu").item(0).className = DropDownMenu.getElementsByClassName("el_drop_down_menu").item(0).className.replace(" el_show", "");
}

/* End Hxtra Html Input */


/* Start Box */

function el_OpenBox(TagId)
{
	var OpenBoxFunctionName = ElanatVariant.OpenBoxFunctionName.replace("$_asp tag_id;", "'" + TagId + "'");
    eval(OpenBoxFunctionName);
}

function el_CloseBox(TagId)
{
	var CloseBoxFunctionName = ElanatVariant.CloseBoxFunctionName.replace("$_asp tag_id;", "'" + TagId + "'");
    eval(CloseBoxFunctionName);
}

function el_CloseParentBox(TagId)
{
    var CloseBoxFunctionName = ElanatVariant.CloseBoxFunctionName.replace("$_asp tag_id;", "'" + TagId + "'");
    parent.eval(CloseBoxFunctionName);

    el_CloseAllParentAjaxLoading();
}

/* End Box */

/* Start File Viewer */

function el_ViewFile(FileId, FilePath)
{
	if (document.getElementById("div_File" + FileId))
    {
        document.getElementById("div_File" + FileId).className = "el_hidden";
        el_OpenBox("div_File" + FileId);

        return;
    }

    var FileExtensions = el_GetFileExtensionsFromPath(FilePath);
    var FileType = el_GetFileType(FileExtensions);

    var DivFile = document.createElement("div");
    DivFile.id = "div_File" + FileId;

    var xmlhttp = (window.XMLHttpRequest)? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200)
        {
            DivFile.innerHTML = xmlhttp.responseText.replace("$_asp file_path;", FilePath);
            document.body.appendChild(DivFile);
            document.getElementById("div_File" + FileId).className = "el_hidden";
            el_OpenBox(DivFile.id);
        }
    }

    xmlhttp.open("GET", ElanatVariant.SitePath + "include/file_viewer/" + ElanatVariant.FileViewerPath + "/" + FileType + "/" + FileExtensions + "/", false);
    xmlhttp.send();
}

function el_GetFileExtensionsFromPath(FilePath)
{
    return FilePath.substr(FilePath.lastIndexOf('.') + 1);
}

function el_GetFileType(FileExtensions)
{
    var XmlDoc = el_LoadXMLDoc(ElanatVariant.SitePath + "client/file_type_list/file_type.xml");
    var FileTypeCount = XmlDoc.getElementsByTagName("file_type").length;

    for (var i = 0; i < FileTypeCount; i++)
    {
        var FileType = XmlDoc.getElementsByTagName("file_type")[i];

        if (FileType.getAttribute("extension") == FileExtensions)
            return FileType.getAttribute("type");
    }

    return "none";
}

/* End File Viewer */


function el_RemoveTag(TagId) 
{
    return (elem = document.getElementById(TagId)).parentNode.removeChild(elem);
}

function el_CheckExistQueryStringInUrl()
{
    var Url = window.location.href;
    return (Url.indexOf("?") != -1);
}

/* Start wysiwyg */

function el_CreateWysiwyg()
{
	var WysiwygPath = ElanatVariant.WysiwygPath;

    var XmlDoc = el_LoadXMLDoc(ElanatVariant.SitePath + "include/wysiwyg/" + WysiwygPath + "/catalog.xml");
    var WysiwygCurrentPath = ElanatVariant.SitePath + "include/wysiwyg/" + ElanatVariant.WysiwygPath + "/";
    var WysiwygStaticHeadTag = XmlDoc.getElementsByTagName("wysiwyg_static_head_tag")[0];

    for (var i = 0; i < WysiwygStaticHeadTag.childNodes.length ; i++)
    {
        if (WysiwygStaticHeadTag.childNodes[i].nodeType === Node.TEXT_NODE)
            continue;


        // Set CData Value
        if (WysiwygStaticHeadTag.childNodes[i].nodeType === Node.CDATA_SECTION_NODE)
        {
            document.head.appendChild(document.createTextNode(WysiwygStaticHeadTag.childNodes[i].nodeValue.replace("$_asp current_path;", WysiwygFullPath)));
            continue;
        }


        // Set Tag Value
        var Tag = WysiwygStaticHeadTag.childNodes[i];
        var HeadTag = document.createElement(Tag.nodeName);

        // Without CData
        if (Tag.childNodes[0])
            HeadTag.innerHTML = Tag.childNodes[0].nodeValue.replace("$_asp current_path;", WysiwygFullPath);

        // Use CData
        if (Tag.childNodes[1])
            HeadTag.innerHTML = Tag.childNodes[1].nodeValue.replace("$_asp current_path;", WysiwygFullPath);

        for (var AttributeCounter = 0; AttributeCounter < Tag.attributes.length; AttributeCounter++)
        {
            HeadTag.setAttribute(Tag.attributes[AttributeCounter].nodeName, Tag.attributes[AttributeCounter].nodeValue.replace("$_asp current_path;", WysiwygCurrentPath));
        }
        document.head.appendChild(HeadTag);
    }
}

function el_InsertContentToWysiwyg(ContentValue)
{
	var InsertContentToWysiwygFunctionName = ElanatVariant.InsertContentToWysiwygFunctionName.replace("$_asp content_value;", ContentValue);
    eval(InsertContentToWysiwygFunctionName);
}

function el_InsertEditorTemplateValueToWysiwyg()
{
    var DivTag = document.createElement("div");
    var EditorTemplateParentDiv = document.createElement("div");
    EditorTemplateParentDiv.className = "el_editor_template";
    EditorTemplateParentDiv.innerHTML = ElanatVariant.EditorTemplateValue.Replace("\n", "<br>").Replace("\"", "&quot;");
    var BrTag = document.createElement("br");

    DivTag.appendChild(EditorTemplateParentDiv);
    DivTag.appendChild(BrTag);

            
    if (document.getElementsByClassName("el_iframe_load").length > 0)
    {
        var IframeLoad = document.getElementsByClassName("el_iframe_load");
        for (var IframeIndexer = 0; IframeIndexer < IframeLoad.length; IframeIndexer++)
        {
            if (IframeLoad.item(IframeIndexer).contentWindow.document.getElementsByClassName("el_load_wysiwyg"))
                IframeLoad.item(IframeIndexer).contentWindow.el_InsertContentToWysiwyg(DivTag.innerHTML);
        }
    }

    if (document.getElementsByClassName("el_load_wysiwyg").item(0))
        el_InsertContentToWysiwyg(DivTag.innerHTML);

    ElanatVariant.EditorTemplateValue = null;
}

/* End wysiwyg */


/* Start Create Content Type Value */

function el_CreateContentTypeValue(ContentType)
{
    // Load Content Type
    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    var ContentTypeValueTag = document.createElement("div");
    var ContentTypeValue = "";

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
        {
            ContentTypeValueTag.innerHTML = xmlhttp.responseText;
            ContentTypeValue = xmlhttp.responseText;


            // Set Content Type
            var TextareaArray = document.getElementsByClassName("el_load_content_type_value");

            if (TextareaArray.length == 0)
	        {
		        el_CloseAjaxLoading();
                return;
	        }

            var TextareaArrayLength = TextareaArray.length;

            i = 0;

            while (i < TextareaArrayLength)
            {
                TextareaArray.item(i).className = TextareaArray.item(i).className.AddHtmlClass("el_hide");

                TextareaArray.item(i).parentElement.appendChild(ContentTypeValueTag);

                el_AppendJavaScriptTag(ContentTypeValue);
                el_AppendStyleTag(ContentTypeValue);

                i++;
            }
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
            return;
        }
    }
		
    xmlhttp.open("GET", ElanatVariant.SitePath + "action/create_content_type_value/Default.aspx?content_type=" + ContentType, false);
    xmlhttp.send();
}

/* End Create Content Type Value */


/* Start Show Hide Part*/

function el_ShowPart(obj) 
{
    obj.setAttribute("onclick", obj.attributes["onclick"].value.replace("el_ShowPart(this)", "el_HidePart(this)"));
    var Part = obj.parentNode;
    var PartLength = Part.childNodes.length.DecreaseToJavaScriptLength();

    var i = (0).IncreaseToJavaScriptLength();

    while (i < PartLength) 
    {
        if (Part.childNodes[i.IncreaseToJavaScriptLength()].className.Contains("el_title"))
            continue;

        Part.childNodes[i.IncreaseToJavaScriptLength()].className = Part.childNodes[i.IncreaseToJavaScriptLength()].className.DeleteHtmlClass("el_hide");
        i++;
    }
}

function el_HidePart(obj) 
{
    obj.setAttribute("onclick", obj.attributes["onclick"].value.replace("el_HidePart(this)", "el_ShowPart(this)"));
    var Part = obj.parentNode;
    var PartLength = Part.childNodes.length.DecreaseToJavaScriptLength();

    var i = (0).IncreaseToJavaScriptLength();
    while (i < PartLength) {
        if (Part.childNodes[i.IncreaseToJavaScriptLength()].className.Contains("el_title"))
            continue;

        Part.childNodes[i.IncreaseToJavaScriptLength()].className = Part.childNodes[i.IncreaseToJavaScriptLength()].className.AddHtmlClass("el_hide");
        i++;
    }
}

/* End Show Hide Part*/


function el_LoadPageWithAjax(Url, FetchScript, PostbackSectionId)
{
    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200)
        {
            if (PostbackSectionId)
                document.getElementById(PostbackSectionId).innerHTML = xmlhttp.responseText;
            else
                document.body.outerHTML = xmlhttp.responseText;

            if (FetchScript)
                el_AppendJavaScriptTag(xmlhttp.responseText);

            el_SetIframeAutoHeight();
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", Url, false);
    xmlhttp.send();
}


var OldInputType;
var TmpObj;

function el_AjaxPostBack(obj, FetchScript, PostbackSectionId, Retrieved)
{
    var TagSubmitName = obj.getAttribute("name");
    var TagSubmitValue = null;

    switch (obj.nodeName.toLowerCase())
    {
        case "input": TagSubmitValue = obj.getAttribute("value"); break;
        case "select": TagSubmitValue = obj.options[obj.selectedIndex].value;
    }

    var Form = obj;
    do
    {
        if (!Form.parentNode)
            return;

        Form = Form.parentNode;
    }
    while (Form.nodeName.toLowerCase() != "form");

    if (Form.nodeName.toLowerCase() != "form")
        return;

    el_OpenSyncAjaxLoading();


    // Delete All Warning Field Class
    el_DeleteWarningField();


    // Set Progress Tag
    el_SetProgressTag(obj, Form);


    // Set Input Type
    if (obj.getAttribute("type"))
        if (obj.getAttribute("type") != "button")
        {
            TmpObj = obj;
            OldInputType = obj.getAttribute("type");
            obj.setAttribute("type", "button");
        }

    var FormElement = Form;
    var FormAction = Form.getAttribute("action");

    var FormIsMultiPart = false;

    if (FormElement.hasAttribute("enctype"))
        if (FormElement.getAttribute("enctype") == "multipart/form-data")
            FormIsMultiPart = true;

    var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200)
        {
            el_DeleteLastAlert(PostbackSectionId);

            var TmpDiv = document.createElement("div");

            // It Used Only for Focus Load In Scroll Tag
			var TmpButtonTag = document.createElement("a");
			TmpButtonTag.id = "a_TmpFocus";
			TmpButtonTag.innerHTML= "tmp";
			TmpButtonTag.href= "tmp";
            TmpDiv.appendChild(TmpButtonTag);

            TmpDiv.appendChild(xmlhttp.responseText.toDOM());

            if (FetchScript)
                el_AppendJavaScriptTag(xmlhttp.responseText);

            // Check Use Server Retrieved
            var UseServerRetrieved = false;

            if (xmlhttp.responseURL.Contains("use_retrieved=true"))
                UseServerRetrieved = true;

            if (PostbackSectionId)
            {
                if (Retrieved || UseServerRetrieved)
                    document.getElementById(PostbackSectionId).innerHTML = TmpDiv.innerHTML;
                else
                    document.getElementById(PostbackSectionId).prepend(TmpDiv);

                window.scrollTo(0, document.getElementById(PostbackSectionId).offsetTop);
            }
            else
                if (document.getElementById("div_PageLoad"))
                {
                    if (Retrieved || UseServerRetrieved)
                        document.getElementById("div_PageLoad").innerHTML = TmpDiv.innerHTML;
                    else
                        document.getElementById("div_PageLoad").prepend(TmpDiv);

                    window.scrollTo(0, document.getElementById("div_PageLoad").offsetTop);
                }
                else
                {
                    if (Retrieved || UseServerRetrieved)
                        document.body.innerHTML = TmpDiv.innerHTML;
                    else
                        document.body.prepend(TmpDiv);

                    window.scrollTo(0, 0);
                }


			// It Used Only for Focus Load In Scroll Tag
			document.getElementById("a_TmpFocus").focus();
			document.getElementById("a_TmpFocus").outerHTML = "";


            el_SetIframeAutoHeight();

            el_LoadCaptcha();

            // Reset Input Type
            setTimeout(el_SetOldSubmitInputType, 1);
        }
    }

    if (xmlhttp.status != 0 && (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200)))
    {
        el_Alert(LanguageVariant.ConnectionError, "problem");


        // Clean Progress Value
        el_CleanProgressValue();

        el_SetIframeAutoHeight();

        el_LoadCaptcha();

        // Reset Input Type
        setTimeout(el_SetOldSubmitInputType, 1);
    }
    else
    {
        el_SetIframeAutoHeight();

        // Reset Input Type
        setTimeout(el_SetOldSubmitInputType, 1);
    }

    xmlhttp.open("POST", FormAction, true);

    if (el_HasFileInput(Form))
        xmlhttp.upload.addEventListener("progress", el_ProgressHandler, false);

    if (!FormIsMultiPart)
        xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")

    xmlhttp.addEventListener("load", function () { el_DeleteSyncAjaxLoadingTag() });
    xmlhttp.addEventListener("error", function () { el_DeleteSyncAjaxLoadingTag() });
    xmlhttp.send(el_FormDataSerialize(FormElement, TagSubmitName, TagSubmitValue, FormIsMultiPart));
}

function el_SetOldSubmitInputType()
{
    if (OldInputType == "submit")
        TmpObj.type = "submit";
}

function el_DeleteLastAlert(PostbackSectionId)
{
    if (PostbackSectionId)
    {
        while (document.getElementById(PostbackSectionId).getElementsByClassName("el_alert")[0])
        {
            document.getElementById(PostbackSectionId).getElementsByClassName("el_alert")[0].outerHTML = null;
        }
    }
    else
    {
        if (document.getElementById("div_PageLoad"))
        {
            while (document.getElementById("div_PageLoad").getElementsByClassName("el_alert")[0])
            {
                document.getElementById("div_PageLoad").getElementsByClassName("el_alert")[0].outerHTML = null;
            }
        }
        else
        {
            while (document.getElementsByClassName("el_alert")[0])
            {
                document.getElementsByClassName("el_alert")[0].outerHTML = null;
            }
        }
    }
}

/* Start Progress Bar */

function el_ProgressHandler(event)
{
    var Percent = (event.loaded / event.total) * 100;

    if (event.total >= 1048576)
        document.getElementById("div_ProgressPercentLoaded").innerHTML = (event.loaded / 1048576).toFixed(1) + "(" + Math.round(Percent) + "%)" +" / " + (event.total / 1048576).toFixed(1) + " MB";
    else
        document.getElementById("div_ProgressPercentLoaded").innerHTML = (event.loaded / 1024).toFixed(1) + "(" + Math.round(Percent) + "%)" +" / " + (event.total / 1024).toFixed(1) + " KB";

    document.getElementById("div_ProgressUploadValue").style.width = Math.round(Percent) + "%";
}

function el_SetProgressTag(obj, form)
{
    if (!el_HasFileInput(form))
        return;

    if (!document.getElementById("div_ProgressUpload"))
    {
        var DivProgressUpload = document.createElement("div");
        DivProgressUpload.id = "div_ProgressUpload";

        var DivProgressPercentLoaded = document.createElement("div");
        DivProgressPercentLoaded.id = "div_ProgressPercentLoaded";

        var DivProgressUploadValue = document.createElement("div");
        DivProgressUploadValue.id = "div_ProgressUploadValue";
        DivProgressUploadValue.style.width = "0%";

        DivProgressUpload.appendChild(DivProgressPercentLoaded);
        DivProgressUpload.appendChild(DivProgressUploadValue);

        if (obj.parentElement)
            obj.parentElement.appendChild(DivProgressUpload);
        else
            document.body.appendChild(DivProgressUpload);
    }
}

function el_CleanProgressValue()
{
    if(document.getElementById("div_ProgressUploadValue"))
        document.getElementById("div_ProgressUpload").outerHTML = "";
}

function el_HasFileInput(Form)
{   
    if (Form.getElementsByTagName("file").length > 0)
        return true;

    var InputCount = Form.getElementsByTagName("input").length;

    for (var i = 0; i < InputCount; i++)
        if (Form.getElementsByTagName("input").item(i).hasAttribute("type"))
            if (Form.getElementsByTagName("input").item(i).getAttribute("type") == "file")
                return true;

    return false;
}

/* End Progress Bar */

var ScriptList = new Array();
function el_InsertScriptFromText(HtmlSource)
{
    while (HtmlSource.indexOf("<script") > -1 || HtmlSource.indexOf("</script") > -1)
    {
        var s = HtmlSource.indexOf("<script");
        var s_e = HtmlSource.indexOf(">", s);
        var e = HtmlSource.indexOf("</script", s);
        var e_e = HtmlSource.indexOf(">", e);

        var CurrentScript = HtmlSource.substring(s + 7, s_e);

        var ScriptTag = document.createElement("script");

        while (CurrentScript.indexOf("=") > -1)
        {
            var EqualIndex = CurrentScript.indexOf("=");

            // Set Name
            var Name = CurrentScript.substring(0, EqualIndex);

            while (Name.charAt(0) == ' ')
                Name = Name.substring(1, Name.length);


            // Set Value
            var Block = CurrentScript.charAt(EqualIndex + 1);

            var Value = "";

            for (var i = 0; i < CurrentScript.length; i++)
            {
                if (CurrentScript.charAt(EqualIndex + 2 + i) == Block)
                    break;

                Value += CurrentScript.charAt(EqualIndex + 2 + i);
            }


            ScriptTag.setAttribute(Name, Value);

            CurrentScript = CurrentScript.substring(EqualIndex + 3 + Value.length, CurrentScript.length);
        }

        var TextNode = document.createTextNode(HtmlSource.substring(s_e + 1, e));
        ScriptTag.appendChild(TextNode);

        this.ScriptList.push(ScriptTag);
        HtmlSource = HtmlSource.substring(0, s) + HtmlSource.substring(e_e + 1);
    }

    return HtmlSource;
}

function el_AppendJavaScriptTag(HtmlSource)
{
    el_InsertScriptFromText(HtmlSource);

    for (var i = 0; i < this.ScriptList.length; i++)
        document.body.appendChild(this.ScriptList[i]);
}

var StyleList = new Array();
function el_InsertStyleFromText(HtmlSource)
{
    while (HtmlSource.indexOf("<style") > -1 || HtmlSource.indexOf("</style") > -1)
    {
        var s = HtmlSource.indexOf("<style");
        var s_e = HtmlSource.indexOf(">", s);
        var e = HtmlSource.indexOf("</style", s);
        var e_e = HtmlSource.indexOf(">", e);

        var CurrentStyle = HtmlSource.substring(s + 7, s_e);

        var StyleTag = document.createElement("style");

        while (CurrentStyle.indexOf("=") > -1)
        {
            var EqualIndex = CurrentStyle.indexOf("=");

            // Set Name
            var Name = CurrentStyle.substring(0, EqualIndex);

            while (Name.charAt(0) == ' ')
                Name = Name.substring(1, Name.length);


            // Set Value
            var Block = CurrentStyle.charAt(EqualIndex + 1);

            var Value = "";

            for (var i = 0; i < CurrentStyle.length; i++)
            {
                if (CurrentStyle.charAt(EqualIndex + 2 + i) == Block)
                    break;

                Value += CurrentStyle.charAt(EqualIndex + 2 + i);
            }


            StyleTag.setAttribute(Name, Value);

            CurrentStyle = CurrentStyle.substring(EqualIndex + 3 + Value.length, CurrentStyle.length);
        }

        var TextNode = document.createTextNode(HtmlSource.substring(s_e + 1, e));
        StyleTag.appendChild(TextNode);

        this.StyleList.push(StyleTag);
        HtmlSource = HtmlSource.substring(0, s) + HtmlSource.substring(e_e + 1);
    }

    return HtmlSource;
}

function el_AppendStyleTag(HtmlSource)
{
    el_InsertStyleFromText(HtmlSource);

        for (var i = 0; i < this.ScriptList.length; i++)
            {
                document.body.appendChild(this.ScriptList[i]);
                ScriptList.splice(i, 1);
            }
}

function el_FormDataSerialize(form, TagSubmitName, TagSubmitValue, FormIsMultiPart)
{       
    var FormString = "";
    var TmpFormData = new FormData();

    if (!form || form.nodeName !== "FORM")
        return;

    var i, j;
    for (i = form.elements.length - 1; i >= 0; i = i - 1)
    {
        if (form.elements[i].name === "")
            continue;

        switch (form.elements[i].nodeName)
        {
            case 'INPUT':
                switch (form.elements[i].type)
                {
                    case 'text':
                    case 'number':
                    case 'hidden':
                    case 'password':
                    case 'reset':
                        {
                            if (FormIsMultiPart)
                                TmpFormData.append(form.elements[i].name, form.elements[i].value);
                            else
                                FormString += form.elements[i].name + "=" + form.elements[i].value + "&";

                        }
                        break;
                    case 'checkbox':
                    case 'radio':
                        if (form.elements[i].checked)
                        {
                            if (FormIsMultiPart)
                                TmpFormData.append(form.elements[i].name, form.elements[i].value);
                            else
                                FormString += form.elements[i].name + "=" + form.elements[i].value + "&";
                        }
                        break;
                    case 'file':
                        {
                            var files = form.elements[i].files;

                            if (files.length == 0)
                                break;

                            var file = files[0];

                            if (FormIsMultiPart)
                                TmpFormData.append(form.elements[i].name, file, file.name);
                            else
                                FormString += form.elements[i].name + "=" + file, file.name + "&";
                        }
                        break;
                }
                break;
            case 'file':
                break;
            case 'TEXTAREA':
                {
                    if (FormIsMultiPart)
                        TmpFormData.append(form.elements[i].name, form.elements[i].value);
                    else
                        FormString += form.elements[i].name + "=" + form.elements[i].value + "&";
                }
                break;
            case 'SELECT':
                switch (form.elements[i].type)
                {
                    case 'select-one':
                        {
                            if (FormIsMultiPart)
                                TmpFormData.append(form.elements[i].name, form.elements[i].value);
                            else
                                FormString += form.elements[i].name + "=" + form.elements[i].value + "&";
                        }
                        break;
                    case 'select-multiple':
                        for (j = form.elements[i].options.length - 1; j >= 0; j = j - 1)
                        {
                            if (form.elements[i].options[j].selected)
                            {
                                if (FormIsMultiPart)
                                    TmpFormData.append(form.elements[i].name, form.elements[i].options[j].value);
                                else
                                    FormString += form.elements[i].name + "=" + form.elements[i].options[j].value + "&";
                            }
                        }
                        break;
                }
                break;
            case 'BUTTON':
                switch (form.elements[i].type)
                {
                    case 'reset':
                    case 'submit':
                    case 'button':
                        {
                            if (FormIsMultiPart)
                                TmpFormData.append(form.elements[i].name, form.elements[i].value);
                            else
                                FormString += form.elements[i].name + "=" + form.elements[i].value + "&";
                        }
                        break;
                }
                break;
        }
    }

    if (FormIsMultiPart)
        TmpFormData.append(TagSubmitName, TagSubmitValue);
    else
        FormString += TagSubmitName + "=" + TagSubmitValue;

    return (FormIsMultiPart) ? TmpFormData : FormString;
}

function el_Serialize(form)
{
    if (!form || form.nodeName !== "FORM")
	{
        return;
    }
    var i, j, q = [];
    for (i = form.elements.length - 1; i >= 0; i = i - 1)
	{
        if (form.elements[i].name === "")
		{
            continue;
        }
        switch (form.elements[i].nodeName)
		{
            case 'INPUT':
                switch (form.elements[i].type)
				{
                    case 'text':
                    case 'number':
                    case 'hidden':
                    case 'password':
                    case 'reset':
                        q.push(form.elements[i].name + "=" + encodeURIComponent(form.elements[i].value));
                        break;
                    case 'checkbox':
                    case 'radio':
                        if (form.elements[i].checked)
						{
                            q.push(form.elements[i].name + "=" + encodeURIComponent(form.elements[i].value));
                        }
                        break;
                    case 'file':
                        break;
                }
                break;
            case 'file':
                break;
            case 'TEXTAREA':
                q.push(form.elements[i].name + "=" + encodeURIComponent(form.elements[i].value));
                break;
            case 'SELECT':
                switch (form.elements[i].type)
				{
                    case 'select-one':
                        q.push(form.elements[i].name + "=" + encodeURIComponent(form.elements[i].value));
                        break;
                    case 'select-multiple':
                        for (j = form.elements[i].options.length - 1; j >= 0; j = j - 1)
						{
                            if (form.elements[i].options[j].selected)
							{
                                q.push(form.elements[i].name + "=" + encodeURIComponent(form.elements[i].options[j].value));
                            }
                        }
                        break;
                }
                break;
            case 'BUTTON':
                switch (form.elements[i].type)
				{
                    case 'reset':
                    case 'submit':
                    case 'button':
                        q.push(form.elements[i].name + "=" + encodeURIComponent(form.elements[i].value));
                        break;
                }
                break;
        }
    }
    return q.join("&");
}

/* End Ajax Postback */

function el_PageLoadWithIframeCheck()
{
    return window.self !== window.top;
}

function el_SetIframeAutoHeight()
{
    if (el_PageLoadWithIframeCheck())
    {
        var TmpId = window.frameElement.id;
        window.frameElement.id = window.frameElement.id + "TmpSelected";

        var Iframe = parent.document.getElementById(window.frameElement.id);
        Iframe.style.height = (Iframe.contentWindow.document.body.scrollHeight + 200) + "px";

        window.frameElement.id = TmpId;
    }
}

/* Start Save Action */

function el_SaveAction(obj, e)
{
    var Action = obj.getAttribute("el_action");
    var CookieName = "el_save_action:" + Action;

    if (el_GetCookie(CookieName))
        el_DeleteCookie(CookieName);
    else
        el_SetCookie(CookieName, e.type, 0.1, false);
}

function el_RunAction()
{
	if (!el_GetCookieLength())
        return;

    var CookieNameArray = el_GetAllCookieName();

    for (var i = 0; i < el_GetCookieLength() ; i++)
    {
        if (CookieNameArray[i].length > 15)
            if (CookieNameArray[i].substring(0, 15) == "el_save_action:")
            {
                var CookieName = CookieNameArray[i];

                var ActionValue = CookieName.substring(15, CookieName.length);

                var EventType = el_GetCookie(CookieName);

                if (document.querySelector("[el_action='" + ActionValue + "']"))
                {
                    eval("document.querySelector(\"[el_action='" + ActionValue + "']\").on" + EventType + "();");

                    el_SetCookie(CookieName, EventType, 0.1, false);
                }
            }
    }
}

/* End Save Action */


/* Start Warning Field */

var FieldNamesArray = [];
var ClassNamesArray = [];

function el_SetWarningField(FieldNames, ClassNames)
{
    FieldNamesArray = FieldNames.split('$');
    ClassNamesArray = ClassNames.split('$');

    var FieldNamesArrayCount = FieldNamesArray.length;

    for (var i = 0; i < FieldNamesArrayCount; i++)
        document.getElementsByName(FieldNamesArray[i])[0].className = document.getElementsByName(FieldNamesArray[i])[0].className.AddHtmlClass(ClassNamesArray[i]);
}

function el_DeleteWarningField()
{
    if (el_DeleteWarningField == null || ClassNamesArray == null)
        return;

    var FieldNamesArrayCount = FieldNamesArray.length;

    for (var i = 0; i < FieldNamesArrayCount; i++) 
        document.getElementsByName(FieldNamesArray[i])[0].className = document.getElementsByName(FieldNamesArray[i])[0].className.DeleteHtmlClass(ClassNamesArray[i]);

    FieldNamesArray = null;
    ClassNamesArray = null;
}

/* End Warning Field */


/* Start Component Table */

function el_SetBoxLayout(AddIncludeImage)
{
	var DivTable = document.getElementById("div_TableBox");

    while (DivTable.getElementsByClassName("el_table_row")[0])
    {
        if (AddIncludeImage)
            DivTable.getElementsByClassName("el_table_row")[0].className = DivTable.getElementsByClassName("el_table_row")[0].className.AddHtmlClass("el_include_image");

        DivTable.getElementsByClassName("el_table_row")[0].className = DivTable.getElementsByClassName("el_table_row")[0].className.AddHtmlClass("el_table_box");
        DivTable.getElementsByClassName("el_table_row")[0].className = DivTable.getElementsByClassName("el_table_row")[0].className.DeleteHtmlClass("el_table_row");
    }

    el_SetIframeAutoHeight();
}

function el_SetRowLayout(RemoveIncludeImage)
{
	var DivTable = document.getElementById("div_TableBox");

    while (DivTable.getElementsByClassName("el_table_box")[0])
    {
        if (RemoveIncludeImage)
            DivTable.getElementsByClassName("el_table_box")[0].className = DivTable.getElementsByClassName("el_table_box")[0].className.DeleteHtmlClass("el_include_image");

        DivTable.getElementsByClassName("el_table_box")[0].className = DivTable.getElementsByClassName("el_table_box")[0].className.AddHtmlClass("el_table_row");
        DivTable.getElementsByClassName("el_table_box")[0].className = DivTable.getElementsByClassName("el_table_box")[0].className.DeleteHtmlClass("el_table_box");
    }
}

/* End Component Table */

/* Start Group Section Show */

function el_ShowGroupSection(SectionId, GroupClassName)
{
	var GroupTag = document.getElementsByClassName(GroupClassName);
    var GroupClassNameLength = GroupTag.length;

    for (var i = 0; i < GroupClassNameLength; i++)
        GroupTag.item(i).className = GroupTag.item(i).className.AddHtmlClass("el_hidden");

    var Section = document.getElementById(SectionId);
    Section.className = Section.className.DeleteHtmlClass("el_hidden");
}

/* End Group Section Show */

/* Start Alert */

function el_Alert(AlertText, Priority)
{
    if (!Priority)
        Priority = "none";

    var Alert = ElanatVariant.Alert;
    Alert = Alert.replace("$_asp alert_text;", AlertText);
    Alert = Alert.replace("$_asp priority;", Priority);
    Alert = Alert.replace(/&quot;/g, "\"");

    var TmpDiv = document.createElement("div");
    TmpDiv.innerHTML = Alert;
    document.body.innerHTML = TmpDiv.outerHTML + document.body.innerHTML;

    window.scrollTo(0, 0);
}

/* End Alert */


/* Start Iframe */

function el_PageLoadWithIframeCheck()
{
    return window.self !== window.top;
}

/* End Iframe */

/* Start Fix Asp.net Error */

/* Start List Value Checked */

function el_SetListValueChecked(CheckBoxListId, InputId)
{
    var value = document.getElementById(InputId).value;
    var ArrayValue = value.split(",");

    var ICheckBoxList = 0;
    while (true)
    {
        if (!document.getElementById(CheckBoxListId + "_" + ICheckBoxList))
            break;

        document.getElementById(CheckBoxListId + "_" + ICheckBoxList).checked = false;

        for (var IArray = 0; IArray < ArrayValue.length; IArray++)
        {
            if (document.getElementById(CheckBoxListId + "_" + ICheckBoxList).value == ArrayValue[IArray])
            {
                document.getElementById(CheckBoxListId + "_" + ICheckBoxList).checked = true;
                break;
            }
        }

        ICheckBoxList++;
    }
}

/* End List Value Checked */

/* Start List Value Selected */

function el_SetListValueSelected(DropDownListId, InputId)
{
    var value = document.getElementById(InputId).value;
    document.getElementById(DropDownListId).value = value;
}

/* End List Value Selected */

/* End Fix Asp.net Error */


/* Start Confirm Message */

var ConfirmVariant = new Object();
ConfirmVariant.ConfirmStatus = "none";

function el_Until(Function) 
{
  const Poll = resolve => { if(Function()) resolve(); else setTimeout(_ => Poll(resolve), 200); }

  return new Promise(Poll);
}

async function el_Confirm(Message)
{
    var div_ConfirmMessageFullPage = document.createElement("div");
    div_ConfirmMessageFullPage.className = "el_confirm_message_full_page";

    var div_ConfirmMessageBox = document.createElement("div");
    div_ConfirmMessageBox.className = "el_confirm_message_box";
    div_ConfirmMessageBox.setAttribute("onclick", "el_CloseConfirmMessage()");

    var div_ConfirmMessage = document.createElement("div");
    div_ConfirmMessage.className = "el_confirm_message";
    div_ConfirmMessage.setAttribute("onclick", "javascript:void(0)");


    var div_Message = document.createElement("div");
    div_Message.className = "el_message";

    var MessageText = document.createTextNode(Message);

    div_Message.appendChild(MessageText);

    div_ConfirmMessage.appendChild(div_Message)

    var div_ButtonBox = document.createElement("div");
    div_ButtonBox.className = "el_button_box";

    var div_Okay = document.createElement("div");
    div_Okay.className = "el_okay";
    div_Okay.setAttribute("onclick", "el_AcceptConfirmMessage()");

    var OkayTextLanguage = document.createTextNode(LanguageVariant.Okay);

    div_Okay.appendChild(OkayTextLanguage);

    var div_No = document.createElement("div");
    div_No.className = "el_no";
    div_No.setAttribute("onclick", "el_CloseConfirmMessage()");

    var NoTextLanguage = document.createTextNode(LanguageVariant.No);

    div_No.appendChild(NoTextLanguage);


    div_ButtonBox.appendChild(div_Okay);
    div_ButtonBox.appendChild(div_No);

    div_ConfirmMessage.appendChild(div_ButtonBox);

    div_ConfirmMessageFullPage.appendChild(div_ConfirmMessageBox);

    div_ConfirmMessageFullPage.appendChild(div_ConfirmMessage);

   
    (el_PageLoadWithIframeCheck()) ? parent.document.body.appendChild(div_ConfirmMessageFullPage) : document.body.appendChild(div_ConfirmMessageFullPage);
	
	await el_Until(_ => ((el_PageLoadWithIframeCheck()) ? parent.ConfirmVariant.ConfirmStatus != "none" : ConfirmVariant.ConfirmStatus != "none"));
	
	var ReturnValue = ((el_PageLoadWithIframeCheck()) ? parent.ConfirmVariant.ConfirmStatus == "true" : ConfirmVariant.ConfirmStatus == "true");

	(el_PageLoadWithIframeCheck()) ? parent.ConfirmVariant.ConfirmStatus = "none" : ConfirmVariant.ConfirmStatus = "none"

	return ReturnValue;
}

function el_AcceptConfirmMessage()
{
    (el_PageLoadWithIframeCheck()) ? parent.document.getElementsByClassName("el_confirm_message_full_page")[0].outerHTML = null : document.getElementsByClassName("el_confirm_message_full_page")[0].outerHTML = null;

    (el_PageLoadWithIframeCheck()) ? parent.ConfirmVariant.ConfirmStatus = "true" : ConfirmVariant.ConfirmStatus = "true";
}

function el_CloseConfirmMessage()
{
    (el_PageLoadWithIframeCheck()) ? parent.document.getElementsByClassName("el_confirm_message_full_page")[0].outerHTML = null : document.getElementsByClassName("el_confirm_message_full_page")[0].outerHTML = null;

    (el_PageLoadWithIframeCheck()) ? parent.ConfirmVariant.ConfirmStatus = "false" : ConfirmVariant.ConfirmStatus = "false";
}

function el_PageLoadWithIframeCheck()
{
	return window.self !== window.top;
}

/* End Confirm Message */


/* Start Calendar */

function el_SetCalendarYear(YearDiff, CalendarPath)
{
    var CurrentDate = document.getElementById("hdn_CurrentDate").value;
    var Array = CurrentDate.split("-");

    var Year = Array[0];
    var Mount = Array[1];
    var Day = Array[2];

    document.getElementById("hdn_CurrentDate").value = (parseInt(Year) + YearDiff) + "-" + Mount + "-" + Day;

    el_SubmitCalendar(CalendarPath);
}

function el_SetCalendarMount(obj, CalendarPath)
{
    var CurrentDate = document.getElementById("hdn_CurrentDate").value;
    var Array = CurrentDate.split("-");

    var Year = Array[0];
    var Mount = obj.value;
    var Day = Array[2];

    document.getElementById("hdn_CurrentDate").value = Year + "-" + Mount + "-" + Day;

    el_SubmitCalendar(CalendarPath);
}

function el_SetCalendarDay(obj, SelectedDay)
{
    if (!SelectedDay)
        return;

    var CurrentDate = document.getElementById("hdn_CurrentDate").value;
    var Array = CurrentDate.split("-");

    var Year = Array[0];
    var Mount = Array[1];
    var Day = SelectedDay;

    document.getElementById("hdn_CurrentDate").value = Year + "-" + Mount + "-" + Day;

    var CalendarDay = document.getElementById("div_Calendar").childNodes;
    var CalendarDayLength = CalendarDay.length;

    for (var i = 0; i < CalendarDayLength; i++)
        if (CalendarDay.item(i).className == "el_select")
            CalendarDay.item(i).className = null;

    obj.setAttribute("class", "el_select");
}

function el_SubmitCalendar(CalendarPath)
{
    var CurrentDate = document.getElementById("hdn_CurrentDate").value;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function () 
	{
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
		{
            var CalendarPostBack = document.getElementById("div_CalendarPostBack");
            CalendarPostBack.innerHTML = xmlhttp.responseText;
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", ElanatVariant.SitePath + "include/calendar/" + CalendarPath + "/server/Default.aspx?current_date=" + CurrentDate, false);
    xmlhttp.send();
}

/* End Calendar */

/* Start AddOns Method */

/* Start Editor Template */

/* Start Plus 14 */

function el_ShowPlus14Picture(obj)
{
    if(obj.getElementsByTagName("img")[0].getAttribute("el_plus14") == "true")
        obj.getElementsByTagName("img")[0].setAttribute("el_plus14", "false");
    else
        obj.getElementsByTagName("img")[0].setAttribute("el_plus14", "true");
}

/* End Plus 14 */

/* Start Image Preview */

function el_ShowImagePreview(obj, IsThumbnail)
{
    var DivTag = document.createElement("div");
    DivTag.id = "div_" + obj.id;
    DivTag.className = "el_hide";

    var ImgTag = document.createElement("img");
    ImgTag.src = (IsThumbnail)? obj.src.replace("/thumb/", "/") : obj.src;
    ImgTag.style.width = "100%";
    ImgTag.style.height = "100%";

    DivTag.appendChild(ImgTag);
    document.body.appendChild(DivTag);
    el_OpenBox(DivTag.id);
}

/* End Image Preview */

/* End Editor Template */

/* End AddOns Method */

/* Start Keep Login */

function el_KeppLogin(StartAddOnInstall)
{
    var UseStartAddOnInstall = (StartAddOnInstall)? "?use_start_add_on_install=true" : "";
    
    if (el_GetCookie("el_current_user-keep_login_random_text"))
    {
        window.location = window.location.protocol + "//" + window.location.host + "/action/keep_login/Default.aspx" + UseStartAddOnInstall;
    }
}

function el_KeppLoginAjax()
{
    if (el_GetCookie("el_current_user-keep_login_random_text"))
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
	    {
            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }

        xmlhttp.open("GET", ElanatVariant.SitePath + "action/keep_login/Default.aspx", false);
        xmlhttp.send();
    }
}

function el_StartReloadElanat()
{
    var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {

    }

    xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/about/action/ReloadElanat.aspx", false);
    xmlhttp.send();
}

/* Start Keep Login */