<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.SitePrint" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentSiteLanguageDirection()%>">
<head>
    <title><%=model.PrintLanguage%></title>
    <link rel='shortcut icon' href='favicon.ico' />
    <meta name="robots" content="nofollow" />
    <!-- Start Client Variant -->
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/site_client_variant/"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/site_client_language_variant"></script>
    <!-- End Client Variant -->	
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
	<script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/site/site.js" ></script>
    <%=elanat.AspxHtmlValue.CurrentSiteStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/site_global.css" />
</head>
<body onload="window.print()">
    <%=model.ContentValue%>
</body>
</html>
