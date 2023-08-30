using CodeBehind;

namespace Elanat
{
    public partial class SitePublicUserInfoModel : CodeBehindModel
    {      
        // Set Language
        public string UserInfoTitleLanguage { get; set; }
        public string ProfileHeadLanguage { get; set; }
        public string UserIsOnlineLanguage { get; set; }
        public string UserGroupNameLanguage { get; set; }
        public string UserRealNameLanguage { get; set; }
        public string UserRealLastNameLanguage { get; set; }
        public string UserSiteNameLanguage { get; set; }
        public string UserDateCreateLanguage { get; set; }
        public string UserEmailLanguage { get; set; }
        public string UserPhoneNumberLanguage { get; set; }
        public string UserAddressLanguage { get; set; }
        public string UserPostalCodeLanguage { get; set; }
        public string UserBirthdayLanguage { get; set; }
        public string UserGenderLanguage { get; set; }
        public string UserPublicEmailLanguage { get; set; }
        public string UserMobileNumberLanguage { get; set; }
        public string UserZipCodeLanguage { get; set; }
        public string UserOtherInfoLanguage { get; set; }
        public string UserCountryLanguage { get; set; }
        public string UserStateOrProvinceLanguage { get; set; }
        public string UserCityLanguage { get; set; }
        public string UserWebsiteLanguage { get; set; }
        public string UserAboutLanguage { get; set; }
        public string UserLastLoginLanguage { get; set; }
        public string UserContentCountLanguage { get; set; }
        public string UserCommentCountLanguage { get; set; }
        public string UserPercentOfContentLanguage { get; set; }
        public string UserRssContentLanguage { get; set; }

        public string BackgroundColorValue { get; set; }
        public string FontColorValue { get; set; }
        public string UserAvatarValue { get; set; }
        public string UserOnlineOfflineValue { get; set; }
        public string UserIsOnlineValue { get; set; }
        public string UserGroupNameValue { get; set; }
        public string UserRealNameValue { get; set; }
        public string UserRealLastNameValue { get; set; }
        public string UserSiteNameValue { get; set; }
        public string UserDateCreateValue { get; set; }
        public string UserEmailValue { get; set; }
        public string UserPhoneNumberValue { get; set; }
        public string UserAddressValue { get; set; }
        public string UserPostalCodeValue { get; set; }
        public string UserBirthdayValue { get; set; }
        public string UserGenderValue { get; set; }
        public string UserPublicEmailValue { get; set; }
        public string UserMobileNumberValue { get; set; }
        public string UserZipCodeValue { get; set; }
        public string UserOtherInfoValue { get; set; }
        public string UserCountryValue { get; set; }
        public string UserStateOrProvinceValue { get; set; }
        public string UserCityValue { get; set; }
        public string UserWebsiteValue { get; set; }
        public string UserAboutValue { get; set; }
        public string UserLastLoginValue { get; set; }
        public string UserContentCountValue { get; set; }
        public string UserCommentCountValue { get; set; }
        public string UserPercentOfContentValue { get; set; }
        public string UserRssContentValue { get; set; }

        public void SetValue(string UserId)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/public_user_info/");
            UserInfoTitleLanguage = aol.GetAddOnsLanguage("user_info");
            ProfileHeadLanguage = aol.GetAddOnsLanguage("profile");
            UserIsOnlineLanguage = aol.GetAddOnsLanguage("user_is_online");
            UserGroupNameLanguage = aol.GetAddOnsLanguage("user_group_name");
            UserRealNameLanguage = aol.GetAddOnsLanguage("user_real_name");
            UserRealLastNameLanguage = aol.GetAddOnsLanguage("user_real_last_name");
            UserSiteNameLanguage = aol.GetAddOnsLanguage("user_site_name");
            UserDateCreateLanguage = aol.GetAddOnsLanguage("user_date_create");
            UserEmailLanguage = aol.GetAddOnsLanguage("user_email");
            UserPhoneNumberLanguage = aol.GetAddOnsLanguage("user_phone_number");
            UserAddressLanguage = aol.GetAddOnsLanguage("user_address");
            UserPostalCodeLanguage = aol.GetAddOnsLanguage("user_postal_code");
            UserBirthdayLanguage = aol.GetAddOnsLanguage("user_birthday");
            UserGenderLanguage = aol.GetAddOnsLanguage("user_gender");
            UserPublicEmailLanguage = aol.GetAddOnsLanguage("user_public_email");
            UserMobileNumberLanguage = aol.GetAddOnsLanguage("user_mobile_number");
            UserZipCodeLanguage = aol.GetAddOnsLanguage("user_zip_code");
            UserOtherInfoLanguage = aol.GetAddOnsLanguage("user_other_info");
            UserCountryLanguage = aol.GetAddOnsLanguage("user_country");
            UserStateOrProvinceLanguage = aol.GetAddOnsLanguage("user_state_or_province");
            UserCityLanguage = aol.GetAddOnsLanguage("user_city");
            UserWebsiteLanguage = aol.GetAddOnsLanguage("user_website");
            UserAboutLanguage = aol.GetAddOnsLanguage("user_about");
            UserLastLoginLanguage = aol.GetAddOnsLanguage("user_last_login");
            UserContentCountLanguage = aol.GetAddOnsLanguage("user_content_count");
            UserCommentCountLanguage = aol.GetAddOnsLanguage("user_comment_count");
            UserPercentOfContentLanguage = aol.GetAddOnsLanguage("user_percent_of_content");
            UserRssContentLanguage = aol.GetAddOnsLanguage("user_rss_content");


