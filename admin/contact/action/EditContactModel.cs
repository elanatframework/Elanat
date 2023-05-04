using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionEditContactModel
    {
        public string RefreshLanguage { get; set; }
        public string EditContactLanguage { get; set; }
        public string ContactGuestNameLanguage { get; set; }
        public string ContactGuestRealNameLanguage { get; set; }
        public string ContactGuestRealLastNameLanguage { get; set; }
        public string ContactGuestEmailLanguage { get; set; }
        public string ContactTypeLanguage { get; set; }
        public string ContactTitleLanguage { get; set; }
        public string ContactTextLanguage { get; set; }
        public string ContactGuestPhoneNumberLanguage { get; set; }
        public string ContactGuestAddressLanguage { get; set; }
        public string ContactGuestPostalCodeLanguage { get; set; }
        public string ContactGuestAboutLanguage { get; set; }
        public string ContactGuestBirthdayLanguage { get; set; }
        public string ContactGuestGenderLanguage { get; set; }
        public string MaleLanguage { get; set; }
        public string FemaleLanguage { get; set; }
        public string UnknownLanguage { get; set; }
        public string ContactGuestWebsiteLanguage { get; set; }
        public string ContactGuestPublicEmailLanguage { get; set; }
        public string ContactGuestCountryLanguage { get; set; }
        public string ContactGuestStateOrProvinceLanguage { get; set; }
        public string ContactGuestCityLanguage { get; set; }
        public string ContactGuestMobileNumberLanguage { get; set; }
        public string ContactGuestZipCodeLanguage { get; set; }
        public string UploadPathLanguage { get; set; }
        public string UseUploadPathLanguage { get; set; }
        public string DeleteContactFileLanguage { get; set; }
        public string SaveContactLanguage { get; set; }
        public string ContactDateSendLanguage { get; set; }
        public string ContactTimeSendLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string ContactIdValue { get; set; }
        public string ContactUploadDirectoryValue { get; set; }
        public string ContactUploadFileValue { get; set; }

        public string ContactTypeOptionListValue { get; set; }
        public string ContactTypeOptionListSelectedValue { get; set; }

        public string LastContactPartValue { get; set; }
        public string InaccessReasonPartValue { get; set; }
        public string ContactBoxPartValue { get; set; }

        public string CaptchaTextValue { get; set; }

        public bool DeleteContactFileValue { get; set; } = false;
        public bool UseUploadPathValue { get; set; } = false;
        public HttpPostedFile UploadPathUploadValue { get; set; }
        public string UploadPathTextValue { get; set; }

        public string ContactGuestBirthdayYearOptionListValue { get; set; }
        public string ContactGuestBirthdayMountOptionListValue { get; set; }
        public string ContactGuestBirthdayDayOptionListValue { get; set; }
        public string ContactGuestBirthdayYearOptionListSelectedValue { get; set; }
        public string ContactGuestBirthdayMountOptionListSelectedValue { get; set; }
        public string ContactGuestBirthdayDayOptionListSelectedValue { get; set; }

        public bool GenderMaleValue { get; set; } = false;
        public bool GenderFemaleValue { get; set; } = false;
        public bool GenderUnknownValue { get; set; } = false;

        public string ContactGuestAboutValue { get; set; } = "";
        public string ContactGuestAddressValue { get; set; } = "";
        public string ContactGuestCityValue { get; set; } = "";
        public string ContactGuestCountryValue { get; set; } = "";
        public string ContactGuestEmailValue { get; set; } = "";
        public string ContactGuestMobileNumberValue { get; set; } = "";
        public string ContactGuestPhoneNumberValue { get; set; } = "";
        public string ContactGuestPostalCodeValue { get; set; } = "";
        public string ContactGuestPublicEmailValue { get; set; } = "";
        public string ContactTitleValue { get; set; } = "";
        public string ContactTextValue { get; set; } = "";
        public string ContactGuestNameValue { get; set; } = "";
        public string ContactGuestRealNameValue { get; set; } = "";
        public string ContactGuestRealLastNameValue { get; set; } = "";
        public string ContactGuestStateOrProvinceValue { get; set; } = "";
        public string ContactGuestWebsiteValue { get; set; } = "";
        public string ContactGuestZipCodeValue { get; set; } = "";
        public string ContactDateSendValue { get; set; } = "";
        public string ContactTimeSendValue { get; set; } = "";

        public string ContactGuestAboutCssClass { get; set; }
        public string ContactGuestAddressCssClass { get; set; }
        public string ContactGuestCityCssClass { get; set; }
        public string ContactGuestCountryCssClass { get; set; }
        public string ContactGuestEmailCssClass { get; set; }
        public string ContactGuestMobileNumberCssClass { get; set; }
        public string ContactGuestPhoneNumberCssClass { get; set; }
        public string ContactGuestPostalCodeCssClass { get; set; }
        public string ContactGuestPublicEmailCssClass { get; set; }
        public string ContactTitleCssClass { get; set; }
        public string ContactTextCssClass { get; set; }
        public string ContactGuestNameCssClass { get; set; }
        public string ContactGuestRealNameCssClass { get; set; }
        public string ContactGuestRealLastNameCssClass { get; set; }
        public string ContactGuestStateOrProvinceCssClass { get; set; }
        public string ContactGuestWebsiteCssClass { get; set; }
        public string ContactGuestZipCodeCssClass { get; set; }
        public string ContactTypeCssClass { get; set; }
        public string ContactGuestBirthdayYearCssClass { get; set; }
        public string ContactGuestBirthdayMountCssClass { get; set; }
        public string ContactGuestBirthdayDayCssClass { get; set; }
        public string ContactDateSendCssClass { get; set; }
        public string ContactTimeSendCssClass { get; set; }

        public string ContactGuestAboutAttribute { get; set; }
        public string ContactGuestAddressAttribute { get; set; }
        public string ContactGuestCityAttribute { get; set; }
        public string ContactGuestCountryAttribute { get; set; }
        public string ContactGuestEmailAttribute { get; set; }
        public string ContactGuestMobileNumberAttribute { get; set; }
        public string ContactGuestPhoneNumberAttribute { get; set; }
        public string ContactGuestPostalCodeAttribute { get; set; }
        public string ContactGuestPublicEmailAttribute { get; set; }
        public string ContactTitleAttribute { get; set; }
        public string ContactTextAttribute { get; set; }
        public string ContactGuestNameAttribute { get; set; }
        public string ContactGuestRealNameAttribute { get; set; }
        public string ContactGuestRealLastNameAttribute { get; set; }
        public string ContactGuestStateOrProvinceAttribute { get; set; }
        public string ContactGuestWebsiteAttribute { get; set; }
        public string ContactGuestZipCodeAttribute { get; set; }
        public string ContactTypeAttribute { get; set; }
        public string ContactGuestBirthdayYearAttribute { get; set; }
        public string ContactGuestBirthdayMountAttribute { get; set; }
        public string ContactGuestBirthdayDayAttribute { get; set; }
        public string ContactDateSendAttribute { get; set; }
        public string ContactTimeSendAttribute { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/contact/");
            SaveContactLanguage = aol.GetAddOnsLanguage("save_contact");
            EditContactLanguage = aol.GetAddOnsLanguage("edit_contact");
            ContactGuestNameLanguage = aol.GetAddOnsLanguage("contact_guest_name");
            ContactGuestRealNameLanguage = aol.GetAddOnsLanguage("contact_guest_real_name");
            ContactGuestRealLastNameLanguage = aol.GetAddOnsLanguage("contact_guest_real_last_name");
            ContactGuestEmailLanguage = aol.GetAddOnsLanguage("contact_guest_email");
            ContactTypeLanguage = aol.GetAddOnsLanguage("contact_type");
            ContactGuestAboutLanguage = aol.GetAddOnsLanguage("contact_guest_about");
            ContactGuestAddressLanguage = aol.GetAddOnsLanguage("contact_guest_address");
            ContactGuestBirthdayLanguage = aol.GetAddOnsLanguage("contact_guest_birthday");
            ContactGuestGenderLanguage = aol.GetAddOnsLanguage("contact_guest_gender");
            FemaleLanguage = aol.GetAddOnsLanguage("female");
            MaleLanguage = aol.GetAddOnsLanguage("male");
            UnknownLanguage = aol.GetAddOnsLanguage("unknown");
            ContactGuestPhoneNumberLanguage = aol.GetAddOnsLanguage("contact_guest_phone_number");
            ContactGuestPostalCodeLanguage = aol.GetAddOnsLanguage("contact_guest_postal_code");
            ContactGuestWebsiteLanguage = aol.GetAddOnsLanguage("contact_guest_website");
            ContactGuestPublicEmailLanguage = aol.GetAddOnsLanguage("contact_guest_public_email");
            ContactGuestCountryLanguage = aol.GetAddOnsLanguage("contact_guest_country");
            ContactGuestStateOrProvinceLanguage = aol.GetAddOnsLanguage("contact_guest_state_or_province");
            ContactGuestCityLanguage = aol.GetAddOnsLanguage("contact_guest_city");
            ContactGuestMobileNumberLanguage = aol.GetAddOnsLanguage("contact_guest_mobile_number");
            ContactGuestZipCodeLanguage = aol.GetAddOnsLanguage("contact_guest_zip_code");
            ContactTitleLanguage = aol.GetAddOnsLanguage("contact_title");
            ContactTextLanguage = aol.GetAddOnsLanguage("contact_text");
            UploadPathLanguage = aol.GetAddOnsLanguage("file_path");
            UseUploadPathLanguage = aol.GetAddOnsLanguage("use_upload_path");
            DeleteContactFileLanguage = aol.GetAddOnsLanguage("delete_contact_file");
            ContactDateSendLanguage = aol.GetAddOnsLanguage("contact_date_send");
            ContactTimeSendLanguage = aol.GetAddOnsLanguage("contact_time_send");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Contact duc = new DataUse.Contact();
                duc.FillCurrentContact(ContactIdValue);

                ContactGuestNameValue = duc.ContactGuestName;
                ContactGuestRealNameValue = duc.ContactGuestRealName;
                ContactGuestRealLastNameValue = duc.ContactGuestRealLastName;
                ContactGuestEmailValue = duc.ContactGuestEmail;
                ContactTitleValue = duc.ContactTitle;
                ContactTextValue = duc.ContactText;
                ContactDateSendValue = duc.ContactDateSend;
                ContactTimeSendValue = duc.ContactTimeSend;
                ContactUploadDirectoryValue = duc.ContactFileDirectoryPath;
                ContactUploadFileValue = duc.ContactFilePhysicalName;
                ContactTypeOptionListSelectedValue = duc.ContactType;
                ContactGuestPhoneNumberValue = duc.ContactGuestPhoneNumber;
                ContactGuestAddressValue = duc.ContactGuestAddress;
                ContactGuestPostalCodeValue = duc.ContactGuestPostalCode;
                ContactGuestAboutValue = duc.ContactGuestAbout;
                ContactGuestBirthdayYearOptionListSelectedValue = duc.ContactGuestBirthday.Substring(0, 4);
                ContactGuestBirthdayMountOptionListSelectedValue = duc.ContactGuestBirthday.Substring(5, 2);
                ContactGuestBirthdayDayOptionListSelectedValue = duc.ContactGuestBirthday.Substring(8, 2);
                if (string.IsNullOrEmpty(duc.ContactGuestGender))
                    GenderUnknownValue = true;
                else
                    if (duc.ContactGuestGender.ZeroOneToBoolean())
                    GenderMaleValue = true;
                else
                    GenderFemaleValue = true;
                ContactGuestPublicEmailValue = duc.ContactGuestPublicEmail;
                ContactGuestMobileNumberValue = duc.ContactGuestMobileNumber;
                ContactGuestZipCodeValue = duc.ContactGuestZipCode;
                ContactGuestCountryValue = duc.ContactGuestCountry;
                ContactGuestStateOrProvinceValue = duc.ContactGuestStateOrProvince;
                ContactGuestCityValue = duc.ContactGuestCity;
                ContactGuestWebsiteValue = duc.ContactGuestWebsite;
            }

            ListClass lc = new ListClass();

            // Set Type Item
            lc.FillContactTypeListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ContactTypeOptionListValue += lc.ContactTypeListItem.HtmlInputToOptionTag(ContactTypeOptionListSelectedValue);

            // Set Birthday Item
            lc.FillBirthdayListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            ContactGuestBirthdayDayOptionListValue += ContactGuestBirthdayDayOptionListValue.HtmlInputAddOptionTag("", "00");
            ContactGuestBirthdayDayOptionListValue += lc.BirthdayDayListItem.HtmlInputToOptionTag(ContactGuestBirthdayDayOptionListSelectedValue);
            ContactGuestBirthdayMountOptionListValue += ContactGuestBirthdayMountOptionListValue.HtmlInputAddOptionTag("", "00");
            ContactGuestBirthdayMountOptionListValue += lc.BirthdayMountListItem.HtmlInputToOptionTag(ContactGuestBirthdayMountOptionListSelectedValue);
            ContactGuestBirthdayYearOptionListValue += ContactGuestBirthdayYearOptionListValue.HtmlInputAddOptionTag("", "0000");
            ContactGuestBirthdayYearOptionListValue += lc.BirthdayYearListItem.HtmlInputToOptionTag(ContactGuestBirthdayYearOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_ContactGuestAbout", "");
            InputRequest.Add("txt_ContactGuestAddress", "");
            InputRequest.Add("txt_ContactGuestCity", "");
            InputRequest.Add("txt_ContactGuestCountry", "");
            InputRequest.Add("txt_ContactGuestEmail", "");
            InputRequest.Add("txt_ContactGuestPhoneNumber", "");
            InputRequest.Add("txt_ContactGuestPostalCode", "");
            InputRequest.Add("txt_ContactGuestPublicEmail", "");
            InputRequest.Add("txt_ContactTitle", "");
            InputRequest.Add("txt_ContactText", "");
            InputRequest.Add("txt_ContactGuestName", "");
            InputRequest.Add("txt_ContactGuestRealName", "");
            InputRequest.Add("txt_ContactGuestRealLastName", "");
            InputRequest.Add("txt_ContactGuestStateOrProvince", "");
            InputRequest.Add("txt_ContactGuestWebsite", "");
            InputRequest.Add("txt_ContactGuestZipCode", "");
            InputRequest.Add("ddlst_ContactType", ContactTypeOptionListValue);
            InputRequest.Add("ddlst_ContactGuestBirthdayYear", ContactGuestBirthdayYearOptionListValue);
            InputRequest.Add("ddlst_ContactGuestBirthdayMount", ContactGuestBirthdayMountOptionListValue);
            InputRequest.Add("ddlst_ContactGuestBirthdayDay", ContactGuestBirthdayDayOptionListValue);
            InputRequest.Add("hdn_ContactId", ContactIdValue);
            InputRequest.Add("hdn_ContactUploadDirectoryValue", ContactUploadDirectoryValue);
            InputRequest.Add("hdn_ContactUploadFileValue", ContactUploadFileValue);
            InputRequest.Add("txt_ContactDateSend", "");
            InputRequest.Add("txt_ContactTimeSend", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/contact/");

            ContactGuestAboutAttribute += vc.ImportantInputAttribute["txt_ContactGuestAbout"];
            ContactGuestAddressAttribute += vc.ImportantInputAttribute["txt_ContactGuestAddress"];
            ContactGuestCityAttribute += vc.ImportantInputAttribute["txt_ContactGuestCity"];
            ContactGuestCountryAttribute += vc.ImportantInputAttribute["txt_ContactGuestCountry"];
            ContactGuestEmailAttribute += vc.ImportantInputAttribute["txt_ContactGuestEmail"];
            ContactGuestPhoneNumberAttribute += vc.ImportantInputAttribute["txt_ContactGuestPhoneNumber"];
            ContactGuestPostalCodeAttribute += vc.ImportantInputAttribute["txt_ContactGuestPostalCode"];
            ContactGuestPublicEmailAttribute += vc.ImportantInputAttribute["txt_ContactGuestPublicEmail"];
            ContactTitleAttribute += vc.ImportantInputAttribute["txt_ContactTitle"];
            ContactTextAttribute += vc.ImportantInputAttribute["txt_ContactText"];
            ContactGuestNameAttribute += vc.ImportantInputAttribute["txt_ContactGuestName"];
            ContactGuestRealNameAttribute += vc.ImportantInputAttribute["txt_ContactGuestRealName"];
            ContactGuestRealLastNameAttribute += vc.ImportantInputAttribute["txt_ContactGuestRealLastName"];
            ContactGuestStateOrProvinceAttribute += vc.ImportantInputAttribute["txt_ContactGuestStateOrProvince"];
            ContactGuestWebsiteAttribute += vc.ImportantInputAttribute["txt_ContactGuestWebsite"];
            ContactGuestZipCodeAttribute += vc.ImportantInputAttribute["txt_ContactGuestZipCode"];
            ContactTypeAttribute += vc.ImportantInputAttribute["ddlst_ContactType"];
            ContactGuestBirthdayYearAttribute += vc.ImportantInputAttribute["ddlst_ContactGuestBirthdayYear"];
            ContactGuestBirthdayMountAttribute += vc.ImportantInputAttribute["ddlst_ContactGuestBirthdayMount"];
            ContactGuestBirthdayDayAttribute += vc.ImportantInputAttribute["ddlst_ContactGuestBirthdayDay"];
            ContactDateSendAttribute += vc.ImportantInputAttribute["txt_ContactDateSend"];
            ContactTimeSendAttribute += vc.ImportantInputAttribute["txt_ContactTimeSend"];

            ContactGuestAboutCssClass = ContactGuestAboutCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestAbout"]);
            ContactGuestAddressCssClass = ContactGuestAddressCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestAddress"]);
            ContactGuestCityCssClass = ContactGuestCityCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestCity"]);
            ContactGuestCountryCssClass = ContactGuestCountryCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestCountry"]);
            ContactGuestEmailCssClass = ContactGuestEmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestEmail"]);
            ContactGuestPhoneNumberCssClass = ContactGuestPhoneNumberCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestPhoneNumber"]);
            ContactGuestPostalCodeCssClass = ContactGuestPostalCodeCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestPostalCode"]);
            ContactGuestPublicEmailCssClass = ContactGuestPublicEmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestPublicEmail"]);
            ContactTitleCssClass = ContactTitleCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactTitle"]);
            ContactTextCssClass = ContactTextCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactText"]);
            ContactGuestNameCssClass = ContactGuestNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestName"]);
            ContactGuestRealNameCssClass = ContactGuestRealNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestRealName"]);
            ContactGuestRealLastNameCssClass = ContactGuestRealLastNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestRealLastName"]);
            ContactGuestStateOrProvinceCssClass = ContactGuestStateOrProvinceCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestStateOrProvince"]);
            ContactGuestWebsiteCssClass = ContactGuestWebsiteCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestWebsite"]);
            ContactGuestZipCodeCssClass = ContactGuestZipCodeCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactGuestZipCode"]);
            ContactTypeCssClass = ContactTypeCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ContactType"]);
            ContactGuestBirthdayYearCssClass = ContactGuestBirthdayYearCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ContactGuestBirthdayYear"]);
            ContactGuestBirthdayMountCssClass = ContactGuestBirthdayMountCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ContactGuestBirthdayMount"]);
            ContactGuestBirthdayDayCssClass = ContactGuestBirthdayDayCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ContactGuestBirthdayDay"]);
            ContactDateSendCssClass = ContactDateSendCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactDateSend"]);
            ContactTimeSendCssClass = ContactTimeSendCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContactTimeSend"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/contact/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //ContactGuestAboutCssClass = ContactGuestAboutCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestAbout"]);
                //ContactGuestAddressCssClass = ContactGuestAddressCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestAddress"]);
                //ContactGuestCityCssClass = ContactGuestCityCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestCity"]);
                //ContactGuestCountryCssClass = ContactGuestCountryCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestCountry"]);
                //ContactGuestEmailCssClass = ContactGuestEmailCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestEmail"]);
                //ContactGuestPhoneNumberCssClass = ContactGuestPhoneNumberCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestPhoneNumber"]);
                //ContactGuestPostalCodeCssClass = ContactGuestPostalCodeCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestPostalCode"]);
                //ContactGuestPublicEmailCssClass = ContactGuestPublicEmailCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestPublicEmail"]);
                //ContactTitleCssClass = ContactTitleCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactTitle"]);
                //ContactTextCssClass = ContactTextCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactText"]);
                //ContactGuestNameCssClass = ContactGuestNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestName"]);
                //ContactGuestRealNameCssClass = ContactGuestRealNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestRealName"]);
                //ContactGuestRealLastNameCssClass = ContactGuestRealLastNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestRealLastName"]);
                //ContactGuestStateOrProvinceCssClass = ContactGuestStateOrProvinceCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestStateOrProvince"]);
                //ContactGuestWebsiteCssClass = ContactGuestWebsiteCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestWebsite"]);
                //ContactGuestZipCodeCssClass = ContactGuestZipCodeCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactGuestZipCode"]);
                //ContactTypeCssClass = ContactTypeCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ContactType"]);
                //ContactGuestBirthdayYearCssClass = ContactGuestBirthdayYearCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ContactGuestBirthdayYear"]);
                //ContactGuestBirthdayMountCssClass = ContactGuestBirthdayMountCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ContactGuestBirthdayMount"]);
                //ContactGuestBirthdayDayCssClass = ContactGuestBirthdayDayCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ContactGuestBirthdayDay"]);
                //ContactDateSendCssClass = ContactDateSendCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactDateSend"]);
                //ContactTimeSendCssClass = ContactTimeSendCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContactTimeSend"]);
            }
        }

        public void SaveContact()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Contact duc = new DataUse.Contact();


            // Delete Upload File
            if (DeleteContactFileValue)
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue + "/" + ContactUploadFileValue)))
                    File.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue + "/" + ContactUploadFileValue));

                // Delete Thumbnail Image
                if (FileAndDirectory.IsImageExtension(Path.GetExtension(ContactUploadFileValue)))
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue + "/thumb/" + ContactUploadFileValue)))
                        File.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue + "/thumb/" + ContactUploadFileValue));

                    int ThumbnailDirectoryLength = System.IO.Directory.GetDirectories(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue + "/thumb/")).Length;
                    int ThumbnailFileLength = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue + "/thumb/")).Length;

                    if (ThumbnailDirectoryLength == 0 && ThumbnailFileLength == 0)
                        Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue + "/thumb/"), true);
                }

                int DirectoryLength = System.IO.Directory.GetDirectories(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue)).Length;
                int FileLength = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue)).Length;

                if (DirectoryLength == 0 && FileLength == 0)
                    Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/" + ContactUploadDirectoryValue), true);
            }


            // Set Extra Value
            ExtraValue evc = new ExtraValue();


            string UploadFilePhysicalName = "";
            string UploadExtension = "";
            string DirectoryName = "";
            string FileExtension = "";

            // If Use Upload Path
            if (UseUploadPathValue)
            {
                if (!StaticObject.RoleUploadFileCheck())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_to_upload_file", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "problem");

                if (string.IsNullOrEmpty(UploadPathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_upload_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "problem");

                // Check Authorized Extension
                FileExtension = Path.GetExtension(UploadPathTextValue);

                if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "warning");

                UploadFilePhysicalName = Path.GetFileName(UploadPathTextValue);

                evc.FilePhysicalName = Path.GetFileName(UploadFilePhysicalName);
                DirectoryName = evc.GetContactUploadDirectoryValue();
                UploadFilePhysicalName = evc.GetContactUploadFileValue();
                UploadFilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/"), UploadFilePhysicalName);


                System.Net.WebClient webClient = new System.Net.WebClient();

                UploadExtension = Path.GetExtension(UploadFilePhysicalName);


                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), DirectoryName);

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(UploadPathTextValue, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName));
            }
            else
            {
                if (UploadPathUploadValue.HtmlInputHasFile())
                {
                    if (!StaticObject.RoleUploadFileCheck())
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_to_upload_file", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "problem");

                    // Check Authorized Extension
                    FileExtension = Path.GetExtension(UploadPathUploadValue.FileName);

                    if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "warning");

                    UploadFilePhysicalName = UploadPathUploadValue.FileName;

                    evc.FilePhysicalName = Path.GetFileName(UploadFilePhysicalName);
                    DirectoryName = evc.GetContactUploadDirectoryValue();
                    UploadFilePhysicalName = evc.GetContactUploadFileValue();
                    UploadFilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/contact/"), UploadFilePhysicalName);


                    UploadExtension = Path.GetExtension(UploadFilePhysicalName);

                    DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), DirectoryName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName)))
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));

                    UploadPathUploadValue.SaveAs(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName));
                }
            }

            if (UseUploadPathValue || UploadPathUploadValue.HtmlInputHasFile())
            {
                // Check Contact Upload File Size
                double FileSize = new FileInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName)).Length;
                string MaxOfUploadSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_contact").Attributes["value"].Value;

                if (FileSize > int.Parse(MaxOfUploadSizeUpload))
                {
                    // Delete Physical File
                    Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfUploadSizeUpload).ToBitSizeTuning()), "problem");
                }
            }


            string TmpUserBirthday = "2000/01/01";

            if (ContactGuestBirthdayYearOptionListSelectedValue != "0000" && ContactGuestBirthdayMountOptionListSelectedValue != "00" && ContactGuestBirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = ContactGuestBirthdayYearOptionListSelectedValue + "/" + ContactGuestBirthdayMountOptionListSelectedValue + "/" + ContactGuestBirthdayDayOptionListSelectedValue;


            // Change Database Data
            duc.ContactId = ContactIdValue;
            duc.UserId = StaticObject.GetCurrentUserId();
            duc.ContactGuestName = StringClass.RemoveHtmlTags(ContactGuestNameValue);
            duc.ContactGuestRealName = StringClass.RemoveHtmlTags(ContactGuestRealNameValue);
            duc.ContactGuestRealLastName = StringClass.RemoveHtmlTags(ContactGuestRealLastNameValue);
            duc.ContactGuestEmail = string.IsNullOrEmpty(ContactGuestEmailValue) ? "" : StringClass.RemoveHtmlTags(ContactGuestEmailValue.ToLower());
            duc.ContactTitle = StringClass.RemoveIllegalCharacters(ContactTitleValue);
            duc.ContactText = (StaticObject.RoleWriteHtmlCheck()) ? ContactTextValue : StringClass.RemoveHtmlTags(ContactTextValue);
            duc.ContactText = (StaticObject.RoleWriteScriptCheck()) ? duc.ContactText : StringClass.RemoveScriptTags(duc.ContactText);
            duc.ContactDateSend = ContactDateSendValue;
            duc.ContactTimeSend = ContactTimeSendValue;
            duc.ContactIpAddress = Security.GetUserIp();
            duc.ContactFileDirectoryPath = DirectoryName;
            duc.ContactFilePhysicalName = UploadFilePhysicalName;
            duc.ContactType = StringClass.RemoveHtmlTags(ContactTypeOptionListSelectedValue);
            duc.ContactGuestPhoneNumber = StringClass.RemoveHtmlTags(ContactGuestPhoneNumberValue);
            duc.ContactGuestAddress = StringClass.RemoveHtmlTags(ContactGuestAddressValue);
            duc.ContactGuestPostalCode = StringClass.RemoveHtmlTags(ContactGuestPostalCodeValue);
            duc.ContactGuestAbout = StringClass.RemoveHtmlTags(ContactGuestAboutValue);
            duc.ContactGuestBirthday = TmpUserBirthday;
            duc.ContactGuestGender = (GenderUnknownValue) ? "" : GenderMaleValue.BooleanToZeroOne();
            duc.ContactGuestPublicEmail = string.IsNullOrEmpty(ContactGuestPublicEmailValue) ? "" : StringClass.RemoveHtmlTags(ContactGuestPublicEmailValue.ToLower());
            duc.ContactGuestMobileNumber = StringClass.RemoveHtmlTags(ContactGuestMobileNumberValue);
            duc.ContactGuestZipCode = StringClass.RemoveHtmlTags(ContactGuestZipCodeValue);
            duc.ContactGuestCountry = StringClass.RemoveHtmlTags(ContactGuestCountryValue);
            duc.ContactGuestStateOrProvince = StringClass.RemoveHtmlTags(ContactGuestStateOrProvinceValue);
            duc.ContactGuestCity = StringClass.RemoveHtmlTags(ContactGuestCityValue);
            duc.ContactGuestWebsite = StringClass.RemoveHtmlTags(ContactGuestWebsiteValue);

            // Edit Contact
            duc.Edit();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_contact", duc.ContactTitle);
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/contact/action/SuccessMessage.aspx");
        }
    }
}