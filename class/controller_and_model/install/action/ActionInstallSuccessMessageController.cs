using CodeBehind;

namespace Elanat
{
    public partial class ActionInstallSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "install/");

            string LinkTemplate = Template.GetSiteTemplate("link/common");
            LinkTemplate = LinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("main_page"));
            LinkTemplate = LinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("main_page"));
            LinkTemplate = LinkTemplate.Replace("$_asp path;", StaticObject.SitePath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());
            rf.AddLocalMessage(aol.GetAddOnsLanguage("click_in_the_below_link_to_go_to_the_main_page"), "none");
            rf.AddLocalMessage(LinkTemplate, "none");

            Write(GlobalClass.Alert(aol.GetAddOnsLanguage("installation_completed_successfully"), StaticObject.GetCurrentSiteGlobalLanguage(), "success"));
            Write(GlobalClass.Alert(aol.GetAddOnsLanguage("click_in_the_below_link_to_go_to_the_main_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "none"));
            Write(GlobalClass.Alert(LinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage(), "none"));
        }
    }
}