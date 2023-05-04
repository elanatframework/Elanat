using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionModuleNewRow : System.Web.UI.Page
    {
        public ActionModuleNewRowModel model = new ActionModuleNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["module_id"]))
                return;

            if (!Request.QueryString["module_id"].ToString().IsNumber())
                return;

            model.ModuleIdValue = Request.QueryString["module_id"].ToString();


            model.SetValue();
        }
    }
}