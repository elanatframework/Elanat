<%@ Page Controller="Elanat.MemberChangePasswordController" Model="Elanat.MemberChangePasswordModel" %>
<div id="div_ChangePasswordPostBack">
        
    <div class="el_head">
        <%=model.MemberLanguage%>
    </div>

    <form id="frm_MemberChangePassword" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/member/change_profile/change_password/Default.aspx">

        <div class="el_part_row">
            <div id="div_ChangePasswordTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangePasswordLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserPasswordLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserPassword" name="txt_UserPassword" type="password" class="el_text_input<%=model.UserPasswordCssClass%>" <%=model.UserPasswordAttribute%> />
            </div>
            <div class="el_item">
                <%=model.RepeatPasswordLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_RepeatPassword" name="txt_RepeatPassword" type="password" class="el_text_input<%=model.RepeatPasswordCssClass%>" <%=model.RepeatPasswordAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_ChangePassword" name="btn_ChangePassword" type="submit" class="el_button_input" value="<%=model.ChangePasswordLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_MemberChangePassword')" />
            </div>
        </div>

    </form>
</div>