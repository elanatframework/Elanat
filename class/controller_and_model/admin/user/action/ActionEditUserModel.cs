using CodeBehind;

namespace Elanat
{
    public partial class ActionEditUserModel : CodeBehindModel
    {
        public string SaveUserLanguage { get; set; }
        public string EditUserLanguage { get; set; }
        public string UserNameLanguage { get; set; }
        public string UserRealNameLanguage { get; set; }
        public string UserRealLastNameLanguage { get; set; }
        public string UserSiteNameLanguage { get; set; }
        public string UserEmailLanguage { get; set; }
        public string RepeatEmailLanguage { get; set; }
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
        public string UserPasswordLanguage { get; set; }
        public string RepeatPasswordLanguage { get; set; }
        public string UserGroupLanguage { get; set; }
        public string GenderFemaleLanguage { get; set; }
        public string GenderMaleLanguage { get; set; }
        public string GenderUnknownLanguage { get; set; }
        public string UserActiveLanguage { get; set; }
        public string UserEmailIsConfirmLanguage { get; set; }
        public string UserDateCreateLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string UserIdValue { get; set; }

        public bool UserActiveValue { get; set; } = false;
        public bool UserEmailIsConfirmValue { get; set; } = false;

        public string UserGroupOptionListValue { get; set; }
        public string UserGroupOptionListSelectedValue { get; set; }
        public string UserBirthdayYearOptionListValue { get; set; }
        public string UserBirthdayMountOptionListValue { get; set; }
        public string UserBirthdayDayOptionListValue { get; set; }
        public string UserBirthdayYearOptionListSelectedValue { get; set; }
        public string UserBirthdayMountOptionListSelectedValue { get; set; }
        public string UserBirthdayDayOptionListSelectedValue { get; set; }

        public bool GenderMaleValue { get; set; } = false;
        public bool GenderFemaleValue { get; set; } = false;
        public bool GenderUnknownValue { get; set; } = false;

        public string UserOtherInfoValue { get; set; } = "";
        public string RepeatEmailValue { get; set; } = "";
        public string UserPasswordValue { get; set; } = "";
        public string RepeatPasswordValue { get; set; } = "";
        public string UserSiteNameValue { get; set; } = "";
        public string UserAboutValue { get; set; } = "";
        public string UserAddressValue { get; set; } = "";
        public string UserCityValue { get; set; } = "";
        public string UserCountryValue { get; set; } = "";
        public string UserEmailValue { get; set; } = "";
        public string UserMobileNumberValue { get; set; } = "";
        public string UserPhoneNumberValue { get; set; } = "";
        public string UserPostalCodeValue { get; set; } = "";
        public string UserPublicEmailValue { get; set; } = "";
        public string UserNameValue { get; set; } = "";
        public string UserRealNameValue { get; set; } = "";
        public string UserRealLastNameValue { get; set; } = "";
        public string UserStateOrProvinceValue { get; set; } = "";
        public string UserWebsiteValue { get; set; } = "";
        public string UserZipCodeValue { get; set; } = "";
        public string UserDateCreateValue { get; set; } = "";

        public string UserOtherInfoCssClass { get; set; }
        public string RepeatEmailCssClass { get; set; }
        public string UserPasswordCssClass { get; set; }
        public string RepeatPasswordCssClass { get; set; }
        public string UserSiteNameCssClass { get; set; }
        public string UserAboutCssClass { get; set; }
        public string UserAddressCssClass { get; set; }
        public string UserCityCssClass { get; set; }
        public string UserCountryCssClass { get; set; }
        public string UserEmailCssClass { get; set; }
        public string UserMobileNumberCssClass { get; set; }
        public string UserPhoneNumberCssClass { get; set; }
        public string UserPostalCodeCssClass { get; set; }
        public string UserPublicEmailCssClass { get; set; }
        public string UserNameCssClass { get; set; }
        public string UserRealNameCssClass { get; set; }
        public string UserRealLastNameCssClass { get; set; }
        public string UserStateOrProvinceCssClass { get; set; }
        public string UserWebsiteCssClass { get; set; }
        public string UserZipCodeCssClass { get; set; }
        public string UserGroupCssClass { get; set; }
        public string UserBirthdayYearCssClass { get; set; }
        public string UserBirthdayMountCssClass { get; set; }
        public string UserBirthdayDayCssClass { get; set; }
        public string UserDateCreateCssClass { get; set; }

