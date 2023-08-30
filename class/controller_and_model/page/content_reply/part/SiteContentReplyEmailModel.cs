using CodeBehind;

namespace Elanat
{
    public partial class SiteContentReplyEmailModel : CodeBehindModel
    {
        public string EmailLanguage { get; set; }

        public string EmailValue { get; set; }

        public string EmailCssClass { get; set; }

        public string EmailAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            EmailLanguage = Language.GetAddOnsLanguage("email", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/content_reply/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_Email", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/content_reply/");


            EmailAttribute += vc.ImportantInputAttribute.GetValue("txt_Email");

            EmailCssClass = EmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_Email"));
        }
    }
}