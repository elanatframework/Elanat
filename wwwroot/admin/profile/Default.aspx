<%@ Page Controller="Elanat.AdminProfileController" Model="Elanat.AdminProfileModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ProfileLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/profile/script/profile.js"></script>
    <!-- Start Client Variant -->
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=Elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=Elanat.AspxHtmlValue.CurrentBoxTag()%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.ProfileLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_ChangePassword" type="button" value="<%=model.ChangePasswordLanguage%>" class="el_add" onclick="el_ChangePassword()" />
        <input id="btn_ChangeEmail" type="button" value="<%=model.ChangeEmailLanguage%>" class="el_add" onclick="el_ChangeEmail()" />
        <input id="btn_ChangeAvatar" type="button" value="<%=model.ChangeAvatarLanguage%>" class="el_add" onclick="el_ChangeAvatar()" />
        <input id="btn_ChangeLanguage" type="button" value="<%=model.ChangeLanguageLanguage%>" class="el_add" onclick="el_ChangeLanguage()" />
        <input id="btn_ChangeTemplateAndStyle" type="button" value="<%=model.ChangeTemplateAndStyleLanguage%>" class="el_add" onclick="el_ChangeTemplateAndStyle()" />
        <input id="btn_ChangeGroup" type="button" value="<%=model.ChangeGroupLanguage%>" class="el_add" onclick="el_ChangeGroup()" />
        <input id="btn_ChangeDateAndTime" type="button" value="<%=model.ChangeDateAndTimeLanguage%>" class="el_add" onclick="el_ChangeDateAndTime()" />
        <input id="btn_ChangeView" type="button" value="<%=model.ChangeViewLanguage%>" class="el_add" onclick="el_ChangeView()" />
        <input id="btn_ChangeProfile" type="button" value="<%=model.ChangeProfileLanguage%>" class="el_add" onclick="el_ChangeProfile()" />
    </div>

    <div class="el_part_row">
        <div id="div_UserInfoTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
            <%=model.UserInfoLanguage%>
            <div class="el_dash"></div>
        </div>
        <div class="el_item">
            <%=model.UserAvatarValue%>
        </div>



        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserIdLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserIdValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserGroupNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserGroupNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserRealNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserRealNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserRealLastNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserRealLastNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserSiteNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserSiteNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserDateCreateLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserDateCreateValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserEmailLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserEmailValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserPhoneNumberLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserPhoneNumberValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserPostalCodeLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserPostalCodeValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserBirthdayLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserBirthdayValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserGenderLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserGenderValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserNumberOfUploadLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserNumberOfUploadValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserSizeOfUploadLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserSizeOfUploadValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserPublicEmailLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserPublicEmailValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserMobileNumberLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserMobileNumberValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserZipCodeLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserZipCodeValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserDefaultSiteStyleNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserDefaultSiteStyleNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserDefaultSiteTemplateNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserDefaultSiteTemplateNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserDefaultAdminStyleNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserDefaultAdminStyleNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserDefaultAdminTemplateNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserDefaultAdminTemplateNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserCountryLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserCountryValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserStateOrProvinceLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserStateOrProvinceValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserCityLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserCityValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserWebsiteLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserWebsiteValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserLastLoginLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserLastLoginValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserContentCountLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserContentCountValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserCommentCountLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserCommentCountValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserPercentOfContentLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserPercentOfContentValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <%=model.UserOtherInfoLanguage%>
        </div>
        <div class="el_item el_label">
            <%=model.UserOtherInfoValue%>
        </div>

        <div class="el_item">
            <%=model.UserAddressLanguage%>
        </div>
        <div class="el_item el_label">
            <%=model.UserAddressValue%>
        </div>

        <div class="el_item">
            <%=model.UserAboutLanguage%>
        </div>
        <div class="el_item el_label">
            <%=model.UserAboutValue%>
        </div>

        <div class="el_item">
            <%=model.DeleteFootPrintLanguage%>
        </div>
        <div class="el_item">
            <form id="frm_AdminDeleteFootPrint" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/profile/Default.aspx">
                <input id="btn_DeleteFootPrint" name="btn_DeleteFootPrint" type="submit" class="el_button_input" value="<%=model.DeleteLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminDeleteFootPrint')" />
            </form>
        </div>
    </div>
    
</body>
</html>