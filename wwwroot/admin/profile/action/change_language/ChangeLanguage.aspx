<%@ Page Controller="Elanat.ActionChangeLanguageController" Model="Elanat.ActionChangeLanguageModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.LanguageLanguage%></title>
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
        <%=model.LanguageLanguage%>
    </div>

    <form id="frm_ActionChangeLanguage" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_language/ChangeLanguage.aspx">

        <div class="el_part_row">
            <div id="div_ChangeLanguageTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeLanguageLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserSiteLanguageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserSiteLanguage" name="ddlst_UserSiteLanguage" class="el_alone_select_input<%=model.UserSiteLanguageCssClass%>" <%=model.UserSiteLanguageAttribute%>>
                    <%=model.SiteLanguageOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.UserAdminLanguageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserAdminLanguage" name="ddlst_UserAdminLanguage" class="el_alone_select_input<%=model.UserAdminLanguageCssClass%>" <%=model.UserAdminLanguageAttribute%>">
                    <%=model.AdminLanguageOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <input id="btn_ChangeLanguage" name="btn_ChangeLanguage" type="submit" class="el_button_input" value="<%=model.ChangeLanguageLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionChangeLanguage')" />
            </div>
        </div>

    </form>

</body>
</html>