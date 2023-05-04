using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionIsCurrentUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["user_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["user_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string UserId = Request.QueryString["user_id"].ToString();

            if (ccoc.UserId == UserId)
                Response.Write("true");
            else
                Response.Write("false");
        }
    }
}