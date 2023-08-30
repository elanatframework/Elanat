using CodeBehind;
using Microsoft.AspNetCore.Http.Extensions;

namespace Elanat
{
    public partial class SiteEmailModel : CodeBehindModel
    {
        public string EmailLanguage { get; set; }
        public string SendEmailLanguage { get; set; }
        public string YourEmailLanguage { get; set; }
        public string RecipientsEmaiLanguage { get; set; }

        public string CaptchaTextValue { get; set; }
        public string ContentIdValue { get; set; }
        public string YourEmailValue { get; set; }
        public string RecipientsEmailValue { get; set; }

        public string YourEmailAttribute { get; set; }
        public string RecipientsEmailAttribute { get; set; }

        public string YourEmailCssClass { get; set; }
        public string RecipientsEmailCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/email/");
            EmailLanguage = aol.GetAddOnsLanguage("email");
            SendEmailLanguage = aol.GetAddOnsLanguage("send_email");
            YourEmailLanguage = aol.GetAddOnsLanguage("your_email");
            RecipientsEmaiLanguage = aol.GetAddOnsLanguage("recipients_email");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_YourEmail", "");
            InputRequest.Add("txt_RecipientsEmail", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/email/");


            YourEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_YourEmail");
            RecipientsEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_RecipientsEmail");

            YourEmailCssClass = YourEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_YourEmail"));
            RecipientsEmailCssClass = RecipientsEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_RecipientsEmail"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentSiteGlobalLanguage(), true, "", StaticObject.SitePath + "page/email/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SendEmail(HttpContext context)
        {
            string ContentId = ContentIdValue;

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_current_content", "@content_id", ContentId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();

                ResponseForm.WriteLocalAlone(Language.GetLanguage("content_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage()), "problem");

                return;
            }

            dbdr.dr.Read();


            EmailClass ec = new EmailClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DateAndTime dat = new DateAndTime();


            string EmailBodyTemplate = Template.GetSiteTemplate("email/send_content_email");
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp site_url;", context.Request.GetDisplayUrl().Replace(context.Request.GetEncodedPathAndQuery(), ""));
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp site_path;", StaticObject.SitePath);
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp local_date;", dat.GetLocalDate(ccoc.Calendar, DateAndTime.GetDate("yyyy/MM/dd")));
            string ContentText = (string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? dbdr.dr["content_text"].ToString() : Language.GetHandheldLanguage("content_protection_by_password", StaticObject.GetCurrentSiteGlobalLanguage());
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp email_content;", ContentText);

            db.Close();

            string EmailBody = EmailBodyTemplate;
            string EmailTitle = Language.GetLanguage("email_content", StaticObject.GetCurrentSiteGlobalLanguage());

            string[] RecipientsEmail = RecipientsEmailValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string email in RecipientsEmail)
            {
                if (!email.IsEmail())
                    continue;

                ec.SendMail(email.ToLower(), EmailTitle + " " + YourEmailValue, EmailBodyTemplate, true, true);
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("send_email_content", YourEmailValue);
        }

        public void CaptchaIncorrectErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("the_captcha_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/email/"), "problem");
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "page/email/action/SuccessMessage.aspx?use_retrieved=true", true);
        }
    }
}