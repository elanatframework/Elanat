using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionShowEditorTemplateList : System.Web.UI.Page
    {
        public ActionShowEditorTemplateListModel model = new ActionShowEditorTemplateListModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Editor Template Component Access Check
            DataUse.Component duc = new DataUse.Component();
            string EditorTemplateComponentId = duc.GetComponentIdByComponentName("editor_template");
            duc.FillComponentRoleAccess(EditorTemplateComponentId);

            if (!duc.ComponentAccessShow)
            {
                HttpContext.Current.Response.Redirect(StaticObject.SitePath + "page/error/401");
                return;
            }

            model.SetValue();
        }
    }
}