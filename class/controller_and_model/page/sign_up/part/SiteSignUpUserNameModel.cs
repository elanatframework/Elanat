using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpUserNameModel : CodeBehindModel
    {
        public string UserNameLanguage { get; set; }

        public string UserNameValue { get; set; }

        public string UserNameCssClass { get; set; }

        public string UserNameAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            UserNameLanguage = Language.GetAddOnsLanguage("user_name", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_UserName", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            UserNameAttribute += vc.ImportantInputAttribute.GetValue("txt_UserName");

            UserNameCssClass = UserNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_UserName"));
        }
    }
}