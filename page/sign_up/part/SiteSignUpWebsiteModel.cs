using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteSignUpWebsiteModel
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
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_Website", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            WebsiteAttribute += vc.ImportantInputAttribute["txt_Website"];

            WebsiteCssClass = WebsiteCssClass.AddHtmlClass(vc.ImportantInputClass["txt_Website"]);
        }
    }
}