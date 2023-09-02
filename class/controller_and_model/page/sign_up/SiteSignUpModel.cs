using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteSignUpModel : CodeBehindModel
    {
        public string SignUpLanguage { get; set; }
        public string SignUpToSiteLanguage { get; set; }
        public string PasswordLanguage { get; set; }
        public string RepeatPasswordLanguage { get; set; }
        public string TermsOfServiceLanguage { get; set; }
        public string PrivacyPolicyLanguage { get; set; }
        public string UserAgreementLanguage { get; set; }
        public string AgreeLanguage { get; set; }

        public string UserNamePartValue { get; set; }
        public string UserSiteNamePartValue { get; set; }
        public string RealNamePartValue { get; set; }
        public string RealLastNamePartValue { get; set; }
        public string EmailPartValue { get; set; }
        public string PhoneNumberPartValue { get; set; }
        public string AddressPartValue { get; set; }
        public string PostalCodePartValue { get; set; }
        public string AboutPartValue { get; set; }
        public string BirthdayPartValue { get; set; }
        public string GenderPartValue { get; set; }
        public string WebsitePartValue { get; set; }
        public string PublicEmailPartValue { get; set; }
        public string CountryPartValue { get; set; }
        public string StateOrProvincePartValue { get; set; }
        public string CityPartValue { get; set; }
        public string MobileNumberPartValue { get; set; }
        public string ZipCodePartValue { get; set; }
        public string AvatarPathPartValue { get; set; }

        public string TermsOfServiceValue { get; set; }
        public string PrivacyPolicyValue { get; set; }
        public string UserAgreementValue { get; set; }

        public string CaptchaTextValue { get; set; }

        public string ReturnUrlValue { get; set; }

        public bool UseAvatarPathValue { get; set; } = false;
        public IFormFile AvatarPathUploadValue { get; set; }
        public string AvatarPathTextValue { get; set; }

        public string BirthdayYearOptionListValue { get; set; }
        public string BirthdayMountOptionListValue { get; set; }
        public string BirthdayDayOptionListValue { get; set; }
        public string BirthdayYearOptionListSelectedValue { get; set; }
        public string BirthdayMountOptionListSelectedValue { get; set; }
        public string BirthdayDayOptionListSelectedValue { get; set; }

        public string BirthdayYearAttribute { get; set; }
        public string BirthdayMountAttribute { get; set; }
        public string BirthdayDayAttribute { get; set; }

        public string BirthdayYearCssClass { get; set; }
        public string BirthdayMountCssClass { get; set; }
        public string BirthdayDayCssClass { get; set; }

        public bool GenderMaleValue { get; set; } = false;
        public bool GenderFemaleValue { get; set; } = false;
        public bool GenderUnknownValue { get; set; } = false;

        public string PasswordValue { get; set; } = "";
        public string RepeatPasswordValue { get; set; } = "";
        public string AboutValue { get; set; } = "";
        public string AddressValue { get; set; } = "";
        public string CityValue { get; set; } = "";
        public string CountryValue { get; set; } = "";
        public string EmailValue { get; set; } = "";
        public string RepeatEmailValue { get; set; } = "";
        public string MobileNumberValue { get; set; } = "";
        public string PhoneNumberValue { get; set; } = "";
        public string PostalCodeValue { get; set; } = "";
        public string PublicEmailValue { get; set; } = "";
        public string RealNameValue { get; set; } = "";
        public string RealLastNameValue { get; set; } = "";
        public string StateOrProvinceValue { get; set; } = "";
        public string UserNameValue { get; set; } = "";
        public string UserSiteNameValue { get; set; } = "";
        public string WebsiteValue { get; set; } = "";
        public string ZipCodeValue { get; set; } = "";

        public string PasswordCssClass { get; set; }
        public string RepeatPasswordCssClass { get; set; }
        public string AboutCssClass { get; set; }
        public string AddressCssClass { get; set; }
        public string CityCssClass { get; set; }
        public string CountryCssClass { get; set; }
        public string EmailCssClass { get; set; }
        public string RepeatEmailCssClass { get; set; }
        public string MobileNumberCssClass { get; set; }
        public string PhoneNumberCssClass { get; set; }
        public string PostalCodeCssClass { get; set; }
        public string PublicEmailCssClass { get; set; }
        public string RealNameCssClass { get; set; }
        public string RealLastNameCssClass { get; set; }
        public string StateOrProvinceCssClass { get; set; }
        public string UserNameCssClass { get; set; }
        public string UserSiteNameCssClass { get; set; }
        public string WebsiteCssClass { get; set; }
        public string ZipCodeCssClass { get; set; }

        public string PasswordAttribute { get; set; }
        public string RepeatPasswordAttribute { get; set; }
        public string AboutAttribute { get; set; }
        public string AddressAttribute { get; set; }
        public string CityAttribute { get; set; }
        public string CountryAttribute { get; set; }
        public string EmailAttribute { get; set; }
        public string RepeatEmailAttribute { get; set; }
        public string MobileNumberAttribute { get; set; }
        public string PhoneNumberAttribute { get; set; }
        public string PostalCodeAttribute { get; set; }
        public string PublicEmailAttribute { get; set; }
        public string RealNameAttribute { get; set; }
        public string RealLastNameAttribute { get; set; }
        public string StateOrProvinceAttribute { get; set; }
        public string UserNameAttribute { get; set; }
        public string UserSiteNameAttribute { get; set; }
        public string WebsiteAttribute { get; set; }
        public string ZipCodeAttribute { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(HttpContext context)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
            SignUpLanguage = aol.GetAddOnsLanguage("sign_up");
            SignUpToSiteLanguage = aol.GetAddOnsLanguage("sign_up_to_site");
            TermsOfServiceLanguage = aol.GetAddOnsLanguage("terms_of_service");
            PrivacyPolicyLanguage = aol.GetAddOnsLanguage("privacy_policy");
            UserAgreementLanguage = aol.GetAddOnsLanguage("user_agreement");
            PasswordLanguage = aol.GetAddOnsLanguage("password");
            RepeatPasswordLanguage = aol.GetAddOnsLanguage("repeat_password");
            AgreeLanguage = aol.GetAddOnsLanguage("agree");


            // Set User Agreement
            SiteTermsOfServiceModel stosm = new SiteTermsOfServiceModel();
            stosm.SetValue();
            TermsOfServiceValue = stosm.ContentValue;

            SitePrivacyPolicyModel sppm = new SitePrivacyPolicyModel();
            sppm.SetValue();
            PrivacyPolicyValue = sppm.ContentValue;

            SiteUserAgreementModel suam = new SiteUserAgreementModel();
            suam.SetValue();
            UserAgreementValue = suam.ContentValue;


            // Set Option Value
            XmlDocument ContactOptionDocument = new XmlDocument();
            ContactOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/sign_up_option/option/sign_up_option.xml"));

            XmlNode node = ContactOptionDocument.SelectSingleNode("sign_up_option_root");

            if (node["user_name"].Attributes["active"].Value == "true")
                UserNamePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpUserName.aspx?user_name_value=" + UserNameValue + "&user_name_css_class=" + UserNameCssClass);

            if (node["user_site_name"].Attributes["active"].Value == "true")
                UserSiteNamePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpUserSiteName.aspx?user_site_name_value=" + UserSiteNameValue + "&user_site_name_css_class=" + UserSiteNameCssClass);

            if (node["about"].Attributes["active"].Value == "true")
                AboutPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpAbout.aspx?about_value=" + AboutValue + "&about_css_class=" + AboutCssClass);

            if (node["address"].Attributes["active"].Value == "true")
                AddressPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpAddress.aspx?address_value=" + AddressValue + "&address_css_class=" + AddressCssClass);

            if (node["avatar"].Attributes["active"].Value == "true")
                AvatarPathPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpAvatarPath.aspx?avatar_path_text_value=" + AvatarPathTextValue);

            if (node["birthday"].Attributes["active"].Value == "true")
                BirthdayPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpBirthday.aspx?birthday_year_value=" + BirthdayYearOptionListSelectedValue + "&birthday_mount_value=" + BirthdayMountOptionListSelectedValue + "&birthday_day_value=" + BirthdayDayOptionListSelectedValue + "&birthday_year_css_class=" + BirthdayYearCssClass + "&birthday_mount_css_class=" + BirthdayMountCssClass + "&birthday_day_css_class=" + BirthdayDayCssClass);

            if (node["email"].Attributes["active"].Value == "true")
                EmailPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpEmail.aspx?email_value=" + EmailValue + "&email_css_class=" + EmailCssClass + "&repeat_email_value=" + RepeatEmailValue + "&repeat_email_css_class=" + RepeatEmailCssClass);

            if (node["gender"].Attributes["active"].Value == "true")
                GenderPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpGender.aspx?gender_checked=" + ((GenderFemaleValue)? "female" : (GenderMaleValue)? "male" : "unknown"));

            if (node["phone_number"].Attributes["active"].Value == "true")
                PhoneNumberPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpPhoneNumber.aspx?phone_number_value=" + PhoneNumberValue + "&phone_number_css_class=" + PhoneNumberCssClass);

            if (node["mobile_number"].Attributes["active"].Value == "true")
                MobileNumberPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpMobileNumber.aspx?mobile_number_value=" + MobileNumberValue + "&mobile_number_css_class=" + MobileNumberCssClass);

            if (node["postal_code"].Attributes["active"].Value == "true")
                PostalCodePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpPostalCode.aspx?postal_code_value=" + PostalCodeValue + "&postal_code_css_class=" + PostalCodeCssClass);

            if (node["real_name"].Attributes["active"].Value == "true")
                RealNamePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpRealName.aspx?real_name_value=" + RealNameValue + "&real_name_css_class=" + RealNameCssClass);

            if (node["real_last_name"].Attributes["active"].Value == "true")
                RealLastNamePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpRealLastName.aspx?real_last_name_value=" + RealLastNameValue + "&real_last_name_css_class=" + RealLastNameCssClass);

            if (node["website"].Attributes["active"].Value == "true")
                WebsitePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpWebsite.aspx?website_value=" + WebsiteValue + "&website_css_class=" + WebsiteCssClass);

            if (node["public_email"].Attributes["active"].Value == "true")
                PublicEmailPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpPublicEmail.aspx?public_email_value=" + PublicEmailValue + "&public_email_css_class=" + PublicEmailCssClass);

            if (node["country"].Attributes["active"].Value == "true")
                CountryPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpCountry.aspx?country_value=" + CountryValue + "&country_css_class=" + CountryCssClass);

            if (node["state_or_province"].Attributes["active"].Value == "true")
                StateOrProvincePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpStateOrProvince.aspx?state_or_province_value=" + StateOrProvinceValue + "&state_or_province_css_class=" + StateOrProvinceCssClass);

            if (node["city"].Attributes["active"].Value == "true")
                CityPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpCity.aspx?city_value=" + CityValue + "&city_css_class=" + CityCssClass);

            if (node["zip_code"].Attributes["active"].Value == "true")
                ZipCodePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/sign_up/part/SiteSignUpZipCode.aspx?zip_code_value=" + ZipCodeValue + "&zip_code_css_class=" + ZipCodeCssClass);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_Password", "");
            InputRequest.Add("txt_RepeatPassword", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            PasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_Password");
            RepeatPasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_RepeatPassword");

            PasswordCssClass = PasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_Password"));
            RepeatPasswordCssClass = RepeatPasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RepeatPassword"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/sign_up/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SignUp()
        {
            string AvatarFilePhysicalName = "";
            string AvatarExtension = "";
            string DirectoryName = "avatar";

            // If Use Avatar Path
            if (UseAvatarPathValue)
            {
                if (string.IsNullOrEmpty(AvatarPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_avatar_path_field_because_this_is_necessary", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                AvatarFilePhysicalName = Path.GetFileName(AvatarPathTextValue);

                AvatarExtension = Path.GetExtension(AvatarFilePhysicalName);

                if (!FileAndDirectory.IsImageExtension(AvatarExtension))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/"), "problem");

                    return;
                }

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AvatarFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(AvatarPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AvatarFilePhysicalName));
            }
            else
            {
                if (AvatarPathUploadValue.HtmlInputHasFile())
                {
                    AvatarFilePhysicalName = AvatarPathUploadValue.FileName;

                    AvatarExtension = Path.GetExtension(AvatarFilePhysicalName);

                    if (!FileAndDirectory.IsImageExtension(AvatarExtension))
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/"), "problem");

                        return;
                    }

                    DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(AvatarFilePhysicalName));

                    Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                    AvatarPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AvatarFilePhysicalName));
                }
            }

            if (UseAvatarPathValue || AvatarPathUploadValue.HtmlInputHasFile())
            {
                // Check User Avatar File Size
                double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AvatarFilePhysicalName)).Length;
                string MaxOfAvatarSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_user_avatar").Attributes["value"].Value;

                if (FileSize > int.Parse(MaxOfAvatarSizeUpload))
                {
                    // Delete Physical File
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfAvatarSizeUpload).ToBitSizeTuning()), "problem");

                    return;
                }
            }


            string TmpUserBirthday = "2000/01/01";

            if (BirthdayYearOptionListSelectedValue != "0000" && BirthdayMountOptionListSelectedValue != "00" && BirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = BirthdayYearOptionListSelectedValue + "/" + BirthdayMountOptionListSelectedValue + "/" + BirthdayDayOptionListSelectedValue;

            // Add Data To Database
            DataUse.User duu = new DataUse.User();
            duu.UserName = StringClass.RemoveHtmlTags(UserNameValue);

            DataUse.Group dug = new DataUse.Group();
            duu.GroupId = dug.GetGroupIdByGroupName(ElanatConfig.GetNode("security/default_group").Attributes["value"].Value);

            duu.UserSiteName = StringClass.RemoveHtmlTags(UserSiteNameValue);
            duu.UserRealName = StringClass.RemoveHtmlTags(RealNameValue);
            duu.UserRealLastName = StringClass.RemoveHtmlTags(RealLastNameValue);

            Security sc = new Security();
            duu.UserPassword = sc.GetHash(PasswordValue);

            duu.UserDateCreate = DateAndTime.GetDate("yyyy/MM/dd");
            duu.UserActive = (ElanatConfig.GetNode("security/registered_user_after_accept_active_email").Attributes["active"].Value == "true") ? "0" : "1";
            duu.UserEmail = string.IsNullOrEmpty(EmailValue) ? "" : StringClass.RemoveHtmlTags(EmailValue.ToLower());
            duu.UserPhoneNumber = StringClass.RemoveHtmlTags(PhoneNumberValue);
            duu.UserAddress = StringClass.RemoveIllegalCharacters(AddressValue);
            duu.UserPostalCode = StringClass.RemoveHtmlTags(PostalCodeValue);
            duu.UserAbout = StringClass.RemoveIllegalCharacters(AboutValue);
            duu.UserBirthday = TmpUserBirthday;
            duu.UserGender = (GenderUnknownValue) ? "" : GenderMaleValue.BooleanToZeroOne();
            duu.UserPublicEmail = string.IsNullOrEmpty(PublicEmailValue) ? "" : StringClass.RemoveHtmlTags(PublicEmailValue.ToLower());
            duu.UserMobileNumber = StringClass.RemoveHtmlTags(MobileNumberValue);
            duu.UserZipCode = StringClass.RemoveHtmlTags(ZipCodeValue);
            duu.UserEmailIsConfirm = (ElanatConfig.GetNode("security/registered_user_after_accept_active_email").Attributes["active"].Value == "true") ? "0" : "1";
            duu.UserCountry = StringClass.RemoveHtmlTags(CountryValue);
            duu.UserStateOrProvince = StringClass.RemoveHtmlTags(StateOrProvinceValue);
            duu.UserCity = StringClass.RemoveHtmlTags(CityValue);
            duu.UserWebsite = StringClass.RemoveHtmlTags(WebsiteValue);

            // Add User
            duu.Add();


            // Create User Data
            FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/user_data/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/user_data/user_" + duu.UserId + "/"), true);


            if (UseAvatarPathValue || AvatarPathUploadValue.HtmlInputHasFile())
            {
                // Convert Image To Png Format
                FileAndDirectory fad = new FileAndDirectory();
                fad.ConvertImageToPngFormat(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AvatarFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AvatarFilePhysicalName + ".tmp"));

                File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + AvatarFilePhysicalName + ".tmp"), StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/user_avatar/" + duu.UserId + ".png"));

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);
            }
            else
                File.Copy(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/user_avatar/default.png"), StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/user_avatar/" + duu.UserId + ".png"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("sign_up", duu.UserId);
        }

        public void SignUpInactiveErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("sign_up_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/"), "problem");
        }

        public void EmailEqualityErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_accept_user_agreement_before_sign_up", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/"), "problem");
        }

        public void AgreeNotAcceptErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("email_and_repeat_email_must_be_alike", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/"), "problem");
        }

        public void PasswordEqualityErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("password_and_repeat_password_must_be_alike", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/"), "problem");
        }

        public void CaptchaIncorrectErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("the_captcha_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/"), "problem");
        }

        public void SuccessView()
        {
            if (!string.IsNullOrEmpty(ReturnUrlValue))
                ReturnUrlValue = "&el_return_url=" + ReturnUrlValue;

            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "page/sign_up/action/SuccessMessage.aspx?use_retrieved=true" + ReturnUrlValue, true);
        }
    }
}