using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteSignUpUserSiteNameModel
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
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_UserSiteName", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            UserSiteNameAttribute += vc.ImportantInputAttribute["txt_UserSiteName"];

            UserSiteNameCssClass = UserSiteNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_UserSiteName"]);
        }
    }
}