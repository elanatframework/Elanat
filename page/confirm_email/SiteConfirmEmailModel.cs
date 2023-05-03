using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace elanat
{
    public class SiteConfirmEmailModel
    {
        public string ConfirmEmailLanguage { get; set; }
        public string GetEmailConfirmLanguage { get; set; }
        public string UserNameOrUserEmailLanguage { get; set; }

        public string UserNameOrUserEmailValue { get; set; }
        public string CaptchaTextValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/confirm_email/");
            ConfirmEmailLanguage = aol.GetAddOnsLanguage("confirm_email");
            UserNameOrUserEmailLanguage = aol.GetAddOnsLanguage("user_name_or_user_email");
            GetEmailConfirmLanguage = aol.GetAddOnsLanguage("get_email_confirm");
        }

        public void GetEmailConfirm()
        {
            HttpContext.Current.Response.Redirect(StaticObject.SitePath + "action/email_confirm/?user_name_or_user_email=" + UserNameOrUserEmailValue + "&captcha=" + CaptchaTextValue);
        }
    }
}