<%@ Page Controller="Elanat.PartSiteSearchDateController" Model="Elanat.PartSiteSearchDateModel" %>
            <div id="pnl_Date">
                <div class="el_item">
                    <%=model.SearchFromLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_SearchFrom" name="txt_SearchFrom" type="text" value="<%=model.SearchFromValue%>" class="el_text_input" />
                </div>
                <div class="el_item">
                    <%=model.SearchUntilLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_SearchUntil" name="txt_SearchUntil" type="text" value="<%=model.SearchUntilValue%>" class="el_text_input" />
                </div>
            </div>