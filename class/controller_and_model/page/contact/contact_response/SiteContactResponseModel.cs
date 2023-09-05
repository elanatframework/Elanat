using CodeBehind;

namespace Elanat
{
    public partial class SiteContactResponseModel : CodeBehindModel
    {
        public string ContactResponseLanguage { get; set; }
        public string ContactResponseCodeLanguage { get; set; }
        public string GetContactResponseLanguage { get; set; }
        public string RecipientsEmaiLanguage { get; set; }

        public string ContactResponseCodeValue { get; set; }
        public string CaptchaTextValue { get; set; }

        public string ContactResponseCodeCssClass { get; set; }

        public string ContactResponseCodeAttribute { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/contact_response/");
            ContactResponseLanguage = aol.GetAddOnsLanguage("contact_response");
            ContactResponseCodeLanguage = aol.GetAddOnsLanguage("contact_response_code");
            GetContactResponseLanguage = aol.GetAddOnsLanguage("get_contact_response");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_ContactResponseCode", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/contact_response/");


            ContactResponseCodeAttribute += vc.ImportantInputAttribute.GetValue("txt_ContactResponseCode");

            ContactResponseCodeCssClass = ContactResponseCodeCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_ContactResponseCode"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/contact/contact_response/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void GetContactResponse()
        {
            string ContactId = ContactResponseCodeValue.Substring(0, 16);
            string ContactResponseCode = ContactResponseCodeValue;

            if (!ContactId.IsNumber())
            {
                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("contact_response_code_is_corrupt", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/contact_response/"), "problem");

                return;
            }

            ContactId = int.Parse(ContactId).ToString();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_contact_response_text", new List<string>() { "@contact_id", "@contact_response_code" }, new List<string>() { ContactId, ContactResponseCode });

            if (dbdr.dr != null && dbdr.dr.HasRows)
                dbdr.dr.Read();
            else
            {
                db.Close();

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("contact_response_code_is_corrupt", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/contact_response/"), "problem");

                return;
            }

            if (!string.IsNullOrEmpty(dbdr.dr["contact_response_text"].ToString()))
            {
                new HttpContextAccessor().HttpContext.Session.SetString("el_contact_response_text", dbdr.dr["contact_response_text"].ToString());

                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());
                rf.AddPageLoad(StaticObject.SitePath + "page/contact/contact_response/action/GetResponse.aspx", "div_ResponseTextBox");
                rf.RedirectToResponseFormPage();
            }
            else
            {
                db.Close();

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("no_contact_response_has_been_received_yet", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/contact_response/"), "problem");

                return;
            }

            db.Close();
        }

        public void CaptchaIncorrectErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("the_captcha_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/contact_response/"), "problem");
        }
    }
}