<%@ Page Controller="Elanat.ExtraHelperContentAvatarController" Model="Elanat.ExtraHelperContentAvatarModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ContentAvatarLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/content_avatar/script/content_avatar.js"></script>
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
<body onload="el_PartPageLoad();">
    <form id="frm_ExtraHelperContentAvatar" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/content_avatar/Default.aspx" enctype="multipart/form-data">

        <div class="el_part_row">
            <div id="div_ContentAvatarTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ContentAvatarLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.AvatarPathLanguage%>
            </div>
            <div class="el_item">
                <input id="upd_AvatarPathUpload" name="upd_AvatarPathUpload" type="file" class="el_file_input" />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseAvatarPath" name="cbx_UseAvatarPath" type="checkbox" /><label for="cbx_UseAvatarPath"><%=model.UseAvatarPathLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="txt_AvatarPath" name="txt_AvatarPath" type="text" class="el_long_text_input el_foreign_path" />
            </div>
            <div class="el_item">
                <input id="btn_StartUpload" name="btn_StartUpload" type="submit" class="el_button_input" value="<%=model.StartUploadLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ExtraHelperContentAvatar')" />
            </div>
        </div>

        <input id="hdn_ContentAvatarPath" name="hdn_ContentAvatarPath" type="hidden" value="<%=model.PathValue%>" />

    </form>

    <form id="frm_ExtraHelperContentAvatar2" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/content_avatar/Default.aspx">
            
        <div class="el_part_row">
            <div id="div_CreateDirectoryTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.CreateDirectoryLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.DirectoryNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_DirectoryName" name="txt_DirectoryName" type="text" class="el_text_input" />
            </div>
            <div class="el_item">
                <input id="btn_CreateDirectory" name="btn_CreateDirectory" type="submit" class="el_button_input" value="<%=model.CreateDirectoryLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ExtraHelperContentAvatar2')" />
            </div>
        </div>

        <div class="el_part_row">
            <div id="div_AvatarTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.AvatarLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ContentAvatarValue%>
            </div>
        </div>

        <input id="hdn_CreateDirectoryPath" name="hdn_CreateDirectoryPath" type="hidden" value="<%=model.PathValue%>" />

    </form>
</body>
</html>