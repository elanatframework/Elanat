using CodeBehind;

namespace Elanat
{
    public partial class ActionEditContentReplyModel : CodeBehindModel
    {
        public string EditContentReplyLanguage { get; set; }
        public string SaveContentReplyLanguage { get; set; }
        public string ContentIdLanguage { get; set; }
        public string ContentReplyActiveLanguage { get; set; }
        public string ContentReplyGuestNameLanguage { get; set; }
        public string ContentReplyGuestRealNameLanguage { get; set; }
        public string ContentReplyGuestRealLastNameLanguage { get; set; }
        public string ContentReplyGuestEmailLanguage { get; set; }
        public string ContentReplyTypeLanguage { get; set; }
        public string ContentReplyTextLanguage { get; set; }
        public string ContentReplyGuestPhoneNumberLanguage { get; set; }
        public string ContentReplyGuestAddressLanguage { get; set; }
        public string ContentReplyGuestPostalCodeLanguage { get; set; }
        public string ContentReplyGuestAboutLanguage { get; set; }
        public string ContentReplyGuestBirthdayLanguage { get; set; }
        public string ContentReplyGuestGenderLanguage { get; set; }
        public string MaleLanguage { get; set; }
        public string FemaleLanguage { get; set; }
        public string UnknownLanguage { get; set; }
        public string ContentReplyGuestWebsiteLanguage { get; set; }
        public string ContentReplyGuestPublicEmailLanguage { get; set; }
        public string ContentReplyGuestCountryLanguage { get; set; }
        public string ContentReplyGuestStateOrProvinceLanguage { get; set; }
        public string ContentReplyGuestCityLanguage { get; set; }
        public string ContentReplyGuestMobileNumberLanguage { get; set; }
        public string ContentReplyGuestZipCodeLanguage { get; set; }
        public string ContentReplyDateSendLanguage { get; set; }
        public string ContentReplyTimeSendLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public bool ContentReplyActiveValue { get; set; } = false;

        public string ContentReplyIdValue { get; set; }
        public string ContentIdValue { get; set; }

        public string ContentReplyTypeOptionListValue { get; set; }
        public string ContentReplyTypeOptionListSelectedValue { get; set; }

        public string LastContentReplyPartValue { get; set; }
        public string InaccessReasonPartValue { get; set; }
        public string ContentReplyBoxPartValue { get; set; }

        public string CaptchaTextValue { get; set; }

        public string ContentReplyGuestBirthdayYearOptionListValue { get; set; }
        public string ContentReplyGuestBirthdayMountOptionListValue { get; set; }
        public string ContentReplyGuestBirthdayDayOptionListValue { get; set; }
        public string ContentReplyGuestBirthdayYearOptionListSelectedValue { get; set; }
        public string ContentReplyGuestBirthdayMountOptionListSelectedValue { get; set; }
        public string ContentReplyGuestBirthdayDayOptionListSelectedValue { get; set; }

        public bool GenderMaleValue { get; set; } = false;
        public bool GenderFemaleValue { get; set; } = false;
        public bool GenderUnknownValue { get; set; } = false;

        public string ContentReplyGuestAboutValue { get; set; } = "";
        public string ContentReplyGuestAddressValue { get; set; } = "";
        public string ContentReplyGuestCityValue { get; set; } = "";
        public string ContentReplyGuestCountryValue { get; set; } = "";
        public string ContentReplyGuestEmailValue { get; set; } = "";
        public string ContentReplyGuestMobileNumberValue { get; set; } = "";
        public string ContentReplyGuestPhoneNumberValue { get; set; } = "";
        public string ContentReplyGuestPostalCodeValue { get; set; } = "";
        public string ContentReplyGuestPublicEmailValue { get; set; } = "";
        public string ContentReplyTextValue { get; set; } = "";
        public string ContentReplyGuestNameValue { get; set; } = "";
        public string ContentReplyGuestRealNameValue { get; set; } = "";
        public string ContentReplyGuestRealLastNameValue { get; set; } = "";
        public string ContentReplyGuestStateOrProvinceValue { get; set; } = "";
        public string ContentReplyGuestWebsiteValue { get; set; } = "";
        public string ContentReplyGuestZipCodeValue { get; set; } = "";
        public string ContentReplyDateSendValue { get; set; } = "";
        public string ContentReplyTimeSendValue { get; set; } = "";

