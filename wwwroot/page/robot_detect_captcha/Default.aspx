<%@ Page Controller="Elanat.RobotDetectCaptchaController" Model="Elanat.RobotDetectCaptchaModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentSiteLanguageDirection()%>">
<head>
    <title><%=model.RobotDetectCaptchaLanguage%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Start Client Variant -->
    <%=Elanat.AspxHtmlValue.CurrentSiteClientVariant()%>
    <!-- End Client Variant -->
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/site/site.js"></script>
    <%=Elanat.AspxHtmlValue.CurrentSiteStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/site_global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_LoadCaptcha();">
    <form id="frm_RobotDetectCaptcha" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/robot_detect_captcha/Default.aspx">

        <div class="el_head">
            <%=model.RobotDetectCaptchaLanguage%>
        </div>

        <div class="el_part_row">
            <div id="div_SetCaptcha" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.SetCaptchaLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.YouHaveALotOfRequestsToTheServerInAShortTimeLanguage%>
            </div>
            <div class="el_item">
                <%=model.PleaseFillCaptchaImageAndClickSetCaptchaButtonLanguage%>
            </div>
            <div class="el_item">
                <div class="el_captcha_value"></div>
            </div>
            <div class="el_item">
                <%=model.RequestRemainingLanguage%>
            </div>
            <div class="el_item">
                <%=model.RequestRemainingValue%>
            </div>
            <div class="el_item">
                <input id="btn_SetCaptcha" name="btn_SetCaptcha" type="submit" class="el_button_input" value="<%=model.SetCaptchaLanguage%>" onclick="el_AjaxPostBack(this, true)" />
            </div>
        </div>

    </form>
</body>
</html>