using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class MemberUserCommentModel
    {
        public string MembeLanguage { get; set; }
        public string UserCommentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(string QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/user_comment/");
            MembeLanguage = aol.GetAddOnsLanguage("member");
			UserCommentLanguage = aol.GetAddOnsLanguage("user_comment");


            // Set Comment Page List
            ActionGetUserCommentListModel lm = new ActionGetUserCommentListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue;
        }
    }
}