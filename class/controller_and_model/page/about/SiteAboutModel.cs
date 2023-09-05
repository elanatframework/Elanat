using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteAboutModel : CodeBehindModel
    {
        public void SetValue(HttpContext context)
        {
            string SiteGlobalName = StaticObject.GetCurrentSiteSiteGlobalName();

            AttributeReader ar = new AttributeReader();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/catalog.xml"));

            XmlNode node = doc.SelectSingleNode("site_catalog_root/site_page_list/about");


            string About = PageLoader.LoadPage(node.Attributes["load_type"].Value, StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/static_page/about/index.html", false);

            if (node.Attributes["use_language"].Value == "true")
                About = ar.ReadLanguage(About, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_elanat"].Value == "true")
                About = ar.ReadElanat(About, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_module"].Value == "true")
                About = ar.ReadModule(About, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_plugin"].Value == "true")
                About = ar.ReadPlugin(About, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_replace_part"].Value == "true")
                About = ar.ReadReplacePart(About, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_fetch"].Value == "true")
                About = ar.ReadFetch(About, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_item"].Value == "true")
                About = ar.ReadItem(About, StaticObject.GetCurrentSiteGlobalLanguage());

            
            About = About.Replace("$_asp site_global_name;", Language.GetLanguage(StaticObject.GetCurrentSiteSiteGlobalName(), StaticObject.GetCurrentSiteGlobalLanguage()));
            About = About.Replace("$_asp site_host;", context.Request.Host.Value + "/site/" + StaticObject.GetCurrentSiteSiteGlobalName());


            Write(Template.GetSiteTemplate("static_page/about").Replace("$_asp about;", About));
        }
    }
}