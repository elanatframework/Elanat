using CodeBehind;

namespace Elanat
{
    public partial class ActionSiteSignUpSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("registration_was_successful", StaticObject.GetCurrentSiteGlobalLanguage(), "success", StaticObject.SitePath + "page/sign_up/"));

            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/sign_up/");

            // Set Alert Template
            string LoginDirectoryPath = StaticObject.SitePath + "page/login/";
            string LinkTemplate = Template.GetSiteTemplate("link/common");
            string TmpLinkTemplate = "";

            if (!string.IsNullOrEmpty(context.Request.Query["el_return_url"]))
            {
                TmpLinkTemplate = LinkTemplate;

                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("previous_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("previous_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath + context.Request.Query["el_return_url"].ToString());

                Write(GlobalClass.Alert(aol.GetAddOnsLanguage("sign_up_successfully_click_in_the_below_link_to_return_to_the_previous_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success"));
                Write(GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage()));

                TmpLinkTemplate = LinkTemplate;

                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("login_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("login_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", LoginDirectoryPath + "?el_return_url=" + context.Request.Query["el_return_url"].ToString());

                Write(GlobalClass.Alert(aol.GetAddOnsLanguage("or_click_in_the_below_link_to_go_to_the_login_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success"));
                Write(GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage()));
            }
            else
            {
                TmpLinkTemplate = LinkTemplate;

                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("login_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("login_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", LoginDirectoryPath);

                Write(GlobalClass.Alert(aol.GetAddOnsLanguage("sign_up_successfully_click_in_the_below_link_to_go_to_the_login_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success"));
                Write(GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage()));
            }
        }
    }
}