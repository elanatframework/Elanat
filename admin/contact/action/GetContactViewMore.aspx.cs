using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetContactViewMore : System.Web.UI.Page
    {
        public ActionGetContactViewMoreModel model = new ActionGetContactViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["contact_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["contact_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["contact_id"]));
            else
                Response.Write("false");
        }
    }
}