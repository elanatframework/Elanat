<%@ Page Controller="Elanat.ActionChangeTemplateAndStyleController" Model="Elanat.ActionChangeTemplateAndStyleModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.TemplateAndStyleLanguage%></title>
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
        <%=model.TemplateAndStyleLanguage%>
    </div>

    <form id="frm_ActionChangeTemplateAndStyle" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_template_and_style/ChangeTemplateAndStyle.aspx">

        <div class="el_part_row">
            <div id="div_ChangeTemplateAndStyleTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeTemplateAndStyleLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserSiteStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserSiteStyle" name="ddlst_UserSiteStyle" class="el_alone_select_input<%=model.UserSiteStyleCssClass%>" <%=model.UserSiteStyleAttribute%>>
                    <%=model.SiteStyleOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.UserSiteTemplateLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserSiteTemplate" name="ddlst_UserSiteTemplate" class="el_alone_select_input<%=model.UserSiteTemplateCssClass%>" <%=model.UserSiteTemplateAttribute%>>
                    <%=model.SiteTemplateOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.UserAdminStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserAdminStyle" name="ddlst_UserAdminStyle" class="el_alone_select_input<%=model.UserAdminStyleCssClass%>" <%=model.UserAdminStyleAttribute%>>
                    <%=model.AdminStyleOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.UserAdminTemplateLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserAdminTemplate" name="ddlst_UserAdminTemplate" class="el_alone_select_input<%=model.UserAdminTemplateCssClass%>" <%=model.UserAdminTemplateAttribute%>>
                    <%=model.AdminTemplateOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <input id="btn_ChangeTemplateAndStyle" name="btn_ChangeTemplateAndStyle" type="submit" class="el_button_input" value="<%=model.ChangeTemplateAndStyleLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionChangeTemplateAndStyle')" />
            </div>
        </div>

    </form>

</body>
</html>