using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionSiteGetResponseModel
    {
        public string ContactResponseTextLanguage { get; set; }

        public string ContactResponseValue { get; set; }

        public void SetValue()
        {
            // Set Language
            ContactResponseTextLanguage = Language.GetAddOnsLanguage("contact_response_text", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/contact_response/");

            ContactResponseValue = HttpContext.Current.Session["el_contact_response_text"].ToString();

            HttpContext.Current.Session.Remove("el_contact_response_text");
        }
    }
}