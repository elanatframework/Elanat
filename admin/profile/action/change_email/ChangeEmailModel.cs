using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace elanat
{
    public class ActionChangeEmailModel
    {
        public string EmailLanguage { get; set; }
        public string ChangeEmailLanguage { get; set; }
        public string UserEmailLanguage { get; set; }
        public string RepeatEmailLanguage { get; set; }

        public string UserCurrentEmail { get; set; }

        public string UserEmailValue { get; set; }
        public string RepeatEmaiValue { get; set; }

        public string UserEmailAttribute { get; set; }
        public string RepeatEmailtAttribute { get; set; }

        public string UserEmailCssClass { get; set; }
        public string RepeatEmailCssClass { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/profile/");
            EmailLanguage = aol.GetAddOnsLanguage("email");
			ChangeEmailLanguage = aol.GetAddOnsLanguage("change_email");
			UserEmailLanguage = aol.GetAddOnsLanguage("user_email");
			RepeatEmailLanguage = aol.GetAddOnsLanguage("repeat_email");
			
			
            // Set User Info
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.User duu = new DataUse.User();
            UserCurrentEmail = duu.GetUserEmail(ccoc.UserId);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_UserEmail", "");
            InputRequest.Add("txt_RepeatEmail", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/profile/", "change_email");


            UserEmailAttribute += vc.ImportantInputAttribute["txt_UserEmail"];
            RepeatEmailtAttribute += vc.ImportantInputAttribute["txt_RepeatEmail"];

            UserEmailCssClass = UserEmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_UserEmail"]);
            RepeatEmailCssClass = RepeatEmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_RepeatEmail"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "change_email", StaticObject.AdminPath + "/profile/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //UserEmailCssClass = UserEmailCssClass.AddHtmlClass(vc.WarningFieldClass["txt_UserEmail"]);
                //RepeatEmailCssClass = RepeatEmailCssClass.AddHtmlClass(vc.WarningFieldClass["txt_RepeatEmail"]);
            }
        }

        public void ChangeEmail()
        {
            // Get Current Client Object
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.User duu = new DataUse.User();

            string Email = UserEmailValue;

            duu.ChangeUserEmail(ccoc.UserId, Email);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("change_email", ccoc.UserId);
        }

        public void EmailEqualityErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("email_and_repeat_email_must_be_alike", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/profile/"), "problem");
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/profile/action/change_email/action/SuccessMessage.aspx", true);
        }
    }
}