using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteSignUpStateOrProvinceModel
    {
        public string StateOrProvinceLanguage { get; set; }

        public string StateOrProvinceValue { get; set; }

        public string StateOrProvinceCssClass { get; set; }

        public string StateOrProvinceAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            StateOrProvinceLanguage = Language.GetAddOnsLanguage("state_or_province", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_StateOrProvince", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/sign_up/");


            StateOrProvinceAttribute += vc.ImportantInputAttribute["txt_StateOrProvince"];

            StateOrProvinceCssClass = StateOrProvinceCssClass.AddHtmlClass(vc.ImportantInputClass["txt_StateOrProvince"]);
        }
    }
}