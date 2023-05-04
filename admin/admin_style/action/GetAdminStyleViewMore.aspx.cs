using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetAdminStyleViewMore : System.Web.UI.Page
    {
        public ActionGetAdminStyleViewMoreModel model = new ActionGetAdminStyleViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["admin_style_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["admin_style_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["admin_style_id"]));
            else
                Response.Write("false");
        }
    }
}