using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetItemViewMore : System.Web.UI.Page
    {
        public ActionGetItemViewMoreModel model = new ActionGetItemViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["item_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["item_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["item_id"]));
            else
                Response.Write("false");
        }
    }
}