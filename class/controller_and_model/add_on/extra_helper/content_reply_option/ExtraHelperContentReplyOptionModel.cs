using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ExtraHelperContentReplyOptionModel : CodeBehindModel
    {
        // Set Language
        public string ContentReplyOptionLanguage { get; set; }
        public string ActiveNameLanguage { get; set; }
        public string ActiveLastNameLanguage { get; set; }
        public string ActiveEmailLanguage { get; set; }
        public string ActiveTextLanguage { get; set; }
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
        public string SaveContentReplyOptionLanguage { get; set; }

        public bool ActiveNameValue { get; set; } = false;
        public bool ActiveLastNameValue { get; set; } = false;
        public bool ActiveEmailValue { get; set; } = false;
        public bool ActiveTextValue { get; set; } = false;
        public bool ActiveTypeValue { get; set; } = false;
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
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/content_reply_option/");
            ContentReplyOptionLanguage = aol.GetAddOnsLanguage("content_reply_option");
            ActiveNameLanguage = aol.GetAddOnsLanguage("active_name");
            ActiveLastNameLanguage = aol.GetAddOnsLanguage("active_last_name");
            ActiveEmailLanguage = aol.GetAddOnsLanguage("active_email");
            ActiveTextLanguage = aol.GetAddOnsLanguage("active_text");
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
            SaveContentReplyOptionLanguage = aol.GetAddOnsLanguage("save_content_reply_option");


            // Set Current Value
            XmlDocument ContentReplyOptionDocument = new XmlDocument();
            ContentReplyOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/content_reply_option/option/content_reply_option.xml"));

            XmlNode node = ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root");

            ActiveAboutValue = (node["about"].Attributes["active"].Value == "true");
            ActiveAddressValue = (node["address"].Attributes["active"].Value == "true");
            ActiveBirthdayValue = (node["birthday"].Attributes["active"].Value == "true");
            ActiveCityValue = (node["city"].Attributes["active"].Value == "true");
            ActiveCountryValue = (node["country"].Attributes["active"].Value == "true");
            ActiveEmailValue = (node["email"].Attributes["active"].Value == "true");
            ActiveGenderValue = (node["gender"].Attributes["active"].Value == "true");
            ActiveLastNameValue = (node["last_name"].Attributes["active"].Value == "true");
            ActiveMobileNumberValue = (node["mobile_number"].Attributes["active"].Value == "true");
            ActiveNameValue = (node["name"].Attributes["active"].Value == "true");
            ActivePhoneNumberValue = (node["phone_number"].Attributes["active"].Value == "true");
            ActivePostalCodeValue = (node["postal_code"].Attributes["active"].Value == "true");
            ActivePublicEmailValue = (node["public_email"].Attributes["active"].Value == "true");
            ActiveStateOrProvinceValue = (node["state_or_province"].Attributes["active"].Value == "true");
            ActiveTextValue = (node["text"].Attributes["active"].Value == "true");
            ActiveTypeValue = (node["type"].Attributes["active"].Value == "true");
            ActiveWebsiteValue = (node["website"].Attributes["active"].Value == "true");
            ActiveZipCodeValue = (node["zip_code"].Attributes["active"].Value == "true");
        }

        public void SaveContentReplyOption()
        {
            XmlDocument ContentReplyOptionDocument = new XmlDocument();
            ContentReplyOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/content_reply_option/option/content_reply_option.xml"));

            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/about").Attributes["active"].Value = ActiveAboutValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/address").Attributes["active"].Value = ActiveAddressValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/birthday").Attributes["active"].Value = ActiveBirthdayValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/city").Attributes["active"].Value = ActiveCityValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/country").Attributes["active"].Value = ActiveCountryValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/email").Attributes["active"].Value = ActiveEmailValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/gender").Attributes["active"].Value = ActiveGenderValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/last_name").Attributes["active"].Value = ActiveLastNameValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/mobile_number").Attributes["active"].Value = ActiveMobileNumberValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/name").Attributes["active"].Value = ActiveNameValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/phone_number").Attributes["active"].Value = ActivePhoneNumberValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/postal_code").Attributes["active"].Value = ActivePostalCodeValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/public_email").Attributes["active"].Value = ActivePublicEmailValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/state_or_province").Attributes["active"].Value = ActiveStateOrProvinceValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/text").Attributes["active"].Value = ActiveTextValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/type").Attributes["active"].Value = ActiveTypeValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/website").Attributes["active"].Value = ActiveWebsiteValue.BooleanToTrueFalse();
            ContentReplyOptionDocument.SelectSingleNode("content_reply_option_root/zip_code").Attributes["active"].Value = ActiveZipCodeValue.BooleanToTrueFalse();

            ContentReplyOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/content_reply_option/option/content_reply_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_content_reply_option", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("content_reply_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/content_reply_option/"), "success");
        }
    }
}