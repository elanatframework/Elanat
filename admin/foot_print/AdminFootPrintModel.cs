using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminFootPrintModel
    {
        public string FootPrintLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/foot_print/");
            FootPrintLanguage = aol.GetAddOnsLanguage("foot_print");


            // Set Foot Print Page List
            ActionGetFootPrintListModel lm = new ActionGetFootPrintListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}