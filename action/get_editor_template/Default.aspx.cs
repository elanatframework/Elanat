using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace elanat
{
    public partial class ActionGetEditorTemplate : System.Web.UI.Page
    {
        public ActionGetEditorTemplateModel model = new ActionGetEditorTemplateModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["editor_template_id"]))
                return;

            if (!Request.QueryString["editor_template_id"].IsNumber())
                return;

            string EditorTemplateId = Request.QueryString["editor_template_id"].ToString();


            // Editor Template Access Check
            DataUse.EditorTemplate duet = new DataUse.EditorTemplate();

            if (!duet.GetEditorTemplateAccessShowCheck(EditorTemplateId))
            {
                HttpContext.Current.Response.Redirect(StaticObject.SitePath + "page/error/401");
                return;
            }

            model.SetValue(EditorTemplateId, Request.QueryString);
        }
    }
}