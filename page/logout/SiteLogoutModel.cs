using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class SiteLogoutModel
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