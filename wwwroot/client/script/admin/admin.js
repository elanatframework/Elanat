/* Start Add-ons Menu */

var FirstLiPath = ElanatVariant.DefaultSystem;

function el_ShowAddOnsGroup(obj, SystemGroupName, UseUrlReplace)
{
    if (el_GetQueryStringFromUrl(document.URL))
    {
        // Check Url Query String Change Event
        var QueryStringValue = el_GetQueryStringFromUrl(document.URL);
        var QueryStringArray = el_GetArrayFromQueryString(QueryStringValue);

        if (QueryStringArray["current_group_name"] && QueryStringArray["component_name"] && UseUrlReplace)
        {
            SystemGroupName = QueryStringArray["current_group_name"];
            obj = document.getElementById("a_Group_" + SystemGroupName);
        }
    }
    
	
    var SystemMenu = document.getElementsByClassName("el_system_menu_item");

    if (SystemMenu.length == 0)
        return;

    var SystemMenuLength = SystemMenu.length;

    i = 0;

    while (i < SystemMenuLength)
    {
        if (SystemMenu.item(i).className != "el_menu_zone")
            SystemMenu.item(i).className = SystemMenu.item(i).className.AddHtmlClass("el_menu_zone");

        SystemMenu.item(i).className = SystemMenu.item(i).className.DeleteHtmlClass("el_menu_selected");

        i++;
    }

    obj.className = obj.className.AddHtmlClass("el_menu_selected");
    obj.className = obj.className.DeleteHtmlClass("el_menu_zone");
    FirstLiPath = obj.innerHTML;

    el_ShowComponentGroup("div_ComponentGroup_" + SystemGroupName);
    el_ShowModuleGroup("div_ModuleGroup_" + SystemGroupName);
    el_ShowExtraHelperGroup("div_ExtraHelperGroup_" + SystemGroupName);
}

function el_ShowComponentGroup(GroupId)
{
	el_HideAllComponentGroup();

    if (document.getElementById(GroupId))
        document.getElementById(GroupId).className = document.getElementById(GroupId).className.DeleteHtmlClass("el_hide");
}

function el_HideAllComponentGroup()
{
    var ComponentGroup = document.getElementsByClassName("el_component_group");
    var ComponentGroupLength = ComponentGroup.length;

    var i = 0;

    while (i < ComponentGroupLength)
    {
        ComponentGroup.item(i).className = ComponentGroup.item(i).className.AddHtmlClass("el_hide");
        i++;
    }
}

function el_ShowModuleGroup(GroupId)
{
	el_HideAllModuleGroup();

    if (document.getElementById(GroupId))
        document.getElementById(GroupId).className = document.getElementById(GroupId).className.DeleteHtmlClass("el_hide");
}

function el_HideAllModuleGroup()
{
    var ModuleGroup = document.getElementsByClassName("el_module_group");
    var ModuleGroupLength = ModuleGroup.length;

    var i = 0;

    while (i < ModuleGroupLength)
    {
        ModuleGroup.item(i).className = ModuleGroup.item(i).className.AddHtmlClass("el_hide");
        i++;
    }
}

function el_ShowExtraHelperGroup(GroupId)
{
	el_HideAllExtraHelperGroup();

    if (document.getElementById(GroupId))
        document.getElementById(GroupId).className = document.getElementById(GroupId).className.DeleteHtmlClass("el_important_hide");
}

function el_HideAllExtraHelperGroup()
{
    var ExtraHelperGroup = document.getElementsByClassName("el_extra_helper_group");
    var ExtraHelperGroupLength = ExtraHelperGroup.length;

    var i = 0;

    while (i < ExtraHelperGroupLength)
    {
        ExtraHelperGroup.item(i).className = ExtraHelperGroup.item(i).className.AddHtmlClass("el_important_hide");
        i++;
    }
}

/* End Add-ons Menu */