        public string ContentIdCssClass { get; set; }
        public string ContentReplyGuestAboutCssClass { get; set; }
        public string ContentReplyGuestAddressCssClass { get; set; }
        public string ContentReplyGuestCityCssClass { get; set; }
        public string ContentReplyGuestCountryCssClass { get; set; }
        public string ContentReplyGuestEmailCssClass { get; set; }
        public string ContentReplyGuestMobileNumberCssClass { get; set; }
        public string ContentReplyGuestPhoneNumberCssClass { get; set; }
        public string ContentReplyGuestPostalCodeCssClass { get; set; }
        public string ContentReplyGuestPublicEmailCssClass { get; set; }
        public string ContentReplyTextCssClass { get; set; }
        public string ContentReplyGuestNameCssClass { get; set; }
        public string ContentReplyGuestRealNameCssClass { get; set; }
        public string ContentReplyGuestRealLastNameCssClass { get; set; }
        public string ContentReplyGuestStateOrProvinceCssClass { get; set; }
        public string ContentReplyGuestWebsiteCssClass { get; set; }
        public string ContentReplyGuestZipCodeCssClass { get; set; }
        public string ContentReplyTypeCssClass { get; set; }
        public string ContentReplyGuestBirthdayYearCssClass { get; set; }
        public string ContentReplyGuestBirthdayMountCssClass { get; set; }
        public string ContentReplyGuestBirthdayDayCssClass { get; set; }
        public string ContentReplyDateSendCssClass { get; set; }
        public string ContentReplyTimeSendCssClass { get; set; }

