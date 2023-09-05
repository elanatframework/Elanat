using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SitePrivacyPolicyModel : CodeBehindModel
    {
        public string ContentValue { get; set; }

        public void SetValue()
        {
            string SiteGlobalName = StaticObject.GetCurrentSiteSiteGlobalName();

            AttributeReader ar = new AttributeReader();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/catalog.xml"));

            XmlNode node = doc.SelectSingleNode("site_catalog_root/site_page_list/privacy_policy");


            string PrivacyPolicy = PageLoader.LoadPage(node.Attributes["load_type"].Value, StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/static_page/privacy_policy/index.html", false);

            if (node.Attributes["use_language"].Value == "true")
                PrivacyPolicy = ar.ReadLanguage(PrivacyPolicy, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_elanat"].Value == "true")
                PrivacyPolicy = ar.ReadElanat(PrivacyPolicy, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_module"].Value == "true")
                PrivacyPolicy = ar.ReadModule(PrivacyPolicy, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_plugin"].Value == "true")
                PrivacyPolicy = ar.ReadPlugin(PrivacyPolicy, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_replace_part"].Value == "true")
                PrivacyPolicy = ar.ReadReplacePart(PrivacyPolicy, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_fetch"].Value == "true")
                PrivacyPolicy = ar.ReadFetch(PrivacyPolicy, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_item"].Value == "true")
                PrivacyPolicy = ar.ReadItem(PrivacyPolicy, StaticObject.GetCurrentSiteGlobalLanguage());


            ContentValue = Template.GetSiteTemplate("static_page/privacy_policy").Replace("$_asp privacy_policy;", PrivacyPolicy);
        }
    }
}