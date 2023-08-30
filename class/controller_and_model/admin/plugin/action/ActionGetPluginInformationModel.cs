using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetPluginInformationModel : CodeBehindModel
    {
        public string GetInformation(string PluginDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/catalog.xml"));

            XmlNode PluginCatalog = doc.SelectSingleNode("plugin_catalog_root");

            string InformationTemplate = Template.GetAdminTemplate("table/plugin/information");

            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/plugin/");
            InformationTemplate = InformationTemplate.Replace("$_lang information;", aol.GetAddOnsLanguage("information"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_name;", aol.GetAddOnsLanguage("plugin_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_category;", aol.GetAddOnsLanguage("plugin_category"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_author;", aol.GetAddOnsLanguage("plugin_author"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_directory_path;", aol.GetAddOnsLanguage("plugin_directory_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_physical_name;", aol.GetAddOnsLanguage("plugin_physical_name"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_version;", aol.GetAddOnsLanguage("plugin_version"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_best_load_status;", aol.GetAddOnsLanguage("plugin_best_load_status"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_release_date;", aol.GetAddOnsLanguage("plugin_release_date"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_info;", aol.GetAddOnsLanguage("plugin_info"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_license;", aol.GetAddOnsLanguage("plugin_license"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_static_head;", aol.GetAddOnsLanguage("plugin_static_head"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_load_tag;", aol.GetAddOnsLanguage("plugin_load_tag"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_version_support;", aol.GetAddOnsLanguage("plugin_version_support"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_author_website;", aol.GetAddOnsLanguage("plugin_author_website"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_install_path;", aol.GetAddOnsLanguage("plugin_install_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_uninstall_path;", aol.GetAddOnsLanguage("plugin_uninstall_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_add_access_path;", aol.GetAddOnsLanguage("plugin_add_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_edit_all_access_path;", aol.GetAddOnsLanguage("plugin_edit_all_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_edit_own_access_path;", aol.GetAddOnsLanguage("plugin_edit_own_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_delete_all_access_path;", aol.GetAddOnsLanguage("plugin_delete_all_access_path"));
            InformationTemplate = InformationTemplate.Replace("$_lang plugin_delete_own_access_path;", aol.GetAddOnsLanguage("plugin_delete_own_access_path"));


            // Set Value
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_name;", PluginCatalog["plugin_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_category;", PluginCatalog["plugin_category"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_author;", PluginCatalog["plugin_author"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_directory_path;", PluginCatalog["plugin_directory_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_physical_name;", PluginCatalog["plugin_physical_name"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_version;", PluginCatalog["plugin_version"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_best_load_status;", PluginCatalog["plugin_best_load_status"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_release_date;", PluginCatalog["plugin_release_date"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_info;", PluginCatalog["plugin_info"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_license;", PluginCatalog["plugin_license"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_static_head;", PluginCatalog["plugin_static_head"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_load_tag;", PluginCatalog["plugin_load_tag"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_version_support;", PluginCatalog["plugin_version_support"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_author_website;", PluginCatalog["plugin_author_website"].InnerText);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_install_path;", PluginCatalog["plugin_install_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_uninstall_path;", PluginCatalog["plugin_uninstall_path"].Attributes["value"].Value);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_add_access_path;", PluginCatalog["plugin_add_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_edit_all_access_path;", PluginCatalog["plugin_edit_all_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_edit_own_access_path;", PluginCatalog["plugin_edit_own_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_delete_all_access_path;", PluginCatalog["plugin_delete_all_access_path"].InnerXml);
            InformationTemplate = InformationTemplate.Replace("$_asp plugin_delete_own_access_path;", PluginCatalog["plugin_delete_own_access_path"].InnerXml);


            return InformationTemplate;
        }
    }
}