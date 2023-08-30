<%@ Page Controller="Elanat.MemberChangeAvatarController" Model="Elanat.MemberChangeAvatarModel" %>
<div id="div_ChangeAvatarPostBack">
        
    <div class="el_head">
        <%=model.MemberLanguage%>
    </div>

    <form id="frm_MemberChangeAvatar" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/member/change_profile/change_avatar/Default.aspx" enctype="multipart/form-data">

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
                <img id="img_AvatarLogo" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/image/user_avatar/<%=model.AvatarIconValue%>.png" alt="" />
            </div>
            <div class="el_item">
                <input id="btn_ChangeAvatar" name="btn_ChangeAvatar" type="submit" class="el_button_input" value="<%=model.ChangeAvatarLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_MemberChangeAvatar')" />
            </div>
        </div>

    </form>
</div>