        public string ContentIdAttribute { get; set; }
        public string ContentReplyGuestAboutAttribute { get; set; }
        public string ContentReplyGuestAddressAttribute { get; set; }
        public string ContentReplyGuestCityAttribute { get; set; }
        public string ContentReplyGuestCountryAttribute { get; set; }
        public string ContentReplyGuestEmailAttribute { get; set; }
        public string ContentReplyGuestMobileNumberAttribute { get; set; }
        public string ContentReplyGuestPhoneNumberAttribute { get; set; }
        public string ContentReplyGuestPostalCodeAttribute { get; set; }
        public string ContentReplyGuestPublicEmailAttribute { get; set; }
        public string ContentReplyTextAttribute { get; set; }
        public string ContentReplyGuestNameAttribute { get; set; }
        public string ContentReplyGuestRealNameAttribute { get; set; }
        public string ContentReplyGuestRealLastNameAttribute { get; set; }
        public string ContentReplyGuestStateOrProvinceAttribute { get; set; }
        public string ContentReplyGuestWebsiteAttribute { get; set; }
        public string ContentReplyGuestZipCodeAttribute { get; set; }
        public string ContentReplyTypeAttribute { get; set; }
        public string ContentReplyGuestBirthdayYearAttribute { get; set; }
        public string ContentReplyGuestBirthdayMountAttribute { get; set; }
        public string ContentReplyGuestBirthdayDayAttribute { get; set; }
        public string ContentReplyDateSendAttribute { get; set; }
        public string ContentReplyTimeSendAttribute { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/content_reply/");
            SaveContentReplyLanguage = aol.GetAddOnsLanguage("save_content_reply");
            EditContentReplyLanguage = aol.GetAddOnsLanguage("edit_content_reply");
            ContentIdLanguage = aol.GetAddOnsLanguage("content_id");
            ContentReplyGuestNameLanguage = aol.GetAddOnsLanguage("content_reply_guest_name");
            ContentReplyGuestRealNameLanguage = aol.GetAddOnsLanguage("content_reply_guest_real_name");
            ContentReplyGuestRealLastNameLanguage = aol.GetAddOnsLanguage("content_reply_guest_real_last_name");
            ContentReplyGuestEmailLanguage = aol.GetAddOnsLanguage("content_reply_guest_email");
            ContentReplyTypeLanguage = aol.GetAddOnsLanguage("content_reply_type");
            ContentReplyGuestAboutLanguage = aol.GetAddOnsLanguage("content_reply_guest_about");
            ContentReplyGuestAddressLanguage = aol.GetAddOnsLanguage("content_reply_guest_address");
            ContentReplyGuestBirthdayLanguage = aol.GetAddOnsLanguage("content_reply_guest_birthday");
            ContentReplyGuestGenderLanguage = aol.GetAddOnsLanguage("content_reply_guest_gender");
            FemaleLanguage = aol.GetAddOnsLanguage("female");
            MaleLanguage = aol.GetAddOnsLanguage("male");
            UnknownLanguage = aol.GetAddOnsLanguage("unknown");
            ContentReplyGuestPhoneNumberLanguage = aol.GetAddOnsLanguage("content_reply_guest_phone_number");
            ContentReplyGuestPostalCodeLanguage = aol.GetAddOnsLanguage("content_reply_guest_postal_code");
            ContentReplyGuestWebsiteLanguage = aol.GetAddOnsLanguage("content_reply_guest_website");
            ContentReplyGuestPublicEmailLanguage = aol.GetAddOnsLanguage("content_reply_guest_public_email");
            ContentReplyGuestCountryLanguage = aol.GetAddOnsLanguage("content_reply_guest_country");
            ContentReplyGuestStateOrProvinceLanguage = aol.GetAddOnsLanguage("content_reply_guest_state_or_province");
            ContentReplyGuestCityLanguage = aol.GetAddOnsLanguage("content_reply_guest_city");
            ContentReplyGuestMobileNumberLanguage = aol.GetAddOnsLanguage("content_reply_guest_mobile_number");
            ContentReplyGuestZipCodeLanguage = aol.GetAddOnsLanguage("content_reply_guest_zip_code");
            ContentReplyTextLanguage = aol.GetAddOnsLanguage("content_reply_text");
            ContentReplyActiveLanguage = aol.GetAddOnsLanguage("content_reply_active");
            ContentReplyDateSendLanguage = aol.GetAddOnsLanguage("content_reply_date_send");
            ContentReplyTimeSendLanguage = aol.GetAddOnsLanguage("content_reply_time_send");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.ContentReply ducr = new DataUse.ContentReply();
                ducr.FillCurrentContentReply(ContentReplyIdValue);

                ContentIdValue = ducr.ContentId;
                ContentReplyGuestNameValue = ducr.ContentReplyGuestName;
                ContentReplyGuestRealNameValue = ducr.ContentReplyGuestRealName;
                ContentReplyGuestRealLastNameValue = ducr.ContentReplyGuestRealLastName;
                ContentReplyGuestEmailValue = ducr.ContentReplyGuestEmail;
                ContentReplyTextValue = ducr.ContentReplyText;
                ContentReplyDateSendValue = ducr.ContentReplyDateSend;
                ContentReplyTimeSendValue = ducr.ContentReplyTimeSend;
                ContentReplyActiveValue = ducr.ContentReplyActive.ZeroOneToBoolean();

                ContentReplyTypeOptionListSelectedValue = ducr.ContentReplyType;
                ContentReplyGuestPhoneNumberValue = ducr.ContentReplyGuestPhoneNumber;
                ContentReplyGuestAddressValue = ducr.ContentReplyGuestAddress;
                ContentReplyGuestPostalCodeValue = ducr.ContentReplyGuestPostalCode;
                ContentReplyGuestAboutValue = ducr.ContentReplyGuestAbout;
                ContentReplyGuestBirthdayYearOptionListSelectedValue = ducr.ContentReplyGuestBirthday.Substring(0, 4);
                ContentReplyGuestBirthdayMountOptionListSelectedValue = ducr.ContentReplyGuestBirthday.Substring(5, 2);
                ContentReplyGuestBirthdayDayOptionListSelectedValue = ducr.ContentReplyGuestBirthday.Substring(8, 2);
                if (string.IsNullOrEmpty(ducr.ContentReplyGuestGender))
                    GenderUnknownValue = true;
                else
                    if (ducr.ContentReplyGuestGender.TrueFalseToBoolean())
                    GenderMaleValue = true;
                else
                    GenderFemaleValue = true;
                ContentReplyGuestPublicEmailValue = ducr.ContentReplyGuestPublicEmail;
                ContentReplyGuestMobileNumberValue = ducr.ContentReplyGuestMobileNumber;
                ContentReplyGuestZipCodeValue = ducr.ContentReplyGuestZipCode;
                ContentReplyGuestCountryValue = ducr.ContentReplyGuestCountry;
                ContentReplyGuestStateOrProvinceValue = ducr.ContentReplyGuestStateOrProvince;
                ContentReplyGuestCityValue = ducr.ContentReplyGuestCity;
                ContentReplyGuestWebsiteValue = ducr.ContentReplyGuestWebsite;
            }

