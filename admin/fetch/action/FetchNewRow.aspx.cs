using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionFetchNewRow : System.Web.UI.Page
    {
        public ActionFetchNewRowModel model = new ActionFetchNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["fetch_id"]))
                return;

            if (!Request.QueryString["fetch_id"].ToString().IsNumber())
                return;

            model.FetchIdValue = Request.QueryString["fetch_id"].ToString();


            model.SetValue();
        }
    }
}