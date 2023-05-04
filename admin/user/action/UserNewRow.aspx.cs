using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionUserNewRow : System.Web.UI.Page
    {
        public ActionUserNewRowModel model = new ActionUserNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["user_id"]))
                return;

            if (!Request.QueryString["user_id"].ToString().IsNumber())
                return;

            model.UserIdValue = Request.QueryString["user_id"].ToString();


            model.SetValue();
        }
    }
}