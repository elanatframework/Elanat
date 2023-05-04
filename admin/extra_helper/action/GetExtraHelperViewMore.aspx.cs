using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetExtraHelperViewMore : System.Web.UI.Page
    {
        public ActionGetExtraHelperViewMoreModel model = new ActionGetExtraHelperViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {		
            if (string.IsNullOrEmpty(Request.QueryString["extra_helper_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["extra_helper_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["extra_helper_id"]));
            else
                Response.Write("false");
        }
    }
}