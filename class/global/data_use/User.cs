using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class User : IDisposable
    {
        public string UserId = "";
        public string UserName = "";
        public string GroupId = "";
        public string UserSiteName = "";
        public string UserRealName = "";
        public string UserRealLastName = "";
        public string UserPassword = "";
        public string UserDateCreate = "";
        public string UserLastLogin = "";
        public string UserActive = "";
        public string UserEmail = "";
        public string UserPhoneNumber = "";
        public string UserAddress = "";
        public string UserPostalCode = "";
        public string UserAbout = "";
        public string UserBirthday = "";
        public string UserGender = "";
        public string UserNumberOfUpload = "";
        public string UserSizeOfUpload = "";
        public string UserPublicEmail = "";
        public string UserMobileNumber = "";
        public string UserZipCode = "";
        public string UserEmailIsConfirm = "";
        public string UserOtherInfo = "";
        public string SiteStyleId = "";
        public string SiteTemplateId = "";
        public string AdminStyleId = "";
        public string AdminTemplateId = "";
        public string UserCountry = "";
        public string UserStateOrProvince = "";
        public string UserCity = "";
        public string UserWebsite = "";
        public string SiteLanguageId = "";
        public string AdminLanguageId = "";
        public string UserCalendar = "";
        public string UserFirstDayOfWeek = "";
        public string UserTimeZone = "";
        public string UserDateFormat = "";
        public string UserTimeFormat = "";
        public string UserDayDifference = "";
        public string UserTimeHoursDifference = "";
        public string UserTimeMinutesDifference = "";
        public string UserCommonLightBackgroundColor = "";
        public string UserCommonLightTextColor = "";
        public string UserCommonMiddleBackgroundColor = "";
        public string UserCommonMiddleTextColor = "";
        public string UserCommonDarkBackgroundColor = "";
        public string UserCommonDarkTextColor = "";
        public string UserNaturalLightBackgroundColor = "";
        public string UserNaturalLightTextColor = "";
        public string UserNaturalMiddleBackgroundColor = "";
        public string UserNaturalMiddleTextColor = "";
        public string UserNaturalDarkBackgroundColor = "";
        public string UserNaturalDarkTextColor = "";
        public string UserBackgroundColor = "";
        public string UserFontSize = "";
        public string UserUserInfoBackgroundColor = "";
        public string UserUserInfoFontColor = "";
        public string UserShowUserAvatarInUserinfo = "";
        public string UserShowUseronlineInUserinfo = "";
        public string UserShowUserEmailInUserinfo = "";
        public string UserShowUserBirthdayInUserinfo = "";
        public string UserShowUserGenderInUserinfo = "";
        public string UserShowUserPhoneNumberInUserinfo = "";
        public string UserShowUserMobileNumberInUserinfo = "";
        public string UserShowUserCountryInUserInfo = "";
        public string UserShowUserStateOrProvinceInUserInfo = "";
        public string UserShowUserCityInUserInfo = "";
        public string UserShowUserZipCodeInUserInfo = "";
        public string UserShowUserPostalCodeInUserInfo = "";
        public string UserShowUserAddressInUserInfo = "";
        public string UserShowUserWebsiteInUserInfo = "";
        public string UserShowUserLastLoginInUserInfo = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_user", "@user_id", UserId);
        }

        public void Inactive(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_user", "@user_id", UserId);
        }

        public void Delete(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_user", "@user_id", UserId);

            // Delete Physical File
            File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/user_avatar/" + UserId + ".png"));
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/user_data/user_" + UserId + "/"), true);
        }

        public void DeleteFootPrint(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_user_foot_print", "@user_id", UserId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_user", new List<string>() { "@user_name", "@group_id", "@user_site_name", "@user_real_name", "@user_real_last_name", "@user_password", "@user_date_create", "@user_active", "@user_email", "@user_phone_number", "@user_address", "@user_postal_code", "@user_about", "@user_birthday", "@user_gender", "@user_public_email", "@user_mobile_number", "@user_zip_code", "@user_email_is_confirm", "@user_other_info", "@user_country", "@user_state_or_province", "@user_city", "@user_website" }, new List<string>() { UserName, GroupId, UserSiteName, UserRealName, UserRealLastName, UserPassword, UserDateCreate, UserActive, UserEmail, UserPhoneNumber, UserAddress, UserPostalCode, UserAbout, UserBirthday, UserGender, UserPublicEmail, UserMobileNumber, UserZipCode, UserEmailIsConfirm, UserOtherInfo, UserCountry, UserStateOrProvince, UserCity, UserWebsite });

            dbdr.dr.Read();

            UserId = dbdr.dr["user_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_user", new List<string>() { "@user_name", "@group_id", "@user_site_name", "@user_real_name", "@user_real_last_name", "@user_password", "@user_date_create", "@user_active", "@user_email", "@user_phone_number", "@user_address", "@user_postal_code", "@user_about", "@user_birthday", "@user_gender", "@user_public_email", "@user_mobile_number", "@user_zip_code", "@user_email_is_confirm", "@user_other_info", "@user_country", "@user_state_or_province", "@user_city", "@user_website" }, new List<string>() { UserName, GroupId, UserSiteName, UserRealName, UserRealLastName, UserPassword, UserDateCreate, UserActive, UserEmail, UserPhoneNumber, UserAddress, UserPostalCode, UserAbout, UserBirthday, UserGender, UserPublicEmail, UserMobileNumber, UserZipCode, UserEmailIsConfirm, UserOtherInfo, UserCountry, UserStateOrProvince, UserCity, UserWebsite });

            ReturnDr.Read();

            UserId = ReturnDr["user_id"].ToString();
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();

            if (string.IsNullOrEmpty(UserPassword))
                db.SetProcedure("edit_user", new List<string>() { "@user_id", "@group_id", "@user_name", "@user_site_name", "@user_real_name", "@user_real_last_name", "@user_date_create", "@user_active", "@user_email", "@user_phone_number", "@user_address", "@user_postal_code", "@user_about", "@user_birthday", "@user_gender", "@user_public_email", "@user_mobile_number", "@user_zip_code", "@user_email_is_confirm", "@user_other_info", "@user_country", "@user_state_or_province", "@user_city", "@user_website" }, new List<string>() { UserId, GroupId, UserName, UserSiteName, UserRealName, UserRealLastName, UserDateCreate, UserActive, UserEmail, UserPhoneNumber, UserAddress, UserPostalCode, UserAbout, UserBirthday, UserGender, UserPublicEmail, UserMobileNumber, UserZipCode, UserEmailIsConfirm, UserOtherInfo, UserCountry, UserStateOrProvince, UserCity, UserWebsite });
            else
                db.SetProcedure("edit_user", new List<string>() { "@user_id", "@group_id", "@user_name", "@user_site_name", "@user_real_name", "@user_real_last_name", "@user_password", "@user_date_create", "@user_active", "@user_email", "@user_phone_number", "@user_address", "@user_postal_code", "@user_about", "@user_birthday", "@user_gender", "@user_public_email", "@user_mobile_number", "@user_zip_code", "@user_email_is_confirm", "@user_other_info", "@user_country", "@user_state_or_province", "@user_city", "@user_website" }, new List<string>() { UserId, GroupId, UserName, UserSiteName, UserRealName, UserRealLastName, UserPassword, UserDateCreate, UserActive, UserEmail, UserPhoneNumber, UserAddress, UserPostalCode, UserAbout, UserBirthday, UserGender, UserPublicEmail, UserMobileNumber, UserZipCode, UserEmailIsConfirm, UserOtherInfo, UserCountry, UserStateOrProvince, UserCity, UserWebsite });
        }

        public void FillCurrentUser(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_user", "@user_id", UserId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.UserId = dbdr.dr["user_id"].ToString();
            UserName = dbdr.dr["user_name"].ToString();
            GroupId = dbdr.dr["group_id"].ToString();
            UserSiteName = dbdr.dr["user_site_name"].ToString();
            UserRealName = dbdr.dr["user_real_name"].ToString();
            UserRealLastName = dbdr.dr["user_real_last_name"].ToString();
            UserPassword = dbdr.dr["user_password"].ToString();
            UserDateCreate = dbdr.dr["user_date_create"].ToString();
            UserLastLogin = dbdr.dr["user_last_login"].ToString();
            UserActive = dbdr.dr["user_active"].ToString().TrueFalseToZeroOne();
            UserEmail = dbdr.dr["user_email"].ToString();
            UserPhoneNumber = dbdr.dr["user_phone_number"].ToString();
            UserAddress = dbdr.dr["user_address"].ToString();
            UserPostalCode = dbdr.dr["user_postal_code"].ToString();
            UserAbout = dbdr.dr["user_about"].ToString();
            UserBirthday = dbdr.dr["user_birthday"].ToString();
            UserGender = dbdr.dr["user_gender"].ToString();
            UserNumberOfUpload = dbdr.dr["user_number_of_upload"].ToString();
            UserSizeOfUpload = dbdr.dr["user_size_of_upload"].ToString();
            UserPublicEmail = dbdr.dr["user_public_email"].ToString();
            UserMobileNumber = dbdr.dr["user_mobile_number"].ToString();
            UserZipCode = dbdr.dr["user_zip_code"].ToString();
            UserEmailIsConfirm = dbdr.dr["user_email_is_confirm"].ToString().TrueFalseToZeroOne();
            UserOtherInfo = dbdr.dr["user_other_info"].ToString();
            SiteStyleId = dbdr.dr["site_style_id"].ToString();
            SiteTemplateId = dbdr.dr["site_template_id"].ToString();
            AdminStyleId = dbdr.dr["admin_style_id"].ToString();
            AdminTemplateId = dbdr.dr["admin_template_id"].ToString();
            UserCountry = dbdr.dr["user_country"].ToString();
            UserStateOrProvince = dbdr.dr["user_state_or_province"].ToString();
            UserCity = dbdr.dr["user_city"].ToString();
            UserWebsite = dbdr.dr["user_website"].ToString();
            SiteLanguageId = dbdr.dr["site_language_id"].ToString();
            AdminLanguageId = dbdr.dr["admin_language_id"].ToString();
            UserCalendar = dbdr.dr["user_calendar"].ToString();
            UserFirstDayOfWeek = dbdr.dr["user_first_day_of_week"].ToString();
            UserTimeZone = dbdr.dr["user_time_zone"].ToString();
            UserDateFormat = dbdr.dr["user_date_format"].ToString();
            UserTimeFormat = dbdr.dr["user_time_format"].ToString();
            UserDayDifference = dbdr.dr["user_day_difference"].ToString();
            UserTimeHoursDifference = dbdr.dr["user_time_hours_difference"].ToString();
            UserTimeMinutesDifference = dbdr.dr["user_time_minutes_difference"].ToString();
            UserCommonLightBackgroundColor = dbdr.dr["user_common_light_background_color"].ToString();
            UserCommonLightTextColor = dbdr.dr["user_common_light_text_color"].ToString();
            UserCommonMiddleBackgroundColor = dbdr.dr["user_common_middle_background_color"].ToString();
            UserCommonMiddleTextColor = dbdr.dr["user_common_middle_text_color"].ToString();
            UserCommonDarkBackgroundColor = dbdr.dr["user_common_dark_background_color"].ToString();
            UserCommonDarkTextColor = dbdr.dr["user_common_dark_text_color"].ToString();
            UserNaturalLightBackgroundColor = dbdr.dr["user_natural_light_background_color"].ToString();
            UserNaturalLightTextColor = dbdr.dr["user_natural_light_text_color"].ToString();
            UserNaturalMiddleBackgroundColor = dbdr.dr["user_natural_middle_background_color"].ToString();
            UserNaturalMiddleTextColor = dbdr.dr["user_natural_middle_text_color"].ToString();
            UserNaturalDarkBackgroundColor = dbdr.dr["user_natural_dark_background_color"].ToString();
            UserNaturalDarkTextColor = dbdr.dr["user_natural_dark_text_color"].ToString();
            UserBackgroundColor = dbdr.dr["user_background_color"].ToString();
            UserFontSize = dbdr.dr["user_font_size"].ToString();
            UserUserInfoBackgroundColor = dbdr.dr["user_user_info_background_color"].ToString();
            UserUserInfoFontColor = dbdr.dr["user_user_info_font_color"].ToString();
            UserShowUserAvatarInUserinfo = dbdr.dr["user_show_user_avatar_in_user_info"].ToString();
            UserShowUseronlineInUserinfo = dbdr.dr["user_show_user_online_in_user_info"].ToString();
            UserShowUserEmailInUserinfo = dbdr.dr["user_show_user_email_in_user_info"].ToString();
            UserShowUserBirthdayInUserinfo = dbdr.dr["user_show_user_birthday_in_user_info"].ToString();
            UserShowUserGenderInUserinfo = dbdr.dr["user_show_user_gender_in_user_info"].ToString();
            UserShowUserPhoneNumberInUserinfo = dbdr.dr["user_show_user_phone_number_in_user_info"].ToString();
            UserShowUserMobileNumberInUserinfo = dbdr.dr["user_show_user_mobile_number_in_user_info"].ToString();
            UserShowUserCountryInUserInfo = dbdr.dr["user_show_user_country_in_user_info"].ToString();
            UserShowUserStateOrProvinceInUserInfo = dbdr.dr["user_show_user_state_or_province_in_user_info"].ToString();
            UserShowUserCityInUserInfo = dbdr.dr["user_show_user_city_in_user_info"].ToString();
            UserShowUserZipCodeInUserInfo = dbdr.dr["user_show_user_zip_code_in_user_info"].ToString();
            UserShowUserPostalCodeInUserInfo = dbdr.dr["user_show_user_postal_code_in_user_info"].ToString();
            UserShowUserAddressInUserInfo = dbdr.dr["user_show_user_address_in_user_info"].ToString();
            UserShowUserWebsiteInUserInfo = dbdr.dr["user_show_user_website_in_user_info"].ToString();
            UserShowUserLastLoginInUserInfo = dbdr.dr["user_show_user_last_login_in_user_info"].ToString();

            db.Close();
        }

        public void FillCurrentUserWithReturnDr(string UserId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_user", "@user_id", UserId);

            if (ReturnDr == null || !ReturnDr.HasRows)
            {
                ReturnDb.Close();
                return;
            }

            ReturnDr.Read();
        }

        public string GetColumnValue(string ColumnName)
        {
            switch (ColumnName)
            {
                case "user_id": return UserId;
                case "user_name": return UserName;
                case "group_id": return GroupId;
                case "user_site_name": return UserSiteName;
                case "user_real_name": return UserRealName;
                case "user_real_last_name": return UserRealLastName;
                case "user_password": return UserPassword;
                case "user_date_create": return UserDateCreate;
                case "user_last_login": return UserLastLogin;
                case "user_active": return UserActive;
                case "user_email": return UserEmail;
                case "user_phone_number": return UserPhoneNumber;
                case "user_address": return UserAddress;
                case "user_postal_code": return UserPostalCode;
                case "user_about": return UserAbout;
                case "user_birthday": return UserBirthday;
                case "user_gender": return UserGender;
                case "user_number_of_upload": return UserNumberOfUpload;
                case "user_size_of_upload": return UserSizeOfUpload;
                case "user_public_email": return UserPublicEmail;
                case "user_mobile_number": return UserMobileNumber;
                case "user_zip_code": return UserZipCode;
                case "user_email_is_confirm": return UserEmailIsConfirm;
                case "user_other_info": return UserOtherInfo;
                case "site_style_id": return SiteStyleId;
                case "site_template_id": return SiteTemplateId;
                case "admin_style_id": return AdminStyleId;
                case "admin_template_id": return AdminTemplateId;
                case "user_country": return UserCountry;
                case "user_state_or_province": return UserStateOrProvince;
                case "user_city": return UserCity;
                case "user_website": return UserWebsite;
                case "site_language_id": return SiteLanguageId;
                case "admin_language_id": return AdminLanguageId;
                case "user_calendar": return UserCalendar;
                case "user_first_day_of_week": return UserFirstDayOfWeek;
                case "user_time_zone": return UserTimeZone;
                case "user_date_format": return UserDateFormat;
                case "user_time_format": return UserTimeFormat;
                case "user_day_difference": return UserDayDifference;
                case "user_time_hours_difference": return UserTimeHoursDifference;
                case "user_time_minutes_difference": return UserTimeMinutesDifference;
                case "user_common_light_background_color": return UserCommonLightBackgroundColor;
                case "user_common_light_text_color": return UserCommonLightTextColor;
                case "user_common_middle_background_color": return UserCommonMiddleBackgroundColor;
                case "user_common_middle_text_color": return UserCommonMiddleTextColor;
                case "user_common_dark_background_color": return UserCommonDarkBackgroundColor;
                case "user_common_dark_text_color": return UserCommonDarkTextColor;
                case "user_natural_light_background_color": return UserNaturalLightBackgroundColor;
                case "user_natural_light_text_color": return UserNaturalLightTextColor;
                case "user_natural_middle_background_color": return UserNaturalMiddleBackgroundColor;
                case "user_natural_middle_text_color": return UserNaturalMiddleTextColor;
                case "user_natural_dark_background_color": return UserNaturalDarkBackgroundColor;
                case "user_natural_dark_text_color": return UserNaturalDarkTextColor;
                case "user_background_color": return UserBackgroundColor;
                case "user_font_size": return UserFontSize;
                case "user_user_info_background_color": return UserUserInfoBackgroundColor;
                case "user_user_info_font_color": return UserUserInfoFontColor;
                case "user_show_user_avatar_in_user_info": return UserShowUserAvatarInUserinfo;
                case "user_show_user_online_in_user_info": return UserShowUseronlineInUserinfo;
                case "user_show_user_email_in_user_info": return UserShowUserEmailInUserinfo;
                case "user_show_user_birthday_in_user_info": return UserShowUserBirthdayInUserinfo;
                case "user_show_user_gender_in_user_info": return UserShowUserGenderInUserinfo;
                case "user_show_user_phone_number_in_user_info": return UserShowUserPhoneNumberInUserinfo;
                case "user_show_user_mobile_number_in_user_info": return UserShowUserMobileNumberInUserinfo;
                case "user_show_user_country_in_user_info": return UserShowUserCountryInUserInfo;
                case "user_show_user_state_or_province_in_user_info": return UserShowUserStateOrProvinceInUserInfo;
                case "user_show_user_city_in_user_info": return UserShowUserCityInUserInfo;
                case "user_show_user_zip_code_in_user_info": return UserShowUserZipCodeInUserInfo;
                case "user_show_user_postal_code_in_user_info": return UserShowUserPostalCodeInUserInfo;
                case "user_show_user_address_in_user_info": return UserShowUserAddressInUserInfo;
                case "user_show_user_website_in_user_info": return UserShowUserWebsiteInUserInfo;
                case "user_show_user_last_login_in_user_info": return UserShowUserLastLoginInUserInfo;

            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            UserId = "";
            UserName = "";
            GroupId = "";
            UserSiteName = "";
            UserRealName = "";
            UserRealLastName = "";
            UserPassword = "";
            UserDateCreate = "";
            UserLastLogin = "";
            UserActive = "";
            UserEmail = "";
            UserPhoneNumber = "";
            UserAddress = "";
            UserPostalCode = "";
            UserAbout = "";
            UserBirthday = "";
            UserGender = "";
            UserNumberOfUpload = "";
            UserSizeOfUpload = "";
            UserPublicEmail = "";
            UserMobileNumber = "";
            UserZipCode = "";
            UserEmailIsConfirm = "";
            UserOtherInfo = "";
            SiteStyleId = "";
            SiteTemplateId = "";
            AdminStyleId = "";
            AdminTemplateId = "";
            UserCountry = "";
            UserStateOrProvince = "";
            UserCity = "";
            UserWebsite = "";
            SiteLanguageId = "";
            AdminLanguageId = "";
            UserCalendar = "";
            UserFirstDayOfWeek = "";
            UserTimeZone = "";
            UserDateFormat = "";
            UserTimeFormat = "";
            UserDayDifference = "";
            UserTimeHoursDifference = "";
            UserTimeMinutesDifference = "";
            UserCommonLightBackgroundColor = "";
            UserCommonLightTextColor = "";
            UserCommonMiddleBackgroundColor = "";
            UserCommonMiddleTextColor = "";
            UserCommonDarkBackgroundColor = "";
            UserCommonDarkTextColor = "";
            UserNaturalLightBackgroundColor = "";
            UserNaturalLightTextColor = "";
            UserNaturalMiddleBackgroundColor = "";
            UserNaturalMiddleTextColor = "";
            UserNaturalDarkBackgroundColor = "";
            UserNaturalDarkTextColor = "";
            UserBackgroundColor = "";
            UserFontSize = "";
            UserUserInfoBackgroundColor = "";
            UserUserInfoFontColor = "";
            UserShowUserAvatarInUserinfo = "";
            UserShowUseronlineInUserinfo = "";
            UserShowUserEmailInUserinfo = "";
            UserShowUserBirthdayInUserinfo = "";
            UserShowUserGenderInUserinfo = "";
            UserShowUserPhoneNumberInUserinfo = "";
            UserShowUserMobileNumberInUserinfo = "";
            UserShowUserCountryInUserInfo = "";
            UserShowUserStateOrProvinceInUserInfo = "";
            UserShowUserCityInUserInfo = "";
            UserShowUserZipCodeInUserInfo = "";
            UserShowUserPostalCodeInUserInfo = "";
            UserShowUserAddressInUserInfo = "";
            UserShowUserWebsiteInUserInfo = "";
            UserShowUserLastLoginInUserInfo = "";

            ReturnDr.Close();
        }

        public void ActiveUserEmailConfirm(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_user_email_is_confirm", "@user_id", UserId);
        }

        public void ChangeUserPassword(string UserId, string Password)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("change_user_password", new List<string>() { "@user_id", "@password" }, new List<string>() { UserId, Password });
        }

        public void ChangeUserEmail(string UserId, string Email)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("change_user_email", new List<string>() { "@user_id", "@email" }, new List<string>() { UserId, Email });
        }

        public void ChangeUserGroup(string UserId, string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("change_user_group", new List<string>() { "@user_id", "@group_id" }, new List<string>() { UserId, GroupId });
        }

        public string GetUserCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_count");

            dbdr.dr.Read();

            string UserCount = dbdr.dr["user_count"].ToString();

            db.Close();

            return UserCount;
        }

        public string GetTodayNewUserCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_today_new_user_count", "@user_date_create", DateAndTime.GetDate("yyyy/MM/dd"));

            dbdr.dr.Read();

            string TodayUserCount = dbdr.dr["today_user_count"].ToString();

            db.Close();

            return TodayUserCount;
        }

        public void InstallUser()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("set_install_user", new List<string>() { "@user_site_name", "@user_name", "@user_real_name", "@user_real_last_name", "@user_email", "@user_password" }, new List<string>() { UserSiteName, UserName, UserRealName, UserRealLastName, UserEmail, UserPassword });
        }


        public void ChangeUserLanguage(string UserId, string SiteLanguageId, string AdminLanguageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("change_user_language", new List<string>() { "@user_id", "@site_language_id", "@admin_language_id" }, new List<string>() { UserId, SiteLanguageId, AdminLanguageId });
        }

        public string GetUserCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string UserCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return UserCount;
        }

        public bool ExistUserNameCheck(string UserName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("exist_user_name_check", "@user_name", UserName);

            bool ExistUserName = dbdr.dr.HasRows;

            db.Close();

            return ExistUserName;
        }

        public void SetUserLastLogin(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("set_user_last_login", new List<string>() { "@user_id", "@user_last_login" }, new List<string>() { UserId, DateAndTime.GetDate("yyyy/MM/dd") + "-" + DateAndTime.GetTime("HH:mm:ss") });
        }

        public string GetUserName(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_name", "@user_id", UserId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string UserName = dbdr.dr["user_name"].ToString();

                db.Close();

                return UserName;
            }

            db.Close();

            return null;
        }

        public string GetUserSiteName(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_site_name", "@user_id", UserId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string UserSiteName = dbdr.dr["user_site_name"].ToString();

                db.Close();

                return UserSiteName;
            }

            db.Close();

            return null;
        }

        public string GetUserIdByUserSiteName(string UserSiteName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_id_by_user_site_name", "@user_site_name", UserSiteName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string UserId = dbdr.dr["user_id"].ToString();

                db.Close();

                return UserId;
            }

            db.Close();

            return null;
        }

        public string GetUserEmail(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_email", "@user_id", UserId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string UserEmail = dbdr.dr["user_email"].ToString();

                db.Close();

                return UserEmail;
            }

            db.Close();

            return null;
        }

        public void IncreaseUserUpload(string UserId, string FileSize)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("increase_user_upload", new List<string>() { "@user_id", "@file_size" }, new List<string>() { UserId, FileSize });
        }

        public void DecreaseUserUpload(string UserId, string FileSize)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("decrease_user_upload", new List<string>() { "@user_id", "@file_size" }, new List<string>() { UserId, FileSize });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Refresh();
                ReturnDb.Close();
                ReturnDb.Dispose();
            }
        }
    }
}