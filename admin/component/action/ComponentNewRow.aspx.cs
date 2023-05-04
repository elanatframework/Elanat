using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionComponentNewRow : System.Web.UI.Page
    {
        public ActionComponentNewRowModel model = new ActionComponentNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["component_id"]))
                return;

            if (!Request.QueryString["component_id"].ToString().IsNumber())
                return;

            model.ComponentIdValue = Request.QueryString["component_id"].ToString();


            model.SetValue();
        }
    }
}