using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetEditorTemplateViewMore : System.Web.UI.Page
    {
        public ActionGetEditorTemplateViewMoreModel model = new ActionGetEditorTemplateViewMoreModel();

        protected void Page_Load(object sender, EventArgs e)
        {		
            if (string.IsNullOrEmpty(Request.QueryString["editor_template_id"]))
            {
                Response.Write("false");
                return;
            }

            if (Request.QueryString["editor_template_id"].ToString().IsNumber())
                Response.Write(model.GetViewMore(Request.QueryString["editor_template_id"]));
            else
                Response.Write("false");
        }
    }
}