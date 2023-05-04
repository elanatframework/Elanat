using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionMoveTmpBinDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set Keep Login
            Security sc = new Security();
            sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("add_on_bin_files_has_bin_set_to_bin_directory", StaticObject.GetCurrentSiteGlobalLanguage()));


            ReCompileIssues rci = new ReCompileIssues();
            rci.SetTmpBinToBinDirectory();

            if (rci.ExistBinBefore)
                rci.StartAddOnInstall();
        }
    }
}