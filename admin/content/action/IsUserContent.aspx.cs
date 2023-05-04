using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionIsUserContent : System.Web.UI.Page
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

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string ContentId = Request.QueryString["content_id"].ToString();

            DataUse.Content duc = new DataUse.Content();

            if(duc.IsUserContent(ccoc.UserId ,ContentId))
                Response.Write("true");
            else
                Response.Write("false");
        }
    }
}