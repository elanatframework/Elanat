using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionChangeLanguageSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalClass.AlertAddOnsLanguageVariant("language_was_change", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/profile/");
        }
    }
}