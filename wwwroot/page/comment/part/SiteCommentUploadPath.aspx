<%@ Page Controller="Elanat.SiteCommentUploadPathController" Model="Elanat.SiteCommentUploadPathModel" %>
            <div id="pnl_UploadPatch">
                <div class="el_item">
                    <%=model.UploadPathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_UploadPath" name="upd_UploadPath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_UseUploadPath" name="cbx_UseUploadPath" type="checkbox" /><label for="cbx_UseUploadPath"><%=model.UseUploadPathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_UploadPath" name="txt_UploadPath" value="<%=model.UploadPathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
            </div>