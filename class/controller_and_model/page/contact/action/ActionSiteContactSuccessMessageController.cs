using CodeBehind;

namespace Elanat
{
    public partial class ActionSiteContactSuccessMessageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            string ResponseCode = context.Request.Query["response_code"];

            Write(GlobalClass.AlertAddOnsLanguageVariant("contact_was_send", StaticObject.GetCurrentSiteGlobalLanguage(), "success", StaticObject.SitePath + "page/contact/"));

            Write(GlobalClass.AlertAddOnsLanguageVariant("write_below_code_for_our_future_response", StaticObject.GetCurrentSiteGlobalLanguage(), "success", StaticObject.SitePath + "page/contact/"));
            Write(GlobalClass.Alert(ResponseCode, StaticObject.GetCurrentSiteGlobalLanguage()));


            string LinkTemplate = Template.GetSiteTemplate("link/common");

            string TmpLinkTemplate = LinkTemplate;

            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath);

            Write(GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage(), "help"));
        }
    }
}