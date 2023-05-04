using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditorTemplateNewRow : System.Web.UI.Page
    {
        public ActionEditorTemplateNewRowModel model = new ActionEditorTemplateNewRowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["editor_template_id"]))
                return;

            if (!Request.QueryString["editor_template_id"].ToString().IsNumber())
                return;

            model.EditorTemplateIdValue = Request.QueryString["editor_template_id"].ToString();


            model.SetValue();
        }
    }
}