function el_HideAllContentStatus()
{
	document.getElementById("div_ContentInactive").className = document.getElementById("div_ContentInactive").className.AddHtmlClass("el_hidden");
    document.getElementById("div_ContentTrash").className = document.getElementById("div_ContentTrash").className.AddHtmlClass("el_hidden");
    document.getElementById("div_ContentDraft").className = document.getElementById("div_ContentDraft").className.AddHtmlClass("el_hidden");

    document.getElementById("a_SetDraftLayout").className = document.getElementById("a_SetDraftLayout").className.DeleteHtmlClass("el_content_status_selected");
    document.getElementById("a_SetInactiveLayout").className = document.getElementById("a_SetInactiveLayout").className.DeleteHtmlClass("el_content_status_selected");
    document.getElementById("a_SetTrashLayout").className = document.getElementById("a_SetTrashLayout").className.DeleteHtmlClass("el_content_status_selected");
}

function el_ShowContentStatus(obj, ContentStatusId)
{
	el_HideAllContentStatus();
    obj.className = obj.className.AddHtmlClass("el_content_status_selected");
    document.getElementById(ContentStatusId).className = document.getElementById(ContentStatusId).className.DeleteHtmlClass("el_hidden");
    FirstLiPath = obj.innerHTML;
}

CurrentComponent = ElanatVariant.DefaultComponent;

function el_SetPage(obj, CurrentGroupName, CurrentPageName, CurrentGroupLocalName, CurrentPageLocalName)
{
	el_SetAdminTitle(CurrentPageLocalName);

    Path = document.getElementById("div_Path");

    var Span = document.createElement("span");

    var Home = document.createElement("li");
    Home.appendChild(Span);

    var CurrentGroup = document.createElement("li");
    CurrentGroup.innerHTML = Span.outerHTML + "<a>" + CurrentGroupLocalName + "</a>" + Span.outerHTML;

    var CurrentPage = document.createElement("li");
    CurrentPage.innerHTML = Span.outerHTML + "<a>" + CurrentPageLocalName + "</a>" + Span.outerHTML;

    Path.innerHTML = Home.outerHTML + CurrentGroup.outerHTML + CurrentPage.outerHTML;

    var CurrentGroup = document.getElementById("a_" + "Group_" + CurrentGroupName.replace(/ /g, ""));
    CurrentGroup.click();

    window.history.pushState("", "", "?current_group_name=" + CurrentGroupName + "&component_name=" + CurrentPageName);

    this.CurrentComponent = CurrentPageName;
}

function el_SetAdminTitle(CurrentPageName)
{
    document.title = LanguageVariant.Admin + " - " + CurrentPageName;
}

function el_SetPagePathFromQueryString()
{
    if (!el_GetQueryStringFromUrl(document.URL))
        return;

	var QueryStringValue = el_GetQueryStringFromUrl(document.URL);

    var QueryStringArray = el_GetArrayFromQueryString(QueryStringValue);

    if (QueryStringArray["current_group_name"] && QueryStringArray["component_name"])
    {
        el_SetServerPage(QueryStringArray["current_group_name"], QueryStringArray["component_name"]);
    }
}

function el_SetPageContentFromHash()
{
	var HashValue = el_GetHashFromUrl(document.URL);

    var HashArray = el_GetArrayFromQueryString(HashValue);

    if (HashArray["current_group_name"] && HashArray["component_name"])
    {
        el_SetServerPage(HashArray["current_group_name"], HashArray["component_name"]);
    }
}

function el_SetServerPage(CurrentGroupName, CurrentPageName)
{
    var TmpCurrentComponent = document.getElementById("a_" + CurrentPageName);

    var CurrentGroup = document.getElementById("a_" + "Group_" + CurrentGroupName.replace(/ /g, ""));
    CurrentGroup.click();

    Path = document.getElementById("div_Path");

    var Span = document.createElement("span");

    var Home = document.createElement("li");
    Home.appendChild(Span);

    var CurrentGroup = document.createElement("li");
    CurrentGroup.innerHTML = Span.outerHTML + "<a>" + TmpCurrentComponent.getAttribute("el_component_category_local_name") + "</a>" + Span.outerHTML;

    var CurrentPage = document.createElement("li");
    CurrentPage.innerHTML = Span.outerHTML + "<a>" + TmpCurrentComponent.getAttribute("el_component_local_name") + "</a>" + Span.outerHTML;

    Path.innerHTML = Home.outerHTML + CurrentGroup.outerHTML + CurrentPage.outerHTML;

    this.CurrentComponent = CurrentPageName;
}

