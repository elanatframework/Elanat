using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elanat
{
    public class AspxHtmlValue
    {
        public static string CurrentSiteStyleTag()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CurrentSiteStyleTag = Struct.GetNode("tag/current_site_style_tag").InnerText.Replace("$_asp site_path;", StaticObject.SitePath).Replace("$_asp site_style_physical_path;", ccoc.SiteStylePhysicalPath);

            return CurrentSiteStyleTag;
        }

        public static string CurrentAdminStyleTag()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CurrentAdminStyleTag = Struct.GetNode("tag/current_admin_style_tag").InnerText.Replace("$_asp site_path;", StaticObject.SitePath).Replace("$_asp admin_style_physical_path;", ccoc.AdminStylePhysicalPath);

            return CurrentAdminStyleTag;
        }

        public static string CurrentSiteLanguageDirection()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            return (ccoc.SiteLanguageIsRightToLeft.ZeroOneToBoolean())? "rtl" : "ltr";
        }

        public static string CurrentAdminLanguageDirection()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            return (ccoc.AdminLanguageIsRightToLeft.ZeroOneToBoolean()) ? "rtl" : "ltr";
        }

        public static string CurrentBoxTag()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            IncludeClass ic = new IncludeClass();
            string CurrentBoxTag = ic.GetBoxHead(ccoc.SiteSiteGlobalName);

            return CurrentBoxTag;
        }

        public static string BooleanToCheckedHtmlAttribute(bool Value)
        {
            return (Value.BooleanToCheckedHtmlAttribute());
        }

        public static string SitePath()
        {
            return StaticObject.SitePath;
        }

        public static string AdminPath()
        {
            string AdminPath = StaticObject.AdminPath;

            return AdminPath;
        }
    }
}