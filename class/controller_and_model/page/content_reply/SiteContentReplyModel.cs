using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteContentReplyModel : CodeBehindModel
    {
        public string ContentReplyLanguage { get; set; }

        public string ContentIdValue { get; set; }

        public string ContentReplyBoxPartValue { get; set; }

        public string CaptchaTextValue { get; set; }

        public string TypeOptionListSelectedValue { get; set; } = "";
        public string BirthdayYearOptionListSelectedValue { get; set; }
        public string BirthdayMountOptionListSelectedValue { get; set; }
        public string BirthdayDayOptionListSelectedValue { get; set; }

        public bool GenderMaleValue { get; set; } = false;
        public bool GenderFemaleValue { get; set; } = false;
        public bool GenderUnknownValue { get; set; } = false;

        public string AboutValue { get; set; } = "";
        public string AddressValue { get; set; } = "";
        public string CityValue { get; set; } = "";
        public string CountryValue { get; set; } = "";
        public string EmailValue { get; set; } = "";
        public string MobileNumberValue { get; set; } = "";
        public string PhoneNumberValue { get; set; } = "";
        public string PostalCodeValue { get; set; } = "";
        public string PublicEmailValue { get; set; } = "";
        public string TextValue { get; set; } = "";
        public string RealNameValue { get; set; } = "";
        public string RealLastNameValue { get; set; } = "";
        public string StateOrProvinceValue { get; set; } = "";
        public string WebsiteValue { get; set; } = "";
        public string ZipCodeValue { get; set; } = "";

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            ContentReplyLanguage = Language.GetAddOnsLanguage("content_reply", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/content_reply/");


            ContentReplyBoxPartValue = PageLoader.LoadWithServer(StaticObject.SitePath + "page/content_reply/part/SiteContentReplyContentReplyBox.aspx");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("hdn_ContentId", ContentIdValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/content_reply/");
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/content_reply/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SendContentReply()
        {
            string TmpUserBirthday = "2000/01/01";

            if (BirthdayYearOptionListSelectedValue != "0000" && BirthdayMountOptionListSelectedValue != "00" && BirthdayDayOptionListSelectedValue != "00")
                TmpUserBirthday = BirthdayYearOptionListSelectedValue + "/" + BirthdayMountOptionListSelectedValue + "/" + BirthdayDayOptionListSelectedValue;

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.ContentReply ducr = new DataUse.ContentReply();

            StringClass sc = new StringClass();
           
            // Add Data To Database
            ducr.ContentId = ContentIdValue;
            ducr.UserId = StaticObject.GetCurrentUserId();
            ducr.ContentReplyGuestName = ccoc.UserName;
            ducr.ContentReplyGuestRealName = StringClass.RemoveHtmlTags(RealNameValue);
            ducr.ContentReplyGuestRealLastName = StringClass.RemoveHtmlTags(RealLastNameValue);
            ducr.ContentReplyGuestEmail = string.IsNullOrEmpty(EmailValue) ? "" : StringClass.RemoveHtmlTags(EmailValue.ToLower()); 
            ducr.ContentReplyText = StringClass.RemoveIllegalCharacters(TextValue);
            ducr.ContentReplyDateSend = DateAndTime.GetDate("yyyy/MM/dd");
            ducr.ContentReplyTimeSend = DateAndTime.GetTime("HH:mm:ss");
            ducr.ContentReplyActive = "1";
            ducr.ContentReplyIpAddress = Security.GetUserIp();
            ducr.ContentReplyType = StringClass.RemoveHtmlTags(TypeOptionListSelectedValue);
            ducr.ContentReplyGuestPhoneNumber = StringClass.RemoveHtmlTags(PhoneNumberValue);
            ducr.ContentReplyGuestAddress = StringClass.RemoveIllegalCharacters(AddressValue);
            ducr.ContentReplyGuestPostalCode = StringClass.RemoveHtmlTags(PostalCodeValue);
            ducr.ContentReplyGuestAbout = StringClass.RemoveIllegalCharacters(AboutValue);
            ducr.ContentReplyGuestBirthday = TmpUserBirthday;
            ducr.ContentReplyGuestGender = (GenderUnknownValue) ? "" : GenderMaleValue.BooleanToZeroOne();
            ducr.ContentReplyGuestPublicEmail = string.IsNullOrEmpty(PublicEmailValue) ? "" : StringClass.RemoveHtmlTags(PublicEmailValue.ToLower());
            ducr.ContentReplyGuestMobileNumber = StringClass.RemoveHtmlTags(MobileNumberValue);
            ducr.ContentReplyGuestZipCode = StringClass.RemoveHtmlTags(ZipCodeValue);
            ducr.ContentReplyGuestCountry = StringClass.RemoveHtmlTags(CountryValue);
            ducr.ContentReplyGuestStateOrProvince = StringClass.RemoveHtmlTags(StateOrProvinceValue);
            ducr.ContentReplyGuestCity = StringClass.RemoveHtmlTags(CityValue);
            ducr.ContentReplyGuestWebsite = StringClass.RemoveHtmlTags(WebsiteValue);

            // Add ContentReply
            ducr.Add();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("send_content_reply", ducr.ContentReplyText);
        }

        public void CaptchaIncorrectErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("the_captcha_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/content_reply/"), "problem");
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "page/content_reply/action/SuccessMessage.aspx?use_retrieved=true");
        }
    }
}