        public string UserOtherInfoAttribute { get; set; }
        public string RepeatEmailAttribute { get; set; }
        public string UserPasswordAttribute { get; set; }
        public string RepeatPasswordAttribute { get; set; }
        public string UserSiteNameAttribute { get; set; }
        public string UserAboutAttribute { get; set; }
        public string UserAddressAttribute { get; set; }
        public string UserCityAttribute { get; set; }
        public string UserCountryAttribute { get; set; }
        public string UserEmailAttribute { get; set; }
        public string UserMobileNumberAttribute { get; set; }
        public string UserPhoneNumberAttribute { get; set; }
        public string UserPostalCodeAttribute { get; set; }
        public string UserPublicEmailAttribute { get; set; }
        public string UserNameAttribute { get; set; }
        public string UserRealNameAttribute { get; set; }
        public string UserRealLastNameAttribute { get; set; }
        public string UserStateOrProvinceAttribute { get; set; }
        public string UserWebsiteAttribute { get; set; }
        public string UserZipCodeAttribute { get; set; }
        public string UserGroupAttribute { get; set; }
        public string UserBirthdayYearAttribute { get; set; }
        public string UserBirthdayMountAttribute { get; set; }
        public string UserBirthdayDayAttribute { get; set; }
        public string UserDateCreateAttribute { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/user/");
            SaveUserLanguage = aol.GetAddOnsLanguage("save_user");
            EditUserLanguage = aol.GetAddOnsLanguage("edit_user");
            UserNameLanguage = aol.GetAddOnsLanguage("user_name");
            UserRealNameLanguage = aol.GetAddOnsLanguage("user_real_name");
            UserRealLastNameLanguage = aol.GetAddOnsLanguage("user_real_last_name");
            UserSiteNameLanguage = aol.GetAddOnsLanguage("user_site_name");
            UserEmailLanguage = aol.GetAddOnsLanguage("user_email");
            RepeatEmailLanguage = aol.GetAddOnsLanguage("repeat_email");
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
            UserPasswordLanguage = aol.GetAddOnsLanguage("user_password");
            RepeatPasswordLanguage = aol.GetAddOnsLanguage("repeat_password");
            UserGroupLanguage = aol.GetAddOnsLanguage("user_group");
            GenderFemaleLanguage = aol.GetAddOnsLanguage("female");
            GenderMaleLanguage = aol.GetAddOnsLanguage("male");
            GenderUnknownLanguage = aol.GetAddOnsLanguage("unknown");
            UserActiveLanguage = aol.GetAddOnsLanguage("user_active");
            UserEmailIsConfirmLanguage = aol.GetAddOnsLanguage("user_email_is_confirm");
            UserDateCreateLanguage = aol.GetAddOnsLanguage("user_date_create");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.User duu = new DataUse.User();
                duu.FillCurrentUser(UserIdValue);

                UserNameValue = duu.UserName;
                UserGroupOptionListSelectedValue = duu.GroupId;
                UserSiteNameValue = duu.UserSiteName;
                UserRealNameValue = duu.UserRealName;
                UserRealLastNameValue = duu.UserRealLastName;
                UserPasswordValue = "";
                RepeatPasswordValue = "";
                UserDateCreateValue = duu.UserDateCreate;
                UserActiveValue = duu.UserActive.ZeroOneToBoolean();
                UserEmailValue = duu.UserEmail;
                RepeatEmailValue = duu.UserEmail;
                UserPhoneNumberValue = duu.UserPhoneNumber;
                UserAddressValue = duu.UserAddress;
                UserPostalCodeValue = duu.UserPostalCode;
                UserAboutValue = duu.UserAbout;
                UserBirthdayYearOptionListSelectedValue = duu.UserBirthday.Substring(0, 4);
                UserBirthdayMountOptionListSelectedValue = duu.UserBirthday.Substring(5, 2);
                UserBirthdayDayOptionListSelectedValue = duu.UserBirthday.Substring(8, 2);
                if (string.IsNullOrEmpty(duu.UserGender))
                    GenderUnknownValue = true;
                else
                    if (duu.UserGender.TrueFalseToBoolean())
                    GenderMaleValue = true;
                else
                    GenderFemaleValue = true;
                UserPublicEmailValue = duu.UserPublicEmail;
                UserMobileNumberValue = duu.UserMobileNumber;
                UserZipCodeValue = duu.UserZipCode;
                UserEmailIsConfirmValue = duu.UserEmailIsConfirm.ZeroOneToBoolean();
                UserOtherInfoValue = duu.UserOtherInfo;
                UserCountryValue = duu.UserCountry;
                UserStateOrProvinceValue = duu.UserStateOrProvince;
                UserCityValue = duu.UserCity;
                UserWebsiteValue = duu.UserWebsite;
            }

