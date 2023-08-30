<%@ Page Controller="Elanat.SiteCommentEmailController" Model="Elanat.SiteCommentEmailModel" %>
            <div id="pnl_Email">
                <div class="el_item">
                    <%=model.EmailLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_Email" name="txt_Email" type="text" value="<%=model.EmailValue%>" class="el_text_input el_left_to_right<%=model.EmailCssClass%>" <%=model.EmailAttribute%> />
                </div>
            </div>