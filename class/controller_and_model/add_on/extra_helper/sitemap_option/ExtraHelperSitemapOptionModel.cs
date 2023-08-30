using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ExtraHelperSitemapOptionModel : CodeBehindModel
    {
        public string SitemapOptionLanguage { get; set; }
        public string ActiveLanguageLanguage { get; set; }
        public string ActiveSiteLanguage { get; set; }
        public string ActivePageLanguage { get; set; }
        public string ActiveContentTypeLanguage { get; set; }
        public string ActiveCategoryLanguage { get; set; }
        public string ActiveLinkLanguage { get; set; }
        public string SaveSitemapOptionLanguage { get; set; }

        public bool ActiveLanguageValue { get; set; } = false;
        public bool ActiveSiteValue { get; set; } = false;
        public bool ActivePageValue { get; set; } = false;
        public bool ActiveContentTypeValue { get; set; } = false;
        public bool ActiveCategoryValue { get; set; } = false;
        public bool ActiveLinkValue { get; set; } = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/sitemap_option/");
            SitemapOptionLanguage = aol.GetAddOnsLanguage("sitemap_option");
            ActiveLanguageLanguage = aol.GetAddOnsLanguage("active_language");
            ActiveSiteLanguage = aol.GetAddOnsLanguage("active_site");
            ActivePageLanguage = aol.GetAddOnsLanguage("active_page");
            ActiveContentTypeLanguage = aol.GetAddOnsLanguage("active_content_type");
            ActiveCategoryLanguage = aol.GetAddOnsLanguage("active_category");
            ActiveLinkLanguage = aol.GetAddOnsLanguage("active_link");
            SaveSitemapOptionLanguage = aol.GetAddOnsLanguage("save_sitemap_option");


            // Set Current Value
            XmlDocument SitemapOptionDocument = new XmlDocument();
            SitemapOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/sitemap_option/option/sitemap_option.xml"));

            XmlNode node = SitemapOptionDocument.SelectSingleNode("sitemap_option_root");

            ActiveLanguageValue = (node["language"].Attributes["active"].Value == "true");
            ActiveSiteValue = (node["site"].Attributes["active"].Value == "true");
            ActivePageValue = (node["page"].Attributes["active"].Value == "true");
            ActiveContentTypeValue = (node["content_type"].Attributes["active"].Value == "true");
            ActiveCategoryValue = (node["category"].Attributes["active"].Value == "true");
            ActiveLinkValue = (node["link"].Attributes["active"].Value == "true");
        }

        public void SaveSitemapOption()
        {
            XmlDocument SitemapOptionDocument = new XmlDocument();
            SitemapOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/sitemap_option/option/sitemap_option.xml"));


            SitemapOptionDocument.SelectSingleNode("sitemap_option_root/language").Attributes["active"].Value = ActiveLanguageValue.BooleanToTrueFalse();
            SitemapOptionDocument.SelectSingleNode("sitemap_option_root/site").Attributes["active"].Value = ActiveSiteValue.BooleanToTrueFalse();
            SitemapOptionDocument.SelectSingleNode("sitemap_option_root/page").Attributes["active"].Value = ActivePageValue.BooleanToTrueFalse();
            SitemapOptionDocument.SelectSingleNode("sitemap_option_root/content_type").Attributes["active"].Value = ActiveContentTypeValue.BooleanToTrueFalse();
            SitemapOptionDocument.SelectSingleNode("sitemap_option_root/category").Attributes["active"].Value = ActiveCategoryValue.BooleanToTrueFalse();
            SitemapOptionDocument.SelectSingleNode("sitemap_option_root/link").Attributes["active"].Value = ActiveLinkValue.BooleanToTrueFalse();

            SitemapOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/sitemap_option/option/sitemap_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_sitemap_option", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("sitemap_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/sitemap_option/"), "success");
        }
    }
}