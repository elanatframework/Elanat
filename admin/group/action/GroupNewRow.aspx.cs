using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGroupNewRow : System.Web.UI.Page
    {
        public ActionGroupNewRowModel model = new ActionGroupNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["group_id"]))
                return;

            if (!Request.QueryString["group_id"].ToString().IsNumber())
                return;

            model.GroupIdValue = Request.QueryString["group_id"].ToString();


            model.SetValue();
        }
    }
}