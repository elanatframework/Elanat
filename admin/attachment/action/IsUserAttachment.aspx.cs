using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionIsUserAttachment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["attachment_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["attachment_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string AttachmentId = Request.QueryString["attachment_id"].ToString();

            DataUse.Attachment dua = new DataUse.Attachment();

            if(dua.IsUserAttachment(ccoc.UserId ,AttachmentId))
                Response.Write("true");
            else
                Response.Write("false");
        }
    }
}