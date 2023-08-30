<%@ Page Controller="Elanat.SitePublicUserInfoController" Model="Elanat.SitePublicUserInfoModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentSiteLanguageDirection()%>">
<head>
    <title><%=model.ProfileHeadLanguage%></title>
    <!-- Start Client Variant -->
    <%=Elanat.AspxHtmlValue.CurrentSiteClientVariant()%>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
	<script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/site/site.js" ></script>
    <%=Elanat.AspxHtmlValue.CurrentSiteStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/site_global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>

    <div class="el_head">
        <%=model.ProfileHeadLanguage%>
    </div>
    <div class="el_part_row" style="background-color:<%=model.BackgroundColorValue%> !important;color:<%=model.FontColorValue%> !important">
        <div id="div_UserInfoTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
            <%=model.UserInfoTitleLanguage%>
            <div class="el_dash"></div>
        </div>
        <div class="el_item">
            <div class="el_user_avatar">
                <div class="el_user_<%=model.UserOnlineOfflineValue%>"></div>
                <%=model.UserAvatarValue%>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserIsOnlineLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserIsOnlineValue%>
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
                    <%=model.UserZipCodeLanguage%>>
                </div>
                <div class="el_extra_value">
                    <%=model.UserZipCodeValue%>
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
                    <%=model.UserPercentOfContentValue%>%
                </div>
            </div>
        </div>
       
        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserRssContentLanguage%>
                </div>
                <div class="el_extra_value">
                    <span class="el_user_rss_mini_icon">
                        <%=model.UserRssContentValue%>
                    </span>
                </div>
            </div>
        </div>

        <div class="el_item">
            <%=model.UserOtherInfoLanguage%>
        </div>
        <div class="el_item">
            <%=model.UserOtherInfoValue%>
        </div>

        <div class="el_item">
            <%=model.UserAddressLanguage%>
        </div>
        <div class="el_item">
            <%=model.UserAddressValue%>
        </div>

        <div class="el_item">
            <%=model.UserAboutLanguage%>
        </div>
        <div class="el_item">
            <%=model.UserAboutValue%>
        </div>

    </div>

</body>
</html>