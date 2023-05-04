using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionIsUserContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["contact_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["contact_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string ContactId = Request.QueryString["contact_id"].ToString();

            DataUse.Contact duc = new DataUse.Contact();

            if(duc.IsUserContact(ccoc.UserId ,ContactId))
                Response.Write("true");
            else
                Response.Write("false");
        }
    }
}