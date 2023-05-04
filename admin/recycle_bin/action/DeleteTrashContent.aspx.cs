using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteTrashContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["content_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["content_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["content_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            DataUse.Content duc = new DataUse.Content();
            duc.Delete(Request.QueryString["content_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_content", Request.QueryString["content_id"].ToString());
        }
    }
}