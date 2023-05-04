using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetContentViewMore : System.Web.UI.Page
    {
        public ActionGetContentViewMoreModel model = new ActionGetContentViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["content_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["content_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["content_id"]));
            else
                Response.Write("false");
        }
    }
}