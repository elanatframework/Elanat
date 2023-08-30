/* Start Bold-Normal Body Text */

function el_SetBodyTextToBold(obj)
{
	document.body.className = document.body.className.AddHtmlClass("el_bold_text");
    obj.setAttribute("onclick", "el_SetBodyTextToNormal(this)");
    obj.setAttribute("alt", "b");
    obj.className = obj.className.DeleteHtmlClass("el_bold");
    obj.className = obj.className.AddHtmlClass("el_no_bold");
}

function el_SetBodyTextToNormal(obj)
{
	document.body.className = document.body.className.DeleteHtmlClass("el_bold_text");
    obj.setAttribute("onclick", "el_SetBodyTextToBold(this)");
    obj.setAttribute("alt", "B");
    obj.className = obj.className.DeleteHtmlClass("el_no_bold");
    obj.className = obj.className.AddHtmlClass("el_bold");
}

/* End Bold-Normal Body Text */

function el_ViewUserInfo(UserId)
{
    DivId = "div_UserInfo_" + UserId;
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
                DivTag.setAttribute("box_group", "user");
                DivTag.innerHTML = xmlhttp.responseText;
                document.body.appendChild(DivTag);
                el_OpenBox(DivId);
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }

        xmlhttp.open("GET", ElanatVariant.SitePath + "action/show_user_info/?user_id=" + UserId, false);
        xmlhttp.send();
    }
    else
        el_OpenBox(DivId);
}

function el_ViewComment(ContentId)
{
    DivId = "div_comment_" + ContentId;
    if (document.getElementById(DivId))
        document.getElementById(DivId).outerHTML = null;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
        {
            var DivTag = document.createElement("div");
            DivTag.id = DivId;
            DivTag.className = "el_hidden";
            DivTag.innerHTML = xmlhttp.responseText;
            el_AppendJavaScriptTag(xmlhttp.responseText);
            el_AppendStyleTag(xmlhttp.responseText);
            document.body.appendChild(DivTag);
            el_OpenBox(DivTag.id);
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", ElanatVariant.SitePath + "page/comment/?show_comment=true&content_id=" + ContentId, false);
    xmlhttp.send();
}

function el_OpenCommentReply(ContentId, CommentId) 
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

function el_OpenContentReply(ContentId)
{
    DivId = "div_content_reply_" + ContentId;
    if (document.getElementById(DivId))
        document.getElementById(DivId).outerHTML = null;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
        {
            var DivTag = document.createElement("div");
            DivTag.id = DivId;
            DivTag.className = "el_hidden";
            DivTag.innerHTML = xmlhttp.responseText;
            el_AppendJavaScriptTag(xmlhttp.responseText);
            el_AppendStyleTag(xmlhttp.responseText);
            document.body.appendChild(DivTag);
            el_OpenBox(DivTag.id);

            el_LoadCaptcha();
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");

            el_LoadCaptcha();
        }
    }

    xmlhttp.open("GET", ElanatVariant.SitePath + "page/content_reply/?content_id=" + ContentId, false);
    xmlhttp.send();
}

function el_SubmitRate(ContentId, Rate) 
{
    if (navigator.cookieEnabled)
	{
        if (!el_GetCookie("el_rating_content_id_" + ContentId))
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true") 
				{
                    var RatingContentId = document.getElementById("RatingContentId" + ContentId);
                    var NumberOfVoted = parseInt(RatingContentId.getAttribute("number_of_voted")) + 1;
                    var Rating = parseInt(RatingContentId.getAttribute("rating")) + parseInt(Rate);

                    RatingContentId.className = "el_rating_" + (((Rating / NumberOfVoted) * 4).toFixed() * 5);
                    RatingContentId.setAttribute("rating", Rating);
                    RatingContentId.setAttribute("number_of_voted", NumberOfVoted);

                    el_SetCookie("el_rating_content_id_" + ContentId, Rate, 100)
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }
			
            xmlhttp.open("GET", ElanatVariant.SitePath + "action/set_rating/Default.aspx?content_id=" + ContentId + '&rate=' + Rate, false);
            xmlhttp.send();

        }
    }
}

