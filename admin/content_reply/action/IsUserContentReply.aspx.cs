using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionIsUserContentReply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["content_reply_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["content_reply_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string ContentReplyId = Request.QueryString["content_reply_id"].ToString();

            DataUse.ContentReply ducr = new DataUse.ContentReply();

            if (ducr.IsUserContentReply(ccoc.UserId, ContentReplyId))
                Response.Write("true");
            else
                Response.Write("false");
        }
    }
}