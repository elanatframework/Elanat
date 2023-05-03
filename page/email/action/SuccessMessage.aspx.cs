using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSiteEmailSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalClass.AlertAddOnsLanguageVariant("email_has_been_send", StaticObject.GetCurrentSiteGlobalLanguage(), "success", StaticObject.SitePath + "page/email/");

            string LinkTemplate = Template.GetSiteTemplate("link/common");

            string TmpLinkTemplate = LinkTemplate;

            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath);

            GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage(), "help");
        }
    }
}