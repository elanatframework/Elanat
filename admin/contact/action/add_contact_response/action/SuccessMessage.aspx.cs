using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionAddContactResponseSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalClass.AlertAddOnsLanguageVariant("contact_response_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/contact/");
        }
    }
}