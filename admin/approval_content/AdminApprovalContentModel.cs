using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminApprovalContentModel
    {
        public string ApprovalContentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/approval_content/");
            ApprovalContentLanguage = aol.GetAddOnsLanguage("approval_content");


            // Set Approval Content Page List
            ActionGetInactiveContentListModel lm = new ActionGetInactiveContentListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}