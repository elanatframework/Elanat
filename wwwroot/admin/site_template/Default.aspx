<%@ Page Controller="Elanat.AdminSiteTemplateController" Model="Elanat.AdminSiteTemplateModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.SiteTemplateLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/site_template/script/site_template.js"></script>
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
        <%=model.SiteTemplateLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_site_template" onclick="el_ShowHideSection(this, 'div_AddSiteTemplate'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddSiteTemplate" class="el_hidden">

        <form id="frm_AdminSiteTemplate" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/site_template/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AddSiteTemplateTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddSiteTemplateLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.SiteTemplatePathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_SiteTemplatePath" name="upd_SiteTemplatePath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_UseSiteTemplatePath" name="cbx_UseSiteTemplatePath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseSiteTemplatePathValue)%> /><label for="cbx_UseSiteTemplatePath"><%=model.UseSiteTemplatePathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_SiteTemplatePath" name="txt_SiteTemplatePath" value="<%=model.SiteTemplatePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_SiteTemplateActive" name="cbx_SiteTemplateActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SiteTemplateActiveValue)%> /><label for="cbx_SiteTemplateActive"><%=model.SiteTemplateActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="btn_AddSiteTemplate" name="btn_AddSiteTemplate" type="submit" class="el_button_input" value="<%=model.AddSiteTemplateLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminSiteTemplate')" />
                </div>
            </div>

        </form>

    </div>

    <div class="el_part_row">
        <div id="div_TableBox" class="el_item">
            <%=model.ContentValue%>
        </div>
    </div>

</body>
</html>