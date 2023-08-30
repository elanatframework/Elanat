using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpWebsiteModel : CodeBehindModel
    {
        public string WebsiteLanguage { get; set; }

        public string WebsiteValue { get; set; }

        public string WebsiteCssClass { get; set; }

        public string WebsiteAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            WebsiteLanguage = Language.GetAddOnsLanguage("website", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_Website", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            WebsiteAttribute += vc.ImportantInputAttribute.GetValue("txt_Website");

            WebsiteCssClass = WebsiteCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_Website"));
        }
    }
}