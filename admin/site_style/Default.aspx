<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.AdminSiteStyle" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.SiteStyleLanguage%></title>
    <script src="<%=elanat.AspxHtmlValue.AdminPath()%>/site_style/script/site_style.js"></script>
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
        <%=model.SiteStyleLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_site_style" onclick="el_ShowHideSection(this, 'div_AddSiteStyle'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddSiteStyle" class="el_hidden">

        <form id="frm_AdminSiteStyle" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/site_style/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AddSiteStyleTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddSiteStyleLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.SiteStylePathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_SiteStylePath" name="upd_SiteStylePath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_UseSiteStylePath" name="cbx_UseSiteStylePath" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseSiteStylePathValue)%> /><label for="cbx_UseSiteStylePath"><%=model.UseSiteStylePathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_SiteStylePath" name="txt_SiteStylePath" value="<%=model.SiteStylePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_SiteStyleActive" name="cbx_SiteStyleActive" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SiteStyleActiveValue)%> /><label for="cbx_SiteStyleActive"><%=model.SiteStyleActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="btn_AddSiteStyle" name="btn_AddSiteStyle" type="submit" class="el_button_input" value="<%=model.AddSiteStyleLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminSiteStyle')" />
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