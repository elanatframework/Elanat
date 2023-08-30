<%@ Page Controller="Elanat.SiteConfirmEmailController" Model="Elanat.SiteConfirmEmailModel" %>
<div id="div_ConfirmEmailPostBack">
    <div class="el_head">
        <%=model.ConfirmEmailLanguage%>
    </div>

    <form id="frm_ConfirmEmail" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/confirm_email/Default.aspx">

        <div class="el_part_row">
            <div id="div_GetEmailConfirm" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.GetEmailConfirmLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserNameOrUserEmailLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserNameOrUserEmail" name="txt_UserNameOrUserEmail" type="text" value="<%=model.UserNameOrUserEmailValue%>" class="el_text_input el_important_field" />
            </div>
            <div class="el_item">
                <div class="el_captcha_value"></div>
            </div>
            <div class="el_item">
                <input id="btn_GetEmailConfirm" name="btn_GetEmailConfirm" type="submit" class="el_button_input" value="<%=model.GetEmailConfirmLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ConfirmEmail')" />
            </div>
        </div>

    </form>
</div>