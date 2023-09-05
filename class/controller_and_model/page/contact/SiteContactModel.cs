using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteContactModel : CodeBehindModel
    {
        public string ContactLanguage { get; set; }
        public string SendContactLanguage { get; set; }

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

        public string ResponseCodeValue { get; set; }

        public string OtherWaysForContactValue { get; set; }

        public string CaptchaTextValue { get; set; }

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
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
            ContactLanguage = aol.GetAddOnsLanguage("contact");
            SendContactLanguage = aol.GetAddOnsLanguage("send_contact");


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
            XmlDocument ContactOptionDocument = new XmlDocument();
            ContactOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/contact_option/option/contact_option.xml"));

            XmlNode node = ContactOptionDocument.SelectSingleNode("contact_option_root");

            if (node["about"].Attributes["active"].Value == "true")
                AboutPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactAbout.aspx?about_value=" + AboutValue + "&about_css_class=" + AboutCssClass + "&about_attribute=" + AboutAttribute);

            if (node["address"].Attributes["active"].Value == "true")
                AddressPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactAddress.aspx?address_value=" + AddressValue + "&address_css_class=" + AddressCssClass + "&address_attribute=" + AddressAttribute);

            if (node["file"].Attributes["active"].Value == "true")
                UploadPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactUploadPath.aspx?upload_path_text_value=" + UploadPathTextValue);

            if (node["birthday"].Attributes["active"].Value == "true")
                BirthdayPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactBirthday.aspx?birthday_year_value=" + BirthdayYearOptionListSelectedValue + "&birthday_mount_value=" + BirthdayMountOptionListSelectedValue + "&birthday_day_value=" + BirthdayDayOptionListSelectedValue + "&birthday_year_css_class=" + BirthdayYearCssClass + "&birthday_mount_css_class=" + BirthdayMountCssClass + "&birthday_day_css_class=" + BirthdayDayCssClass + "&birthday_year_attribute=" + BirthdayYearAttribute + "&birthday_mount_attribute=" + BirthdayMountAttribute + "&birthday_day_attribute=" + BirthdayDayAttribute);

            if (node["email"].Attributes["active"].Value == "true")
                EmailPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactEmail.aspx?email_value=" + EmailValue + "&email_css_class=" + EmailCssClass + "&email_attribute=" + EmailAttribute);

            if (node["type"].Attributes["active"].Value == "true")
                TypePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactType.aspx?type_value=" + TypeOptionListSelectedValue + "&email_css_class=" + TypeCssClass);

            if (node["gender"].Attributes["active"].Value == "true")
                GenderPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactGender.aspx?gender_checked=" + ((GenderFemaleValue)? "female" : (GenderMaleValue)? "male" : "unknown") + "&gender_unknown_attribute=" + GenderUnknownAttribute + "&gender_male_attribute=" + GenderMaleAttribute + "&gender_female_attribute=" + GenderFemaleAttribute);

            if (node["phone_number"].Attributes["active"].Value == "true")
                PhoneNumberPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactPhoneNumber.aspx?phone_number_value=" + PhoneNumberValue + "&phone_number_css_class=" + PhoneNumberCssClass + "&phone_number_attribute=" + PhoneNumberAttribute);

            if (node["mobile_number"].Attributes["active"].Value == "true")
                MobileNumberPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactMobileNumber.aspx?mobile_number_value=" + MobileNumberValue + "&mobile_number_css_class=" + MobileNumberCssClass + "&mobile_number_attribute=" + MobileNumberAttribute);

            if (node["postal_code"].Attributes["active"].Value == "true")
                PostalCodePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactPostalCode.aspx?postal_code_value=" + PostalCodeValue + "&postal_code_css_class=" + PostalCodeCssClass + "&postal_code_attribute=" + PostalCodeAttribute);

            if (node["title"].Attributes["active"].Value == "true")
                TitlePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactTitle.aspx?title_value=" + TitleValue + "&title_css_class=" + TitleCssClass);

            if (node["text"].Attributes["active"].Value == "true")
                TextPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactText.aspx?text_value=" + TextValue + "&text_css_class=" + TextCssClass);

            if (node["name"].Attributes["active"].Value == "true")
                RealNamePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactRealName.aspx?real_name_value=" + RealNameValue + "&real_name_css_class=" + RealNameCssClass + "&real_name_attribute=" + RealNameAttribute);

            if (node["last_name"].Attributes["active"].Value == "true")
                RealLastNamePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactRealLastName.aspx?real_last_name_value=" + RealLastNameValue + "&real_last_name_css_class=" + RealLastNameCssClass + "&real_last_name_attribute=" + RealLastNameAttribute);

            if (node["website"].Attributes["active"].Value == "true")
                WebsitePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactWebsite.aspx?website_value=" + WebsiteValue + "&website_css_class=" + WebsiteCssClass + "&website_attribute=" + WebsiteAttribute);

            if (node["public_email"].Attributes["active"].Value == "true")
                PublicEmailPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactPublicEmail.aspx?public_email_value=" + PublicEmailValue + "&public_email_css_class=" + PublicEmailCssClass + "&public_email_attribute=" + PublicEmailAttribute);

            if (node["country"].Attributes["active"].Value == "true")
                CountryPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactCountry.aspx?country_value=" + CountryValue + "&country_css_class=" + CountryCssClass + "&country_attribute=" + CountryAttribute);

            if (node["state_or_province"].Attributes["active"].Value == "true")
                StateOrProvincePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactStateOrProvince.aspx?state_or_province_value=" + StateOrProvinceValue + "&state_or_province_css_class=" + StateOrProvinceCssClass + "&state_or_province_attribute=" + StateOrProvinceAttribute);

            if (node["city"].Attributes["active"].Value == "true")
                CityPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactCity.aspx?city_value=" + CityValue + "&city_css_class=" + CityCssClass + "&city_attribute=" + CityAttribute);

            if (node["zip_code"].Attributes["active"].Value == "true")
                ZipCodePartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/contact/part/SiteContactZipCode.aspx?zip_code_value=" + ZipCodeValue + "&zip_code_css_class=" + ZipCodeCssClass + "&zip_code_attribute=" + ZipCodeAttribute);


            // Set Other Ways For Contact
            string SiteGlobalName = StaticObject.GetCurrentSiteSiteGlobalName();

            AttributeReader ar = new AttributeReader();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/catalog.xml"));

            XmlNode ContactNode = doc.SelectSingleNode("site_catalog_root/site_page_list/contact");


            string Contact = PageLoader.LoadPage(ContactNode.Attributes["load_type"].Value, StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/static_page/contact/index.html", false);

            if (ContactNode.Attributes["use_language"].Value == "true")
                Contact = ar.ReadLanguage(Contact, StaticObject.GetCurrentSiteGlobalLanguage());

            if (ContactNode.Attributes["use_elanat"].Value == "true")
                Contact = ar.ReadElanat(Contact, StaticObject.GetCurrentSiteGlobalLanguage());

            if (ContactNode.Attributes["use_module"].Value == "true")
                Contact = ar.ReadModule(Contact, StaticObject.GetCurrentSiteGlobalLanguage());

            if (ContactNode.Attributes["use_plugin"].Value == "true")
                Contact = ar.ReadPlugin(Contact, StaticObject.GetCurrentSiteGlobalLanguage());

            if (ContactNode.Attributes["use_replace_part"].Value == "true")
                Contact = ar.ReadReplacePart(Contact, StaticObject.GetCurrentSiteGlobalLanguage());

            if (ContactNode.Attributes["use_fetch"].Value == "true")
                Contact = ar.ReadFetch(Contact, StaticObject.GetCurrentSiteGlobalLanguage());

            if (ContactNode.Attributes["use_item"].Value == "true")
                Contact = ar.ReadItem(Contact, StaticObject.GetCurrentSiteGlobalLanguage());

            OtherWaysForContactValue = Template.GetSiteTemplate("static_page/contact").Replace("$_asp contact;", Contact);
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/contact/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SendContact()
        {
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
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_to_upload_file", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "problem");

                    return;
                }

                if (string.IsNullOrEmpty(UploadPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_upload_path_field_because_this_is_necessary", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "problem");

                    return;
                }

                // Check Authorized Extension
                FileExtension = Path.GetExtension(UploadPathTextValue);

                if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "problem");

                    return;
                }

                UploadFilePhysicalName = Path.GetFileName(UploadPathTextValue);

                evc.FilePhysicalName = Path.GetFileName(UploadFilePhysicalName);
                DirectoryName = evc.GetContactUploadDirectoryValue();
                UploadFilePhysicalName = evc.GetContactUploadFileValue();
                UploadFilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/"), UploadFilePhysicalName);


                HttpClient webClient = new HttpClient();

                UploadExtension = Path.GetExtension(UploadFilePhysicalName);


                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), DirectoryName);

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(UploadPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName));
            }
            else
            {
                if (UploadPathUploadValue.HtmlInputHasFile())
                {
                    if (!StaticObject.RoleUploadFileCheck())
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("role_can_not_access_to_upload_file", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "problem");

                        return;
                    }

                    // Check Authorized Extension
                    FileExtension = Path.GetExtension(UploadPathUploadValue.FileName);

                    if (!Security.ExtensionIsAuthorizedForUpload(FileExtension))
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("your_file_type_is_not_allowed", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "warning");

                        return;
                    }

                    UploadFilePhysicalName = UploadPathUploadValue.FileName;

                    evc.FilePhysicalName = Path.GetFileName(UploadFilePhysicalName);
                    DirectoryName = evc.GetContactUploadDirectoryValue();
                    UploadFilePhysicalName = evc.GetContactUploadFileValue();
                    UploadFilePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/"), UploadFilePhysicalName);


                    UploadExtension = Path.GetExtension(UploadFilePhysicalName);

                    DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), DirectoryName);

                    if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName)))
                        Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));

                    UploadPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName));
                }
            }

            if (UseUploadPathValue || UploadPathUploadValue.HtmlInputHasFile())
            {
                // Check Contact Upload File Size
                double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName)).Length;
                string MaxOfUploadSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_contact").Attributes["value"].Value;

                if (FileSize > int.Parse(MaxOfUploadSizeUpload))
                {
                    // Delete Physical File
                    Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                    ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfUploadSizeUpload).ToBitSizeTuning()), "problem");

                    return;
                }
            }


            string TmpUserBirthday = "2000/01/01";

            if (BirthdayYearOptionListSelectedValue != "0000" && BirthdayMountOptionListSelectedValue != "00" && BirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = BirthdayYearOptionListSelectedValue + "/" + BirthdayMountOptionListSelectedValue + "/" + BirthdayDayOptionListSelectedValue;

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.Contact duc = new DataUse.Contact();

            StringClass sc = new StringClass();

            // Add Data To Database
            duc.UserId = StaticObject.GetCurrentUserId();
            duc.ContactGuestName = ccoc.UserName;
            duc.ContactGuestRealName = StringClass.RemoveHtmlTags(RealNameValue);
            duc.ContactGuestRealLastName = StringClass.RemoveHtmlTags(RealLastNameValue);
            duc.ContactGuestEmail = string.IsNullOrEmpty(EmailValue) ? "" : StringClass.RemoveHtmlTags(EmailValue.ToLower()); 
            duc.ContactTitle = StringClass.RemoveIllegalCharacters(TitleValue);
            duc.ContactText = StringClass.RemoveIllegalCharacters(TextValue);
            duc.ContactDateSend = DateAndTime.GetDate("yyyy/MM/dd");
            duc.ContactTimeSend = DateAndTime.GetTime("HH:mm:ss");
            duc.ContactIpAddress = Security.GetUserIp();
            duc.ContactFileDirectoryPath = DirectoryName;
            duc.ContactFilePhysicalName = UploadFilePhysicalName;
            duc.ContactType = StringClass.RemoveHtmlTags(TypeOptionListSelectedValue);
            duc.ContactGuestPhoneNumber = StringClass.RemoveHtmlTags(PhoneNumberValue);
            duc.ContactGuestAddress = StringClass.RemoveIllegalCharacters(AddressValue);
            duc.ContactGuestPostalCode = StringClass.RemoveHtmlTags(PostalCodeValue);
            duc.ContactGuestAbout = StringClass.RemoveIllegalCharacters(AboutValue);
            duc.ContactGuestBirthday = TmpUserBirthday;
            duc.ContactGuestGender = (GenderUnknownValue) ? "" : GenderMaleValue.BooleanToZeroOne();
            duc.ContactGuestPublicEmail = string.IsNullOrEmpty(PublicEmailValue) ? "" : StringClass.RemoveHtmlTags(PublicEmailValue.ToLower());
            duc.ContactGuestMobileNumber = StringClass.RemoveHtmlTags(MobileNumberValue);
            duc.ContactGuestZipCode = StringClass.RemoveHtmlTags(ZipCodeValue);
            duc.ContactGuestCountry = StringClass.RemoveHtmlTags(CountryValue);
            duc.ContactGuestStateOrProvince = StringClass.RemoveHtmlTags(StateOrProvinceValue);
            duc.ContactGuestCity = StringClass.RemoveHtmlTags(CityValue);
            duc.ContactGuestWebsite = StringClass.RemoveHtmlTags(WebsiteValue);
            duc.ContactResponseCode = "00000000000000000000000000000000";

            // Add Contact
            duc.Add();


            // Add Contact Response Code
            int TmpContactId = int.Parse(duc.ContactId);
            string ResponseCode = TmpContactId.ToString("0000000000000000") + sc.GetCleanRandomText(16);

            duc.AddContactResponseCode(duc.ContactId, ResponseCode);

            ResponseCodeValue = ResponseCode;


            if (UseUploadPathValue || UploadPathUploadValue.HtmlInputHasFile())
            {
                if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/" + DirectoryName)))
                    Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/" + DirectoryName));

                File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + UploadFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/" + DirectoryName + "/" + UploadFilePhysicalName));

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


                // Create Thumbnail Image
                if (FileAndDirectory.IsImageExtension(FileExtension))
                    if (ElanatConfig.GetNode("file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value == "true")
                    {
                        if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/" + DirectoryName + "/thumb/")))
                            Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/" + DirectoryName + "/thumb/"));

                        FileAndDirectory.CreateThumbnailImage(StaticObject.SitePath + "upload/contact/" + DirectoryName + "/" + UploadFilePhysicalName, StaticObject.SitePath + "upload/contact/" + DirectoryName + "/thumb/" + UploadFilePhysicalName);
                    }
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("send_contact", duc.ContactTitle);
        }

        public void CaptchaIncorrectErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("the_captcha_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/"), "problem");
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "page/contact/action/SuccessMessage.aspx?response_code=" + ResponseCodeValue);
        }
    }
}