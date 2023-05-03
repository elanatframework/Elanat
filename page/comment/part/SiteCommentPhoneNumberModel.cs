using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteCommentPhoneNumberModel
    {
        public string PhoneNumberLanguage { get; set; }

        public string PhoneNumberValue { get; set; }

        public string PhoneNumberCssClass { get; set; }

        public string PhoneNumberAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            PhoneNumberLanguage = Language.GetAddOnsLanguage("phone_number", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_PhoneNumber", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");


            PhoneNumberAttribute += vc.ImportantInputAttribute["txt_PhoneNumber"];

            PhoneNumberCssClass = PhoneNumberCssClass.AddHtmlClass(vc.ImportantInputClass["txt_PhoneNumber"]);
        }
    }
}