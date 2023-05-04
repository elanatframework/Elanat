using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetSiteTemplateViewMore : System.Web.UI.Page
    {
        public ActionGetSiteTemplateViewMoreModel model = new ActionGetSiteTemplateViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {		
            if (string.IsNullOrEmpty(Request.QueryString["site_template_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["site_template_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["site_template_id"]));
            else
                Response.Write("false");
        }
    }
}