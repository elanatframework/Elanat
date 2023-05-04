using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class AdminAddContentSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Action = Request.QueryString["action"];

            if (Action == "add")
                GlobalClass.AlertAddOnsLanguageVariant("content_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/add_content/");
            else
                GlobalClass.AlertAddOnsLanguageVariant("content_was_save_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/add_content/");
        }
    }
}