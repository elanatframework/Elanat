using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminApprovalCommentModel
    {
        public string ApprovalCommentLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/approval_comment/");
            ApprovalCommentLanguage = aol.GetAddOnsLanguage("approval_comment");


            // Set Approval Comment Page List
            ActionGetInactiveCommentListModel lm = new ActionGetInactiveCommentListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}