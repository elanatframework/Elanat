using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionPluginNewRow : System.Web.UI.Page
    {
        public ActionPluginNewRowModel model = new ActionPluginNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["plugin_id"]))
                return;

            if (!Request.QueryString["plugin_id"].ToString().IsNumber())
                return;

            model.PluginIdValue = Request.QueryString["plugin_id"].ToString();


            model.SetValue();
        }
    }
}