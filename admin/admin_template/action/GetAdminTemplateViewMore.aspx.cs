using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetAdminTemplateViewMore : System.Web.UI.Page
    {
        public ActionGetAdminTemplateViewMoreModel model = new ActionGetAdminTemplateViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["admin_template_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["admin_template_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["admin_template_id"]));
            else
                Response.Write("false");
        }
    }
}