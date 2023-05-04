using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveLanguage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["language_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["language_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Language dul = new DataUse.Language();
            dul.Inactive(Request.QueryString["language_id"].ToString());
            Response.Write("true");


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_language", Request.QueryString["language_id"].ToString());
        }
    }
}