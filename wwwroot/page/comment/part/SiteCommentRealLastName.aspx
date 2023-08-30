<%@ Page Controller="Elanat.SiteCommentRealLastNameController" Model="Elanat.SiteCommentRealLastNameModel" %>
            <div id="pnl_RealLastName">
                <div class="el_item">
                    <%=model.RealLastNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_RealLastName" name="txt_RealLastName" type="text" value="<%=model.RealLastNameValue%>" class="el_text_input<%=model.RealLastNameCssClass%>" <%=model.RealLastNameAttribute%> />
                </div>
            </div>