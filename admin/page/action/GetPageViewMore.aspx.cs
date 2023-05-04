using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetPageViewMore : System.Web.UI.Page
    {
        public ActionGetPageViewMoreModel model = new ActionGetPageViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["page_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["page_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["page_id"]));
            else
                Response.Write("false");
        }
    }
}