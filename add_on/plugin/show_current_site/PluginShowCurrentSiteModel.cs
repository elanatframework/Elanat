using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat
{
    public class PluginShowCurrentSiteModel
    {
        public void SetValue()
        {
            string CurrentSiteTemplate = Template.GetAdminTemplate("part/show_current_site");
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string CurrentSite = (ccoc.SiteId == "0") ? Language.GetLanguage("global", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetHandheldLanguage(ccoc.SiteSiteGlobalName, StaticObject.GetCurrentAdminGlobalLanguage());
            CurrentSiteTemplate = CurrentSiteTemplate.Replace("$_asp current_site;", CurrentSite);
            CurrentSiteTemplate = CurrentSiteTemplate.Replace("$_asp_lang current_site;", Language.GetLanguage("current_site", StaticObject.GetCurrentAdminGlobalLanguage()));

            HttpContext.Current.Response.Write(CurrentSiteTemplate);
        }
    }
}