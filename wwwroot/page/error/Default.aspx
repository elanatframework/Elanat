﻿<%@ Page Controller="Elanat.SiteErrorController" Model="Elanat.SiteErrorModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentSiteLanguageDirection()%>">
<head>
    <title><%=model.ErrorLanguage%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Start Client Variant -->
    <%=Elanat.AspxHtmlValue.CurrentSiteClientVariant()%>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
	<script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/site/site.js" ></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/site_global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <%=model.ContentValue%>
</body>
</html>