function el_SendEmailContent(ContentId)
{
    DivId = "div_SendEmailContent" + ContentId;
    if (document.getElementById(DivId))
        document.getElementById(DivId).outerHTML = null;

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "false")
        {
            var DivTag = document.createElement("div");
            DivTag.id = DivId;
            DivTag.className = "el_hidden";
            DivTag.innerHTML = xmlhttp.responseText;
            el_AppendJavaScriptTag(xmlhttp.responseText);
            el_AppendStyleTag(xmlhttp.responseText);
            document.body.appendChild(DivTag);
            el_OpenBox(DivTag.id);
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }

    xmlhttp.open("GET", ElanatVariant.SitePath + "page/email/Default.aspx?content_id=" + ContentId, false);
    xmlhttp.send();
}

/* Start Resize Browser */

function el_SetResizeWindow(BrowserSize, UnifyRightLeftLocation)
{
	var BodyClassSize = "el_size_" + BrowserSize;
    if (document.body.getAttribute("class"))
            (document.body.className += " " + BodyClassSize)
        else
        document.body.setAttribute("class", BodyClassSize);

    // Menu Responsive
    if(BrowserSize < 720)
        el_SetMenuResponsive();
    else
        el_ZoneMenuResponsive();
}

function el_DeleteResizeWindow()
{
    if (document.body.getAttribute("class"))
    {
        if (document.body.className.indexOf("el_size_") > -1)
        {
            var Space = " ";

            if (document.body.className.indexOf("el_size_") == 0)
                Space = "";

            document.body.className = document.body.className.replace(Space + "el_size_320", "");
            document.body.className = document.body.className.replace(Space + "el_size_480", "");
            document.body.className = document.body.className.replace(Space + "el_size_640", "");
            document.body.className = document.body.className.replace(Space + "el_size_720", "");
            document.body.className = document.body.className.replace(Space + "el_size_768", "");
            document.body.className = document.body.className.replace(Space + "el_size_800", "");
            document.body.className = document.body.className.replace(Space + "el_size_960", "");
            document.body.className = document.body.className.replace(Space + "el_size_1024", "");
            document.body.className = document.body.className.replace(Space + "el_size_1280", "");
            document.body.className = document.body.className.replace(Space + "el_size_1366", "");
            document.body.className = document.body.className.replace(Space + "el_size_1440", "");

        }
    }
}

function el_SetPreviewForResizeWindow()
{
	el_DeleteResizeWindow();

    var BrowserWidth = window.innerWidth;

    var UnifyRightLeftLocation = false;

    if (BrowserWidth <= 320)
        BrowserSize = "320";
    else if (BrowserWidth <= 480)
        BrowserSize = "480";
    else if (BrowserWidth <= 640)
        BrowserSize = "640";
    else if (BrowserWidth <= 720)
        BrowserSize = "720";
    else if (BrowserWidth <= 768)
        BrowserSize = "768";
    else if (BrowserWidth <= 800)
        BrowserSize = "800";
    else if (BrowserWidth <= 960)
        BrowserSize = "960";
    else if (BrowserWidth <= 1024)
    {
        BrowserSize = "1024";
        UnifyRightLeftLocation = true;
    }
    else if (BrowserWidth <= 1280)
    {
        BrowserSize = "1280";
        UnifyRightLeftLocation = true;
    }
    else if (BrowserWidth <= 1366)
{
        BrowserSize = "1366";
        UnifyRightLeftLocation = true;
    }
    else if (BrowserWidth <= 1440)
        BrowserSize = "1440";
    else if (BrowserWidth > 1440)
        BrowserSize = "maximum";

    el_SetResizeWindow(BrowserSize, UnifyRightLeftLocation);
}

function el_SetMenuResponsive()
{
    var DivMenu = document.getElementById("div_Menu");
	DivMenu.className = "el_menu_responsive_button";

    if (document.body.contains(document.getElementById("div_TmpFooter")) != true)
    {
        var Footer1 = document.getElementsByClassName("el_footer_1").item(0).innerHTML;
        var Footer2 = document.getElementsByClassName("el_footer_2").item(0).innerHTML;

        var DivTmpFooter = document.createElement("div");
        DivTmpFooter.id = "div_TmpFooter";
        DivTmpFooter.innerHTML += Footer1;
        DivTmpFooter.innerHTML += Footer2;

        DivMenu.appendChild(DivTmpFooter);
    }
}

