using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class MemberUserContentModel
    {
        public string MembeLanguage { get; set; }
        public string UserContentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(string QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/user_content/");
            MembeLanguage = aol.GetAddOnsLanguage("member");
			UserContentLanguage = aol.GetAddOnsLanguage("user_content");


            // Set Content Page List
            ActionGetUserContentListModel lm = new ActionGetUserContentListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue;
        }
    }
}