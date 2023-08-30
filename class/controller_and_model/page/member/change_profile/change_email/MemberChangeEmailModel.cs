using CodeBehind;

namespace Elanat
{
    public partial class MemberChangeEmailModel : CodeBehindModel
    {
        public string MemberLanguage { get; set; }
        public string ChangeEmailLanguage { get; set; }
        public string UserEmailLanguage { get; set; }
        public string RepeatEmailLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;

        public string UserCurrentEmail { get; set; }

        public string UserEmailValue { get; set; }
        public string RepeatEmaiValue { get; set; }

        public string UserEmailAttribute { get; set; }
        public string RepeatEmailtAttribute { get; set; }

        public string UserEmailCssClass { get; set; }
        public string RepeatEmailCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_profile/change_email/");
            MemberLanguage = aol.GetAddOnsLanguage("member");
			ChangeEmailLanguage = aol.GetAddOnsLanguage("change_email");
			UserEmailLanguage = aol.GetAddOnsLanguage("user_email");
			RepeatEmailLanguage = aol.GetAddOnsLanguage("repeat_email");


            // Set User Info
            if (IsFirstStart)
            {
                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                DataUse.User duu = new DataUse.User();
                UserCurrentEmail = duu.GetUserEmail(ccoc.UserId);
            }
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_UserEmail", "");
            InputRequest.Add("txt_RepeatEmail", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/member/change_profile/change_email/");


            UserEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_UserEmail");
            RepeatEmailtAttribute += vc.ImportantInputAttribute.GetValue("txt_RepeatEmail");

            UserEmailCssClass = UserEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserEmail"));
            RepeatEmailCssClass = RepeatEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RepeatEmail"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/member/change_profile/change_email/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
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
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("email_and_repeat_email_must_be_alike", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/change_profile/change_email/"), "problem");
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "page/member/change_profile/change_email/action/SuccessMessage.aspx?use_retrieved=true", true);
        }
    }
}