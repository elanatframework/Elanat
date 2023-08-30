using CodeBehind;

namespace Elanat
{
    public partial class SiteLoginModel : CodeBehindModel
    {
        public string LoginLanguage { get; set; }
        public string LoginToSiteLanguage { get; set; }
        public string UserNameOrUserEmailLanguage { get; set; }
        public string PasswordLanguage { get; set; }
        public string SecretKeyLanguage { get; set; }
        public string LanguageLanguage { get; set; }
        public string ForgetPasswordLanguage { get; set; }
        public string ConfirmEmailLanguage { get; set; }
        public string SignUpLanguage { get; set; }

        public string UserNameOrUserEmailValue { get; set; }
        public string PasswordValue { get; set; }
        public string CaptchaTextValue { get; set; }
        public string LanguageOptionListValue { get; set; }
        public string LanguageOptionSelectedListValue { get; set; }
        public string SecretKeyValue { get; set; }
        public string ReturnUrlValue { get; set; }

        public string SecretKeyCssClass { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/");
            LoginLanguage = aol.GetAddOnsLanguage("login");
            LoginToSiteLanguage = aol.GetAddOnsLanguage("login_to_site");
            LanguageLanguage = aol.GetAddOnsLanguage("language");
            PasswordLanguage = aol.GetAddOnsLanguage("password");
            UserNameOrUserEmailLanguage = aol.GetAddOnsLanguage("user_name_or_user_email");
            SignUpLanguage = aol.GetAddOnsLanguage("sign_up");
            ForgetPasswordLanguage = aol.GetAddOnsLanguage("forget_password");
            ConfirmEmailLanguage = aol.GetAddOnsLanguage("confirm_email");


            // Check Secret Key
            if (ElanatConfig.GetNode("security/use_secret_key_for_login").Attributes["active"].Value == "true")
                SecretKeyLanguage = aol.GetAddOnsLanguage("secret_key");
            else
                SecretKeyCssClass = SecretKeyCssClass.AddHtmlClass(" el_hidden");


            string TmpCurrentSiteLanguageId = string.IsNullOrEmpty(LanguageOptionSelectedListValue) ? StaticObject.GetCurrentSiteLanguageId() : LanguageOptionSelectedListValue;

            // Set Language Item
            ListClass.LanguageList lcl = new ListClass.LanguageList();
            lcl.FillActiveLanguageListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            LanguageOptionListValue += lcl.ActiveLanguageListItem.HtmlInputToOptionTag(TmpCurrentSiteLanguageId);
        }

        public void Login(string UserId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Set Current Client Object
            ccoc.FillUserClientSetting(UserId, false);


            // Increase Visit Statistics
            if (StaticObject.RoleSubmitVisitCheck())
            {
                DataUse.VisitStatistics duvs = new DataUse.VisitStatistics();
                duvs.IncreaseVisit();
            }


            DataUse.User duu = new DataUse.User();
            duu.SetUserLastLogin(UserId);

            StaticObject.OnlineUser++;


            // Set Secure Value
            Security sc = new Security();
            sc.SetUserLogin();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("login", UserId);
        }

        public string CaptchaIncorrectErrorView()
        {
            return GlobalClass.Alert(Language.GetAddOnsLanguage("the_captcha_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/"), StaticObject.GetCurrentSiteGlobalLanguage(), "problem");
        }

        public void SuccessView()
        {
            if (!string.IsNullOrEmpty(ReturnUrlValue))
                ReturnUrlValue = "&el_return_url=" + ReturnUrlValue;

            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "page/login/action/SuccessMessage.aspx?use_retrieved=true" + ReturnUrlValue, true, true);
        }
    }
}