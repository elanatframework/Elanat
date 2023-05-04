using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveEditorTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["editor_template_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["editor_template_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.EditorTemplate duet = new DataUse.EditorTemplate();
            duet.Inactive(Request.QueryString["editor_template_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_editor_template", Request.QueryString["editor_template_id"].ToString());
        }
    }
}