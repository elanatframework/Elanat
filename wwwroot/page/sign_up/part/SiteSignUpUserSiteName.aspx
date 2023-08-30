<%@ Page Controller="Elanat.SiteSignUpUserSiteNameController" Model="Elanat.SiteSignUpUserSiteNameModel" %>
            <div id="pnl_UserSiteName">
                <div class="el_item">
                    <%=model.UserSiteNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_UserSiteName" name="txt_UserSiteName" type="text" value="<%=model.UserSiteNameValue%>" class="el_text_input<%=model.UserSiteNameCssClass%>" <%=model.UserSiteNameAttribute%> />
                </div>
            </div>