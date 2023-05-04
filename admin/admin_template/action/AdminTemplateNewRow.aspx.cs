using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionAdminTemplateNewRow : System.Web.UI.Page
    {
        public ActionAdminTemplateNewRowModel model = new ActionAdminTemplateNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["admin_template_id"]))
                return;

            if (!Request.QueryString["admin_template_id"].ToString().IsNumber())
                return;

            model.AdminTemplateIdValue = Request.QueryString["admin_template_id"].ToString();


            model.SetValue();
        }
    }
}