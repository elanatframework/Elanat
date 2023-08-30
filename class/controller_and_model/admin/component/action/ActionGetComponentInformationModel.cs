using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetComponentInformationModel : CodeBehindModel
    {
        public string GetInformation(string ComponentDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + ComponentDirectoryPath + "/catalog.xml"));

            XmlNode ComponentCatalog = doc.SelectSingleNode("component_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/component/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/component/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_name;", aol.GetAddOnsLanguage("component_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_category;", aol.GetAddOnsLanguage("component_category"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_author;", aol.GetAddOnsLanguage("component_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_directory_path;", aol.GetAddOnsLanguage("component_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_physical_name;", aol.GetAddOnsLanguage("component_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_version;", aol.GetAddOnsLanguage("component_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_best_load_status;", aol.GetAddOnsLanguage("component_best_load_status"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_release_date;", aol.GetAddOnsLanguage("component_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_info;", aol.GetAddOnsLanguage("component_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_license;", aol.GetAddOnsLanguage("component_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_static_head;", aol.GetAddOnsLanguage("component_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_load_tag;", aol.GetAddOnsLanguage("component_load_tag"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_version_support;", aol.GetAddOnsLanguage("component_version_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_author_website;", aol.GetAddOnsLanguage("component_author_website"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_install_path;", aol.GetAddOnsLanguage("component_install_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_uninstall_path;", aol.GetAddOnsLanguage("component_uninstall_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_add_access_path;", aol.GetAddOnsLanguage("component_add_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_edit_all_access_path;", aol.GetAddOnsLanguage("component_edit_all_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_edit_own_access_path;", aol.GetAddOnsLanguage("component_edit_own_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_delete_all_access_path;", aol.GetAddOnsLanguage("component_delete_all_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang component_delete_own_access_path;", aol.GetAddOnsLanguage("component_delete_own_access_path"));


            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp component_name;", ComponentCatalog["component_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_category;", ComponentCatalog["component_category"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_author;", ComponentCatalog["component_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_directory_path;", ComponentCatalog["component_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_physical_name;", ComponentCatalog["component_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_version;", ComponentCatalog["component_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_best_load_status;", ComponentCatalog["component_best_load_status"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_release_date;", ComponentCatalog["component_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_info;", ComponentCatalog["component_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp component_license;", ComponentCatalog["component_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp component_static_head;", ComponentCatalog["component_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp component_load_tag;", ComponentCatalog["component_load_tag"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp component_version_support;", ComponentCatalog["component_version_support"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp component_author_website;", ComponentCatalog["component_author_website"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp component_install_path;", ComponentCatalog["component_install_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_uninstall_path;", ComponentCatalog["component_uninstall_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp component_add_access_path;", ComponentCatalog["component_add_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp component_edit_all_access_path;", ComponentCatalog["component_edit_all_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp component_edit_own_access_path;", ComponentCatalog["component_edit_own_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp component_delete_all_access_path;", ComponentCatalog["component_delete_all_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp component_delete_own_access_path;", ComponentCatalog["component_delete_own_access_path"].InnerXml);


            return InformationTemplate;
        }
    }
}