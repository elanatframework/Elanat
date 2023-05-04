using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat
{
    public class PluginSiteShowAcceptCookieMessageModel
    {
        public string AgreeAndNotAgreeWithCookiesPolicyLanguage { get; set; }
        
        public void SetValue()
        {
            // Set Language
            if (HttpContext.Current.Request.Cookies["el_accept_cookie"] != null)
                if (HttpContext.Current.Request.Cookies["el_accept_cookie"].Value == "true")
                {
                    AgreeAndNotAgreeWithCookiesPolicyLanguage = Language.GetAddOnsLanguage("you_agree_with_cookies_policy", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "add_on/plugin/show_accept_cookie_message/");
                    return;
                }

            AgreeAndNotAgreeWithCookiesPolicyLanguage = Language.GetAddOnsLanguage("you_not_agree_with_cookies_policy", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "add_on/plugin/show_accept_cookie_message/");
        }
    }
}