<%@ Page Controller="Elanat.SiteContentReplyContentReplyBoxController" Model="Elanat.SiteContentReplyContentReplyBoxModel" %>

        <div id="div_ContentReplyBox">

            <div class="el_part_row">

                <div id="div_SendContentReplyTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.SendContentReplyLanguage%>
                    <div class="el_dash"></div>
                </div>
                
                <%=model.RealNamePartValue%>

                <%=model.RealLastNamePartValue%>

                <%=model.EmailPartValue%>

                <%=model.TypePartValue%>

                <%=model.TextPartValue%>

                <%=model.PhoneNumberPartValue%>

                <%=model.AddressPartValue%>

                <%=model.PostalCodePartValue%>

                <%=model.AboutPartValue%>

                <%=model.BirthdayPartValue%>

                <%=model.GenderPartValue%>

                <%=model.WebsitePartValue%>

                <%=model.PublicEmailPartValue%>

                <%=model.CountryPartValue%>

                <%=model.StateOrProvincePartValue%>
                
                <%=model.CityPartValue%>

                <%=model.MobileNumberPartValue%>

                <%=model.ZipCodePartValue%>

                <div class="el_item">
                    <div class="el_captcha_value"></div>
                </div>

                <div class="el_item">
                    <input id="btn_SendContentReply" name="btn_SendContentReply" type="submit" class="el_button_input" value="<%=model.SendContentReplyLanguage%>" onclick="el_AjaxPostBack(this, true, 'div_ContentReplyBox')" />
                </div>
            </div>

        </div>