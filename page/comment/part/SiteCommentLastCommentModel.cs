using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteCommentLastCommentModel
    {
        public string LastCommentValue { get; set; }

        public void SetValue(string ContentId)
        {
            ContentClass cc = new ContentClass();
            LastCommentValue = cc.GetContentComment(ContentId);
        }
    }
}