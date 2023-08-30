<%@ Page Controller="Elanat.ExtraHelperSiteLogoController" Model="Elanat.ExtraHelperSiteLogoModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.SiteLogoLanguage%></title>
    <script src="script/site_logo.js"></script>
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">
    <form id="frm_ExtraHelperUploadLogo" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/site_logo/Default.aspx" enctype="multipart/form-data">

        <div class="el_part_row">
            <div id="div_UploadLogoTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.UploadLogoLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.LogoPathLanguage%>
            </div>
            <div class="el_item">
                <input id="upd_LogoPath" name="upd_LogoPath" type="file" class="el_file_input" />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseLogoPath" name="cbx_UseLogoPath" type="checkbox" /><label for="cbx_UseLogoPath"><%=model.UseLogoPathLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="txt_LogoPath" name="txt_LogoPath" value="<%=model.LogoPathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
            </div>
            <div class="el_item">
                <%=model.SiteLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_Site" name="ddlst_Site" class="el_alone_select_input" onchange="el_GetSiteLogo()">
                    <%=model.SiteOptionListValue %>
                </select>
            </div>
            <div class="el_item">
                <img id="img_SiteLogo" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/image/site_logo/<%=model.SiteIconValue%>.png" alt="" class="el_image_size_256" />
            </div>
            <div class="el_item">
                <input id="btn_StartUpload" name="btn_StartUpload" type="submit" class="el_button_input" value="<%=model.StartUploadLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ExtraHelperUploadLogo')" />
            </div>
        </div>

    </form>
</body>
</html>