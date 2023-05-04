<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.ActionLockLogin" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentSiteLanguageDirection()%>">
<head>
    <link id="link_Style" rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel='shortcut icon' href='favicon.ico' />
    <title><%=model.LockLoginActiveInactiveLanguage%></title>
</head>
<body>
    <%=model.ContentValue%>
</body>
</html>