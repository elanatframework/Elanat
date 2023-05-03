using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContactZipCodeModel
    {
        public string ZipCodeLanguage { get; set; }

        public string ZipCodeValue { get; set; }

        public string ZipCodeCssClass { get; set; }

        public string ZipCodeAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            ZipCodeLanguage = Language.GetAddOnsLanguage("zip_code", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_ZipCode", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            ZipCodeAttribute += vc.ImportantInputAttribute["txt_ZipCode"];

            ZipCodeCssClass = ZipCodeCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ZipCode"]);
        }
    }
}