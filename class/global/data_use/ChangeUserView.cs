namespace Elanat.DataUse
{
    public class ChangeUserView
    {
        public string UserId;
        public string UserBackgroundColor;
        public string UserFontSize;
        public string UserCommonLightBackgroundColor;
        public string UserCommonLightTextColor;
        public string UserCommonMiddleBackgroundColor;
        public string UserCommonMiddleTextColor;
        public string UserCommonDarkBackgroundColor;
        public string UserCommonDarkTextColor;
        public string UserNaturalLightBackgroundColor;
        public string UserNaturalLightTextColor;
        public string UserNaturalMiddleBackgroundColor;
        public string UserNaturalMiddleTextColor;
        public string UserNaturalDarkBackgroundColor;
        public string UserNaturalDarkTextColor;
        public string UserInfoBackgroundColor;
        public string UserInfoFontColor;
        public bool UserShowUserAvatarInUserInfo;
        public bool UserShowUserOnlineInUserInfo;
        public bool UserShowUserEmailInUserInfo;
        public bool UserShowUserBirthdayInUserInfo;
        public bool UserShowUserGenderInUserInfo;
        public bool UserShowUserPhoneNumberInUserInfo;
        public bool UserShowUserMobileNumberInUserInfo;
        public bool UserShowUserCountryInUserInfo;
        public bool UserShowUserStateOrProvinceInUserInfo;
        public bool UserShowUserCityInUserInfo;
        public bool UserShowUserZipCodeInUserInfo;
        public bool UserShowUserPostalCodeInUserInfo;
        public bool UserShowUserAddressInUserInfo;
        public bool UserShowUserWebsiteInUserInfo;
        public bool UserShowUserLastLoginInUserInfo;

        public void Start()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("change_user_view", new List<string>() { "@user_id", "@user_background_color", "@user_font_size", "@user_common_light_background_color", "@user_common_light_text_color", "@user_common_middle_background_color", "@user_common_middle_text_color", "@user_common_dark_background_color", "@user_common_dark_text_color", "@user_natural_light_background_color", "@user_natural_light_text_color", "@user_natural_middle_background_color", "@user_natural_middle_text_color", "@user_natural_dark_background_color", "@user_natural_dark_text_color", "@user_user_info_background_color", "@user_user_info_font_color", "@user_show_user_avatar_in_user_info", "@user_show_user_online_in_user_info", "@user_show_user_email_in_user_info", "@user_show_user_birthday_in_user_info", "@user_show_user_gender_in_user_info", "@user_show_user_phone_number_in_user_info", "@user_show_user_mobile_number_in_user_info", "@user_show_user_country_in_user_info", "@user_show_user_state_or_province_in_user_info", "@user_show_user_city_in_user_info", "@user_show_user_zip_code_in_user_info", "@user_show_user_postal_code_in_user_info", "@user_show_user_address_in_user_info", "@user_show_user_website_in_user_info", "@user_show_user_last_login_in_user_info" }, new List<string>() { UserId, UserBackgroundColor, UserFontSize, UserCommonLightBackgroundColor, UserCommonLightTextColor, UserCommonMiddleBackgroundColor, UserCommonMiddleTextColor, UserCommonDarkBackgroundColor, UserCommonDarkTextColor, UserNaturalLightBackgroundColor, UserNaturalLightTextColor, UserNaturalMiddleBackgroundColor, UserNaturalMiddleTextColor, UserNaturalDarkBackgroundColor, UserNaturalDarkTextColor, UserInfoBackgroundColor, UserInfoFontColor, UserShowUserAvatarInUserInfo.BooleanToZeroOne(), UserShowUserOnlineInUserInfo.BooleanToZeroOne(), UserShowUserEmailInUserInfo.BooleanToZeroOne(), UserShowUserBirthdayInUserInfo.BooleanToZeroOne(), UserShowUserGenderInUserInfo.BooleanToZeroOne(), UserShowUserPhoneNumberInUserInfo.BooleanToZeroOne(), UserShowUserMobileNumberInUserInfo.BooleanToZeroOne(), UserShowUserCountryInUserInfo.BooleanToZeroOne(), UserShowUserStateOrProvinceInUserInfo.BooleanToZeroOne(), UserShowUserCityInUserInfo.BooleanToZeroOne(), UserShowUserZipCodeInUserInfo.BooleanToZeroOne(), UserShowUserPostalCodeInUserInfo.BooleanToZeroOne(), UserShowUserAddressInUserInfo.BooleanToZeroOne(), UserShowUserWebsiteInUserInfo.BooleanToZeroOne(), UserShowUserLastLoginInUserInfo.BooleanToZeroOne() });
        }
    }
}