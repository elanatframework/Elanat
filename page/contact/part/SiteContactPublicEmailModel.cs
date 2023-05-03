using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContactPublicEmailModel
    {
        public string PublicEmailLanguage { get; set; }

        public string PublicEmailValue { get; set; }

        public string PublicEmailCssClass { get; set; }

        public string PublicEmailAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            PublicEmailLanguage = Language.GetAddOnsLanguage("public_email", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_PublicEmail", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            PublicEmailAttribute += vc.ImportantInputAttribute["txt_PublicEmail"];

            PublicEmailCssClass = PublicEmailCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PublicEmail"]);
        }
    }
}