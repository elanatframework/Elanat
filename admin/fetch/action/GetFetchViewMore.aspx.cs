using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetFetchViewMore : System.Web.UI.Page
    {
        public ActionGetFetchViewMoreModel model = new ActionGetFetchViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["fetch_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["fetch_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["fetch_id"]));
            else
                Response.Write("false");
        }
    }
}