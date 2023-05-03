using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContactRealLastNameModel
    {
        public string RealLastNameLanguage { get; set; }

        public string RealLastNameValue { get; set; }

        public string RealLastNameCssClass { get; set; }

        public string RealLastNameAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            RealLastNameLanguage = Language.GetAddOnsLanguage("real_last_name", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_RealLastName", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            RealLastNameAttribute += vc.ImportantInputAttribute["txt_RealLastName"];

            RealLastNameCssClass = RealLastNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_RealLastName"]);
        }
    }
}