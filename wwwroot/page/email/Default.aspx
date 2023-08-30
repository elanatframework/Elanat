<%@ Page Controller="Elanat.SiteEmailController" Model="Elanat.SiteEmailModel" %>
    <div id="div_EmailPostBack">

        <div class="el_head">
            <%=model.EmailLanguage%>
        </div>

        <form id="frm_SiteEmail" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/email/Default.aspx?content_id=<%=model.ContentIdValue%>">

            <div class="el_part_row">
                <div id="div_EmailTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.SendEmailLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.YourEmailLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_YourEmail" name="txt_YourEmail" type="text" value="<%=model.YourEmailValue%>" class="el_text_input el_left_to_right<%=model.YourEmailCssClass%>" <%=model.YourEmailAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.RecipientsEmaiLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_RecipientsEmail" name="txt_RecipientsEmail" class="el_textarea_input el_left_to_right<%=model.RecipientsEmailCssClass%>" <%=model.RecipientsEmailAttribute%>><%=model.RecipientsEmailValue%></textarea>
                </div>
                <div class="el_item">
                    <div class="el_captcha_value"></div>
                </div>
                <div class="el_item">
                    <input id="btn_SendEmail" name="btn_SendEmail" type="submit" class="el_button_input" value="<%=model.SendEmailLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_SiteEmail')" />
                </div>
            </div>

            <input id="hdn_ContentId" name="hdn_ContentId" type="hidden" value="<%=model.ContentIdValue%>" />

        </form>
    </div>