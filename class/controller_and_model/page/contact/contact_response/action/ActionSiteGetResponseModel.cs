using CodeBehind;

namespace Elanat
{
    public partial class ActionSiteGetResponseModel : CodeBehindModel
    {
        public string ContactResponseTextLanguage { get; set; }

        public string ContactResponseValue { get; set; }

        public void SetValue(HttpContext context)
        {
            // Set Language
            ContactResponseTextLanguage = Language.GetAddOnsLanguage("contact_response_text", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/contact_response/");

            ContactResponseValue = context.Session.GetString("el_contact_response_text");

            context.Session.Remove("el_contact_response_text");
        }
    }
}