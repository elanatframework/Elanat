<%@ Page Controller="Elanat.InstallController" Model="Elanat.InstallModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentSiteLanguageDirection()%>">
<head>
    <title><%=model.InstallLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>install/script/install.js"></script>
    <!-- Start Client Variant -->
    <%=Elanat.AspxHtmlValue.CurrentSiteClientVariant()%>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
	<script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/site/site.js" ></script>
    <%=Elanat.AspxHtmlValue.CurrentSiteStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/site_global.css" />
    <%=Elanat.AspxHtmlValue.CurrentBoxTag()%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>

    <div id="div_steps">
        <input type="button" id="btn_GoToLicense" class="el_button_input" value="<%=model.GoToLicenseLanguage%>" onclick="el_ShowGroupSection('pnl_License', 'el_install_group'); Javascript: return false;" />
        <input type="button" id="btn_GoToDateAndTime" class="el_button_input" value="<%=model.GoToDateAndTimeLanguage%>" onclick="el_ShowGroupSection('pnl_DateAndTime', 'el_install_group'); Javascript: return false;" />
        <input type="button" id="btn_GoToSite" class="el_button_input" value="<%=model.GoToSiteLanguage%>" onclick="el_ShowGroupSection('pnl_Site', 'el_install_group'); Javascript: return false;" />
        <input type="button" id="btn_GoToUser" class="el_button_input" value="<%=model.GoToUserLanguage%>" onclick="el_ShowGroupSection('pnl_User', 'el_install_group'); Javascript: return false;" />
    </div>

    <div id="div_main">

        <div class="el_head">
            <%=model.InstallLanguage%>
        </div>

        <form id="frm_Install" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>install/Install.aspx">

            <div id="pnl_License" class="el_install_group">
                <div class="el_part_row">
                    <div id="div_LicenseTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                        <%=model.LicenseLanguage%>
                        <div class="el_dash"></div>
                    </div>
                    <div id="pnl_InstallCode" class="<%=model.InstallCodePanelCssClass%>">
                        <div class="el_item">
                            <%=model.InstallCodeLanguage%>
                        </div>
                        <div class="el_item">
                            <input id="txt_InstallCode" name="txt_InstallCode" type="password" value="<%=model.InstallCodeValue%>" class="el_text_input<%=model.InstallCodeCssClass%>" <%=model.InstallCodeAttribute%> />
                        </div>
                    </div>
                    <div class="el_item">
                        <%=model.LicenseLanguage%>
                    </div>
                    <div class="el_item">
                        <textarea id="txt_License" class="el_textarea_input" readonly="readonly"><%=model.LicenseValue%></textarea>
                    </div>
                    <div class="el_item el_red_text">
                        <%=model.UpdateAlertValue%>
                    </div>
                    <div class="el_item">
                        <span class="el_checkbox_input el_important_field">
                            <input id="cbx_AgreeLicense" name="cbx_AgreeLicense" type="checkbox" /><label for="cbx_AgreeLicense"><%=model.AgreeLicenseLanguage%></label></span>
                    </div>
                    <div class="el_item">
                        <input type="button" id="btn_Next1" class="el_button_input" value="<%=model.NextLanguage%>" onclick="el_ShowGroupSection('pnl_DateAndTime', 'el_install_group'); Javascript: return false;" />
                    </div>
                </div>
            </div>

            <div id="pnl_DateAndTime" class="el_install_group el_hidden">
                <div class="el_part_row">
                    <div id="div_DateAndTimeTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                        <%=model.DateAndTimeLanguage%>
                        <div class="el_dash"></div>
                    </div>
                    <div class="el_item">
                        <%=model.SiteTimeZoneLanguage%>
                    </div>
                    <div class="el_item">
                        <select id="ddlst_SiteTimeZone" name="ddlst_SiteTimeZone" class="el_alone_select_input<%=model.SiteTimeZoneCssClass%>" <%=model.SiteTimeZoneAttribute%>>
                            <%=model.SiteTimeZoneOptionListValue %>
                        </select>
                    </div>
                    <div class="el_item">
                        <input type="button" id="btn_Previous1" class="el_button_input" value="<%=model.PreviousLanguage%>" onclick="el_ShowGroupSection('pnl_License', 'el_install_group'); Javascript: return false;" /><input type="button" id="btn_Next2" class="el_button_input" value="<%=model.NextLanguage%>" onclick="el_ShowGroupSection('pnl_Site', 'el_install_group'); Javascript: return false;" />
                    </div>
                </div>
            </div>

            <div id="pnl_Site" class="el_install_group el_hidden">
                <div class="el_part_row">
                    <div id="div_SiteTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                        <%=model.SiteLanguage%>
                        <div class="el_dash"></div>
                    </div>
                    <div class="el_item">
                        <%=model.HostPathLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_HostPath" name="txt_HostPath" type="text" value="<%=model.HostPathValue%>" class="el_text_input el_left_to_right<%=model.HostPathCssClass%>" <%=model.HostPathAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.SiteNameLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_SiteName" name="txt_SiteName" type="text" value="<%=model.SiteNameValue%>" class="el_text_input<%=model.SiteNameCssClass%>" <%=model.SiteNameAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.SiteLanguageLanguage%>
                    </div>
                    <div class="el_item">
                        <select id="ddlst_SiteLanguage" name="ddlst_SiteLanguage" class="el_alone_select_input<%=model.SiteLanguageCssClass%>" <%=model.SiteLanguageAttribute%>>
                            <%=model.SiteLanguageOptionListValue %>
                        </select>
                    </div>
                    <div class="el_item">
                        <%=model.SiteEmailLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_SiteEmail" name="txt_SiteEmail" type="text" value="<%=model.SiteEmailValue%>" class="el_text_input el_left_to_right<%=model.SiteEmailCssClass%>" <%=model.SiteEmailAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.SiteTitleLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_SiteTitle" name="txt_SiteTitle" type="text" value="<%=model.SiteTitleValue%>" class="el_text_input<%=model.SiteTitleCssClass%>" <%=model.SiteTitleAttribute%> />
                    </div>
                    <div class="el_item">
                        <input type="button" id="btn_Previous2" class="el_button_input" value="<%=model.PreviousLanguage%>" onclick="el_ShowGroupSection('pnl_DateAndTime', 'el_install_group'); Javascript: return false;" /><input type="button" id="btn_Next3" class="el_button_input" value="<%=model.NextLanguage%>" onclick="el_ShowGroupSection('pnl_User', 'el_install_group'); Javascript: return false;" />
                    </div>
                </div>
            </div>

            <div id="pnl_User" class="el_install_group<%=model.UserPanelCssClass%>">
                <div class="el_part_row">
                    <div id="div_AdminUserTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                        <%=model.AdminUserLanguage%>
                        <div class="el_dash"></div>
                    </div>
                    <div class="el_item">
                        <%=model.UserSiteNameLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_UserSiteName" name="txt_UserSiteName" type="text" value="<%=model.UserSiteNameValue%>" class="el_text_input<%=model.UserSiteNameCssClass%>" <%=model.UserSiteNameAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.UserNameLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_UserName" name="txt_UserName" type="text" value="<%=model.UserNameValue%>" class="el_text_input<%=model.UserNameCssClass%>" <%=model.UserNameAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.UserRealNameLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_UserRealName" name="txt_UserRealName" type="text" value="<%=model.UserRealNameValue%>" class="el_text_input<%=model.UserRealNameCssClass%>" <%=model.UserRealNameAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.UserRealLastNameLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_UserRealLastName" name="txt_UserRealLastName" type="text" value="<%=model.UserRealLastNameValue%>" class="el_text_input<%=model.UserRealLastNameCssClass%>" <%=model.UserRealLastNameAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.UserEmailLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_UserEmail" name="txt_UserEmail" type="text" value="<%=model.UserEmailValue%>" class="el_text_input el_left_to_right<%=model.UserEmailCssClass%>" <%=model.UserEmailAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.RepeatUserEmailLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_RepeatUserEmail" name="txt_RepeatUserEmail" type="text" value="<%=model.RepeatUserEmailValue%>" class="el_text_input el_left_to_right<%=model.RepeatUserEmailCssClass%>" <%=model.RepeatUserEmailAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.UserPasswordLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_UserPassword" name="txt_UserPassword" type="password" value="<%=model.UserPasswordValue%>" class="el_text_input<%=model.UserPasswordCssClass%>" <%=model.UserPasswordAttribute%> />
                    </div>
                    <div class="el_item">
                        <%=model.RepeatUserPasswordLanguage%>
                    </div>
                    <div class="el_item">
                        <input id="txt_RepeatUserPassword" name="txt_RepeatUserPassword" type="password" value="<%=model.RepeatUserPasswordValue%>" class="el_text_input<%=model.RepeatUserPasswordCssClass%>" <%=model.RepeatUserPasswordAttribute%> />
                    </div>
                    <div class="el_item">
                        <input type="button" id="btn_Previous3" class="el_button_input" value="<%=model.PreviousLanguage%>" onclick="el_ShowGroupSection('pnl_Site', 'el_install_group'); Javascript: return false;" /><input id="btn_Submit" name="btn_Submit" type="submit" class="el_button_input" value="<%=model.SubmitLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_Install')" />
                    </div>
                </div>
            </div>
        </form>
    </div>

</body>
</html>