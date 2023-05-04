using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteFootPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["foot_print_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["foot_print_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["foot_print_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            DataUse.FootPrint dufp = new DataUse.FootPrint();
            dufp.Delete(Request.QueryString["foot_print_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_foot_print", Request.QueryString["foot_print_id"].ToString());
        }
    }
}