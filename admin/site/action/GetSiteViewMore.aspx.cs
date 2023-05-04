using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetSiteViewMore : System.Web.UI.Page
    {
        public ActionGetSiteViewMoreModel model = new ActionGetSiteViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {		
            if (string.IsNullOrEmpty(Request.QueryString["site_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["site_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["site_id"]));
            else
                Response.Write("false");
        }
    }
}