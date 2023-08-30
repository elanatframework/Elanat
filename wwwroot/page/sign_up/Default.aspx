<%@ Page Controller="Elanat.SiteSignUpController" Model="Elanat.SiteSignUpModel" %>
<div id="div_SignUpPostBack">
    
    <div class="el_head">
        <%=model.SignUpLanguage%>
    </div>

    <form id="frm_SiteSignUp" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/sign_up/Default.aspx" enctype="multipart/form-data">

        <div class="el_part_row">
            <div id="div_SignUpTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.SignUpToSiteLanguage%>
                <div class="el_dash"></div>
            </div>

            <%=model.UserNamePartValue%>

            <%=model.UserSiteNamePartValue%>

            <%=model.RealNamePartValue%>

            <%=model.RealLastNamePartValue%>

            <div class="el_item">
                <%=model.PasswordLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_Password" name="txt_Password" type="password" class="el_text_input<%=model.PasswordCssClass%>" <%=model.PasswordAttribute%> />
            </div>
            <div class="el_item">
                <%=model.RepeatPasswordLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_RepeatPassword" name="txt_RepeatPassword" type="password" class="el_text_input<%=model.RepeatPasswordCssClass%>" <%=model.RepeatPasswordAttribute%> />
            </div>

            <%=model.EmailPartValue%>

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

            <%=model.AvatarPathPartValue%>

            <div class="el_item">
                <%=model.TermsOfServiceLanguage%>
            </div>
            <div class="el_item">
                <div id="div_TermsOfService" class="el_panel_resize">
                    <%=model.TermsOfServiceValue%>
                </div>
            </div>
            <div class="el_item">
                <%=model.PrivacyPolicyLanguage%>
            </div>
            <div class="el_item">
                <div id="div_PrivacyPolicy" class="el_panel_resize">
                    <%=model.PrivacyPolicyValue%>
                </div>
            </div>
            <div class="el_item">
                <%=model.UserAgreementLanguage%>
            </div>
            <div class="el_item">
                <div id="div_UserAgreement" class="el_panel_resize">
                    <%=model.UserAgreementValue%>
                </div>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input el_important_field"><input id="cbx_Agree" name="cbx_Agree" type="checkbox" /><label for="cbx_Agree"><%=model.AgreeLanguage%></label></span>
            </div>

            <div class="el_item">
                <div class="el_captcha_value"></div>
            </div>

            <div class="el_item">
                <input id="btn_SignUp" name="btn_SignUp" type="submit" class="el_button_input" value="<%=model.SignUpLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_SiteSignUp')" />
            </div>

        </div>

        <input id="hdn_ReturnUrl" name="hdn_ReturnUrl" type="hidden" value="<%=model.ReturnUrlValue%>" />

    </form>
</div>