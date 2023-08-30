<%@ Page Controller="Elanat.MemberChangeEmailController" Model="Elanat.MemberChangeEmailModel" %>
<div id="div_ChangeEmailPostBack">

    <div class="el_head">
        <%=model.MemberLanguage%>
    </div>

    <form id="frm_MemberChangeEmail" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/member/change_profile/change_email/Default.aspx">

        <div class="el_part_row">
            <div id="div_ChangeEmailTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeEmailLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserEmailLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_UserEmail" name="txt_UserEmail" type="text" value="<%=model.UserEmailValue%>" class="el_text_input el_left_to_right<%=model.UserEmailCssClass%>" <%=model.UserEmailAttribute%> />
            </div>
            <div class="el_item">
                <%=model.RepeatEmailLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_RepeatEmail" name="txt_RepeatEmail" type="text" value="<%=model.RepeatEmaiValue%>" class="el_text_input el_left_to_right<%=model.RepeatEmailCssClass%>" <%=model.RepeatEmailtAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_ChangeEmail" name="btn_ChangeEmail" type="submit" class="el_button_input" value="<%=model.ChangeEmailLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_MemberChangeEmail')" />
            </div>
        </div>

    </form>
</div>