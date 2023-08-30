<%@ Page Controller="Elanat.ActionInstallSuccessDatabaseMessageController" Model="Elanat.ActionInstallSuccessDatabaseMessageModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=model.ContentTitle%></title>
    <script src="../script/install.js"></script>
    <link rel="stylesheet" type="text/css" href="../style/install.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>

    <%=model.ContentValue%>

</body>
</html>