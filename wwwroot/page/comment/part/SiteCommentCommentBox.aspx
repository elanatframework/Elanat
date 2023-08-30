<%@ Page Controller="Elanat.SiteCommentCommentBoxController" Model="Elanat.SiteCommentCommentBoxModel" %>

        <div id="div_CommentBox">

            <div class="el_part_row">

                <div id="div_SendCommentTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.SendCommentLanguage%>
                    <div class="el_dash"></div>
                </div>
                
                <%=model.RealNamePartValue%>

                <%=model.RealLastNamePartValue%>

                <%=model.EmailPartValue%>

                <%=model.TypePartValue%>

                <%=model.TitlePartValue%>

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

                <%=model.UploadPartValue%>

                <div class="el_item">
                    <div class="el_captcha_value"></div>
                </div>

                <div class="el_item">
                    <input id="btn_SendComment" name="btn_SendComment" type="submit" class="el_button_input" value="<%=model.SendCommentLanguage%>" onclick="el_AjaxPostBack(this, true, 'div_CommentBox')" />
                </div>
            
            </div>

        </div>