using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteSignUpEmailModel
    {
        public string EmailLanguage { get; set; }
        public string RepeatEmailLanguage { get; set; }

        public string EmailValue { get; set; }
        public string RepeatEmailValue { get; set; }

        public string EmailCssClass { get; set; }
        public string RepeatEmailCssClass { get; set; }

        public string EmailAttribute { get; set; }
        public string RepeatEmailAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
            EmailLanguage = aol.GetAddOnsLanguage("email");
            RepeatEmailLanguage = aol.GetAddOnsLanguage("repeat_email");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_Email", "");
            InputRequest.Add("txt_RepeatEmail", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            EmailAttribute += vc.ImportantInputAttribute["txt_Email"];
            EmailAttribute += vc.ImportantInputAttribute["txt_RepeatEmail"];

            EmailCssClass = EmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_Email"]);
            RepeatEmailCssClass = RepeatEmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_RepeatEmail"]);
        }
    }
}