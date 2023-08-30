<%@ Page Controller="Elanat.SiteSignUpAvatarPathController" Model="Elanat.SiteSignUpAvatarPathModel" %>
            <div id="pnl_AvatarPatch">
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
            </div>