using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteContentReply : System.Web.UI.Page
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

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["content_reply_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            DataUse.ContentReply ducr = new DataUse.ContentReply();
            ducr.Delete(Request.QueryString["content_reply_id"].ToString());

            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_content_reply", Request.QueryString["content_reply_id"].ToString());
        }
    }
}