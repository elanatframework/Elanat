<%@ Page Controller="Elanat.SiteSignUpZipCodeController" Model="Elanat.SiteSignUpZipCodeModel" %>
            <div id="pnl_ZipCode">
                <div class="el_item">
                    <%=model.ZipCodeLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ZipCode" name="txt_ZipCode" type="text" value="<%=model.ZipCodeValue%>" class="el_text_input el_left_to_right<%=model.ZipCodeCssClass%>" <%=model.ZipCodeAttribute%> />
                </div>
            </div>