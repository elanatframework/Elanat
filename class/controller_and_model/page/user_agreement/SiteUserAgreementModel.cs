using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteUserAgreementModel : CodeBehindModel
    {
        public string ContentValue { get; set; }

        public void SetValue()
        {
            string SiteGlobalName = StaticObject.GetCurrentSiteSiteGlobalName();

            AttributeReader ar = new AttributeReader();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/catalog.xml"));

            XmlNode node = doc.SelectSingleNode("site_catalog_root/site_page_list/user_agreement");


            string UserAgreement = PageLoader.LoadPage(node.Attributes["load_type"].Value, StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/static_page/user_agreement/index.html", false);

            if (node.Attributes["use_language"].Value == "true")
                UserAgreement = ar.ReadLanguage(UserAgreement, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_elanat"].Value == "true")
                UserAgreement = ar.ReadElanat(UserAgreement, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_module"].Value == "true")
                UserAgreement = ar.ReadModule(UserAgreement, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_plugin"].Value == "true")
                UserAgreement = ar.ReadPlugin(UserAgreement, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_replace_part"].Value == "true")
                UserAgreement = ar.ReadReplacePart(UserAgreement, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_fetch"].Value == "true")
                UserAgreement = ar.ReadFetch(UserAgreement, StaticObject.GetCurrentSiteGlobalLanguage());

            if (node.Attributes["use_item"].Value == "true")
                UserAgreement = ar.ReadItem(UserAgreement, StaticObject.GetCurrentSiteGlobalLanguage());


            ContentValue = Template.GetSiteTemplate("static_page/user_agreement").Replace("$_asp user_agreement;", UserAgreement);
        }
    }
}