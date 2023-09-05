using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteTermsOfServiceModel : CodeBehindModel
    {
        public string ContentValue { get; set; }

        public void SetValue()
        {
            string SiteGlobalName = StaticObject.GetCurrentSiteSiteGlobalName();

            AttributeReader ar = new AttributeReader();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/catalog.xml"));

            XmlNode node = doc.SelectSingleNode("site_catalog_root/site_page_list/terms_of_service");


            string TermsOfService = PageLoader.LoadPage(node.Attributes["load_type"].Value, StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/static_page/terms_of_service/index.html", false);

            if (node.Attributes["use_language"].Value == "true")
                TermsOfService = ar.ReadLanguage(TermsOfService, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_elanat"].Value == "true")
                TermsOfService = ar.ReadElanat(TermsOfService, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_module"].Value == "true")
                TermsOfService = ar.ReadModule(TermsOfService, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_plugin"].Value == "true")
                TermsOfService = ar.ReadPlugin(TermsOfService, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_replace_part"].Value == "true")
                TermsOfService = ar.ReadReplacePart(TermsOfService, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_fetch"].Value == "true")
                TermsOfService = ar.ReadFetch(TermsOfService, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_item"].Value == "true")
                TermsOfService = ar.ReadItem(TermsOfService, StaticObject.GetCurrentSiteGlobalLanguage());


            ContentValue = Template.GetSiteTemplate("static_page/terms_of_service").Replace("$_asp terms_of_service;", TermsOfService);
        }
    }
}