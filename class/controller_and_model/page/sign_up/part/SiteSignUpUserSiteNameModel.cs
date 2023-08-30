using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpUserSiteNameModel : CodeBehindModel
    {
        public string UserSiteNameLanguage { get; set; }

        public string UserSiteNameValue { get; set; }

        public string UserSiteNameCssClass { get; set; }

        public string UserSiteNameAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            UserSiteNameLanguage = Language.GetAddOnsLanguage("user_site_name", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_UserSiteName", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            UserSiteNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserSiteName");

            UserSiteNameCssClass = UserSiteNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserSiteName"));
        }
    }
}