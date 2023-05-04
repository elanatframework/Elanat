using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteInactivaComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["comment_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["comment_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["comment_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            DataUse.Comment duc = new DataUse.Comment();
            duc.Delete(Request.QueryString["comment_id"].ToString());

            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_comment", Request.QueryString["comment_id"].ToString());
        }
    }
}