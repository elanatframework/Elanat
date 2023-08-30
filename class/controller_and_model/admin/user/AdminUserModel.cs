using CodeBehind;

namespace Elanat
{
    public partial class AdminUserModel : CodeBehindModel
    {
        public string AddUserLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string UserLanguage { get; set; }
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
        public string RefreshLanguage { get; set; }

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

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/user/");
            AddUserLanguage = aol.GetAddOnsLanguage("add_user");
            AddLanguage = aol.GetAddOnsLanguage("add");
            UserLanguage = aol.GetAddOnsLanguage("user");
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
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


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


            GenderUnknownValue = true;


            // Set User Page List
            ActionGetUserListModel lm = new ActionGetUserListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
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
            InputRequest.Add("ddlst_UserGroup", UserGroupOptionListValue);
            InputRequest.Add("ddlst_UserBirthdayYear", UserBirthdayYearOptionListValue);
            InputRequest.Add("ddlst_UserBirthdayMount", UserBirthdayMountOptionListValue);
            InputRequest.Add("ddlst_UserBirthdayDay", UserBirthdayDayOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/user/");

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
            UserGroupCssClass = UserGroupCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserGroup"));
            UserBirthdayYearCssClass = UserBirthdayYearCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserBirthdayYear"));
            UserBirthdayMountCssClass = UserBirthdayMountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserBirthdayMount"));
            UserBirthdayDayCssClass = UserBirthdayDayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_UserBirthdayDay"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/user/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void AddUser()
        {
            // Add Data To Database
            DataUse.User duu = new DataUse.User();


            string TmpUserBirthday = "2000/01/01";

            if (UserBirthdayYearOptionListSelectedValue != "0000" && UserBirthdayMountOptionListSelectedValue != "00" && UserBirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = UserBirthdayYearOptionListSelectedValue + "/" + UserBirthdayMountOptionListSelectedValue + "/" + UserBirthdayDayOptionListSelectedValue;


            duu.UserName = UserNameValue;
            duu.GroupId = UserGroupOptionListSelectedValue;
            duu.UserSiteName = UserSiteNameValue;
            duu.UserRealName = UserRealNameValue;
            duu.UserRealLastName = UserRealLastNameValue;
            Security sc = new Security();
            duu.UserPassword = sc.GetHash(UserPasswordValue);
            duu.UserDateCreate = DateAndTime.GetDate("yyyy/MM/dd");
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

            // Add User
            duu.AddWithFillReturnDr();


            // Create User Data
            FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/user_data/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/user_data/user_" + duu.UserId + "/"), true);

            File.Copy(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/user_avatar/default.png"), StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/user_avatar/" + duu.UserId + ".png"));


            try { duu.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_user", duu.UserId);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("user_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/user/"), "success", false, StaticObject.AdminPath + "/user/action/UserNewRow.aspx?user_id=" + duu.UserId, "div_TableBox");
        }

        public void EmailEqualityErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("email_and_repeat_email_must_be_alike", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/user/"), "problem");
        }

        public void PasswordEqualityErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("password_and_repeat_password_must_be_alike", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/user/"), "problem");
        }
    }
}