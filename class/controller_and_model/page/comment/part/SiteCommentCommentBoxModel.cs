using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteCommentCommentBoxModel : CodeBehindModel
    {
        public string SendCommentLanguage { get; set; }

        public string TitlePartValue { get; set; }
        public string TextPartValue { get; set; }
        public string RealNamePartValue { get; set; }
        public string RealLastNamePartValue { get; set; }
        public string EmailPartValue { get; set; }
        public string TypePartValue { get; set; }
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
        public string UploadPartValue { get; set; }

        public string CommentTypeValue { get; set; }

        public bool UseUploadPathValue { get; set; } = false;
        public IFormFile UploadPathUploadValue { get; set; }
        public string UploadPathTextValue { get; set; }

        public string TypeOptionListValue { get; set; }
        public string BirthdayYearOptionListValue { get; set; }
        public string BirthdayMountOptionListValue { get; set; }
        public string BirthdayDayOptionListValue { get; set; }
        public string TypeOptionListSelectedValue { get; set; } = "";
        public string BirthdayYearOptionListSelectedValue { get; set; }
        public string BirthdayMountOptionListSelectedValue { get; set; }
        public string BirthdayDayOptionListSelectedValue { get; set; }

        public string TypeAttribute { get; set; }
        public string BirthdayYearAttribute { get; set; }
        public string BirthdayMountAttribute { get; set; }
        public string BirthdayDayAttribute { get; set; }

        public string TypeCssClass { get; set; }
        public string BirthdayYearCssClass { get; set; }
        public string BirthdayMountCssClass { get; set; }
        public string BirthdayDayCssClass { get; set; }

        public bool GenderMaleValue { get; set; } = false;
        public bool GenderFemaleValue { get; set; } = false;
        public bool GenderUnknownValue { get; set; } = false;

        public string GenderMaleAttribute { get; set; }
        public string GenderFemaleAttribute { get; set; }
        public string GenderUnknownAttribute { get; set; }

        public string AboutValue { get; set; } = "";
        public string AddressValue { get; set; } = "";
        public string CityValue { get; set; } = "";
        public string CountryValue { get; set; } = "";
        public string EmailValue { get; set; } = "";
        public string MobileNumberValue { get; set; } = "";
        public string PhoneNumberValue { get; set; } = "";
        public string PostalCodeValue { get; set; } = "";
        public string PublicEmailValue { get; set; } = "";
        public string TitleValue { get; set; } = "";
        public string TextValue { get; set; } = "";
        public string RealNameValue { get; set; } = "";
        public string RealLastNameValue { get; set; } = "";
        public string StateOrProvinceValue { get; set; } = "";
        public string WebsiteValue { get; set; } = "";
        public string ZipCodeValue { get; set; } = "";

        public string AboutCssClass { get; set; }
        public string AddressCssClass { get; set; }
        public string CityCssClass { get; set; }
        public string CountryCssClass { get; set; }
        public string EmailCssClass { get; set; }
        public string MobileNumberCssClass { get; set; }
        public string PhoneNumberCssClass { get; set; }
        public string PostalCodeCssClass { get; set; }
        public string PublicEmailCssClass { get; set; }
        public string TitleCssClass { get; set; }
        public string TextCssClass { get; set; }
        public string RealNameCssClass { get; set; }
        public string RealLastNameCssClass { get; set; }
        public string StateOrProvinceCssClass { get; set; }
        public string WebsiteCssClass { get; set; }
        public string ZipCodeCssClass { get; set; }

        public string AboutAttribute { get; set; }
        public string AddressAttribute { get; set; }
        public string CityAttribute { get; set; }
        public string CountryAttribute { get; set; }
        public string EmailAttribute { get; set; }
        public string MobileNumberAttribute { get; set; }
        public string PhoneNumberAttribute { get; set; }
        public string PostalCodeAttribute { get; set; }
        public string PublicEmailAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public string TextAttribute { get; set; }
        public string RealNameAttribute { get; set; }
        public string RealLastNameAttribute { get; set; }
        public string StateOrProvinceAttribute { get; set; }
        public string WebsiteAttribute { get; set; }
        public string ZipCodeAttribute { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
            SendCommentLanguage = aol.GetAddOnsLanguage("send_comment");


            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Set User Value
            if (ccoc.RoleDominantType != "guest")
            {
                DataUse.User duu = new DataUse.User();
                duu.FillCurrentUser(ccoc.UserId);

                RealNameValue = duu.UserRealName;
                RealNameAttribute += "disabled ";

                AboutValue = duu.UserAbout;
                AboutAttribute += "disabled ";

                RealLastNameValue = duu.UserRealLastName;
                RealLastNameAttribute += "disabled ";

                AddressValue = duu.UserAddress;
                AddressAttribute += "disabled ";

                BirthdayYearOptionListSelectedValue = duu.UserBirthday.Substring(0, 4);
                BirthdayMountOptionListSelectedValue = duu.UserBirthday.Substring(5, 2);
                BirthdayDayOptionListSelectedValue = duu.UserBirthday.Substring(8, 2);
                BirthdayYearAttribute += "disabled ";
                BirthdayMountAttribute += "disabled ";
                BirthdayDayAttribute += "disabled ";

                CityValue = duu.UserCity;
                CityAttribute += "disabled ";

                CountryValue = duu.UserCountry;
                CountryAttribute += "disabled ";

                EmailValue = duu.UserEmail;
                EmailAttribute += "disabled ";

                if (string.IsNullOrEmpty(duu.UserGender))
                    GenderUnknownValue = true;
                else
                    if (duu.UserGender.TrueFalseToBoolean())
                    GenderMaleValue = true;
                else
                    GenderFemaleValue = true;

                GenderUnknownAttribute += "disabled ";
                GenderMaleAttribute += "disabled ";
                GenderFemaleAttribute += "disabled ";

                MobileNumberValue = duu.UserMobileNumber;
                MobileNumberAttribute += "disabled ";

                PhoneNumberValue = duu.UserPhoneNumber;
                PhoneNumberAttribute += "disabled ";

                PostalCodeValue = duu.UserPostalCode;
                PostalCodeAttribute += "disabled ";

                PublicEmailValue = duu.UserPublicEmail;
                PublicEmailAttribute += "disabled ";

                StateOrProvinceValue = duu.UserStateOrProvince;
                StateOrProvinceAttribute += "disabled ";

                WebsiteValue = duu.UserWebsite;
                WebsiteAttribute += "disabled ";

                ZipCodeValue = duu.UserZipCode;
                ZipCodeAttribute += "disabled ";
            }


            // Set Option Value
            XmlDocument CommentOptionDocument = new XmlDocument();
            CommentOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/comment_option/option/comment_option.xml"));

            XmlNode node = CommentOptionDocument.SelectSingleNode("comment_option_root");

            if (node["about"].Attributes["active"].Value == "true")
                AboutPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentAbout.aspx?about_value=" + AboutValue + "&about_css_class=" + AboutCssClass + "&about_attribute=" + AboutAttribute);

            if (node["address"].Attributes["active"].Value == "true")
                AddressPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentAddress.aspx?address_value=" + AddressValue + "&address_css_class=" + AddressCssClass + "&address_attribute=" + AddressAttribute);

            if (node["file"].Attributes["active"].Value == "true")
                UploadPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentUploadPath.aspx?upload_path_text_value=" + UploadPathTextValue);

            if (node["birthday"].Attributes["active"].Value == "true")
                BirthdayPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentBirthday.aspx?birthday_year_value=" + BirthdayYearOptionListSelectedValue + "&birthday_mount_value=" + BirthdayMountOptionListSelectedValue + "&birthday_day_value=" + BirthdayDayOptionListSelectedValue + "&birthday_year_css_class=" + BirthdayYearCssClass + "&birthday_mount_css_class=" + BirthdayMountCssClass + "&birthday_day_css_class=" + BirthdayDayCssClass + "&birthday_year_attribute=" + BirthdayYearAttribute + "&birthday_mount_attribute=" + BirthdayMountAttribute + "&birthday_day_attribute=" + BirthdayDayAttribute);

            if (node["email"].Attributes["active"].Value == "true")
                EmailPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentEmail.aspx?email_value=" + EmailValue + "&email_css_class=" + EmailCssClass + "&email_attribute=" + EmailAttribute);

            if (node["type"].Attributes["active"].Value == "true")
                TypePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentType.aspx?type_value=" + TypeOptionListSelectedValue + "&email_css_class=" + TypeCssClass + "&comment_type=" + CommentTypeValue);

            if (node["gender"].Attributes["active"].Value == "true")
                GenderPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentGender.aspx?gender_checked=" + ((GenderFemaleValue) ? "female" : (GenderMaleValue) ? "male" : "unknown") + "&gender_unknown_attribute=" + GenderUnknownAttribute + "&gender_male_attribute=" + GenderMaleAttribute + "&gender_female_attribute=" + GenderFemaleAttribute);

            if (node["phone_number"].Attributes["active"].Value == "true")
                PhoneNumberPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentPhoneNumber.aspx?phone_number_value=" + PhoneNumberValue + "&phone_number_css_class=" + PhoneNumberCssClass + "&phone_number_attribute=" + PhoneNumberAttribute);

            if (node["mobile_number"].Attributes["active"].Value == "true")
                MobileNumberPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentMobileNumber.aspx?mobile_number_value=" + MobileNumberValue + "&mobile_number_css_class=" + MobileNumberCssClass + "&mobile_number_attribute=" + MobileNumberAttribute);

            if (node["postal_code"].Attributes["active"].Value == "true")
                PostalCodePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentPostalCode.aspx?postal_code_value=" + PostalCodeValue + "&postal_code_css_class=" + PostalCodeCssClass + "&postal_code_attribute=" + PostalCodeAttribute);

            if (node["title"].Attributes["active"].Value == "true")
                TitlePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentTitle.aspx?title_value=" + TitleValue + "&title_css_class=" + TitleCssClass);

            if (node["text"].Attributes["active"].Value == "true")
                TextPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentText.aspx?text_value=" + TextValue + "&text_css_class=" + TextCssClass);

            if (node["name"].Attributes["active"].Value == "true")
                RealNamePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentRealName.aspx?real_name_value=" + RealNameValue + "&real_name_css_class=" + RealNameCssClass + "&real_name_attribute=" + RealNameAttribute);

            if (node["last_name"].Attributes["active"].Value == "true")
                RealLastNamePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentRealLastName.aspx?real_last_name_value=" + RealLastNameValue + "&real_last_name_css_class=" + RealLastNameCssClass + "&real_last_name_attribute=" + RealLastNameAttribute);

            if (node["website"].Attributes["active"].Value == "true")
                WebsitePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentWebsite.aspx?website_value=" + WebsiteValue + "&website_css_class=" + WebsiteCssClass + "&website_attribute=" + WebsiteAttribute);

            if (node["public_email"].Attributes["active"].Value == "true")
                PublicEmailPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentPublicEmail.aspx?public_email_value=" + PublicEmailValue + "&public_email_css_class=" + PublicEmailCssClass + "&public_email_attribute=" + PublicEmailAttribute);

            if (node["country"].Attributes["active"].Value == "true")
                CountryPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentCountry.aspx?country_value=" + CountryValue + "&country_css_class=" + CountryCssClass + "&country_attribute=" + CountryAttribute);

            if (node["state_or_province"].Attributes["active"].Value == "true")
                StateOrProvincePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentStateOrProvince.aspx?state_or_province_value=" + StateOrProvinceValue + "&state_or_province_css_class=" + StateOrProvinceCssClass + "&state_or_province_attribute=" + StateOrProvinceAttribute);

            if (node["city"].Attributes["active"].Value == "true")
                CityPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentCity.aspx?city_value=" + CityValue + "&city_css_class=" + CityCssClass + "&city_attribute=" + CityAttribute);

            if (node["zip_code"].Attributes["active"].Value == "true")
                ZipCodePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/comment/part/SiteCommentZipCode.aspx?zip_code_value=" + ZipCodeValue + "&zip_code_css_class=" + ZipCodeCssClass + "&zip_code_attribute=" + ZipCodeAttribute);
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/comment/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }
    }
}