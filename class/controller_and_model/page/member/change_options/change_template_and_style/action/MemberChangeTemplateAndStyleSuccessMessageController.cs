using CodeBehind;

namespace Elanat
{
    public partial class MemberChangeTemplateAndStyleSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            Write(GlobalClass.AlertAddOnsLanguageVariant("template_and_style_was_change", StaticObject.GetCurrentSiteGlobalLanguage(), "success", StaticObject.SitePath + "page/member/change_options/change_template_and_style/"));

            string LinkTemplate = Template.GetSiteTemplate("link/common");

            string TmpLinkTemplate = LinkTemplate;

            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath);

            Write(GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage(), "help"));
        }
    }
}