using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionContentReplyNewRow : System.Web.UI.Page
    {
        public ActionContentReplyNewRowModel model = new ActionContentReplyNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["content_reply_id"]))
                return;

            if (!Request.QueryString["content_reply_id"].ToString().IsNumber())
                return;

            model.ContentReplyIdValue = Request.QueryString["content_reply_id"].ToString();


            model.SetValue();
        }
    }
}