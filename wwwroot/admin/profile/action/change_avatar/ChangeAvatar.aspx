<%@ Page Controller="Elanat.ActionChangeAvatarController" Model="Elanat.ActionChangeAvatarModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.AvatarLanguage%></title>
    <script src="script/change_avatar.js"></script>
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
        <%=model.AvatarLanguage%>
    </div>

    <form id="frm_ActionChangeAvatar" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_avatar/ChangeAvatar.aspx" enctype="multipart/form-data">

        <div class="el_part_row">
            <div id="div_ChangeAvatarTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeAvatarLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.AvatarPathLanguage%>
            </div>
            <div class="el_item">
                <input id="upd_AvatarPath" name="upd_AvatarPath" type="file" class="el_file_input" />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseAvatarPath" name="cbx_UseAvatarPath" type="checkbox" /><label for="cbx_UseAvatarPath"><%=model.UseAvatarPathLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="txt_AvatarPath" name="txt_AvatarPath" value="<%=model.AvatarPathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
            </div>
            <div class="el_item">
                <img id="img_AvatarLogo" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/image/user_avatar/<%=model.AvatarIconValue%>.png" alt="" class="el_image_size_256" />
            </div>
            <div class="el_item">
                <input id="btn_ChangeAvatar" name="btn_ChangeAvatar" type="submit" class="el_button_input" value="<%=model.ChangeAvatarLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionChangeAvatar')" />
            </div>
        </div>

    </form>

</body>
</html>