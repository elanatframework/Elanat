<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.ActionKeepLogin" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/site_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
</head>
<body>
    <script>

        function el_StartAddOnInstall()
        {
            var xmlhttp = (window.XMLHttpRequest)? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function ()
	        {

            }
		
            xmlhttp.open("GET", ElanatVariant.AdminDirectoryPath + "/refresh/action/StartAddOnInstall.aspx", false);
            xmlhttp.send();
        }

        if (<%=model.UseStartAddOnInstall%>)
            el_StartAddOnInstall();


        el_DeleteCookie("el_current_user-keep_login_random_text");
        el_DeleteCookie("el_current_user-keep_login_user_id");

        if (el_PageLoadWithIframeCheck())
            window.parent.location = window.location.protocol + "//" + window.location.host + ElanatVariant.SitePath + "<%=model.CurrentPathLineValue%>";
        else
            window.location = window.location.protocol + "//" + window.location.host + ElanatVariant.SitePath + "<%=model.CurrentPathLineValue%>";
    </script>
</body>
</html>