function el_ZoneMenuResponsive()
{
	el_CloseMenuResponsive();
    if (document.getElementById("div_Menu"))
        document.getElementById("div_Menu").className = "el_menu";

    if (document.getElementById("div_TmpFooter"))
        document.getElementById("div_TmpFooter").outerHTML = "";
}

function el_ShowMenuResponsive()
{
    if (document.getElementById("div_Menu"))
	    document.getElementById("div_Menu").className = "el_menu_responsive_show";
}

function el_CloseMenuResponsive()
{
    if (document.getElementById("div_Menu"))
        document.getElementById("div_Menu").className = "el_menu_responsive_button";
}

if (ElanatVariant.UseSiteAutoResize)
    if(window.addEventListener)
        window.addEventListener('resize', function (event)
        {
            el_SetPreviewForResizeWindow()
        });
    else
        window.attachEvent('resize', function (event)
        {
            el_SetPreviewForResizeWindow()
        });


function el_CheckPreviewForResizeWindow()
{
    if (ElanatVariant.UseSiteAutoResize)
        el_SetPreviewForResizeWindow();
}

/* End Resize Browser */

function el_AcceptCookie()
{
    if (ElanatVariant.ShowUseCookieMessageAlert)
        if (!el_GetCookie("el_accept_cookie"))
            el_SetCookie("el_accept_cookie", "true", 365);

    el_RemoveTag("div_UseCookieMessageAlert");
}

/* Start Read More */
function el_OpenReadMore(ContentId, UseLink, UseAjax)
{
    if (UseLink)
        return false;
    else
        if (UseAjax)
        {
            var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () 
			{
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
				{
                    document.getElementById("div_ReadMoreContent" + ContentId).innerHTML = xmlhttp.responseText;
                }

                if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
                {
                    el_Alert(LanguageVariant.ConnectionError, "problem");
                }
            }

            xmlhttp.open("GET", ElanatVariant.SitePath + "action/get_content_text/?content_id=" + ContentId, false);
            xmlhttp.send();

            el_OpenBox("div_ReadMoreContent" + ContentId);
        }
        else
            el_OpenBox("div_ReadMoreContent" + ContentId);
}
/* End Read More */

/* Start Protection Content */

function el_ShowProtectionContent(ContentId)
{
    var Div_ProtectionContent = document.getElementById("div_ProtectionContent" + ContentId);
    var ContentPasswordValue = document.getElementById("txt_ProtectionContentPassword" + ContentId).value;
    var CaptchaValue = "null";

    if (document.getElementById("txt_Captcha"))
        CaptchaValue = document.getElementById("txt_Captcha").value;
    

    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

	xmlhttp.onreadystatechange = function ()
	{
		if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "") 
		{
			Div_ProtectionContent.outerHTML = xmlhttp.responseText;
		}
        
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "")
            el_LoadCaptcha();

		if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
		{
			el_Alert(LanguageVariant.ConnectionError, "problem");
		}
	}


	xmlhttp.open("GET", ElanatVariant.SitePath + "action/show_protection_content/?content_id=" + ContentId + "&content_password=" + ContentPasswordValue + "&captcha_value=" + CaptchaValue, false);
	xmlhttp.send();
}

/* End Protection Content */

/* Start Protection Attachment */

function el_ShowProtectionAttachment(AttachmentId)
{
    var Div_ProtectionAttachment = document.getElementById("div_ProtectionAttachment" + AttachmentId);
    var AttachmentPasswordValue = document.getElementById("txt_ProtectionAttachmentPassword" + AttachmentId).value;
    var CaptchaValue = "null";

    if (document.getElementById("txt_Captcha"))
        CaptchaValue = document.getElementById("txt_Captcha").value;


    var xmlhttp = (window.XMLHttpRequest) ? xmlhttp = new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function () 
	{
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText != "") 
		{
            Div_ProtectionAttachment.outerHTML = xmlhttp.responseText;
        }

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "")
            el_LoadCaptcha();

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }


    xmlhttp.open("GET", ElanatVariant.SitePath + "action/show_protection_attachment/?attachment_id=" + AttachmentId + "&attachment_password=" + AttachmentPasswordValue + "&captcha_value=" + CaptchaValue, false);
    xmlhttp.send();
}

/* End Protection Attachment */