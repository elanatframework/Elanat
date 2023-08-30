<%@ Page Controller="Elanat.SiteContactController" Model="Elanat.SiteContactModel" %>
<div id="div_ContactPostBack">
    <form id="frm_SiteContact" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/contact/Default.aspx" enctype="multipart/form-data">

        <div class="el_head">
            <%=model.ContactLanguage%>
        </div>

        <div id="div_ContactBox">

            <div class="el_part_row">
                <div id="div_SendContactTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.SendContactLanguage%>
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
                    <input id="btn_SendContact" name="btn_SendContact" type="submit" class="el_button_input" value="<%=model.SendContactLanguage%>" onclick="el_AjaxPostBack(this, true, 'div_ContactBox')" />
                </div>
            </div>

        </div>

        <%=model.OtherWaysForContactValue%>

    </form>
</div>