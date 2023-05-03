using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContentReplyMobileNumberModel
    {
        public string MobileNumberLanguage { get; set; }

        public string MobileNumberValue { get; set; }

        public string MobileNumberCssClass { get; set; }

        public string MobileNumberAttribute { get; set; }

        public void SetValue()
        {
            // Set Language
            MobileNumberLanguage = Language.GetAddOnsLanguage("mobile_number", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/content_reply/");
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_MobileNumber", "");

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/content_reply/");


            MobileNumberAttribute += vc.ImportantInputAttribute["txt_MobileNumber"];

            MobileNumberCssClass = MobileNumberCssClass.AddHtmlClass(vc.ImportantInputClass["txt_MobileNumber"]);
        }
    }
}