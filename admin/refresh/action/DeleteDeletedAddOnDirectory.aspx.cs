using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteDeletedAddOnDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("deleted_add_ons_directory_has_been_delete_successfully", StaticObject.GetCurrentSiteGlobalLanguage()));


            ReCompileIssues rci = new ReCompileIssues();
            rci.DeleteDeletedAddOnDirectory(true, true);
        }
    }
}