            // Set User Group Item Without Guest Group
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserGroupListItemWithoutGuestGroup(StaticObject.GetCurrentAdminGlobalLanguage());
            UserGroupOptionListValue += lcu.UserGroupListItemWithoutGuestGroup.HtmlInputToOptionTag(UserGroupOptionListSelectedValue);

            // Set Birthday Item
            ListClass.DateAndTime lcdat = new ListClass.DateAndTime();
            lcdat.FillBirthdayListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            UserBirthdayDayOptionListValue += UserBirthdayDayOptionListValue.HtmlInputAddOptionTag("", "00");
            UserBirthdayDayOptionListValue += lcdat.BirthdayDayListItem.HtmlInputToOptionTag(UserBirthdayDayOptionListSelectedValue);
            UserBirthdayMountOptionListValue += UserBirthdayMountOptionListValue.HtmlInputAddOptionTag("", "00");
            UserBirthdayMountOptionListValue += lcdat.BirthdayMountListItem.HtmlInputToOptionTag(UserBirthdayMountOptionListSelectedValue);
            UserBirthdayYearOptionListValue += UserBirthdayYearOptionListValue.HtmlInputAddOptionTag("", "0000");
            UserBirthdayYearOptionListValue += lcdat.BirthdayYearListItem.HtmlInputToOptionTag(UserBirthdayYearOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_UserOtherInfo", "");
            InputRequest.Add("txt_RepeatEmail", "");
            InputRequest.Add("txt_UserPassword", "");
            InputRequest.Add("txt_RepeatPassword", "");
            InputRequest.Add("txt_UserSiteName", "");
            InputRequest.Add("txt_UserAbout", "");
            InputRequest.Add("txt_UserAddress", "");
            InputRequest.Add("txt_UserCity", "");
            InputRequest.Add("txt_UserCountry", "");
            InputRequest.Add("txt_UserEmail", "");
            InputRequest.Add("txt_UserPhoneNumber", "");
            InputRequest.Add("txt_UserPostalCode", "");
            InputRequest.Add("txt_UserPublicEmail", "");
            InputRequest.Add("txt_UserName", "");
            InputRequest.Add("txt_UserRealName", "");
            InputRequest.Add("txt_UserRealLastName", "");
            InputRequest.Add("txt_UserStateOrProvince", "");
            InputRequest.Add("txt_UserWebsite", "");
            InputRequest.Add("txt_UserZipCode", "");
            InputRequest.Add("txt_UserDateCreate", "");
            InputRequest.Add("ddlst_UserGroup", UserGroupOptionListValue);
            InputRequest.Add("ddlst_UserBirthdayYear", UserBirthdayYearOptionListValue);
            InputRequest.Add("ddlst_UserBirthdayMount", UserBirthdayMountOptionListValue);
            InputRequest.Add("ddlst_UserBirthdayDay", UserBirthdayDayOptionListValue);
            InputRequest.Add("hdn_UserId", UserIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/user/", "edit");

            UserOtherInfoAttribute += vc.ImportantInputAttribute.GetValue("txt_UserOtherInfo");
            RepeatEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_RepeatEmail");
            UserPasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_UserPassword");
            RepeatPasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_RepeatPassword");
            UserSiteNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserSiteName");
            UserAboutAttribute += vc.ImportantInputAttribute.GetValue("txt_UserAbout");
            UserAddressAttribute += vc.ImportantInputAttribute.GetValue("txt_UserAddress");
            UserCityAttribute += vc.ImportantInputAttribute.GetValue("txt_UserCity");
            UserCountryAttribute += vc.ImportantInputAttribute.GetValue("txt_UserCountry");
            UserEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_UserEmail");
            UserPhoneNumberAttribute += vc.ImportantInputAttribute.GetValue("txt_UserPhoneNumber");
            UserPostalCodeAttribute += vc.ImportantInputAttribute.GetValue("txt_UserPostalCode");
            UserPublicEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_UserPublicEmail");
            UserNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserName");
            UserRealNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserRealName");
            UserRealLastNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserRealLastName");
            UserStateOrProvinceAttribute += vc.ImportantInputAttribute.GetValue("txt_UserStateOrProvince");
            UserWebsiteAttribute += vc.ImportantInputAttribute.GetValue("txt_UserWebsite");
            UserZipCodeAttribute += vc.ImportantInputAttribute.GetValue("txt_UserZipCode");
            UserDateCreateAttribute += vc.ImportantInputAttribute.GetValue("txt_UserDateCreate");
            UserGroupAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserGroup");
            UserBirthdayYearAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserBirthdayYear");
            UserBirthdayMountAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserBirthdayMount");
            UserBirthdayDayAttribute += vc.ImportantInputAttribute.GetValue("ddlst_UserBirthdayDay");

            UserOtherInfoCssClass = UserOtherInfoCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserOtherInfo"));
            RepeatEmailCssClass = RepeatEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RepeatEmail"));
            UserPasswordCssClass = UserPasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserPassword"));
            RepeatPasswordCssClass = RepeatPasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RepeatPassword"));
            UserSiteNameCssClass = UserSiteNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserSiteName"));
            UserAboutCssClass = UserAboutCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserAbout"));
            UserAddressCssClass = UserAddressCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserAddress"));
            UserCityCssClass = UserCityCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserCity"));
            UserCountryCssClass = UserCountryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserCountry"));
            UserEmailCssClass = UserEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserEmail"));
            UserPhoneNumberCssClass = UserPhoneNumberCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserPhoneNumber"));
            UserPostalCodeCssClass = UserPostalCodeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserPostalCode"));
            UserPublicEmailCssClass = UserPublicEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserPublicEmail"));
            UserNameCssClass = UserNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserName"));
            UserRealNameCssClass = UserRealNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserRealName"));
            UserRealLastNameCssClass = UserRealLastNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserRealLastName"));
            UserStateOrProvinceCssClass = UserStateOrProvinceCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserStateOrProvince"));
            UserWebsiteCssClass = UserWebsiteCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserWebsite"));
            UserZipCodeCssClass = UserZipCodeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserZipCode"));
            UserDateCreateCssClass = UserDateCreateCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserDateCreate"));
            UserGroupCssClass = UserGroupCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserGroup"));
            UserBirthdayYearCssClass = UserBirthdayYearCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserBirthdayYear"));
            UserBirthdayMountCssClass = UserBirthdayMountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserBirthdayMount"));
            UserBirthdayDayCssClass = UserBirthdayDayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserBirthdayDay"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit", StaticObject.AdminPath + "/user/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveUser()
        {
            DataUse.User duu = new DataUse.User();


            string TmpUserBirthday = "2000/01/01";

            if (UserBirthdayYearOptionListSelectedValue != "0000" && UserBirthdayMountOptionListSelectedValue != "00" && UserBirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = UserBirthdayYearOptionListSelectedValue + "/" + UserBirthdayMountOptionListSelectedValue + "/" + UserBirthdayDayOptionListSelectedValue;


            // Change Database Data
            duu.UserId = UserIdValue;
            duu.UserName = UserNameValue;
            duu.GroupId = UserGroupOptionListSelectedValue;
            duu.UserSiteName = UserSiteNameValue;
            duu.UserRealName = UserRealNameValue;
            duu.UserRealLastName = UserRealLastNameValue;
            Security sc = new Security();
            duu.UserPassword = (string.IsNullOrEmpty(UserPasswordValue)) ? "" : sc.GetHash(UserPasswordValue);
            duu.UserDateCreate = UserDateCreateValue;
            duu.UserActive = UserActiveValue.BooleanToZeroOne();
            duu.UserEmail = UserEmailValue.ToLower();
            duu.UserPhoneNumber = UserPhoneNumberValue;
            duu.UserAddress = UserAddressValue;
            duu.UserPostalCode = UserPostalCodeValue;
            duu.UserAbout = UserAboutValue;
            duu.UserBirthday = TmpUserBirthday;
            duu.UserGender = (GenderUnknownValue) ? "" : GenderMaleValue.BooleanToZeroOne();
            duu.UserPublicEmail = UserPublicEmailValue.ToLower();
            duu.UserMobileNumber = UserMobileNumberValue;
            duu.UserZipCode = UserZipCodeValue;
            duu.UserEmailIsConfirm = UserEmailIsConfirmValue.BooleanToZeroOne();
            duu.UserOtherInfo = UserOtherInfoValue;
            duu.UserCountry = UserCountryValue;
            duu.UserStateOrProvince = UserStateOrProvinceValue;
            duu.UserCity = UserCityValue;
            duu.UserWebsite = UserWebsiteValue;

            // Edit User
            duu.Edit();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_user", duu.UserName);
        }

        public void EmailEqualityErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("email_and_repeat_email_must_be_alike", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/user/"), "problem");
        }

        public void PasswordEqualityErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("password_and_repeat_password_must_be_alike", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/user/"), "problem");
        }

        public void ExistValueToColumnUserSiteNameErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("user_site_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/user/")), "problem");
        }

        public void ExistValueToColumnUserNameErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("user_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/user/")), "problem");
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/user/action/SuccessMessage.aspx");
        }
    }
}