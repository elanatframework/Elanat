<%@ Page Controller="Elanat.SiteSignUpUserNameController" Model="Elanat.SiteSignUpUserNameModel" %>
            <div id="pnl_UserName">
                <div class="el_item">
                    <%=model.UserNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_UserName" name="txt_UserName" type="text" value="<%=model.UserNameValue%>" class="el_text_input<%=model.UserNameCssClass%>" <%=model.UserNameAttribute%> />
                </div>
            </div>