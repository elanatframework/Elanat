using CodeBehind;

namespace Elanat
{
    public partial class SiteContactPublicEmailModel : CodeBehindModel
    {
        public string PublicEmailLanguage { get; set; }

        public string PublicEmailValue { get; set; }

        public string PublicEmailCssClass { get; set; }

        public string PublicEmailAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            PublicEmailLanguage = Language.GetAddOnsLanguage("public_email", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_PublicEmail", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            PublicEmailAttribute += vc.ImportantInputAttribute.GetValue("txt_PublicEmail");

            PublicEmailCssClass = PublicEmailCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_PublicEmail"));
        }
    }
}