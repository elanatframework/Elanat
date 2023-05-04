using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionCommentNewRow : System.Web.UI.Page
    {
        public ActionCommentNewRowModel model = new ActionCommentNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["comment_id"]))
                return;

            if (!Request.QueryString["comment_id"].ToString().IsNumber())
                return;

            model.CommentIdValue = Request.QueryString["comment_id"].ToString();


            model.SetValue();
        }
    }
}