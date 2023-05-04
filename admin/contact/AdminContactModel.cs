using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminContactModel
    {
        public string ContactLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/contact/");
            ContactLanguage = aol.GetAddOnsLanguage("contact");


            // Set Approval Comment Page List
            ActionGetContactListModel lm = new ActionGetContactListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}