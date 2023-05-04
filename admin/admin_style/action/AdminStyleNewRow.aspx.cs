using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionAdminStyleNewRow : System.Web.UI.Page
    {
        public ActionAdminStyleNewRowModel model = new ActionAdminStyleNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["admin_style_id"]))
                return;

            if (!Request.QueryString["admin_style_id"].ToString().IsNumber())
                return;

            model.AdminStyleIdValue = Request.QueryString["admin_style_id"].ToString();


            model.SetValue();
        }
    }
}