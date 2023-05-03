using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContactCountryModel
    {
        public string CountryLanguage { get; set; }

        public string CountryValue { get; set; }

        public string CountryCssClass { get; set; }

        public string CountryAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            CountryLanguage = Language.GetAddOnsLanguage("country", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_Country", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            CountryAttribute += vc.ImportantInputAttribute["txt_Country"];

            CountryCssClass = CountryCssClass.AddHtmlClass(vc.ImportantInputClass["txt_Country"]);
        }
    }
}