using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionItemNewRow : System.Web.UI.Page
    {
        public ActionItemNewRowModel model = new ActionItemNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["item_id"]))
                return;

            if (!Request.QueryString["item_id"].ToString().IsNumber())
                return;

            model.ItemIdValue = Request.QueryString["item_id"].ToString();


            model.SetValue();
        }
    }
}