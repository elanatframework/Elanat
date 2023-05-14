using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetLinkViewMore : System.Web.UI.Page
    {
        public ActionGetLinkViewMoreModel model = new ActionGetLinkViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {		
            if (string.IsNullOrEmpty(Request.QueryString["link_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["link_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["link_id"]));
            else
                Response.Write("false");
        }
    }
}