<%@ Page Controller="Elanat.ActionLockLoginController" Model="Elanat.ActionLockLoginModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentSiteLanguageDirection()%>">
<head>
    <link id="link_Style" rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel='shortcut icon' href='favicon.ico' />
    <title><%=model.LockLoginActiveInactiveLanguage%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <%=model.ContentValue%>
</body>
</html>