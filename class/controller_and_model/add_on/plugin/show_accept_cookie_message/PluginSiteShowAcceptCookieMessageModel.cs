using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowAcceptCookieMessageModel : CodeBehindModel
    {
        public string AgreeAndNotAgreeWithCookiesPolicyLanguage { get; set; }
        
        public void SetValue(HttpContext context)
        {
            // Set Language
            if (context.Request.Cookies["el_accept_cookie"] != null)
                if (context.Request.Cookies["el_accept_cookie"] == "true")
                {
                    AgreeAndNotAgreeWithCookiesPolicyLanguage = Language.GetAddOnsLanguage("you_agree_with_cookies_policy", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "add_on/plugin/show_accept_cookie_message/");
                    return;
                }

            AgreeAndNotAgreeWithCookiesPolicyLanguage = Language.GetAddOnsLanguage("you_not_agree_with_cookies_policy", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "add_on/plugin/show_accept_cookie_message/");
        }
    }
}