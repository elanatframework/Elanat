﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class MemberChangeProfileModel
    {
        public string ChangeProfileLanguage { get; set; }
        public string MemberLanguage { get; set; }
        public string UserRealNameLanguage { get; set; }
        public string UserRealLastNameLanguage { get; set; }
        public string UserPhoneNumberLanguage { get; set; }
        public string UserAddressLanguage { get; set; }
        public string UserPostalCodeLanguage { get; set; }
        public string UserAboutLanguage { get; set; }
        public string UserBirthdayLanguage { get; set; }
        public string UserGenderLanguage { get; set; }
        public string MaleLanguage { get; set; }
        public string FemaleLanguage { get; set; }
        public string UnknownLanguage { get; set; }
        public string UserPublicEmailLanguage { get; set; }
        public string UserMobileNumberLanguage { get; set; }
        public string UserZipCodeLanguage { get; set; }
        public string UserOtherInfoLanguage { get; set; }
        public string UserCountryLanguage { get; set; }
        public string UserStateOrProvinceLanguage { get; set; }
        public string UserCityLanguage { get; set; }
        public string UserWebsiteLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;

        public string UserRealNameValue { get; set; }
        public string UserRealLastNameValue { get; set; }
        public string UserPhoneNumberValue { get; set; }
        public string UserAddressValue { get; set; }
        public string UserPostalCodeValue { get; set; }
        public string UserAboutValue { get; set; }
        public string UserPublicEmailValue { get; set; }
        public string UserMobileNumberValue { get; set; }
        public string UserZipCodeValue { get; set; }
        public string UserOtherInfoValue { get; set; }
        public string UserCountryValue { get; set; }
        public string UserStateOrProvinceValue { get; set; }
        public string UserCityValue { get; set; }
        public string UserWebsiteValue { get; set; }

        public string UserRealNameAttribute { get; set; }
        public string UserRealLastNameAttribute { get; set; }
        public string UserPhoneNumberAttribute { get; set; }
        public string UserAddressAttribute { get; set; }
        public string UserPostalCodeAttribute { get; set; }
        public string UserAboutAttribute { get; set; }
        public string UserPublicEmailAttribute { get; set; }
        public string UserMobileNumberAttribute { get; set; }
        public string UserZipCodeAttribute { get; set; }
        public string UserOtherInfoAttribute { get; set; }
        public string UserCountryAttribute { get; set; }
        public string UserStateOrProvinceAttribute { get; set; }
        public string UserCityAttribute { get; set; }
        public string UserWebsiteAttribute { get; set; }

        public string UserRealNameCssClass { get; set; }
        public string UserRealLastNameCssClass { get; set; }
        public string UserPhoneNumberCssClass { get; set; }
        public string UserAddressCssClass { get; set; }
        public string UserPostalCodeCssClass { get; set; }
        public string UserAboutCssClass { get; set; }
        public string UserPublicEmailCssClass { get; set; }
        public string UserMobileNumberCssClass { get; set; }
        public string UserZipCodeCssClass { get; set; }
        public string UserOtherInfoCssClass { get; set; }
        public string UserCountryCssClass { get; set; }
        public string UserStateOrProvinceCssClass { get; set; }
        public string UserCityCssClass { get; set; }
        public string UserWebsiteCssClass { get; set; }

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

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_profile/");
            MemberLanguage = aol.GetAddOnsLanguage("member");
            FemaleLanguage = aol.GetAddOnsLanguage("female");
            MaleLanguage = aol.GetAddOnsLanguage("male");
            UnknownLanguage = aol.GetAddOnsLanguage("unknown");
            UserAboutLanguage = aol.GetAddOnsLanguage("user_about");
            UserAddressLanguage = aol.GetAddOnsLanguage("user_address");
            UserBirthdayLanguage = aol.GetAddOnsLanguage("user_birthday");
            ChangeProfileLanguage = aol.GetAddOnsLanguage("change_profile");
            UserGenderLanguage = aol.GetAddOnsLanguage("user_gender");
            UserPhoneNumberLanguage = aol.GetAddOnsLanguage("user_phone_number");
            UserPostalCodeLanguage = aol.GetAddOnsLanguage("user_postal_code");
            UserRealLastNameLanguage = aol.GetAddOnsLanguage("user_real_last_name");
            UserRealNameLanguage = aol.GetAddOnsLanguage("user_real_name");
            UserPublicEmailLanguage = aol.GetAddOnsLanguage("user_public_email");
            UserMobileNumberLanguage = aol.GetAddOnsLanguage("user_mobile_number");
            UserZipCodeLanguage = aol.GetAddOnsLanguage("user_zip_code");
            UserOtherInfoLanguage = aol.GetAddOnsLanguage("user_other_info");
            UserCountryLanguage = aol.GetAddOnsLanguage("user_country");
            UserStateOrProvinceLanguage = aol.GetAddOnsLanguage("user_state_or_province");
            UserCityLanguage = aol.GetAddOnsLanguage("user_city");
            UserWebsiteLanguage = aol.GetAddOnsLanguage("user_website");


            // Set User Info
            if (IsFirstStart)
            {
                DataBaseSocket db = new DataBaseSocket();

                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                DataBaseDataReader dbdr = new DataBaseDataReader();
			    dbdr.dr = db.GetProcedure("get_user_info", "@user_id", ccoc.UserId);
                if (dbdr.dr != null && dbdr.dr.HasRows)
                    dbdr.dr.Read();


                string BirthdayDay = dbdr.dr["user_birthday"].ToString().Substring(8, 2);
                string BirthdayMount = dbdr.dr["user_birthday"].ToString().Substring(5, 2);
                string BirthdayYear = dbdr.dr["user_birthday"].ToString().Substring(0, 4);

                ListClass lc = new ListClass();

                // Set Birthday Item
                lc.FillBirthdayListItem(StaticObject.GetCurrentSiteGlobalLanguage());
                BirthdayDayOptionListValue += BirthdayDayOptionListValue.HtmlInputAddOptionTag("", "00");
                BirthdayDayOptionListValue += lc.BirthdayDayListItem.HtmlInputToOptionTag(BirthdayDay);
                BirthdayMountOptionListValue += BirthdayMountOptionListValue.HtmlInputAddOptionTag("", "00");
                BirthdayMountOptionListValue += lc.BirthdayMountListItem.HtmlInputToOptionTag(BirthdayMount);
                BirthdayYearOptionListValue += BirthdayYearOptionListValue.HtmlInputAddOptionTag("", "0000");
                BirthdayYearOptionListValue += lc.BirthdayYearListItem.HtmlInputToOptionTag(BirthdayYear);


                // Set Current Value
                UserRealNameValue = dbdr.dr["user_real_name"].ToString();
                UserRealLastNameValue = dbdr.dr["user_real_last_name"].ToString();
                UserPhoneNumberValue = dbdr.dr["user_phone_number"].ToString();
                UserAddressValue = dbdr.dr["user_address"].ToString();
                UserPostalCodeValue = dbdr.dr["user_postal_code"].ToString();
                UserAboutValue = dbdr.dr["user_about"].ToString();
                UserPublicEmailValue = dbdr.dr["user_public_email"].ToString();
                UserMobileNumberValue = dbdr.dr["user_mobile_number"].ToString();
                UserZipCodeValue = dbdr.dr["user_zip_code"].ToString();
                UserOtherInfoValue = dbdr.dr["user_other_info"].ToString();
                UserCountryValue = dbdr.dr["user_country"].ToString();
                UserStateOrProvinceValue = dbdr.dr["user_state_or_province"].ToString();
                UserCityValue = dbdr.dr["user_city"].ToString();
                UserWebsiteValue = dbdr.dr["user_website"].ToString();
                if (string.IsNullOrEmpty(dbdr.dr["user_gender"].ToString()))
                    GenderUnknownValue = true;
                else
                    if (dbdr.dr["user_gender"].ToString() == "1")
                    GenderMaleValue = true;
                else
                    GenderFemaleValue = true;

                db.Close();
            }
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("ddlst_BirthdayYear", BirthdayYearOptionListValue);
            InputRequest.Add("ddlst_BirthdayMount", BirthdayMountOptionListValue);
            InputRequest.Add("ddlst_BirthdayDay", BirthdayDayOptionListValue);
            InputRequest.Add("txt_UserRealName", "");
            InputRequest.Add("txt_UserRealLastName", "");
            InputRequest.Add("txt_UserPhoneNumber", "");
            InputRequest.Add("txt_UserAddress", "");
            InputRequest.Add("txt_UserPostalCode", "");
            InputRequest.Add("txt_UserAbout", "");
            InputRequest.Add("txt_UserPublicEmail", "");
            InputRequest.Add("txt_UserMobileNumber", "");
            InputRequest.Add("txt_UserZipCode", "");
            InputRequest.Add("txt_UserOtherInfo", "");
            InputRequest.Add("txt_UserCountry", "");
            InputRequest.Add("txt_UserStateOrProvince", "");
            InputRequest.Add("txt_UserCity", "");
            InputRequest.Add("txt_UserWebsite", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/member/change_profile/");

            BirthdayYearAttribute += vc.ImportantInputAttribute["ddlst_BirthdayYear"];
            BirthdayMountAttribute += vc.ImportantInputAttribute["ddlst_BirthdayMount"];
            BirthdayDayAttribute += vc.ImportantInputAttribute["ddlst_BirthdayDay"];
            UserRealNameAttribute += vc.ImportantInputAttribute["txt_UserRealName"];
            UserRealLastNameAttribute += vc.ImportantInputAttribute["txt_UserRealLastName"];
            UserPhoneNumberAttribute += vc.ImportantInputAttribute["txt_UserPhoneNumber"];
            UserAddressAttribute += vc.ImportantInputAttribute["txt_UserAddress"];
            UserPostalCodeAttribute += vc.ImportantInputAttribute["txt_UserPostalCode"];
            UserAboutAttribute += vc.ImportantInputAttribute["txt_UserAbout"];
            UserPublicEmailAttribute += vc.ImportantInputAttribute["txt_UserPublicEmail"];
            UserMobileNumberAttribute += vc.ImportantInputAttribute["txt_UserMobileNumber"];
            UserZipCodeAttribute += vc.ImportantInputAttribute["txt_UserZipCode"];
            UserOtherInfoAttribute += vc.ImportantInputAttribute["txt_UserOtherInfo"];
            UserCountryAttribute += vc.ImportantInputAttribute["txt_UserCountry"];
            UserStateOrProvinceAttribute += vc.ImportantInputAttribute["txt_UserStateOrProvince"];
            UserCityAttribute += vc.ImportantInputAttribute["txt_UserCity"];
            UserWebsiteAttribute += vc.ImportantInputAttribute["txt_UserWebsite"];

            BirthdayYearAttribute = BirthdayYearAttribute.AddHtmlClass(vc.ImportantInputClass["ddlst_BirthdayYear"]);
            BirthdayMountAttribute = BirthdayMountAttribute.AddHtmlClass(vc.ImportantInputClass["ddlst_BirthdayMount"]);
            BirthdayDayAttribute = BirthdayDayAttribute.AddHtmlClass(vc.ImportantInputClass["ddlst_BirthdayDay"]);
            UserRealNameAttribute = UserRealNameAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserRealName"]);
            UserRealLastNameAttribute = UserRealLastNameAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserRealLastName"]);
            UserPhoneNumberAttribute = UserPhoneNumberAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserPhoneNumber"]);
            UserAddressAttribute = UserAddressAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserAddress"]);
            UserPostalCodeAttribute = UserPostalCodeAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserPostalCode"]);
            UserAboutAttribute = UserAboutAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserAbout"]);
            UserPublicEmailAttribute = UserPublicEmailAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserPublicEmail"]);
            UserMobileNumberAttribute = UserMobileNumberAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserMobileNumber"]);
            UserZipCodeAttribute = UserZipCodeAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserZipCode"]);
            UserOtherInfoAttribute = UserOtherInfoAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserOtherInfo"]);
            UserCountryAttribute = UserCountryAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserCountry"]);
            UserStateOrProvinceAttribute = UserStateOrProvinceAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserStateOrProvince"]);
            UserCityAttribute = UserCityAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserCity"]);
            UserWebsiteAttribute = UserWebsiteAttribute.AddHtmlClass(vc.ImportantInputClass["txt_UserWebsite"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/member/change_profile/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentSiteGlobalLanguage(), "problem");

                //BirthdayYearAttribute = BirthdayYearAttribute.AddHtmlClass(vc.WarningFieldClass["ddlst_BirthdayYear"]);
                //BirthdayMountAttribute = BirthdayMountAttribute.AddHtmlClass(vc.WarningFieldClass["ddlst_BirthdayMount"]);
                //BirthdayDayAttribute = BirthdayDayAttribute.AddHtmlClass(vc.WarningFieldClass["ddlst_BirthdayDay"]);
                //UserRealNameAttribute = UserRealNameAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserRealName"]);
                //UserRealLastNameAttribute = UserRealLastNameAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserRealLastName"]);
                //UserPhoneNumberAttribute = UserPhoneNumberAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserPhoneNumber"]);
                //UserAddressAttribute = UserAddressAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserAddress"]);
                //UserPostalCodeAttribute = UserPostalCodeAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserPostalCode"]);
                //UserAboutAttribute = UserAboutAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserAbout"]);
                //UserPublicEmailAttribute = UserPublicEmailAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserPublicEmail"]);
                //UserMobileNumberAttribute = UserMobileNumberAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserMobileNumber"]);
                //UserZipCodeAttribute = UserZipCodeAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserZipCode"]);
                //UserOtherInfoAttribute = UserOtherInfoAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserOtherInfo"]);
                //UserCountryAttribute = UserCountryAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserCountry"]);
                //UserStateOrProvinceAttribute = UserStateOrProvinceAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserStateOrProvince"]);
                //UserCityAttribute = UserCityAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserCity"]);
                //UserWebsiteAttribute = UserWebsiteAttribute.AddHtmlClass(vc.WarningFieldClass["txt_UserWebsite"]);
            }
        }

        public void ChangeProfile()
        {
            // Get Current Client Object
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string TmpUserBirthday = "2000/01/01";

            if (BirthdayYearOptionListSelectedValue != "0000" && BirthdayMountOptionListSelectedValue != "00" && BirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = BirthdayYearOptionListSelectedValue + "/" + BirthdayMountOptionListSelectedValue + "/" + BirthdayDayOptionListSelectedValue;

            DataUse.ChangeUser ducu = new DataUse.ChangeUser();

            ducu.UserId = ccoc.UserId;
            ducu.UserRealName = UserRealNameValue;
            ducu.UserRealLastName = UserRealLastNameValue;
            ducu.UserPhoneNumber = UserPhoneNumberValue;
            ducu.UserAddress = UserAddressValue;
            ducu.UserPostalCode = UserPostalCodeValue;
            ducu.UserAbout = UserAboutValue;
            ducu.UserBirthday = TmpUserBirthday;
            ducu.UserGender = (GenderUnknownValue) ? "" : ((GenderMaleValue) ? "1" : "0");
            ducu.UserPublicEmail = UserPublicEmailValue.ToLower();
            ducu.UserMobileNumber = UserMobileNumberValue;
            ducu.UserZipCode = UserZipCodeValue;
            ducu.UserOtherInfo = UserOtherInfoValue;
            ducu.UserCountry = UserCountryValue;
            ducu.UserStateOrProvince = UserStateOrProvinceValue;
            ducu.UserCity = UserCityValue;
            ducu.UserWebsite = UserWebsiteValue;

            ducu.Start();

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("change_profile", ccoc.UserId);
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.SitePath + "page/member/change_profile/action/SuccessMessage.aspx?use_retrieved=true", true);
        }
    }
}