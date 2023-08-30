<%@ Page Controller="Elanat.MemberChangeTemplateAndStyleController" Model="Elanat.MemberChangeTemplateAndStyleModel" %>
<div id="div_ChangeTemplateAndStylePostBack">

    <div class="el_head">
        <%=model.MemberLanguage%>
    </div>

    <form id="frm_MemberChangeTemplateAndStyle" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/member/change_options/change_template_and_style/Default.aspx">

        <div class="el_part_row">
            <div id="div_ChangeTemplateAndStyleTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeTemplateAndStyleLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserSiteStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserSiteStyle" name="ddlst_UserSiteStyle" class="el_alone_select_input<%=model.UserSiteStyleCssClass%>" <%=model.UserSiteStyleAttribute%>>
                    <%=model.SiteStyleOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.UserSiteTemplateLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserSiteTemplate" name="ddlst_UserSiteTemplate" class="el_alone_select_input<%=model.UserSiteTemplateCssClass%>" <%=model.UserSiteTemplateAttribute%>>
                    <%=model.SiteTemplateOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.UserAdminStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserAdminStyle" name="ddlst_UserAdminStyle" class="el_alone_select_input<%=model.UserAdminStyleCssClass%>" <%=model.UserAdminStyleAttribute%>>
                    <%=model.AdminStyleOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.UserAdminTemplateLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserAdminTemplate" name="ddlst_UserAdminTemplate" class="el_alone_select_input<%=model.UserAdminTemplateCssClass%>" <%=model.UserAdminTemplateAttribute%>>
                    <%=model.AdminTemplateOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <input id="btn_ChangeTemplateAndStyle" name="btn_ChangeTemplateAndStyle" type="submit" class="el_button_input" value="<%=model.ChangeTemplateAndStyleLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_MemberChangeTemplateAndStyle')" />
            </div>
        </div>

    </form>
</div>