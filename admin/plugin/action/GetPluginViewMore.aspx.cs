using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetPluginViewMore : System.Web.UI.Page
    {
        public ActionGetPluginViewMoreModel model = new ActionGetPluginViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {		
            if (string.IsNullOrEmpty(Request.QueryString["plugin_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["plugin_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["plugin_id"]));
            else
                Response.Write("false");
        }
    }
}