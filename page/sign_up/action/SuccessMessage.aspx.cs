using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSiteSignUpSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalClass.AlertAddOnsLanguageVariant("registration_was_successful", StaticObject.GetCurrentSiteGlobalLanguage(), "success", StaticObject.SitePath + "page/sign_up/");

            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");

            // Set Alert Template
            string LoginDirectoryPath = StaticObject.SitePath + "page/login/";
            string LinkTemplate = Template.GetSiteTemplate("link/common");
            string TmpLinkTemplate = "";

            if (!string.IsNullOrEmpty(Request.QueryString["el_return_url"]))
            {
                TmpLinkTemplate = LinkTemplate;

                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("previous_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("previous_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath + Request.QueryString["el_return_url"].ToString());

                GlobalClass.Alert(aol.GetAddOnsLanguage("sign_up_successfully_click_in_the_below_link_to_return_to_the_previous_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success");
                GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage());

                TmpLinkTemplate = LinkTemplate;

                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("login_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("login_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", LoginDirectoryPath + "?el_return_url=" + Request.QueryString["el_return_url"].ToString());

                GlobalClass.Alert(aol.GetAddOnsLanguage("or_click_in_the_below_link_to_go_to_the_login_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success");
                GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage());
            }
            else
            {
                TmpLinkTemplate = LinkTemplate;

                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("login_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("login_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", LoginDirectoryPath);

                GlobalClass.Alert(aol.GetAddOnsLanguage("sign_up_successfully_click_in_the_below_link_to_go_to_the_login_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success");
                GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage());
            }
        }
    }
}