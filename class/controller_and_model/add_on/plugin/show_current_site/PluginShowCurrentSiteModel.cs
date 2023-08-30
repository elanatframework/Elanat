using CodeBehind;

namespace Elanat
{
    public partial class PluginShowCurrentSiteModel : CodeBehindModel
    {
        public void SetValue()
        {
            string CurrentSiteTemplate = Template.GetAdminTemplate("part/show_current_site");
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string CurrentSite = (ccoc.SiteId == "0") ? Language.GetLanguage("global", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetHandheldLanguage(ccoc.SiteSiteGlobalName, StaticObject.GetCurrentAdminGlobalLanguage());
            CurrentSiteTemplate = CurrentSiteTemplate.Replace("$_asp current_site;", CurrentSite);
            CurrentSiteTemplate = CurrentSiteTemplate.Replace("$_asp_lang current_site;", Language.GetLanguage("current_site", StaticObject.GetCurrentAdminGlobalLanguage()));

            Write(CurrentSiteTemplate);
        }
    }
}