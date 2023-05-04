using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionViewNewRow : System.Web.UI.Page
    {
        public ActionViewNewRowModel model = new ActionViewNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["view_id"]))
                return;

            if (!Request.QueryString["view_id"].ToString().IsNumber())
                return;

            model.ViewIdValue = Request.QueryString["view_id"].ToString();


            model.SetValue();
        }
    }
}