            // Set Type Item
            ListClass.ContentReply lccr = new ListClass.ContentReply();
            lccr.FillContentReplyTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ContentReplyTypeOptionListValue += lccr.ContentReplyTypeListItem.HtmlInputToOptionTag(ContentReplyTypeOptionListSelectedValue);

            // Set Birthday Item
            ListClass.DateAndTime lcdat = new ListClass.DateAndTime();
            lcdat.FillBirthdayListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ContentReplyGuestBirthdayDayOptionListValue += ContentReplyGuestBirthdayDayOptionListValue.HtmlInputAddOptionTag("", "00");
            ContentReplyGuestBirthdayDayOptionListValue += lcdat.BirthdayDayListItem.HtmlInputToOptionTag(ContentReplyGuestBirthdayDayOptionListSelectedValue);
            ContentReplyGuestBirthdayMountOptionListValue += ContentReplyGuestBirthdayMountOptionListValue.HtmlInputAddOptionTag("", "00");
            ContentReplyGuestBirthdayMountOptionListValue += lcdat.BirthdayMountListItem.HtmlInputToOptionTag(ContentReplyGuestBirthdayMountOptionListSelectedValue);
            ContentReplyGuestBirthdayYearOptionListValue += ContentReplyGuestBirthdayYearOptionListValue.HtmlInputAddOptionTag("", "0000");
            ContentReplyGuestBirthdayYearOptionListValue += lcdat.BirthdayYearListItem.HtmlInputToOptionTag(ContentReplyGuestBirthdayYearOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_ContentId", "");
            InputRequest.Add("txt_ParentContentReply", "");
            InputRequest.Add("txt_ContentReplyGuestAbout", "");
            InputRequest.Add("txt_ContentReplyGuestAddress", "");
            InputRequest.Add("txt_ContentReplyGuestCity", "");
            InputRequest.Add("txt_ContentReplyGuestCountry", "");
            InputRequest.Add("txt_ContentReplyGuestEmail", "");
            InputRequest.Add("txt_ContentReplyGuestPhoneNumber", "");
            InputRequest.Add("txt_ContentReplyGuestPostalCode", "");
            InputRequest.Add("txt_ContentReplyGuestPublicEmail", "");
            InputRequest.Add("txt_ContentReplyText", "");
            InputRequest.Add("txt_ContentReplyGuestName", "");
            InputRequest.Add("txt_ContentReplyGuestRealName", "");
            InputRequest.Add("txt_ContentReplyGuestRealLastName", "");
            InputRequest.Add("txt_ContentReplyGuestStateOrProvince", "");
            InputRequest.Add("txt_ContentReplyGuestWebsite", "");
            InputRequest.Add("txt_ContentReplyGuestZipCode", "");
            InputRequest.Add("ddlst_ContentReplyType", ContentReplyTypeOptionListValue);
            InputRequest.Add("ddlst_ContentReplyGuestBirthdayYear", ContentReplyGuestBirthdayYearOptionListValue);
            InputRequest.Add("ddlst_ContentReplyGuestBirthdayMount", ContentReplyGuestBirthdayMountOptionListValue);
            InputRequest.Add("ddlst_ContentReplyGuestBirthdayDay", ContentReplyGuestBirthdayDayOptionListValue);
            InputRequest.Add("hdn_ContentReplyId", ContentReplyIdValue);
            InputRequest.Add("txt_ContentReplyDateSend", "");
            InputRequest.Add("txt_ContentReplyTimeSend", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/content_reply/");

            ContentIdAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentId");
            ContentReplyGuestAboutAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestAbout");
            ContentReplyGuestAddressAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestAddress");
            ContentReplyGuestCityAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestCity");
            ContentReplyGuestCountryAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestCountry");
            ContentReplyGuestEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestEmail");
            ContentReplyGuestPhoneNumberAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestPhoneNumber");
            ContentReplyGuestPostalCodeAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestPostalCode");
            ContentReplyGuestPublicEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestPublicEmail");
            ContentReplyTextAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyText");
            ContentReplyGuestNameAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestName");
            ContentReplyGuestRealNameAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestRealName");
            ContentReplyGuestRealLastNameAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestRealLastName");
            ContentReplyGuestStateOrProvinceAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestStateOrProvince");
            ContentReplyGuestWebsiteAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestWebsite");
            ContentReplyGuestZipCodeAttribute += vc.ImportantInputAttribute.GetValue("txt_ContentReplyGuestZipCode");
            ContentReplyTypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ContentReplyType");
            ContentReplyGuestBirthdayYearAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ContentReplyGuestBirthdayYear");
            ContentReplyGuestBirthdayMountAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ContentReplyGuestBirthdayMount");
            ContentReplyGuestBirthdayDayAttribute += vc.ImportantInputAttribute.GetValue("ddlst_ContentReplyGuestBirthdayDay");
            ContentReplyDateSendAttribute += vc.ImportantInputAttribute.GetValue("txt_ ContentReplyDateSend");
            ContentReplyTimeSendAttribute += vc.ImportantInputAttribute.GetValue("txt_ ContentReplyTimeSend");

            ContentIdCssClass = ContentIdCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentId"));
            ContentReplyGuestAboutCssClass = ContentReplyGuestAboutCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestAbout"));
            ContentReplyGuestAddressCssClass = ContentReplyGuestAddressCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestAddress"));
            ContentReplyGuestCityCssClass = ContentReplyGuestCityCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestCity"));
            ContentReplyGuestCountryCssClass = ContentReplyGuestCountryCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestCountry"));
            ContentReplyGuestEmailCssClass = ContentReplyGuestEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestEmail"));
            ContentReplyGuestPhoneNumberCssClass = ContentReplyGuestPhoneNumberCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestPhoneNumber"));
            ContentReplyGuestPostalCodeCssClass = ContentReplyGuestPostalCodeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestPostalCode"));
            ContentReplyGuestPublicEmailCssClass = ContentReplyGuestPublicEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestPublicEmail"));
            ContentReplyTextCssClass = ContentReplyTextCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyText"));
            ContentReplyGuestNameCssClass = ContentReplyGuestNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestName"));
            ContentReplyGuestRealNameCssClass = ContentReplyGuestRealNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestRealName"));
            ContentReplyGuestRealLastNameCssClass = ContentReplyGuestRealLastNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestRealLastName"));
            ContentReplyGuestStateOrProvinceCssClass = ContentReplyGuestStateOrProvinceCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestStateOrProvince"));
            ContentReplyGuestWebsiteCssClass = ContentReplyGuestWebsiteCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestWebsite"));
            ContentReplyGuestZipCodeCssClass = ContentReplyGuestZipCodeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyGuestZipCode"));
            ContentReplyTypeCssClass = ContentReplyTypeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ContentReplyType"));
            ContentReplyGuestBirthdayYearCssClass = ContentReplyGuestBirthdayYearCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ContentReplyGuestBirthdayYear"));
            ContentReplyGuestBirthdayMountCssClass = ContentReplyGuestBirthdayMountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ContentReplyGuestBirthdayMount"));
            ContentReplyGuestBirthdayDayCssClass = ContentReplyGuestBirthdayDayCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_ContentReplyGuestBirthdayDay"));
            ContentReplyDateSendCssClass = ContentReplyDateSendCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyDateSend"));
            ContentReplyTimeSendCssClass = ContentReplyTimeSendCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContentReplyTimeSend"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/content_reply/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveContentReply()
        {
            string TmpUserBirthday = "2000/01/01";

            if (ContentReplyGuestBirthdayYearOptionListSelectedValue != "0000" && ContentReplyGuestBirthdayMountOptionListSelectedValue != "00" && ContentReplyGuestBirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = ContentReplyGuestBirthdayYearOptionListSelectedValue + "/" + ContentReplyGuestBirthdayMountOptionListSelectedValue + "/" + ContentReplyGuestBirthdayDayOptionListSelectedValue;


            DataUse.ContentReply ducr = new DataUse.ContentReply();

            // Change Database Data
            ducr.ContentReplyId = ContentReplyIdValue;
            ducr.ContentId = ContentIdValue;
            ducr.UserId = StaticObject.GetCurrentUserId();
            ducr.ContentReplyGuestName = StringClass.RemoveHtmlTags(ContentReplyGuestNameValue);
            ducr.ContentReplyGuestRealName = StringClass.RemoveHtmlTags(ContentReplyGuestRealNameValue);
            ducr.ContentReplyGuestRealLastName = StringClass.RemoveHtmlTags(ContentReplyGuestRealLastNameValue);
            ducr.ContentReplyGuestEmail = string.IsNullOrEmpty(ContentReplyGuestEmailValue) ? "" : StringClass.RemoveHtmlTags(ContentReplyGuestEmailValue.ToLower());
            ducr.ContentReplyText = (StaticObject.RoleWriteHtmlCheck()) ? ContentReplyTextValue : StringClass.RemoveHtmlTags(ContentReplyTextValue);
            ducr.ContentReplyText = (StaticObject.RoleWriteScriptCheck()) ? ducr.ContentReplyText : StringClass.RemoveScriptTags(ducr.ContentReplyText);
            ducr.ContentReplyDateSend = ContentReplyDateSendValue;
            ducr.ContentReplyTimeSend = ContentReplyTimeSendValue;
            ducr.ContentReplyActive = ContentReplyActiveValue.BooleanToZeroOne();
            ducr.ContentReplyIpAddress = Security.GetUserIp();
            ducr.ContentReplyType = StringClass.RemoveHtmlTags(ContentReplyTypeOptionListSelectedValue);
            ducr.ContentReplyGuestPhoneNumber = StringClass.RemoveHtmlTags(ContentReplyGuestPhoneNumberValue);
            ducr.ContentReplyGuestAddress = StringClass.RemoveHtmlTags(ContentReplyGuestAddressValue);
            ducr.ContentReplyGuestPostalCode = StringClass.RemoveHtmlTags(ContentReplyGuestPostalCodeValue);
            ducr.ContentReplyGuestAbout = StringClass.RemoveHtmlTags(ContentReplyGuestAboutValue);
            ducr.ContentReplyGuestBirthday = TmpUserBirthday;
            ducr.ContentReplyGuestGender = (GenderUnknownValue) ? "" : GenderMaleValue.BooleanToZeroOne();
            ducr.ContentReplyGuestPublicEmail = string.IsNullOrEmpty(ContentReplyGuestPublicEmailValue) ? "" : StringClass.RemoveHtmlTags(ContentReplyGuestPublicEmailValue.ToLower());
            ducr.ContentReplyGuestMobileNumber = StringClass.RemoveHtmlTags(ContentReplyGuestMobileNumberValue);
            ducr.ContentReplyGuestZipCode = StringClass.RemoveHtmlTags(ContentReplyGuestZipCodeValue);
            ducr.ContentReplyGuestCountry = StringClass.RemoveHtmlTags(ContentReplyGuestCountryValue);
            ducr.ContentReplyGuestStateOrProvince = StringClass.RemoveHtmlTags(ContentReplyGuestStateOrProvinceValue);
            ducr.ContentReplyGuestCity = StringClass.RemoveHtmlTags(ContentReplyGuestCityValue);
            ducr.ContentReplyGuestWebsite = StringClass.RemoveHtmlTags(ContentReplyGuestWebsiteValue);

            // Edit ContentReply
            ducr.Edit();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_content_reply", ducr.ContentReplyId);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/content_reply/action/SuccessMessage.aspx");
        }
    }
}