            // Set User Info
            DataBaseSocket db = new DataBaseSocket();

            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_info", "@user_id", UserId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            string Private = aol.GetAddOnsLanguage("private");

            BackgroundColorValue = dbdr.dr["user_user_info_background_color"].ToString();
            FontColorValue = dbdr.dr["user_user_info_font_color"].ToString();
            UserAvatarValue = (dbdr.dr["user_show_user_avatar_in_user_info"].ToString().TrueFalseToBoolean()) ? Template.GetSiteTemplate("part/user_avatar_image").Replace("$_db user_id;", dbdr.dr["user_id"].ToString()) : "";
            UserIsOnlineValue = (dbdr.dr["user_show_user_online_in_user_info"].ToString().TrueFalseToBoolean()) ? (Language.GetLanguage(StaticObject.UserIsOnline(UserId).BooleanToTrueFalse(), StaticObject.GetCurrentSiteGlobalLanguage())) : Private;
            UserOnlineOfflineValue = (dbdr.dr["user_show_user_online_in_user_info"].ToString().TrueFalseToBoolean()) ? ((StaticObject.UserIsOnline(UserId)) ? "online" : "offline") : "offline";
            UserGroupNameValue = dbdr.dr["group_name"].ToString();
            UserRealNameValue = dbdr.dr["user_real_name"].ToString();
            UserRealLastNameValue = dbdr.dr["user_real_last_name"].ToString();
            UserSiteNameValue = dbdr.dr["user_site_name"].ToString();
            UserDateCreateValue = dbdr.dr["user_date_create"].ToString();
            UserEmailValue = (dbdr.dr["user_show_user_email_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_email"].ToString() : Private;
            UserPhoneNumberValue = (dbdr.dr["user_show_user_phone_number_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_phone_number"].ToString() : Private;
            UserAddressValue = (dbdr.dr["user_show_user_address_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_address"].ToString() : Private;
            UserPostalCodeValue = (dbdr.dr["user_show_user_postal_code_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_postal_code"].ToString() : Private;
            UserBirthdayValue = (dbdr.dr["user_show_user_birthday_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_birthday"].ToString() : Private;
            UserGenderValue = (dbdr.dr["user_show_user_gender_in_user_info"].ToString().TrueFalseToBoolean()) ? Language.GetLanguage((dbdr.dr["user_gender"].ToString().TrueFalseToBoolean()) ? "female" : "male", StaticObject.GetCurrentSiteGlobalLanguage()) : Private;
            UserPublicEmailValue = dbdr.dr["user_public_email"].ToString();
            UserMobileNumberValue = (dbdr.dr["user_show_user_mobile_number_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_mobile_number"].ToString() : Private;
            UserZipCodeValue = (dbdr.dr["user_show_user_zip_code_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_zip_code"].ToString() : Private;
            UserOtherInfoValue = dbdr.dr["user_other_info"].ToString();
            UserCountryValue = (dbdr.dr["user_show_user_country_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_country"].ToString() : Private;
            UserStateOrProvinceValue = (dbdr.dr["user_show_user_state_or_province_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_state_or_province"].ToString() : Private;
            UserCityValue = (dbdr.dr["user_show_user_city_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_city"].ToString() : Private;
            UserWebsiteValue = (dbdr.dr["user_show_user_website_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_website"].ToString() : Private;
            UserAboutValue = dbdr.dr["user_about"].ToString();
            UserLastLoginValue = (dbdr.dr["user_show_user_last_login_in_user_info"].ToString().TrueFalseToBoolean()) ? dbdr.dr["user_last_login"].ToString() : Private;
            UserContentCountValue = dbdr.dr["user_content_count"].ToString();
            UserCommentCountValue = dbdr.dr["user_comment_count"].ToString();
            UserPercentOfContentValue = dbdr.dr["user_percent_of_content"].ToString();
            UserRssContentValue = Template.GetSiteTemplate("part/user_rss").Replace("$_asp user_id;", dbdr.dr["user_id"].ToString());

            db.Close();
        }
    }
}