using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionActiveAttachment : System.Web.UI.Page
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

            DataUse.Attachment dua = new DataUse.Attachment();
            dua.Active(Request.QueryString["attachment_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_attachment", Request.QueryString["attachment_id"].ToString());
        }
    }
}