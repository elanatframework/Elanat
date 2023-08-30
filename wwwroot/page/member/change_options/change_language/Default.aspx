<%@ Page Controller="Elanat.MemberChangeLanguageController" Model="Elanat.MemberChangeLanguageModel" %>
<div id="div_ChangeLanguagePostBack">

    <div class="el_head">
        <%=model.MemberLanguage%>
    </div>

    <form id="frm_MemberChangeLanguage" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/member/change_options/change_language/Default.aspx">

        <div class="el_part_row">
            <div id="div_ChangeLanguageTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeLanguageLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.UserSiteLanguageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserSiteLanguage" name="ddlst_UserSiteLanguage" class="el_alone_select_input<%=model.UserSiteLanguageCssClass%>" <%=model.UserSiteLanguageAttribute%>>
                    <%=model.SiteLanguageOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.UserAdminLanguageLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_UserAdminLanguage" name="ddlst_UserAdminLanguage" class="el_alone_select_input<%=model.UserAdminLanguageCssClass%>" <%=model.UserAdminLanguageAttribute%>">
                    <%=model.AdminLanguageOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <input id="btn_ChangeLanguage" name="btn_ChangeLanguage" type="submit" class="el_button_input" value="<%=model.ChangeLanguageLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_MemberChangeLanguage')" />
            </div>
        </div>

    </form>
</div>