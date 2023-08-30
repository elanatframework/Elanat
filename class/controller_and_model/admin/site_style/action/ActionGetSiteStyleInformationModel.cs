using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetSiteStyleInformationModel : CodeBehindModel
    {
        public string GetInformation(string SiteStyleDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/site/" + SiteStyleDirectoryPath + "/catalog.xml"));

            XmlNode SiteStyleCatalog = doc.SelectSingleNode("site_style_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/site_style/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_style/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_name;", aol.GetAddOnsLanguage("site_style_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_template;", aol.GetAddOnsLanguage("site_style_template"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_author;", aol.GetAddOnsLanguage("site_style_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_directory_path;", aol.GetAddOnsLanguage("site_style_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_physical_name;", aol.GetAddOnsLanguage("site_style_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_right_to_left_language_support;", aol.GetAddOnsLanguage("site_style_right_to_left_language_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_view_support;", aol.GetAddOnsLanguage("site_style_view_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_responsive_support;", aol.GetAddOnsLanguage("site_style_responsive_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_version;", aol.GetAddOnsLanguage("site_style_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_release_date;", aol.GetAddOnsLanguage("site_style_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_info;", aol.GetAddOnsLanguage("site_style_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_license;", aol.GetAddOnsLanguage("site_style_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_static_head;", aol.GetAddOnsLanguage("site_style_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_load_tag;", aol.GetAddOnsLanguage("site_style_load_tag"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_style_load_tag;", aol.GetAddOnsLanguage("site_style_load_tag"));
            InformationTemplate = InformationTemplate.Replace("$_lang current_view_style;", aol.GetAddOnsLanguage("current_view_style"));

            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_name;", SiteStyleCatalog["site_style_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_template;", SiteStyleCatalog["site_style_template"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_author;", SiteStyleCatalog["site_style_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_directory_path;", SiteStyleCatalog["site_style_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_physical_name;", SiteStyleCatalog["site_style_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_right_to_left_language_support;", SiteStyleCatalog["site_style_right_to_left_language_support"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_view_support;", SiteStyleCatalog["site_style_view_support"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_responsive_support;", SiteStyleCatalog["site_style_responsive_support"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_version;", SiteStyleCatalog["site_style_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_release_date;", SiteStyleCatalog["site_style_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_info;", SiteStyleCatalog["site_style_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_license;", SiteStyleCatalog["site_style_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_static_head;", SiteStyleCatalog["site_style_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp site_style_load_tag;", SiteStyleCatalog["site_style_load_tag"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp current_view_style;", SiteStyleCatalog["current_view_style"].OuterXml);

            return InformationTemplate;
        }
    }
}