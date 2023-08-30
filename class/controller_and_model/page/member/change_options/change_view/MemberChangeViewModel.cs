using CodeBehind;

namespace Elanat
{
    public partial class MemberChangeViewModel : CodeBehindModel
    {
        public string ChangeViewLanguage { get; set; }
        public string MemberLanguage { get; set; }
        public string UserBackgroundColorLanguage { get; set; }
        public string UserFontSizeLanguage { get; set; }
        public string UserCommonLightBackgroundColorLanguage { get; set; }
        public string UserCommonLightTextColorLanguage { get; set; }
        public string UserCommonMiddleBackgroundColorLanguage { get; set; }
        public string UserCommonMiddleTextColorLanguage { get; set; }
        public string UserCommonDarkBackgroundColorLanguage { get; set; }
        public string UserCommonDarkTextColorLanguage { get; set; }
        public string UserNaturalLightBackgroundColorLanguage { get; set; }
        public string UserNaturalLightTextColorLanguage { get; set; }
        public string UserNaturalMiddleBackgroundColorLanguage { get; set; }
        public string UserNaturalMiddleTextColorLanguage { get; set; }
        public string UserNaturalDarkBackgroundColorLanguage { get; set; }
        public string UserNaturalDarkTextColorLanguage { get; set; }
        public string UserInfoBackgroundColorLanguage { get; set; }
        public string UserInfoFontColorLanguage { get; set; }
        public string ShowUserAvatarInUserInfoLanguage { get; set; }
        public string ShowUserOnlineInUserInfoLanguage { get; set; }
        public string ShowUserEmailInUserInfoLanguage { get; set; }
        public string ShowUserBirthdayInUserInfoLanguage { get; set; }
        public string ShowUserGenderInUserInfoLanguage { get; set; }
        public string ShowUserPhoneNumberInUserInfoLanguage { get; set; }
        public string ShowUserMobileNumberInUserInfoLanguage { get; set; }
        public string ShowUserCountryInUserInfoLanguage { get; set; }
        public string ShowUserStateOrProvinceInUserInfoLanguage { get; set; }
        public string ShowUserCityInUserInfoLanguage { get; set; }
        public string ShowUserZipCodeInUserInfoLanguage { get; set; }
        public string ShowUserPostalCodeInUserInfoLanguage { get; set; }
        public string ShowUserAddressInUserInfoLanguage { get; set; }
        public string ShowUserWebsiteInUserInfoLanguage { get; set; }
        public string ShowUserLastLoginInUserInfoLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;

        public bool ShowUserAvatarInUserInfoValue { get; set; } = false;
        public bool ShowUserOnlineInUserInfoValue { get; set; } = false;
        public bool ShowUserEmailInUserInfoValue { get; set; } = false;
        public bool ShowUserBirthdayInUserInfoValue { get; set; } = false;
        public bool ShowUserGenderInUserInfoValue { get; set; } = false;
        public bool ShowUserPhoneNumberInUserInfoValue { get; set; } = false;
        public bool ShowUserMobileNumberInUserInfoValue { get; set; } = false;
        public bool ShowUserCountryInUserInfoValue { get; set; } = false;
        public bool ShowUserStateOrProvinceInUserInfoValue { get; set; } = false;
        public bool ShowUserCityInUserInfoValue { get; set; } = false;
        public bool ShowUserZipCodeInUserInfoValue { get; set; } = false;
        public bool ShowUserPostalCodeInUserInfoValue { get; set; } = false;
        public bool ShowUserAddressInUserInfoValue { get; set; } = false;
        public bool ShowUserWebsiteInUserInfoValue { get; set; } = false;
        public bool ShowUserLastLoginInUserInfoValue { get; set; } = false;

