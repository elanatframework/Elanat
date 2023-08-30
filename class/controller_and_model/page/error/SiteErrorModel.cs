using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteErrorModel : CodeBehindModel
    {
        public string ErrorLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(string ErrorValue)
        {
			// Set Language
			ErrorLanguage = Language.GetAddOnsLanguage("error", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/error/");
			
			
            string ErrorContent = "";
            if (!string.IsNullOrEmpty(ErrorValue))
            {
                switch (ErrorValue)
                {
                    case "400":
                        {
                            ErrorContent = Language.GetLanguageFromContent(Template.GetSiteTemplate("page/error/error_400", true), StaticObject.GetCurrentSiteGlobalLanguage());
                        } break;

                    case "401":
                        {
                            ErrorContent = Language.GetLanguageFromContent(Template.GetSiteTemplate("page/error/error_401", true), StaticObject.GetCurrentSiteGlobalLanguage());
                        } break;

                    case "403":
                        {
                            ErrorContent = Language.GetLanguageFromContent(Template.GetSiteTemplate("page/error/error_403", true), StaticObject.GetCurrentSiteGlobalLanguage());
                        } break;

                    case "404":
                        {
                            ErrorContent = Language.GetLanguageFromContent(Template.GetSiteTemplate("page/error/error_404", true), StaticObject.GetCurrentSiteGlobalLanguage());
                        } break;

                    case "500":
                        {
                            ErrorContent = Language.GetLanguageFromContent(Template.GetSiteTemplate("page/error/error_500", true), StaticObject.GetCurrentSiteGlobalLanguage());
                        } break;

                    default:
                        {
                            ErrorContent = Language.GetLanguageFromContent(Template.GetSiteTemplate("page/error/error_other", true), StaticObject.GetCurrentSiteGlobalLanguage());
                        } break;
                }

                if (ErrorValue.IsNumber())
                    ErrorContent = ErrorContent.Replace("$_asp error_number;", ErrorValue);
                else
                    ErrorContent = ErrorContent.Replace("$_asp error_number;", Language.GetLanguage(ErrorValue, StaticObject.GetCurrentSiteGlobalLanguage()));
            }
            else
            {
                ErrorContent = Language.GetLanguageFromContent(Template.GetSiteTemplate("page/error/error_other", true), StaticObject.GetCurrentSiteGlobalLanguage());
                ErrorContent = ErrorContent.Replace("$_asp error_number;", null);
            }

            ContentValue = ErrorContent;
        }
    }
}