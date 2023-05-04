using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetComponentViewMore : System.Web.UI.Page
    {
        public ActionGetComponentViewMoreModel model = new ActionGetComponentViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["component_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["component_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["component_id"]));
            else
                Response.Write("false");
        }
    }
}