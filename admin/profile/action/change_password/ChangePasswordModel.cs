using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace elanat
{
    public class ActionChangePasswordModel
    {
        public string PasswordLanguage { get; set; }
        public string ChangePasswordLanguage { get; set; }
        public string UserPasswordLanguage { get; set; }
        public string RepeatPasswordLanguage { get; set; }

        public string UserPasswordValue { get; set; }

        public string UserPasswordAttribute { get; set; }
        public string RepeatPasswordAttribute { get; set; }

        public string UserPasswordCssClass { get; set; }
        public string RepeatPasswordCssClass { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/profile/");
            PasswordLanguage = aol.GetAddOnsLanguage("password");
            ChangePasswordLanguage = aol.GetAddOnsLanguage("change_password");
            UserPasswordLanguage = aol.GetAddOnsLanguage("user_password");
            RepeatPasswordLanguage = aol.GetAddOnsLanguage("repeat_password");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_UserPassword", "");
            InputRequest.Add("txt_RepeatPassword", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/profile/", "change_password");


            UserPasswordAttribute += vc.ImportantInputAttribute["txt_UserPassword"];
            RepeatPasswordAttribute += vc.ImportantInputAttribute["txt_RepeatPassword"];

            UserPasswordCssClass = UserPasswordCssClass.AddHtmlClass(vc.ImportantInputClass["txt_UserPassword"]);
            RepeatPasswordCssClass = RepeatPasswordCssClass.AddHtmlClass(vc.ImportantInputClass["txt_RepeatPassword"]);
        }
        
        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "change_password", StaticObject.AdminPath + "/profile/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //UserPasswordCssClass = UserPasswordCssClass.AddHtmlClass(vc.WarningFieldClass["txt_UserPassword"]);
                //RepeatPasswordCssClass = UserPasswordCssClass.AddHtmlClass(vc.WarningFieldClass["txt_RepeatPassword"]);
            }
        }

        public void ChangePassword()
        {
            // Get Current Client Object
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.User duu = new DataUse.User();

            Security sc = new Security();
            string Password = sc.GetHash(UserPasswordValue);

            duu.ChangeUserPassword(ccoc.UserId, Password);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("change_password", ccoc.UserId);
        }

        public void PasswordEqualityErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("password_and_repeat_password_must_be_alike", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/profile/"), "problem");
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/profile/action/change_password/action/SuccessMessage.aspx", true);
        }
    }
}