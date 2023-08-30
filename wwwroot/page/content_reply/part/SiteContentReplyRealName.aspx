<%@ Page Controller="Elanat.SiteContentReplyRealNameController" Model="Elanat.SiteContentReplyRealNameModel" %>
            <div id="pnl_RealName">
                <div class="el_item">
                    <%=model.RealNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_RealName" name="txt_RealName" type="text" value="<%=model.RealNameValue%>" class="el_text_input<%=model.RealNameCssClass%>" <%=model.RealNameAttribute%> />
                </div>
            </div>