        public string UserBackgroundColorValue { get; set; }
        public string UserFontSizeValue { get; set; }
        public string UserCommonLightBackgroundColorValue { get; set; }
        public string UserCommonLightTextColorValue { get; set; }
        public string UserCommonMiddleBackgroundColorValue { get; set; }
        public string UserCommonMiddleTextColorValue { get; set; }
        public string UserCommonDarkBackgroundColorValue { get; set; }
        public string UserCommonDarkTextColorValue { get; set; }
        public string UserNaturalLightBackgroundColorValue { get; set; }
        public string UserNaturalLightTextColorValue { get; set; }
        public string UserNaturalMiddleBackgroundColorValue { get; set; }
        public string UserNaturalMiddleTextColorValue { get; set; }
        public string UserNaturalDarkBackgroundColorValue { get; set; }
        public string UserNaturalDarkTextColorValue { get; set; }
        public string UserInfoBackgroundColorValue { get; set; }
        public string UserInfoFontColorValue { get; set; }

        public string UserBackgroundColorAttribute { get; set; }
        public string UserFontSizeAttribute { get; set; }
        public string UserCommonLightBackgroundColorAttribute { get; set; }
        public string UserCommonLightTextColorAttribute { get; set; }
        public string UserCommonMiddleBackgroundColorAttribute { get; set; }
        public string UserCommonMiddleTextColorAttribute { get; set; }
        public string UserCommonDarkBackgroundColorAttribute { get; set; }
        public string UserCommonDarkTextColorAttribute { get; set; }
        public string UserNaturalLightBackgroundColorAttribute { get; set; }
        public string UserNaturalLightTextColorAttribute { get; set; }
        public string UserNaturalMiddleBackgroundColorAttribute { get; set; }
        public string UserNaturalMiddleTextColorAttribute { get; set; }
        public string UserNaturalDarkBackgroundColorAttribute { get; set; }
        public string UserNaturalDarkTextColorAttribute { get; set; }
        public string UserInfoBackgroundColorAttribute { get; set; }
        public string UserInfoFontColorAttribute { get; set; }

        public string UserBackgroundColorCssClass { get; set; }
        public string UserFontSizeCssClass { get; set; }
        public string UserCommonLightBackgroundColorCssClass { get; set; }
        public string UserCommonLightTextColorCssClass { get; set; }
        public string UserCommonMiddleBackgroundColorCssClass { get; set; }
        public string UserCommonMiddleTextColorCssClass { get; set; }
        public string UserCommonDarkBackgroundColorCssClass { get; set; }
        public string UserCommonDarkTextColorCssClass { get; set; }
        public string UserNaturalLightBackgroundColorCssClass { get; set; }
        public string UserNaturalLightTextColorCssClass { get; set; }
        public string UserNaturalMiddleBackgroundColorCssClass { get; set; }
        public string UserNaturalMiddleTextColorCssClass { get; set; }
        public string UserNaturalDarkBackgroundColorCssClass { get; set; }
        public string UserNaturalDarkTextColorCssClass { get; set; }
        public string UserInfoBackgroundColorCssClass { get; set; }
        public string UserInfoFontColorCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_options/change_view/");
            ChangeViewLanguage = aol.GetAddOnsLanguage("change_view");
            MemberLanguage = aol.GetAddOnsLanguage("member");
            UserBackgroundColorLanguage = aol.GetAddOnsLanguage("user_background_color");
            UserFontSizeLanguage = aol.GetAddOnsLanguage("user_font_size");
            UserCommonLightBackgroundColorLanguage = aol.GetAddOnsLanguage("user_common_light_background_color");
            UserCommonLightTextColorLanguage = aol.GetAddOnsLanguage("user_common_light_text_color");
            UserCommonMiddleBackgroundColorLanguage = aol.GetAddOnsLanguage("user_common_middle_background_color");
            UserCommonMiddleTextColorLanguage = aol.GetAddOnsLanguage("user_common_middle_text_color");
            UserCommonDarkBackgroundColorLanguage = aol.GetAddOnsLanguage("user_common_dark_background_color");
            UserCommonDarkTextColorLanguage = aol.GetAddOnsLanguage("user_common_dark_text_color");
            UserNaturalLightBackgroundColorLanguage = aol.GetAddOnsLanguage("user_natural_light_background_color");
            UserNaturalLightTextColorLanguage = aol.GetAddOnsLanguage("user_natural_light_text_color");
            UserNaturalMiddleBackgroundColorLanguage = aol.GetAddOnsLanguage("user_natural_middle_background_color");
            UserNaturalMiddleTextColorLanguage = aol.GetAddOnsLanguage("user_natural_middle_text_color");
            UserNaturalDarkBackgroundColorLanguage = aol.GetAddOnsLanguage("user_natural_dark_background_color");
            UserNaturalDarkTextColorLanguage = aol.GetAddOnsLanguage("user_natural_dark_text_color");
            UserInfoBackgroundColorLanguage = aol.GetAddOnsLanguage("user_info_background_color");
            UserInfoFontColorLanguage = aol.GetAddOnsLanguage("user_info_font_color");
            ShowUserAvatarInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_avatar_in_user_info");
            ShowUserOnlineInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_online_in_user_info");
            ShowUserEmailInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_email_in_user_info");
            ShowUserBirthdayInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_birthday_in_user_info");
            ShowUserGenderInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_gender_in_user_info");
            ShowUserPhoneNumberInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_phone_number_in_user_info");
            ShowUserMobileNumberInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_mobile_number_in_user_info");
            ShowUserCountryInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_country_in_user_info");
            ShowUserStateOrProvinceInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_state_or_province_in_user_info");
            ShowUserCityInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_city_in_user_info");
            ShowUserZipCodeInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_zip_code_in_user_info");
            ShowUserPostalCodeInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_postal_code_in_user_info");
            ShowUserAddressInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_address_in_user_info");
            ShowUserWebsiteInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_website_in_user_info");
            ShowUserLastLoginInUserInfoLanguage = aol.GetAddOnsLanguage("show_user_last_login_in_user_info");


