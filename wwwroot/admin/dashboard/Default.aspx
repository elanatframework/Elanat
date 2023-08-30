<%@ Page Controller="Elanat.AdminDashboardController" Model="Elanat.AdminDashboardModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.DashboardLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/attachment/script/attachment.js"></script>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/comment/script/comment.js"></script>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/contact/script/contact.js"></script>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/content/script/content.js"></script>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/recycle_bin/script/recycle_bin.js"></script>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/user/script/user.js"></script>
    <!-- Start Client Variant -->
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=Elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=Elanat.AspxHtmlValue.CurrentBoxTag()%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.DashboardLanguage%>
    </div>

    <%=model.DashboardLocationValue%>

</body>
</html>