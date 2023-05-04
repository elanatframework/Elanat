using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionRoleNewRow : System.Web.UI.Page
    {
        public ActionRoleNewRowModel model = new ActionRoleNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["role_id"]))
                return;

            if (!Request.QueryString["role_id"].ToString().IsNumber())
                return;

            model.RoleIdValue = Request.QueryString["role_id"].ToString();


            model.SetValue();
        }
    }
}