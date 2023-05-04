<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeLanguage.aspx.cs" Inherits="elanat.ActionChangeLanguage" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.LanguageLanguage%></title>
    <!-- Start Client Variant -->
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant"></script>
    <!-- End Client Variant -->	
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=elanat.AspxHtmlValue.CurrentBoxTag()%>
</head>
<body onload="el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.LanguageLanguage%>
    </div>

    <form id="frm_ActionChangeLanguage" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_language/ChangeLanguage.aspx">

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
                <input id="btn_ChangeLanguage" name="btn_ChangeLanguage" type="submit" class="el_button_input" value="<%=model.ChangeLanguageLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionChangeLanguage')" />
            </div>
        </div>

    </form>

</body>
</html>