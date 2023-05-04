using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionIsUserInactiveComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["comment_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["comment_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string CommentId = Request.QueryString["comment_id"].ToString();

            DataUse.Comment duc = new DataUse.Comment();

            if(duc.IsUserComment(ccoc.UserId ,CommentId))
                Response.Write("true");
            else
                Response.Write("false");
        }
    }
}