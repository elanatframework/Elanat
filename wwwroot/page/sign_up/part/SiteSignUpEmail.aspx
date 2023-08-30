<%@ Page Controller="Elanat.SiteSignUpEmailController" Model="Elanat.SiteSignUpEmailModel" %>
            <div id="pnl_Email">
                <div class="el_item">
                    <%=model.EmailLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_Email" name="txt_Email" type="text" value="<%=model.EmailValue%>" class="el_text_input el_left_to_right<%=model.EmailCssClass%>" <%=model.EmailAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.RepeatEmailLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_RepeatEmail" name="txt_RepeatEmail" type="text" value="<%=model.RepeatEmailValue%>" class="el_text_input el_left_to_right<%=model.RepeatEmailCssClass%>" <%=model.RepeatEmailAttribute%> />
                </div>
            </div>