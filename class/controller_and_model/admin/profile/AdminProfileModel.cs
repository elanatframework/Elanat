using CodeBehind;

namespace Elanat
{
    public partial class AdminProfileModel : CodeBehindModel
    {
        public string ChangePasswordLanguage { get; set; }
        public string ChangeEmailLanguage { get; set; }
        public string ChangeAvatarLanguage { get; set; }
        public string ChangeLanguageLanguage { get; set; }
        public string ChangeTemplateAndStyleLanguage { get; set; }
        public string ChangeGroupLanguage { get; set; }
        public string ChangeDateAndTimeLanguage { get; set; }
        public string ChangeViewLanguage { get; set; }
        public string ChangeProfileLanguage { get; set; }
        public string UserIdLanguage { get; set; }
        public string UserGroupNameLanguage { get; set; }
        public string UserNameLanguage { get; set; }
        public string UserNumberOfUploadLanguage { get; set; }
        public string UserSizeOfUploadLanguage { get; set; }
        public string UserDefaultSiteStyleNameLanguage { get; set; }
        public string UserDefaultSiteTemplateNameLanguage { get; set; }
        public string UserDefaultAdminStyleNameLanguage { get; set; }
        public string UserDefaultAdminTemplateNameLanguage { get; set; }
        public string DeleteFootPrintLanguage { get; set; }
        public string UserInfoLanguage { get; set; }
        public string ProfileLanguage { get; set; }
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
        public string DeleteLanguage { get; set; }

        public string UserIdValue { get; set; }
        public string UserNameValue { get; set; }
        public string UserNumberOfUploadValue { get; set; }
        public string UserSizeOfUploadValue { get; set; }
        public string UserDefaultSiteStyleNameValue { get; set; }
        public string UserDefaultSiteTemplateNameValue { get; set; }
        public string UserDefaultAdminStyleNameValue { get; set; }
        public string UserDefaultAdminTemplateNameValue { get; set; }
        public string UserAvatarValue { get; set; }
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

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/profile/");
            ChangePasswordLanguage = aol.GetAddOnsLanguage("change_password");
            ChangeEmailLanguage = aol.GetAddOnsLanguage("change_email");
            ChangeAvatarLanguage = aol.GetAddOnsLanguage("change_avatar");
            ChangeLanguageLanguage = aol.GetAddOnsLanguage("change_language");
            ChangeTemplateAndStyleLanguage = aol.GetAddOnsLanguage("change_template_and_style");
            ChangeGroupLanguage = aol.GetAddOnsLanguage("change_group");
            ChangeDateAndTimeLanguage = aol.GetAddOnsLanguage("change_date_and_time");
            ChangeViewLanguage = aol.GetAddOnsLanguage("change_view");
            ChangeProfileLanguage = aol.GetAddOnsLanguage("change_profile");
            ProfileLanguage = aol.GetAddOnsLanguage("profile");
            UserInfoLanguage = aol.GetAddOnsLanguage("user_info");
            UserIdLanguage = aol.GetAddOnsLanguage("user_id");
            UserGroupNameLanguage = aol.GetAddOnsLanguage("user_group_name");
            UserNameLanguage = aol.GetAddOnsLanguage("user_name");
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
            UserNumberOfUploadLanguage = aol.GetAddOnsLanguage("user_number_of_upload");
            UserSizeOfUploadLanguage = aol.GetAddOnsLanguage("user_size_of_upload");
            UserPublicEmailLanguage = aol.GetAddOnsLanguage("user_public_email");
            UserMobileNumberLanguage = aol.GetAddOnsLanguage("user_mobile_number");
            UserZipCodeLanguage = aol.GetAddOnsLanguage("user_zip_code");
            UserOtherInfoLanguage = aol.GetAddOnsLanguage("user_other_info");
            UserDefaultSiteStyleNameLanguage = aol.GetAddOnsLanguage("default_site_style_name");
            UserDefaultSiteTemplateNameLanguage = aol.GetAddOnsLanguage("default_site_template_name");
            UserDefaultAdminStyleNameLanguage = aol.GetAddOnsLanguage("default_admin_style_name");
            UserDefaultAdminTemplateNameLanguage = aol.GetAddOnsLanguage("default_admin_template_name");
            UserCountryLanguage = aol.GetAddOnsLanguage("user_country");
            UserStateOrProvinceLanguage = aol.GetAddOnsLanguage("user_state_or_province");
            UserCityLanguage = aol.GetAddOnsLanguage("user_city");
            UserWebsiteLanguage = aol.GetAddOnsLanguage("user_website");
            UserAboutLanguage = aol.GetAddOnsLanguage("user_about");
            UserLastLoginLanguage = aol.GetAddOnsLanguage("user_last_login");
            UserContentCountLanguage = aol.GetAddOnsLanguage("user_content_count");
            UserCommentCountLanguage = aol.GetAddOnsLanguage("user_comment_count");
            UserPercentOfContentLanguage = aol.GetAddOnsLanguage("user_percent_of_content");
            DeleteFootPrintLanguage = aol.GetAddOnsLanguage("delete_foot_print");
            DeleteLanguage = aol.GetAddOnsLanguage("delete");


