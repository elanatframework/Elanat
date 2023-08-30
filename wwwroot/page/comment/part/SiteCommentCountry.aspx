<%@ Page Controller="Elanat.SiteCommentCountryController" Model="Elanat.SiteCommentCountryModel" %>
            <div id="pnl_Country">
                <div class="el_item">
                    <%=model.CountryLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_Country" name="txt_Country" type="text" value="<%=model.CountryValue%>" class="el_text_input<%=model.CountryCssClass%>" <%=model.CountryAttribute%> />
                </div>
            </div>