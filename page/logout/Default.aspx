<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.SiteLogout" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentSiteLanguageDirection()%>">
<head>
    <title><%=model.LogoutLanguage%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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
<body onload="el_PartPageLoad();">
    <%=model.ContentValue%>
</body>
</html>