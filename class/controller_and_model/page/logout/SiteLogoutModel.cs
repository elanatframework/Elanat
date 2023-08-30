using CodeBehind;

namespace Elanat
{
    public partial class SiteLogoutModel : CodeBehindModel
    { 
        public string LogoutLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue()
        {
			// Set Language
			LogoutLanguage = Language.GetAddOnsLanguage("logout", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/logout/");
			
			
            Security.ExitUser();

            String LogoutTemplate = Template.GetSiteTemplate("page/logout");

            ContentValue = LogoutTemplate;
        }
    }
}