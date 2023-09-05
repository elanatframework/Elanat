using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteInactiveSiteModel : CodeBehindModel
    {
        public void SetValue()
        {
            string SiteGlobalName = StaticObject.GetCurrentSiteSiteGlobalName();

            AttributeReader ar = new AttributeReader();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/catalog.xml"));

            XmlNode node = doc.SelectSingleNode("site_catalog_root/site_page_list/inactive_site");


            string InactiveSite = PageLoader.LoadPage(node["load_type"].Value, StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/static_page/inactive_site/index.html", false);

            if (node.Attributes["use_language"].Value == "true")
                InactiveSite = ar.ReadLanguage(InactiveSite, StaticObject.GetCurrentSiteSiteGlobalName());

            if (node.Attributes["use_elanat"].Value == "true")
                InactiveSite = ar.ReadElanat(InactiveSite, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_module"].Value == "true")
                InactiveSite = ar.ReadModule(InactiveSite, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_plugin"].Value == "true")
                InactiveSite = ar.ReadPlugin(InactiveSite, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_replace_part"].Value == "true")
                InactiveSite = ar.ReadReplacePart(InactiveSite, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_fetch"].Value == "true")
                InactiveSite = ar.ReadFetch(InactiveSite, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_item"].Value == "true")
                InactiveSite = ar.ReadItem(InactiveSite, StaticObject.GetCurrentSiteGlobalLanguage());


            Write(Template.GetSiteTemplate("static_page/inactive_site").Replace("$_asp inactive_site;", InactiveSite));
        }
    }
}