using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetMenuViewMore : System.Web.UI.Page
    {
        public ActionGetMenuViewMoreModel model = new ActionGetMenuViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["menu_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["menu_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["menu_id"]));
            else
                Response.Write("false");
        }
    }
}