using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class MemberUserFootPrintModel
    {
        public string MembeLanguage { get; set; }
        public string UserFootPrintLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(string QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/user_foot_print/");
            MembeLanguage = aol.GetAddOnsLanguage("member");
			UserFootPrintLanguage = aol.GetAddOnsLanguage("user_foot_print");


            // Set Foot Print Page List
            ActionGetUserFootPrintListModel lm = new ActionGetUserFootPrintListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue;
        }
    }
}