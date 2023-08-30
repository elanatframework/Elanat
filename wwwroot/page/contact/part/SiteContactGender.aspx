<%@ Page Controller="Elanat.SiteContactGenderController" Model="Elanat.SiteContactGenderModel" %>
            <div id="pnl_Gender">
                <div class="el_item">
                    <%=model.GenderLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_radio_input"><input id="rdbtn_GenderMale" value="rdbtn_GenderMale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderMaleValue)%> <%=model.GenderMaleAttribute%> /><label for="rdbtn_GenderMale"><%=model.MaleLanguage%></label></span>
                    <span class="el_radio_input"><input id="rdbtn_GenderFemale" value="rdbtn_GenderFemale" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderFemaleValue)%> <%=model.GenderFemaleAttribute%> /><label for="RadioButton1"><%=model.FemaleLanguage%></label></span>
                    <span class="el_radio_input"><input id="rdbtn_GenderUnknown" value="rdbtn_GenderUnknown" name="rdbtn_Gender" type="radio" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GenderUnknownValue)%> <%=model.GenderUnknownAttribute%> /><label for="RadioButton1"><%=model.UnknownLanguage%></label></span>
                </div>
            </div>