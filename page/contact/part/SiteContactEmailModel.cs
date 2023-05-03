using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContactEmailModel
    {
        public string EmailLanguage { get; set; }

        public string EmailValue { get; set; }

        public string EmailCssClass { get; set; }

        public string EmailAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            EmailLanguage = Language.GetAddOnsLanguage("email", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_Email", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            EmailAttribute += vc.ImportantInputAttribute["txt_Email"];

            EmailCssClass = EmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_Email"]);
        }
    }
}