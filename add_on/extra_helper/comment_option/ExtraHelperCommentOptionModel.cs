﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ExtraHelperCommentOptionModel
    {
        public string CommentOptionLanguage { get; set; }
        public string ActiveNameLanguage { get; set; }
        public string ActiveLastNameLanguage { get; set; }
        public string ActiveEmailLanguage { get; set; }
        public string ActiveTitleLanguage { get; set; }
        public string ActiveTextLanguage { get; set; }
        public string ActiveFileLanguage { get; set; }
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
        public string SaveCommentOptionLanguage { get; set; }

        public bool ActiveNameValue { get; set; } = false;
        public bool ActiveLastNameValue { get; set; } = false;
        public bool ActiveEmailValue { get; set; } = false;
        public bool ActiveTitleValue { get; set; } = false;
        public bool ActiveTextValue { get; set; } = false;
        public bool ActiveFileValue { get; set; } = false;
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
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/comment_option/");
            CommentOptionLanguage = aol.GetAddOnsLanguage("comment_option");
            ActiveNameLanguage = aol.GetAddOnsLanguage("active_name");
            ActiveLastNameLanguage = aol.GetAddOnsLanguage("active_last_name");
            ActiveEmailLanguage = aol.GetAddOnsLanguage("active_email");
            ActiveTitleLanguage = aol.GetAddOnsLanguage("active_title");
            ActiveTextLanguage = aol.GetAddOnsLanguage("active_text");
            ActiveFileLanguage = aol.GetAddOnsLanguage("active_file");
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
            SaveCommentOptionLanguage = aol.GetAddOnsLanguage("save_comment_option");


            // Set Current Value
            XmlDocument CommentOptionDocument = new XmlDocument();
            CommentOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/comment_option/option/comment_option.xml"));

            XmlNode node = CommentOptionDocument.SelectSingleNode("comment_option_root");

            ActiveAboutValue = (node["about"].Attributes["active"].Value == "true");
            ActiveAddressValue = (node["address"].Attributes["active"].Value == "true");
            ActiveBirthdayValue = (node["birthday"].Attributes["active"].Value == "true");
            ActiveCityValue = (node["city"].Attributes["active"].Value == "true");
            ActiveCountryValue = (node["country"].Attributes["active"].Value == "true");
            ActiveEmailValue = (node["email"].Attributes["active"].Value == "true");
            ActiveFileValue = (node["file"].Attributes["active"].Value == "true");
            ActiveGenderValue = (node["gender"].Attributes["active"].Value == "true");
            ActiveLastNameValue = (node["last_name"].Attributes["active"].Value == "true");
            ActiveMobileNumberValue = (node["mobile_number"].Attributes["active"].Value == "true");
            ActiveNameValue = (node["name"].Attributes["active"].Value == "true");
            ActivePhoneNumberValue = (node["phone_number"].Attributes["active"].Value == "true");
            ActivePostalCodeValue = (node["postal_code"].Attributes["active"].Value == "true");
            ActivePublicEmailValue = (node["public_email"].Attributes["active"].Value == "true");
            ActiveStateOrProvinceValue = (node["state_or_province"].Attributes["active"].Value == "true");
            ActiveTextValue = (node["text"].Attributes["active"].Value == "true");
            ActiveTitleValue = (node["title"].Attributes["active"].Value == "true");
            ActiveTypeValue = (node["type"].Attributes["active"].Value == "true");
            ActiveWebsiteValue = (node["website"].Attributes["active"].Value == "true");
            ActiveZipCodeValue = (node["zip_code"].Attributes["active"].Value == "true");
        }

        public void SaveCommentOption()
        {
            XmlDocument CommentOptionDocument = new XmlDocument();
            CommentOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/comment_option/option/comment_option.xml"));

            CommentOptionDocument.SelectSingleNode("comment_option_root/about").Attributes["active"].Value = ActiveAboutValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/address").Attributes["active"].Value = ActiveAddressValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/birthday").Attributes["active"].Value = ActiveBirthdayValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/city").Attributes["active"].Value = ActiveCityValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/country").Attributes["active"].Value = ActiveCountryValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/email").Attributes["active"].Value = ActiveEmailValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/file").Attributes["active"].Value = ActiveFileValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/gender").Attributes["active"].Value = ActiveGenderValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/last_name").Attributes["active"].Value = ActiveLastNameValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/mobile_number").Attributes["active"].Value = ActiveMobileNumberValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/name").Attributes["active"].Value = ActiveNameValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/phone_number").Attributes["active"].Value = ActivePhoneNumberValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/postal_code").Attributes["active"].Value = ActivePostalCodeValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/public_email").Attributes["active"].Value = ActivePublicEmailValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/state_or_province").Attributes["active"].Value = ActiveStateOrProvinceValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/text").Attributes["active"].Value = ActiveTextValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/title").Attributes["active"].Value = ActiveTitleValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/type").Attributes["active"].Value = ActiveTypeValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/website").Attributes["active"].Value = ActiveWebsiteValue.BooleanToTrueFalse();
            CommentOptionDocument.SelectSingleNode("comment_option_root/zip_code").Attributes["active"].Value = ActiveZipCodeValue.BooleanToTrueFalse();

            CommentOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/comment_option/option/comment_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_comment_option", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("comment_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/comment_option/"), "success");
        }
    }
}