            // Set User Info
            if (IsFirstStart)
            {
                DataBaseSocket db = new DataBaseSocket();

                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                DataBaseDataReader dbdr = new DataBaseDataReader();
			    dbdr.dr = db.GetProcedure("get_user_info", "@user_id", ccoc.UserId);
                if (dbdr.dr != null && dbdr.dr.HasRows)
                    dbdr.dr.Read();

                // Set Current Value
                UserBackgroundColorValue = dbdr.dr["user_background_color"].ToString();
                UserFontSizeValue = dbdr.dr["user_font_size"].ToString();
                UserCommonLightBackgroundColorValue = dbdr.dr["user_common_light_background_color"].ToString();
                UserCommonLightTextColorValue = dbdr.dr["user_common_light_text_color"].ToString();
                UserCommonMiddleBackgroundColorValue = dbdr.dr["user_common_middle_background_color"].ToString();
                UserCommonMiddleTextColorValue = dbdr.dr["user_common_middle_text_color"].ToString();
                UserCommonDarkBackgroundColorValue = dbdr.dr["user_common_dark_background_color"].ToString();
                UserCommonDarkTextColorValue = dbdr.dr["user_common_dark_text_color"].ToString();
                UserNaturalLightBackgroundColorValue = dbdr.dr["user_natural_light_background_color"].ToString();
                UserNaturalLightTextColorValue = dbdr.dr["user_natural_light_text_color"].ToString();
                UserNaturalMiddleBackgroundColorValue = dbdr.dr["user_natural_middle_background_color"].ToString();
                UserNaturalMiddleTextColorValue = dbdr.dr["user_natural_middle_text_color"].ToString();
                UserNaturalDarkBackgroundColorValue = dbdr.dr["user_natural_dark_background_color"].ToString();
                UserNaturalDarkTextColorValue = dbdr.dr["user_natural_dark_text_color"].ToString();
                UserInfoBackgroundColorValue = dbdr.dr["user_user_info_background_color"].ToString();
                UserInfoFontColorValue = dbdr.dr["user_user_info_font_color"].ToString();
                ShowUserAvatarInUserInfoValue = (dbdr.dr["user_show_user_avatar_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserOnlineInUserInfoValue = (dbdr.dr["user_show_user_online_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserEmailInUserInfoValue = (dbdr.dr["user_show_user_email_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserBirthdayInUserInfoValue = (dbdr.dr["user_show_user_birthday_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserGenderInUserInfoValue = (dbdr.dr["user_show_user_gender_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserPhoneNumberInUserInfoValue = (dbdr.dr["user_show_user_phone_number_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserMobileNumberInUserInfoValue = (dbdr.dr["user_show_user_mobile_number_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserCountryInUserInfoValue = (dbdr.dr["user_show_user_country_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserStateOrProvinceInUserInfoValue = (dbdr.dr["user_show_user_state_or_province_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserCityInUserInfoValue = (dbdr.dr["user_show_user_city_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserZipCodeInUserInfoValue = (dbdr.dr["user_show_user_zip_code_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserPostalCodeInUserInfoValue = (dbdr.dr["user_show_user_postal_code_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserAddressInUserInfoValue = (dbdr.dr["user_show_user_address_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserWebsiteInUserInfoValue = (dbdr.dr["user_show_user_website_in_user_info"].ToString().TrueFalseToBoolean());
                ShowUserLastLoginInUserInfoValue = (dbdr.dr["user_show_user_last_login_in_user_info"].ToString().TrueFalseToBoolean());

                db.Close();

                UserFontSizeValue = "99";
            }
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_UserBackgroundColor", "");
            InputRequest.Add("txt_UserFontSize", "");
            InputRequest.Add("txt_UserCommonLightBackgroundColor", "");
            InputRequest.Add("txt_UserCommonLightTextColor", "");
            InputRequest.Add("txt_UserCommonMiddleBackgroundColor", "");
            InputRequest.Add("txt_UserCommonMiddleTextColor", "");
            InputRequest.Add("txt_UserCommonDarkBackgroundColor", "");
            InputRequest.Add("txt_UserCommonDarkTextColor", "");
            InputRequest.Add("txt_UserNaturalLightBackgroundColor", "");
            InputRequest.Add("txt_UserNaturalLightTextColor", "");
            InputRequest.Add("txt_UserNaturalMiddleBackgroundColor", "");
            InputRequest.Add("txt_UserNaturalMiddleTextColor", "");
            InputRequest.Add("txt_UserNaturalDarkBackgroundColor", "");
            InputRequest.Add("txt_UserNaturalDarkTextColor", "");
            InputRequest.Add("txt_UserInfoBackgroundColor", "");
            InputRequest.Add("txt_UserInfoFontColor", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/member/change_options/change_view/");

            UserBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserBackgroundColor");
            UserFontSizeAttribute += vc.ImportantInputAttribute.GetValue("txt_UserFontSize");
            UserCommonLightBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserCommonLightBackgroundColor");
            UserCommonLightTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserCommonLightTextColor");
            UserCommonMiddleBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserCommonMiddleBackgroundColor");
            UserCommonMiddleTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserCommonMiddleTextColor");
            UserCommonDarkBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserCommonDarkBackgroundColor");
            UserCommonDarkTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserCommonDarkTextColor");
            UserNaturalLightBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserNaturalLightBackgroundColor");
            UserNaturalLightTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserNaturalLightTextColor");
            UserNaturalMiddleBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserNaturalMiddleBackgroundColor");
            UserNaturalMiddleTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserNaturalMiddleTextColor");
            UserNaturalDarkBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserNaturalDarkBackgroundColor");
            UserNaturalDarkTextColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserNaturalDarkTextColor");
            UserInfoBackgroundColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserInfoBackgroundColor");
            UserInfoFontColorAttribute += vc.ImportantInputAttribute.GetValue("txt_UserInfoFontColor");

            UserBackgroundColorCssClass = UserBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserBackgroundColor"));
            UserFontSizeCssClass = UserFontSizeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserFontSize"));
            UserCommonLightBackgroundColorCssClass = UserCommonLightBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserCommonLightBackgroundColor"));
            UserCommonLightTextColorCssClass = UserCommonLightTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserCommonLightTextColor"));
            UserCommonMiddleBackgroundColorCssClass = UserCommonMiddleBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserCommonMiddleBackgroundColor"));
            UserCommonMiddleTextColorCssClass = UserCommonMiddleTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserCommonMiddleTextColor"));
            UserCommonDarkBackgroundColorCssClass = UserCommonDarkBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserCommonDarkBackgroundColor"));
            UserCommonDarkTextColorCssClass = UserCommonDarkTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserCommonDarkTextColor"));
            UserNaturalLightBackgroundColorCssClass = UserNaturalLightBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserNaturalLightBackgroundColor"));
            UserNaturalLightTextColorCssClass = UserNaturalLightTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserNaturalLightTextColor"));
            UserNaturalMiddleBackgroundColorCssClass = UserNaturalMiddleBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserNaturalMiddleBackgroundColor"));
            UserNaturalMiddleTextColorCssClass = UserNaturalMiddleTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserNaturalMiddleTextColor"));
            UserNaturalDarkBackgroundColorCssClass = UserNaturalDarkBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserNaturalDarkBackgroundColor"));
            UserNaturalDarkTextColorCssClass = UserNaturalDarkTextColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserNaturalDarkTextColor"));
            UserInfoBackgroundColorCssClass = UserInfoBackgroundColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserInfoBackgroundColor"));
            UserInfoFontColorCssClass = UserInfoFontColorCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserInfoFontColor"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/member/change_options/change_view/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void ChangeView()
        {
            // Get Current Client Object
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.ChangeUserView ducuv = new DataUse.ChangeUserView();

            ducuv.UserId = ccoc.UserId;
            ducuv.UserBackgroundColor = UserBackgroundColorValue;
            ducuv.UserFontSize = UserFontSizeValue;
            ducuv.UserCommonLightBackgroundColor = UserCommonLightBackgroundColorValue;
            ducuv.UserCommonLightTextColor = UserCommonLightTextColorValue;
            ducuv.UserCommonMiddleBackgroundColor = UserCommonMiddleBackgroundColorValue;
            ducuv.UserCommonMiddleTextColor = UserCommonMiddleTextColorValue;
            ducuv.UserCommonDarkBackgroundColor = UserCommonDarkBackgroundColorValue;
            ducuv.UserCommonDarkTextColor = UserCommonDarkTextColorValue;
            ducuv.UserNaturalLightBackgroundColor = UserNaturalLightBackgroundColorValue;
            ducuv.UserNaturalLightTextColor = UserNaturalLightTextColorValue;
            ducuv.UserNaturalMiddleBackgroundColor = UserNaturalMiddleBackgroundColorValue;
            ducuv.UserNaturalMiddleTextColor = UserNaturalMiddleTextColorValue;
            ducuv.UserNaturalDarkBackgroundColor = UserNaturalDarkBackgroundColorValue;
            ducuv.UserNaturalDarkTextColor = UserNaturalDarkTextColorValue;
            ducuv.UserInfoBackgroundColor = UserInfoBackgroundColorValue;
            ducuv.UserInfoFontColor = UserInfoFontColorValue;
            ducuv.UserShowUserAvatarInUserInfo = ShowUserAvatarInUserInfoValue;
            ducuv.UserShowUserOnlineInUserInfo = ShowUserOnlineInUserInfoValue;
            ducuv.UserShowUserEmailInUserInfo = ShowUserOnlineInUserInfoValue;
            ducuv.UserShowUserBirthdayInUserInfo = ShowUserBirthdayInUserInfoValue;
            ducuv.UserShowUserGenderInUserInfo = ShowUserGenderInUserInfoValue;
            ducuv.UserShowUserPhoneNumberInUserInfo = ShowUserPhoneNumberInUserInfoValue;
            ducuv.UserShowUserMobileNumberInUserInfo = ShowUserMobileNumberInUserInfoValue;
            ducuv.UserShowUserCountryInUserInfo = ShowUserCountryInUserInfoValue;
            ducuv.UserShowUserStateOrProvinceInUserInfo = ShowUserStateOrProvinceInUserInfoValue;
            ducuv.UserShowUserCityInUserInfo = ShowUserCityInUserInfoValue;
            ducuv.UserShowUserZipCodeInUserInfo = ShowUserZipCodeInUserInfoValue;
            ducuv.UserShowUserPostalCodeInUserInfo = ShowUserPostalCodeInUserInfoValue;
            ducuv.UserShowUserAddressInUserInfo = ShowUserAddressInUserInfoValue;
            ducuv.UserShowUserWebsiteInUserInfo = ShowUserWebsiteInUserInfoValue;
            ducuv.UserShowUserLastLoginInUserInfo = ShowUserLastLoginInUserInfoValue;

            ducuv.Start();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("change_user_view", ccoc.UserId);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "page/member/change_options/change_view/action/SuccessMessage.aspx?use_retrieved=true", true);
        }
    }
}