using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInstallSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/");

            string LinkTemplate = Template.GetSiteTemplate("link/common");
            LinkTemplate = LinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("main_page"));
            LinkTemplate = LinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("main_page"));
            LinkTemplate = LinkTemplate.Replace("$_asp path;", StaticObject.SitePath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());
            rf.AddLocalMessage(aol.GetAddOnsLanguage("click_in_the_below_link_to_go_to_the_main_page"), "none");
            rf.AddLocalMessage(LinkTemplate, "none");

            GlobalClass.Alert(aol.GetAddOnsLanguage("installation_completed_successfully"), StaticObject.GetCurrentSiteGlobalLanguage(), "success");
            GlobalClass.Alert(aol.GetAddOnsLanguage("click_in_the_below_link_to_go_to_the_main_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "none");
            GlobalClass.Alert(LinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage(), "none");
        }
    }
}