<%@ Page Controller="Elanat.SiteCommentMobileNumberController" Model="Elanat.SiteCommentMobileNumberModel" %>
            <div id="pnl_MobileNumber">
                <div class="el_item">
                    <%=model.MobileNumberLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_MobileNumber" name="txt_MobileNumber" type="text" value="<%=model.MobileNumberValue%>" class="el_text_input el_left_to_right<%=model.MobileNumberCssClass%>" <%=model.MobileNumberAttribute%> />
                </div>
            </div>