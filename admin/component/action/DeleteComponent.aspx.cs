using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteComponent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["component_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["component_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(Request.QueryString["component_id"].ToString(), "../"))
            {
                Response.Write("false");
                return;
            }


            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("keep_login_user_after_delete_add_on", StaticObject.GetCurrentSiteGlobalLanguage()));


            DataUse.Component duc = new DataUse.Component();
            duc.Delete(Request.QueryString["component_id"].ToString());

            Response.Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_component", Request.QueryString["component_id"].ToString());
        }
    }
}