using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetCommentViewMore : System.Web.UI.Page
    {
        public ActionGetCommentViewMoreModel model = new ActionGetCommentViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (string.IsNullOrEmpty(Request.QueryString["comment_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["comment_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["comment_id"]));
            else
                Response.Write("false");
        }
    }
}