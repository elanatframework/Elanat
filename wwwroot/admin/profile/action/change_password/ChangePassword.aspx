<%@ Page Controller="Elanat.ActionChangePasswordController" Model="Elanat.ActionChangePasswordModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.PasswordLanguage%></title>
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
        <%=model.PasswordLanguage%>
    </div>

    <form id="frm_ActionChangePassword" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_password/ChangePassword.aspx">

        <div class="el_part_row">
            <div id="div_ChangePasswordTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangePasswordLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserPasswordLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserPassword" name="txt_UserPassword" type="password" class="el_text_input<%=model.UserPasswordCssClass%>" <%=model.UserPasswordAttribute%> />
            </div>
            <div class="el_item">
                <%=model.RepeatPasswordLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_RepeatPassword" name="txt_RepeatPassword" type="password" class="el_text_input<%=model.RepeatPasswordCssClass%>" <%=model.RepeatPasswordAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_ChangePassword" name="btn_ChangePassword" type="submit" class="el_button_input" value="<%=model.ChangePasswordLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionChangePassword')" />
            </div>
        </div>

    </form>

</body>
</html>