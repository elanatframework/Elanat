using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContactRealNameModel
    {
        public string RealNameLanguage { get; set; }

        public string RealNameValue { get; set; }

        public string RealNameCssClass { get; set; }

        public string RealNameAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            RealNameLanguage = Language.GetAddOnsLanguage("real_name", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_RealName", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");


            RealNameAttribute += vc.ImportantInputAttribute["txt_RealName"];

            RealNameCssClass = RealNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_RealName"]);
        }
    }
}