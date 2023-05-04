using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["item_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["item_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["item_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }

            DataUse.Item dui = new DataUse.Item();
            dui.Delete(Request.QueryString["item_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_item", Request.QueryString["item_id"].ToString());
        }
    }
}