            // Set User Info
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_info", "@user_id", ccoc.UserId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            UserAvatarValue = Template.GetSiteTemplate("part/user_avatar_image").Replace("$_db user_id;", dbdr.dr["user_id"].ToString());
            UserIdValue = dbdr.dr["user_id"].ToString();
            UserGroupNameValue = dbdr.dr["group_name"].ToString();
            UserNameValue = dbdr.dr["user_name"].ToString();
            UserRealNameValue = dbdr.dr["user_real_name"].ToString();
            UserRealLastNameValue = dbdr.dr["user_real_last_name"].ToString();
            UserSiteNameValue = dbdr.dr["user_site_name"].ToString();
            UserDateCreateValue = dbdr.dr["user_date_create"].ToString();
            UserEmailValue = dbdr.dr["user_email"].ToString();
            UserPhoneNumberValue = dbdr.dr["user_phone_number"].ToString();
            UserAddressValue = dbdr.dr["user_address"].ToString();
            UserPostalCodeValue = dbdr.dr["user_postal_code"].ToString();
            UserBirthdayValue = dbdr.dr["user_birthday"].ToString();
            UserGenderValue = Language.GetLanguage((dbdr.dr["user_gender"].ToString().TrueFalseToBoolean()) ? "female" : "male", StaticObject.GetCurrentAdminGlobalLanguage());
            UserNumberOfUploadValue = dbdr.dr["user_number_of_upload"].ToString();
            UserSizeOfUploadValue = dbdr.dr["user_size_of_upload"].ToString();
            UserPublicEmailValue = dbdr.dr["user_public_email"].ToString();
            UserMobileNumberValue = dbdr.dr["user_mobile_number"].ToString();
            UserZipCodeValue = dbdr.dr["user_zip_code"].ToString();
            UserOtherInfoValue = dbdr.dr["user_other_info"].ToString();
            UserDefaultSiteStyleNameValue = dbdr.dr["site_style_name"].ToString();
            UserDefaultSiteTemplateNameValue = dbdr.dr["site_template_name"].ToString();
            UserDefaultAdminStyleNameValue = dbdr.dr["admin_style_name"].ToString();
            UserDefaultAdminTemplateNameValue = dbdr.dr["admin_template_name"].ToString();
            UserCountryValue = dbdr.dr["user_country"].ToString();
            UserStateOrProvinceValue = dbdr.dr["user_state_or_province"].ToString();
            UserCityValue = dbdr.dr["user_city"].ToString();
            UserWebsiteValue = dbdr.dr["user_website"].ToString();
            UserAboutValue = dbdr.dr["user_about"].ToString();
            UserLastLoginValue = dbdr.dr["user_last_login"].ToString();
            UserContentCountValue = dbdr.dr["user_content_count"].ToString();
            UserCommentCountValue = dbdr.dr["user_comment_count"].ToString();
            UserPercentOfContentValue = dbdr.dr["user_percent_of_content"].ToString() + "%";

            db.Close();
        }

        public void DeleteFootPrint()
        {
            // Get Current Client Object
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.FootPrint duft = new DataUse.FootPrint();
            duft.DeleteUserFootPrint(ccoc.UserId);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_foot_print", ccoc.UserId);
        }

        public void DeleteFootPrintAccessErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_do_not_access_to_delete_own_foot_print", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/profile/"), "problem");
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/profile/action/SuccessMessage.aspx", true);
        }
    }
}