using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminContentModel
    {
        public string ContentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/content/");
            ContentLanguage = aol.GetAddOnsLanguage("content");


            // Set Content Page List
            ActionGetContentListModel lm = new ActionGetContentListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}