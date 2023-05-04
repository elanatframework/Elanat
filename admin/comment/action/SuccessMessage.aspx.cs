using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionCommentSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalClass.AlertAddOnsLanguageVariant("comment_was_save_edit", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/comment/");
        }
    }
}