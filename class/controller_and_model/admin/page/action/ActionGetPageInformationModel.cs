using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetPageInformationModel : CodeBehindModel
    {
        public string GetInformation(string PageDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "page/" + PageDirectoryPath + "/catalog.xml"));

            XmlNode PageCatalog = doc.SelectSingleNode("page_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/page/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/page/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_name;", aol.GetAddOnsLanguage("page_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_directory_path;", aol.GetAddOnsLanguage("page_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_physical_name;", aol.GetAddOnsLanguage("page_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_author;", aol.GetAddOnsLanguage("page_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_best_load_status;", aol.GetAddOnsLanguage("page_best_load_status"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_version;", aol.GetAddOnsLanguage("page_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_release_date;", aol.GetAddOnsLanguage("page_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_info;", aol.GetAddOnsLanguage("page_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_title;", aol.GetAddOnsLanguage("page_title"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_license;", aol.GetAddOnsLanguage("page_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_static_head;", aol.GetAddOnsLanguage("page_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang page_load_tag;", aol.GetAddOnsLanguage("page_load_tag"));

            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp page_global_name;", PageCatalog["page_global_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp page_name;", PageCatalog["page_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp page_directory_path;", PageCatalog["page_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp page_physical_name;", PageCatalog["page_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp page_author;", PageCatalog["page_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp page_best_load_status;", PageCatalog["page_best_load_status"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp page_version;", PageCatalog["page_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp page_release_date;", PageCatalog["page_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp page_info;", PageCatalog["page_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp page_title;", PageCatalog["page_title"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp page_license;", PageCatalog["page_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp page_static_head;", PageCatalog["page_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp page_load_tag;", PageCatalog["page_load_tag"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp page_directory_path;", PageDirectoryPath);

            return InformationTemplate;
        }
    }
}