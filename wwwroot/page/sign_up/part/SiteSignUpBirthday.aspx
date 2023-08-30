<%@ Page Controller="Elanat.SiteSignUpBirthdayController" Model="Elanat.SiteSignUpBirthdayModel" %>
            <div id="pnl_Birthday">
                <div class="el_item">
                    <%=model.BirthdayLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_BirthdayYear" name="ddlst_BirthdayYear" class="el_short_select_input<%=model.BirthdayYearCssClass%>" <%=model.BirthdayYearAttribute%>><%=model.BirthdayYearOptionListValue%></select><select id="ddlst_BirthdayMount" name="ddlst_BirthdayMount" class="el_short_select_input<%=model.BirthdayMountCssClass%>" <%=model.BirthdayMountAttribute%>><%=model.BirthdayMountOptionListValue%></select><select id="ddlst_BirthdayDay" name="ddlst_BirthdayDay" class="el_short_select_input<%=model.BirthdayDayCssClass%>" <%=model.BirthdayDayAttribute%>><%=model.BirthdayDayOptionListValue%></select>
                </div>
            </div>