function el_GetHashFromUrl(Url)
{	
    var a = document.createElement("a");
    a.href = Url;
    return a.hash.replace(/^#/, "");
}

function el_GetQueryStringFromUrl(Url)
{	
    return Url.GetTextAfter("?");
}

/* Start Extra Helper */
function el_OpenExtraHelper(ExtraHelperId, ExtraHelperDirectoryPath)
{
    var DivId = 'div_ExtraHelper_' + ExtraHelperId;

    if (!document.getElementById(DivId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
			{
                var DivTag = document.createElement("div");
                DivTag.id = DivId;
                DivTag.className = "el_hidden";

                DivTag.innerHTML = xmlhttp.responseText;
                el_AppendJavaScriptTag(xmlhttp.responseText);
                el_AppendStyleTag(xmlhttp.responseText);

                document.body.appendChild(DivTag);
                

                var XmlDoc = el_LoadXMLDoc(ElanatVariant.SitePath + "add_on/extra_helper/" + ExtraHelperDirectoryPath + "/catalog.xml");
                var ExtraHelperCurrentPath = ElanatVariant.SitePath + "add_on/extra_helper/" + ExtraHelperDirectoryPath + "/";

                // Set Extra Helper Static Head
                var ExtraHelperStaticHeadTag = XmlDoc.getElementsByTagName("extra_helper_static_head")[0];

                for (var i = 0; i < ExtraHelperStaticHeadTag.childNodes.length ; i++)
                {
                    var Tag = ExtraHelperStaticHeadTag.childNodes[i];

                    if (Tag.nodeType === Node.TEXT_NODE)
                        continue;

                    // Initialization
                    var HeadTag = document.createElement("div");

                    // Use CData
                    if (Tag.nodeName == "#cdata-section")
                    {
                        var TagValue = Tag.nodeValue.replace("$_asp current_path;", ExtraHelperCurrentPath);
                        el_AppendJavaScriptTag(TagValue);
                        el_AppendStyleTag(TagValue);
                        continue;
                    }

                    // Without CData
                    if (Tag.nodeName != "#cdata-section")
                    {
                        var TagValue = Tag.outerHTML.replace("<![CDATA[", "").replace("]]>", "").replace("$_asp current_path;", ExtraHelperCurrentPath);
                        el_AppendJavaScriptTag(TagValue);
                        el_AppendStyleTag(TagValue);
                        continue;
                    }
                }

                // Set Extra Helper Load Tag
                var UseCDataCheker = (XmlDoc.getElementsByTagName("extra_helper_load_tag")[0].childNodes[1]) ? 1 : 0;
                var ExtraHelperLoadTagValue = XmlDoc.getElementsByTagName("extra_helper_load_tag")[0].childNodes[UseCDataCheker].nodeValue;
                var DivLoadTag = document.createElement("div");
                DivLoadTag.className = "el_hide";
                DivLoadTag.innerHTML = ExtraHelperLoadTagValue.replace("$_asp current_path;", ExtraHelperCurrentPath);
                DivTag.appendChild(DivLoadTag);


                el_OpenBox(DivId);
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
			}   
        }

        xmlhttp.open("GET", ElanatVariant.SitePath + "action/get_extra_helper/Default.aspx?extra_helper_id=" + ExtraHelperId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox(DivId);
}
/* End Extra Helper */

/* Start Editor Template */
function el_OpenEditorTemplate(EditorTemplateId, EditorTemplateDirectoryPath)
{
    var DivId = 'div_EditorTemplate_' + EditorTemplateId;

    if (!document.getElementById(DivId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
			{
                var DivTag = document.createElement("div");
                DivTag.id = DivId;
                DivTag.className = "el_hidden";

                DivTag.innerHTML = xmlhttp.responseText;
                el_AppendJavaScriptTag(xmlhttp.responseText);
                el_AppendStyleTag(xmlhttp.responseText);

                document.body.appendChild(DivTag);
                el_OpenBox(DivId);
                
                var XmlDoc = el_LoadXMLDoc(ElanatVariant.SitePath + "add_on/editor_template/" + EditorTemplateDirectoryPath + "/catalog.xml");
                var EditorTemplateCurrentPath = ElanatVariant.SitePath + "add_on/editor_template/" + EditorTemplateDirectoryPath + "/";

                // Set Editor Template Static Head
                var EditorTemplateStaticHeadTag = XmlDoc.getElementsByTagName("editor_template_static_head")[0];

                for (var i = 0; i < EditorTemplateStaticHeadTag.childNodes.length ; i++)
                {
                    var Tag = EditorTemplateStaticHeadTag.childNodes[i];

                    if (Tag.nodeType === Node.TEXT_NODE)
                        continue;

                    // Initialization
                    var HeadTag = document.createElement("div");

                    // Use CData
                    if (Tag.nodeName == "#cdata-section")
                    {
                        var TagValue = Tag.nodeValue.replace("$_asp current_path;", EditorTemplateCurrentPath);
                        el_AppendJavaScriptTag(TagValue);
                        el_AppendStyleTag(TagValue);
                        continue;
                    }

                    // Without CData
                    if (Tag.nodeName != "#cdata-section")
                    {
                        var TagValue = Tag.outerHTML.replace("<![CDATA[", "").replace("]]>", "").replace("$_asp current_path;", EditorTemplateCurrentPath);
                        el_AppendJavaScriptTag(TagValue);
                        el_AppendStyleTag(TagValue);
                        continue;
                    }
                }

                // Set Editor Template Load Tag
                var UseCDataCheker = (XmlDoc.getElementsByTagName("editor_template_load_tag")[0].childNodes[1]) ? 1 : 0;
                var EditorTemplateLoadTagValue = XmlDoc.getElementsByTagName("editor_template_load_tag")[0].childNodes[UseCDataCheker].nodeValue;
                var DivLoadTag = document.createElement("div");
                DivLoadTag.className = "el_hide";
                DivLoadTag.innerHTML = EditorTemplateLoadTagValue.replace("$_asp current_path;", EditorTemplateCurrentPath);
                DivTag.appendChild(DivLoadTag);
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
			}   
        }

        xmlhttp.open("GET", ElanatVariant.SitePath + "action/get_editor_template/Default.aspx?editor_template_id=" + EditorTemplateId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox(DivId);
}
/* End Editor Template */

function el_ViewExtraHelperList() 
{
    var DivId = 'div_ExtraHelperList';
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

        xmlhttp.open("GET", ElanatVariant.SitePath + "action/show_extra_helper_list/Default.aspx", false);
        xmlhttp.send();
    }
    else
        el_OpenBox(DivId);
}

function el_ViewLogsList() 
{
    var DivId = 'div_LogsList';
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

        xmlhttp.open("GET", ElanatVariant.SitePath + "action/get_log_list/Default.aspx", false);
        xmlhttp.send();
    }
    else
        el_OpenBox(DivId);
}

function el_ViewLog(LogName)
{
    var DivId = 'div_Log_' + LogName;
    if (!document.getElementById(DivId))
	{
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
			{
                var DivTag = document.createElement("div");
                DivTag.id = DivId;
                DivTag.className = "el_left_to_right";
                DivTag.className = DivTag.className.AddHtmlClass("el_hidden");
                DivTag.innerHTML = xmlhttp.responseText;
                document.body.appendChild(DivTag);
                el_OpenBox(DivId);
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
			}
        }

        xmlhttp.open("GET", ElanatVariant.SitePath + "add_on/extra_helper/show_logs_list/action/show_log/Default.aspx?log_name=" + LogName, false);
        xmlhttp.send();
    }
    else
        el_OpenBox(DivId);
}

function el_ViewAccess() 
{
    var DivId = 'div_Access';
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

        xmlhttp.open("GET", ElanatVariant.SitePath + "action/get_access/Default.aspx", false);
        xmlhttp.send();
    }
    else
        el_OpenBox(DivId);
}

/* Start Page Load */

function el_ComponentLoadWithAjax(Path)
{
	var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    var DivMain = document.getElementById("div_Main");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200)
            DivMain.innerHTML = xmlhttp.responseText;

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }
    xmlhttp.open("GET", Path, false);
    xmlhttp.send();
}

