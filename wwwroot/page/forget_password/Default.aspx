<%@ Page Controller="Elanat.SiteForgetPasswordController" Model="Elanat.SiteForgetPasswordModel" %>
<div id="div_ForgetPasswordPostBack">
    
    <div class="el_head">
        <%=model.ForgetPasswordLanguage%>
    </div>

    <form id="frm_ForgetPassword" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/forget_password/Default.aspx">

        <div class="el_part_row">
            <div id="div_GetNewPassword" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.GetNewPasswordLanguage%>
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
                <input id="btn_GetNewPassword" name="btn_GetNewPassword" type="submit" class="el_button_input" value="<%=model.GetNewPasswordLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ForgetPassword')" />
            </div>
        </div>

    </form>
</div>