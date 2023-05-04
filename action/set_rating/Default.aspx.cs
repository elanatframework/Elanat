using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSetRating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["content_id"]) && !string.IsNullOrEmpty(Request.QueryString["rate"]))
                if (Request.QueryString["content_id"].IsNumber() && Request.QueryString["rate"].IsNumber())
                {
                    if (int.Parse(Request.QueryString["rate"]) <= 5)
                    {
                        DataUse.Rating dur = new DataUse.Rating();
                        dur.Set(Request.QueryString["content_id"].ToString(), Request.QueryString["rate"].ToString());
                        Response.Write("true");
                    }
                }
                else
                    Response.Write("false");
        }
    }
}