using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteSignUpPostalCodeModel
    {
        public string PostalCodeLanguage { get; set; }

        public string PostalCodeValue { get; set; }

        public string PostalCodeCssClass { get; set; }

        public string PostalCodeAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            PostalCodeLanguage = Language.GetAddOnsLanguage("postal_code", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_PostalCode", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            PostalCodeAttribute += vc.ImportantInputAttribute["txt_PostalCode"];

            PostalCodeCssClass = PostalCodeCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PostalCode"]);
        }
    }
}