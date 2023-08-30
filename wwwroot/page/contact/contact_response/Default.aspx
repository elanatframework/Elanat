<%@ Page Controller="Elanat.SiteContactResponseController" Model="Elanat.SiteContactResponseModel" %>
<div id="div_ContactResponsePostBack">
    
    <div class="el_head">
        <%=model.ContactResponseLanguage%>
    </div>

    <form id="frm_SiteContactResponse" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/contact/contact_response/Default.aspx">

        <div class="el_part_row">
            <div id="div_ContactResponseTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.GetContactResponseLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ContactResponseCodeLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContactResponseCode" name="txt_ContactResponseCode" type="text" value="<%=model.ContactResponseCodeValue%>" class="el_text_input<%=model.ContactResponseCodeCssClass%>" <%=model.ContactResponseCodeAttribute%> />
            </div>
            <div class="el_item">
                <div class="el_captcha_value"></div>
            </div>
            <div class="el_item">
                <input id="btn_GetContactResponse" name="btn_GetContactResponse" type="submit" class="el_button_input" value="<%=model.GetContactResponseLanguage%>" onclick="el_DeleteInnerValue('div_ResponseTextBox');el_AjaxPostBack(this, true, 'frm_SiteContactResponse')" />
            </div>
            <div id="div_ResponseTextBox">

            </div>
        </div>

    </form>
</div>