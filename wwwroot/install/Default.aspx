<%@ Page Controller="Elanat.InstallSetDatabaseController" Model="Elanat.InstallSetDatabaseModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=model.LanguageDirectionValue%>">
<head>
    <title><%=model.SetElanatDatabaseLanguage%></title>
    <script src="script/install.js"></script>
    <link rel="stylesheet" type="text/css" href="style/install.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="frm_SetDatabase" method="post" action="Default.aspx">
        <div class="el_page_center">
            <h3><%=model.LanguageLanguage%></h3>
            <select id="ddlst_Language" name="ddlst_Language" class="el_alone_select_input" onchange="this.form.submit()"><%=model.LanguageOptionListValue%></select>
            <h1><%=model.SetElanatDatabaseTemplateValue%></h1>
            <br />
            <h3><%=model.YouShouldSetSqlServerDatabaseConnectionValuesBeforeInstallingLanguage%></h3>
            <br />
            <h2><%=model.SetDatabaseConnectionLanguage%></h2>
            <br />
            <h3><%=model.ServerNameLanguage%></h3>
            <input id="txt_ServerName" name="txt_ServerName" type="text" value="<%=model.ServerNameValue%>" class="el_text_input" onchange="el_SetConnectionValue()"/>
            <br />
            <h3><%=model.DatabaseNameLanguage%></h3>
            <input id="txt_DatabaseName" name="txt_DatabaseName" type="text" value="<%=model.DataBaseNameValue%>" class="el_text_input" onchange="el_SetConnectionValue()"/>
            <br />
            <h3><%=model.UserIdLanguage%></h3>
            <input id="txt_UserId" name="txt_UserId" type="text"  value="<%=model.UserIdValue%>" class="el_text_input" onchange="el_SetConnectionValue()"/>
            <br />
            <h3><%=model.PasswordLanguage%></h3>
            <input id="txt_Password" name="txt_Password" type="password" value="<%=model.PasswordValue%>" class="el_text_input" onchange="el_SetConnectionValue()"/>
            <br />
            <h3><%=model.ConnectionStringLanguage%></h3>
            <input id="txt_ConnectionString" name="txt_ConnectionString" type="text" value="<%=model.ConnectionStringValue%>" class="el_long_text_input" />
            <br />
            <input id="btn_SetConnectionString" name="btn_SetConnectionString" type="submit" class="el_button_input" value="<%=model.SetConnectionStringLanguage%>" />
        </div>
    </form>
</body>
</html>