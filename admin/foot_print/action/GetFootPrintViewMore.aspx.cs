using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetFootPrintViewMore : System.Web.UI.Page
    {
        public ActionGetFootPrintViewMoreModel model = new ActionGetFootPrintViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["foot_print_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["foot_print_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["foot_print_id"]));
            else
                Response.Write("false");
        }
    }
}