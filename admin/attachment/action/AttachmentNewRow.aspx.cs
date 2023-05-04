using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionAttachmentNewRow : System.Web.UI.Page
    {
        public ActionAttachmentNewRowModel model = new ActionAttachmentNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["attachment_id"]))
                return;

            if (!Request.QueryString["attachment_id"].ToString().IsNumber())
                return;

            model.AttachmentIdValue = Request.QueryString["attachment_id"].ToString();


            model.SetValue();
        }
    }
}