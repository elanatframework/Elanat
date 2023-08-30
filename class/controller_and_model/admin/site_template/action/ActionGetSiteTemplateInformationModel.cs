using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetSiteTemplateInformationModel : CodeBehindModel
    {
        public string GetInformation(string SiteTemplateDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/site/" + SiteTemplateDirectoryPath + "/catalog.xml"));

            XmlNode SiteTemplateCatalog = doc.SelectSingleNode("site_template_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/site_template/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_name;", aol.GetAddOnsLanguage("site_template_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_author;", aol.GetAddOnsLanguage("site_template_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_directory_path;", aol.GetAddOnsLanguage("site_template_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_physical_name;", aol.GetAddOnsLanguage("site_template_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_version;", aol.GetAddOnsLanguage("site_template_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_release_date;", aol.GetAddOnsLanguage("site_template_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_info;", aol.GetAddOnsLanguage("site_template_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_license;", aol.GetAddOnsLanguage("site_template_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_static_head;", aol.GetAddOnsLanguage("site_template_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang site_template_load_tag;", aol.GetAddOnsLanguage("site_template_load_tag"));

            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_name;", SiteTemplateCatalog["site_template_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_author;", SiteTemplateCatalog["site_template_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_directory_path;", SiteTemplateCatalog["site_template_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_physical_name;", SiteTemplateCatalog["site_template_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_version;", SiteTemplateCatalog["site_template_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_release_date;", SiteTemplateCatalog["site_template_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_info;", SiteTemplateCatalog["site_template_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_license;", SiteTemplateCatalog["site_template_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_static_head;", SiteTemplateCatalog["site_template_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp site_template_load_tag;", SiteTemplateCatalog["site_template_load_tag"].InnerXml);

            return InformationTemplate;
        }
    }
}