using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ExtraHelperSignUpOptionModel : CodeBehindModel
    {
        public string SignUpOptionLanguage { get; set; }
        public string ActiveUserNameLanguage { get; set; }
        public string ActiveUserSiteNameLanguage { get; set; }
        public string ActiveRealNameLanguage { get; set; }
        public string ActiveRealLastNameLanguage { get; set; }
        public string ActiveEmailLanguage { get; set; }
        public string ActiveAvatarLanguage { get; set; }
        public string ActiveTypeLanguage { get; set; }
        public string ActivePhoneNumberLanguage { get; set; }
        public string ActiveMobileNumberLanguage { get; set; }
        public string ActiveAddressLanguage { get; set; }
        public string ActivePostalCodeLanguage { get; set; }
        public string ActiveAboutLanguage { get; set; }
        public string ActiveBirthdayLanguage { get; set; }
        public string ActiveGenderLanguage { get; set; }
        public string ActiveCountryLanguage { get; set; }
        public string ActiveStateOrProvinceLanguage { get; set; }
        public string ActiveCityLanguage { get; set; }
        public string ActiveZipCodeLanguage { get; set; }
        public string ActivePublicEmailLanguage { get; set; }
        public string ActiveWebsiteLanguage { get; set; }
        public string SaveSignUpOptionLanguage { get; set; }

        public bool ActiveUserNameValue { get; set; } = false;
        public bool ActiveUserSiteNameValue { get; set; } = false;
        public bool ActiveRealNameValue { get; set; } = false;
        public bool ActiveRealLastNameValue { get; set; } = false;
        public bool ActiveEmailValue { get; set; } = false;
        public bool ActiveAvatarValue { get; set; } = false;
        public bool ActivePhoneNumberValue { get; set; } = false;
        public bool ActiveMobileNumberValue { get; set; } = false;
        public bool ActiveAddressValue { get; set; } = false;
        public bool ActivePostalCodeValue { get; set; } = false;
        public bool ActiveAboutValue { get; set; } = false;
        public bool ActiveBirthdayValue { get; set; } = false;
        public bool ActiveGenderValue { get; set; } = false;
        public bool ActiveCountryValue { get; set; } = false;
        public bool ActiveStateOrProvinceValue { get; set; } = false;
        public bool ActiveCityValue { get; set; } = false;
        public bool ActiveZipCodeValue { get; set; } = false;
        public bool ActivePublicEmailValue { get; set; } = false;
        public bool ActiveWebsiteValue { get; set; } = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/sign_up_option/");
            SignUpOptionLanguage = aol.GetAddOnsLanguage("sign_up_option");
            ActiveUserNameLanguage = aol.GetAddOnsLanguage("active_user_name");
            ActiveUserSiteNameLanguage = aol.GetAddOnsLanguage("active_user_site_name");
            ActiveRealNameLanguage = aol.GetAddOnsLanguage("active_real_name");
            ActiveRealLastNameLanguage = aol.GetAddOnsLanguage("active_real_last_name");
            ActiveEmailLanguage = aol.GetAddOnsLanguage("active_email");
            ActiveAvatarLanguage = aol.GetAddOnsLanguage("active_avatar");
            ActiveTypeLanguage = aol.GetAddOnsLanguage("active_type");
            ActivePhoneNumberLanguage = aol.GetAddOnsLanguage("active_phone_number");
            ActiveMobileNumberLanguage = aol.GetAddOnsLanguage("active_mobile_number");
            ActiveAddressLanguage = aol.GetAddOnsLanguage("active_address");
            ActivePostalCodeLanguage = aol.GetAddOnsLanguage("active_postal_code");
            ActiveAboutLanguage = aol.GetAddOnsLanguage("active_about");
            ActiveBirthdayLanguage = aol.GetAddOnsLanguage("active_birthday");
            ActiveGenderLanguage = aol.GetAddOnsLanguage("active_gender");
            ActiveCountryLanguage = aol.GetAddOnsLanguage("active_country");
            ActiveStateOrProvinceLanguage = aol.GetAddOnsLanguage("active_state_or_province");
            ActiveCityLanguage = aol.GetAddOnsLanguage("active_city");
            ActiveZipCodeLanguage = aol.GetAddOnsLanguage("active_zip_code");
            ActivePublicEmailLanguage = aol.GetAddOnsLanguage("active_public_email");
            ActiveWebsiteLanguage = aol.GetAddOnsLanguage("active_website");
            SaveSignUpOptionLanguage = aol.GetAddOnsLanguage("save_sign_up_option");


            // Set Current Value
            XmlDocument SignUpOptionDocument = new XmlDocument();
            SignUpOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/sign_up_option/option/sign_up_option.xml"));

            XmlNode node = SignUpOptionDocument.SelectSingleNode("sign_up_option_root");

            ActiveAboutValue = (node["about"].Attributes["active"].Value == "true");
            ActiveAddressValue = (node["address"].Attributes["active"].Value == "true");
            ActiveBirthdayValue = (node["birthday"].Attributes["active"].Value == "true");
            ActiveCityValue = (node["city"].Attributes["active"].Value == "true");
            ActiveCountryValue = (node["country"].Attributes["active"].Value == "true");
            ActiveEmailValue = (node["email"].Attributes["active"].Value == "true");
            ActiveAvatarValue = (node["avatar"].Attributes["active"].Value == "true");
            ActiveGenderValue = (node["gender"].Attributes["active"].Value == "true");
            ActiveRealLastNameValue = (node["real_last_name"].Attributes["active"].Value == "true");
            ActiveMobileNumberValue = (node["mobile_number"].Attributes["active"].Value == "true");
            ActiveUserNameValue = (node["user_name"].Attributes["active"].Value == "true");
            ActiveUserSiteNameValue = (node["user_site_name"].Attributes["active"].Value == "true");
            ActiveRealNameValue = (node["real_name"].Attributes["active"].Value == "true");
            ActivePhoneNumberValue = (node["phone_number"].Attributes["active"].Value == "true");
            ActivePostalCodeValue = (node["postal_code"].Attributes["active"].Value == "true");
            ActivePublicEmailValue = (node["public_email"].Attributes["active"].Value == "true");
            ActiveStateOrProvinceValue = (node["state_or_province"].Attributes["active"].Value == "true");
            ActiveWebsiteValue = (node["website"].Attributes["active"].Value == "true");
            ActiveZipCodeValue = (node["zip_code"].Attributes["active"].Value == "true");
        }

        public void SaveSignUpOption()
        {
            XmlDocument SignUpOptionDocument = new XmlDocument();
            SignUpOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/sign_up_option/option/sign_up_option.xml"));

            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/about").Attributes["active"].Value = ActiveAboutValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/address").Attributes["active"].Value = ActiveAddressValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/birthday").Attributes["active"].Value = ActiveBirthdayValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/city").Attributes["active"].Value = ActiveCityValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/country").Attributes["active"].Value = ActiveCountryValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/email").Attributes["active"].Value = ActiveEmailValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/avatar").Attributes["active"].Value = ActiveAvatarValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/gender").Attributes["active"].Value = ActiveGenderValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/real_last_name").Attributes["active"].Value = ActiveRealLastNameValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/mobile_number").Attributes["active"].Value = ActiveMobileNumberValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/user_name").Attributes["active"].Value = ActiveUserNameValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/user_site_name").Attributes["active"].Value = ActiveUserSiteNameValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/real_name").Attributes["active"].Value = ActiveRealNameValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/phone_number").Attributes["active"].Value = ActivePhoneNumberValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/postal_code").Attributes["active"].Value = ActivePostalCodeValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/public_email").Attributes["active"].Value = ActivePublicEmailValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/state_or_province").Attributes["active"].Value = ActiveStateOrProvinceValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/website").Attributes["active"].Value = ActiveWebsiteValue.BooleanToTrueFalse();
            SignUpOptionDocument.SelectSingleNode("sign_up_option_root/zip_code").Attributes["active"].Value = ActiveZipCodeValue.BooleanToTrueFalse();

            SignUpOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/sign_up_option/option/sign_up_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_sign_up_option", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("sign_up_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/sign_up_option/"), "success");
        }
    }
}