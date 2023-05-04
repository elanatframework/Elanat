using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetInactiveContentViewMore : System.Web.UI.Page
    {
        public ActionGetInactiveContentViewMoreModel model = new ActionGetInactiveContentViewMoreModel();

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