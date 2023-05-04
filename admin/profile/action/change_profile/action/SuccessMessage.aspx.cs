using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionChangeProfileSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalClass.AlertAddOnsLanguageVariant("user_profile_was_change", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/profile/");
        }
    }
}