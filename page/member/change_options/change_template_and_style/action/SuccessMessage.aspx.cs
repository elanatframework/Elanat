using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class MemberChangeTemplateAndStyleSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalClass.AlertAddOnsLanguageVariant("template_and_style_was_change", StaticObject.GetCurrentSiteGlobalLanguage(), "success", StaticObject.SitePath + "page/member/change_options/change_template_and_style/");

            string LinkTemplate = Template.GetSiteTemplate("link/common");

            string TmpLinkTemplate = LinkTemplate;

            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath);

            GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage(), "help");
        }
    }
}