function el_ComponentLoadWithIframe(Path)
{
	var IframePageLoad = ElanatVariant.IframePageLoad;
    IframePageLoad = IframePageLoad.replace("$_asp page_path;", Path);
    IframePageLoad = IframePageLoad.replace(/&quot;/g, "\"");

    var DivMain = document.getElementById("div_Main");
    var TmpDiv = document.createElement("div");
    TmpDiv.innerHTML = IframePageLoad;
    DivMain.innerHTML = TmpDiv.outerHTML;
}

/* End Page Load */


/* Start legal Characters */

function el_RemoveIllegalCharacters(Text)
{
    var Html = Text;
    Html = Html.replace(/&/g, "&amp;");
    Html = Html.replace(/'/g, "&apos;");
    Html = Html.replace(/</g, "&lt;");
    Html = Html.replace(/>/g, "&gt;");
    Html = Html.replace(/"/g, "&quot;");
    return Html;
}

function el_RemoveLegalCharacters(Text)
{
    var Xml = Text;
    Xml = Xml.replace(/&amp;/g, "&");
    Xml = Xml.replace(/&apos;/g, "'");
    Xml = Xml.replace(/&lt;/g, "<");
    Xml = Xml.replace(/&gt;/g, ">");
    Xml = Xml.replace(/&quot;/g, "\"");
    return Xml;
}

/* End legal Characters */


/* Start Module */

function el_ViewModuleOption(ModuleId)
{
    if (!document.getElementById("div_ViewModuleOption" + ModuleId))
    {
        var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function ()
        {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
            {
                var DivTag = document.createElement("div");
                DivTag.id = "div_ViewModuleOption" + ModuleId;
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
		
        xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/module/action/ViewModuleOption.aspx?module_id=" + ModuleId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox("div_ViewModuleOption" + ModuleId);
}

/* End Module */


/* Start Add On Not Access */

function el_SetComponentNotAccess(obj)
{
    obj.src = ElanatVariant.SitePath + "client/image/add_on_not_access/component.png";
}

function el_SetModuleOptionNotAccess(obj)
{
    obj.src = ElanatVariant.SitePath + "client/image/add_on_not_access/module_option.png";
}

/* End Add On Not Access */

/* Start Menu Hide Show */

function el_SetLeftAndRightMenuShowButton()
{
    var LeftMenu = document.getElementById("div_LeftLocation");
    var RightMenu = document.getElementById("div_RightLocation");
    
    if (LeftMenu.getElementsByClassName("el_left_menu_menu").length > 0)
    {
        el_SetLeftMenuShowButton();
    }

    if (RightMenu.getElementsByClassName("el_right_menu_menu").length > 0)
    {
        el_SetRightMenuShowButton();
    }
}

function el_SetLeftMenuShowButton()
{
    var DivShowLeftMenu = document.createElement("div");
    DivShowLeftMenu.id = "div_ShowLeftMenu";
    DivShowLeftMenu.setAttribute("onclick","el_ShowLeftMenu()");

    document.body.appendChild(DivShowLeftMenu);
}

function el_SetRightMenuShowButton()
{
    var DivShowRightMenu = document.createElement("div");
    DivShowRightMenu.id = "div_ShowRightMenu";
    DivShowRightMenu.setAttribute("onclick","el_ShowRightMenu()");

    document.body.appendChild(DivShowRightMenu);
}

function el_CloseLeftMenu()
{
    document.getElementById("div_LeftLocation").className = document.getElementById("div_LeftLocation").className.DeleteHtmlClass("el_show");
    document.getElementById("div_LeftLocation").className = document.getElementById("div_LeftLocation").className.AddHtmlClass("el_hide");

    el_SetLeftMenuShowButton();
}

function el_CloseRightMenu()
{
    document.getElementById("div_RightLocation").className = document.getElementById("div_RightLocation").className.DeleteHtmlClass("el_show");
    document.getElementById("div_RightLocation").className = document.getElementById("div_RightLocation").className.AddHtmlClass("el_hide");

    el_SetRightMenuShowButton();
}

function el_ShowLeftMenu()
{
    document.getElementById("div_LeftLocation").className = document.getElementById("div_LeftLocation").className.DeleteHtmlClass("el_hide");
    document.getElementById("div_LeftLocation").className = document.getElementById("div_LeftLocation").className.AddHtmlClass("el_show");

    el_RemoveTag("div_ShowLeftMenu");
}

function el_ShowRightMenu()
{
    document.getElementById("div_RightLocation").className = document.getElementById("div_RightLocation").className.DeleteHtmlClass("el_hide");
    document.getElementById("div_RightLocation").className = document.getElementById("div_RightLocation").className.AddHtmlClass("el_show");

    el_RemoveTag("div_ShowRightMenu");
}

/* End Menu Hide Show */