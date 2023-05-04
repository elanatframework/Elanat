using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetModuleViewMore : System.Web.UI.Page
    {
        public ActionGetModuleViewMoreModel model = new ActionGetModuleViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["module_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["module_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["module_id"]));
            else
                Response.Write("false");
        }
    }
}