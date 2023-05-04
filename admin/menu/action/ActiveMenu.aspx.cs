using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionActiveMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["menu_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["menu_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Menu dum = new DataUse.Menu();
            dum.Active(Request.QueryString["menu_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_menu", Request.QueryString["menu_id"].ToString());
        }
    }
}